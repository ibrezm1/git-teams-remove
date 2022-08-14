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
            string client_id = ConfigurationManager.AppSettings["client_id"];
            string client_secret = ConfigurationManager.AppSettings["client_secret"];
            ChatRemoveHelper cr = new ChatRemoveHelper(client_id, client_secret);
            cr.RemoveMembers("19:77762a2c48c0419c90e44293666413bf@thread.v2");


            Console.ReadKey();

        }
    }
}