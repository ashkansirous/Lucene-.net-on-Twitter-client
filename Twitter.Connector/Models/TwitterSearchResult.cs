using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Connector.Models
{
 

    public class TwitterSearchResult
    {
        public Status[] statuses { get; set; }
        public Search_Metadata search_metadata { get; set; }
    }
}
