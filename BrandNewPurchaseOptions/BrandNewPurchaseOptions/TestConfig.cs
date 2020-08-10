using System;
using System.Collections.Generic;
using System.Text;

namespace Brandnew.Configuration
{
    public class TestConfig
    {
        public string SiteUrl { get; set; }
        public int TestEventId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EventUrl
        {
            get
            {
                return SiteUrl + "/" + TestEventId;
            }
        }
    }
}
