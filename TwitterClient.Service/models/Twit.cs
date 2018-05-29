using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClient.Services.models
{
   public  class Twit
    {
        public string Id  { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public string CreatedAt { get; set; }
        public bool Checked { get; set; }
    }
}
