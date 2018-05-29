using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitterClient.Services.models;

namespace TwitterClient.Service
{
    public class FileService
    {
        public static void Export(string fileName, List<Twit> twitList)
        {
           var twitsStr= JsonConvert.SerializeObject(twitList);
         File.WriteAllText(fileName,twitsStr, Encoding.Unicode);
        }
}
}
