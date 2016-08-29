using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe_Slee_Aggregator
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Topic> TopicList { get; set; }
        public List<Topic> DislikedTopicList { get; set; } // Not sure if needed.
    }
}
