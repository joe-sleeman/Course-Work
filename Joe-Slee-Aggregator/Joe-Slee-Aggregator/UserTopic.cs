using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe_Slee_Aggregator
{
    public class UserTopic
    {
        public int UserTopicID { get; set; }
        public int UserID { get; set; }
        public int TopicID { get; set; }
        public bool Liked { get; set; }
    }
}
