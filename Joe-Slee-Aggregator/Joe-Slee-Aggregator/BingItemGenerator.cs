using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joe_Slee_Aggregator
{
    public class BingItemGenerator
    {
        string accountKey;
        string rootURL;
        string query;

        public BingItemGenerator()
        {
            accountKey = Constants.AccountKey;
            rootURL = Constants.RootURL;
            query = Constants.Query;
        }

        public void PerformSearch(string searchTerm, string searchParam, RichTextBox rtb, List<Topic> notList, int skip)
        {
            string queryString = generateQueryString(searchTerm, searchParam, notList, skip);
            string jsonData = getJsonData(queryString);
            List<BingItem> bingItems = convertJsonToBingItemObjects(jsonData);
            displayItems(bingItems, rtb);
        }

        private string generateQueryString(string searchTerm, string searchParam, List<Topic> notList, int skip)
        {
            // Surround search term with Bing API stuff.
            string notString = generateNotString(notList);
            searchParam += "?";
            searchTerm = "%27" + searchTerm + notString + "%27&$top=10" + "&$skip=" + skip +"&$format=JSON";
            // Build the query. 
            string queryString = rootURL + searchParam + query + searchTerm;
            return queryString;
        }

        // Example of NOT that works...
        // https://api.datamarket.azure.com/Bing/Search/News?Query=%27Skateboarding%20NOT%20Wayne%20OR%27&$top=10&$format=JSON 
        private string generateNotString(List<Topic> notList)
        {
            string returnString = "";
            if (notList.Any())
            {
                foreach (Topic t in notList)
                {
                    returnString += "%20NOT%20%" + t.TopicName;
                }
            }
            return returnString;
        }

        // Try catch has to go in here to prepare for *random* lag @@@@@@
        // Run that query against the Bing API - Return JSON formatted data.
        private string getJsonData(string queryString)
        {
            // Create a URI out of our search query - ToString() to avoid formatting errors.
            Uri formattedURL = new Uri(queryString.ToString());
            // Create HttpWebRequest out of URI.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(formattedURL);
            // Load credentials.
            NetworkCredential credentials = new NetworkCredential(accountKey, accountKey);
            // Give them to our request.
            request.Credentials = credentials;
            // Get a response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Instantiate a string that we will populate with JSON data.
            string jsonData = "";
            // Use a StreamReader to read our response.
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                jsonData = reader.ReadToEnd();  // Read everything.
            }
            // return our JSON data string.
            return jsonData;
        }
        private List<BingItem> convertJsonToBingItemObjects(string jsonData)
        {
            // Create JObject instance that holds all of our JSON.
            JObject jObject = JObject.Parse(jsonData);
            // Create JToken that is our root array.
            JToken jRoot = jObject["d"];
            // Create JToken that is our results.
            JToken jResults = jRoot["results"];
            // See how many results we have.
            int jLength = jResults.Count();

            // Instantiate a list to hold and return our Bing Items.
            List<BingItem> bingItems = new List<BingItem>();

            // Loop though jResults.
            for (int i = 0; i < jLength; i++)
            {
                // Grab current instance of jResults.
                JToken jFields = jResults[i];

                // Generate a Bing Item based on fields of current instance.
                BingItem bingItem = new BingItem
                {
                    Title = jFields["Title"].ToString(),
                    Description = jFields["Description"].ToString(),
                    Url = jFields["Url"].ToString(),
                };
                // Add the Bing Item to our list.
                bingItems.Add(bingItem);
            }
            return bingItems;
        }


        private void displayItems(List<BingItem> bingItems, RichTextBox rtb)
        {
            // Clear text box
            rtb.Clear();
            rtb.AppendText("Results:");

            foreach (BingItem b in bingItems)
            {
                rtb.AppendText(Environment.NewLine + b.Title);
                rtb.AppendText(Environment.NewLine + b.Url);
                rtb.AppendText(Environment.NewLine + b.Description);
                rtb.AppendText(Environment.NewLine);
            }
        }

    }
}
