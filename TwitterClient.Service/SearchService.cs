using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Twitter.Connector.Repositories;
using TwitterClient.Services.models;

namespace TwitterClient.Services
{
    public class SearchService
    {
        private const string IndexFolder = @"Index";
        public List< Twit> Search(string term)
        {
            var tws = new TwitterRepository();
            var searchResults = tws.Search(term);
            var resultsDto = searchResults
                .Select(sr =>
                    new Twit()
                        {Id = sr.id_str, Text = sr.text, Username = sr.user.name,
                            CreatedAt = sr.created_at}).ToList();

            UpdateIndex(resultsDto);

            return resultsDto;
        }
        private static void UpdateIndex(List<Twit> twitList)
        {
            var dirInfo = new System.IO.DirectoryInfo(IndexFolder);
         

            using (var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            using (var indexDir = FSDirectory.Open(dirInfo))
            {
                using (var indexWriter = new IndexWriter(indexDir, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    indexWriter.DeleteAll();
                    foreach (var twit in twitList)
                    {
                        string docid = twit.Id;

                        // remove older index entry
                        //var searchQuery = new TermQuery(new Term("Id", docid));
                        //indexWriter.DeleteDocuments(searchQuery);

                        // Create a Lucene document...
                        Document document = new Document();

                        document.Add(new Field("Id", docid, Field.Store.YES, Field.Index.NOT_ANALYZED));
                        document.Add(new Field("Text", twit.Text, Field.Store.YES, Field.Index.ANALYZED));

                        document.Add(new Field("UserName", twit.Username, Field.Store.YES, Field.Index.ANALYZED));
           
                        //add doc
                        indexWriter.AddDocument(document);
                    }
                }
            }
        }

        public static List< FilteredTwit> FindInIndexes(string term)
        {
            var results= new List<FilteredTwit>();
            var indexDir = Lucene.Net.Store.FSDirectory.Open(new System.IO.DirectoryInfo(IndexFolder));
            var stdAnalyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

            using (var indexReader = IndexReader.Open(indexDir, readOnly: true))
            {
                var parser = new MultiFieldQueryParser(
                    Lucene.Net.Util.Version.LUCENE_30,
                    new[] { "Id", "Text", "UserName" },
                    stdAnalyzer);


                var query = parser.Parse(term);

                using (var searcher = new IndexSearcher(indexReader))
                {
                    var searchResults = searcher.Search(query, 10000);
                    foreach (var result in searchResults.ScoreDocs)
                    {
                        var doc = searcher.Doc(result.Doc);
                        var score = result.Score;
                        var twit= new FilteredTwit()
                        {
                            Id = doc.GetValues("Id")[0] ,
                            Text = doc.GetValues("Text")[0],
                            Username = doc.GetValues("UserName")[0],
                            Score=score
                        };
                        results.Add(twit);
                      // Console.WriteLine($" doc: {doc.GetValues("Id")[0]},score{score} ");
                    }

                    //Console.WriteLine("Total hits: {0}", results.TotalHits);
                }
            }

            return results;
        }
    }
}
