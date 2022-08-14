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

// https://stackoverflow.com/questions/10226089/restsharp-simple-complete-example
namespace ConsoleApp4
{


    public class Program
    {
        public static void Main()
        {

            ChatRemoveHelper cr = new ChatRemoveHelper("787997e6-1a3d-4470-bc84-67bdc80b1aaa", "bki8Q~FdcGpSnZ2Aq_uiusxQPd7xea63WI~06bxc");
            cr.RemoveMembers("19:77762a2c48c0419c90e44293666413bf@thread.v2");


            Console.ReadKey();

        }
    }
}