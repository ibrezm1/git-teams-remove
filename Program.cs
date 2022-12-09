using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Text.Json;
using RestSharp;
// Need to add reference to system.web.Externsions
using System.Text.Json.Serialization;
using System.Web;
using System.Configuration;
// Add reference to configuration

// https://stackoverflow.com/questions/10226089/restsharp-simple-complete-example
namespace ConsoleApp4
{


    public class Program
    {
        public static void Main()
        {

            ReadSettings();
            string client_id = ConfigurationManager.AppSettings["client_id"];
            string client_secret = ConfigurationManager.AppSettings["client_secret"];
            string tenant = ConfigurationManager.AppSettings["tenant"];

            ChatRemoveHelper cr = new ChatRemoveHelper(client_id, client_secret, tenant);
            cr.RemoveMembers("19:5612f725c75f4276aff39cfa34b5765b@thread.v2");
            //https://teams.microsoft.com/_#/conversations/19:77762a2c48c0419c90e44293666413bf@thread.v2?ctx=chat

            Console.ReadKey();

        }
        public static void ReadSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
    }

 
}