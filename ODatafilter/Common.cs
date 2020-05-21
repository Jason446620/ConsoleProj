using System;
using System.Collections.Generic;
using System.Text;

namespace ODatafilter
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.Azure.Documents;

    public class Common
    {
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=panshubeistorage;AccountKey=MB1n+LK06juPEjnrqWoEKWl8B/m/UA1Op5Y1iwGwLyQYshCZJgiE9xgS0Ic0LEYzIiAh0LLeYhQHaG14GSKPsg==;EndpointSuffix=core.windows.net";
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }
    }
}
