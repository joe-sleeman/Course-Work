using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe_Slee_Aggregator
{
    public class Constants
    {
        // DB Constants
        public const string BitdevConnection =
                "Data Source = bitdev.ict.op.ac.nz;" +
                "Initial Catalog = IN712_201501_sleemjm1;" +
                "User ID = sleemjm1;" +
                "Password = JSl_A421";

        // Bing API
        public const string AccountKey = "LIr2JN3D1AjtMkwXfknZCHMqvMZ0o1fiBmrDHGa20oM";
        public const string RootURL = "https://api.datamarket.azure.com/Bing/Search/";
        public const string Query = "Query=";
        public const string NewsParam = "News?";
        public const string WebParam = "Web?";
    }
}
