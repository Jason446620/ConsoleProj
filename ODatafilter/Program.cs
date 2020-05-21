using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static ODatafilter.HttpHelper;

namespace ODatafilter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Azure Cosmos Table Samples");
            string baseurl = @"https://panshubeistorage.table.core.windows.net/";
            //Console.WriteLine("pls input table name:");
            string tbname = "People";//Console.ReadLine();
            //You can find in portal
            string sastoken = @"?sv=2019-10-10&******************";
            string filter = @"&$filter=PartitionKey%20eq%20'Smith'%20";
            baseurl = baseurl + tbname + "()" + sastoken+filter;
            HttpResponseData data = HttpHelper.GetForOData(baseurl);
            string responseData = data.Data.Replace(".","_");
            ODataResponse odata = JsonConvert.DeserializeObject<ODataResponse>(responseData);

            foreach (ODatavalue m in odata.value)
            {
                Console.WriteLine(m.PartitionKey + "    " + m.PhoneNumber + "    " + m.RowKey + "   " + m.Email);
            }
            Console.WriteLine("Press any key to exit");
            Console.Read();

            
            //var list1 = linqQuery1.AsQueryable();


        }
        public class ODataResponse
        {
            public string odata_metadata { get; set; }
            public List<ODatavalue> value { get; set; }
        }
        public class ODatavalue {
            public string odata_type { get; set; }
            public string odata_id { get; set; }
            public string odata_etag { get; set; }
            public string odata_editLink { get; set; }
            public string Timestamp { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
