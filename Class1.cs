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

namespace ConsoleApp4
{
    class ChatRemoveHelper
    {
        string client_id, client_secret, tenant;
        public ChatRemoveHelper(string client_id, string client_secret, string tenant)
        {
            this.client_id = client_id;
            this.client_secret = client_secret;
            this.tenant = tenant;
        }

        string GenerateToken()
        {
            var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            var client = new RestClient("https://login.microsoftonline.com");

            var request = new RestRequest(tenant + "/oauth2/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "fpc=ArPq__3fHnpBob8pAW5daE2fRkgiAQAAAJwFidoOAAAA; stsservicecookie=estsfd; x-ms-gateway-slice=estsfd");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", client_id );
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("resource", "https://graph.microsoft.com");

            //RestResponse response = null;
            RestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            var jsontext = response?.Content;

            dynamic result = ser.DeserializeObject(jsontext);
            string btoken = "Bearer " + result["access_token"];
            return btoken;
        }

        public void RemoveMembers(string chatid)
        {
            string btoken = GenerateToken();
            var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            var client = new RestClient("https://graph.microsoft.com");
            //var chatid = "19:77762a2c48c0419c90e44293666413bf@thread.v2";
            string callurl = String.Format("v1.0/chats/{0}/members", chatid);
            var request = new RestRequest(callurl, Method.Get);
            request.AddHeader("Authorization", btoken);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            var jsontext = response.Content;

            //https://stackoverflow.com/questions/34043384/easiest-way-to-parse-json-response

            dynamic result = ser.DeserializeObject(jsontext);
            //Console.WriteLine(result["value"][0]["id"]);
            foreach (var key in result["value"])
            {
                Console.WriteLine("Key: {0}", key["id"]);
                client = new RestClient("https://graph.microsoft.com");

                string removeurl = String.Format("v1.0/chats/{0}/members/{1}", chatid, key["id"]);

                if (key["email"] != "ibrez@outlook.com")
                {
                    request = new RestRequest(removeurl, Method.Delete);
                    request.AddHeader("Authorization", btoken);
                    response = client.Execute(request);
                    //Console.WriteLine(response.Content);
                    jsontext = response.Content;
                    Console.WriteLine(jsontext);
                }


            }

            // Getting Chats 
            callurl = String.Format("v1.0/teams/e0cf5f00-6b19-404c-a65c-8dd44cbe899e/channels/19:e0edaa5c577b4253b7c0cc049e3cf593@thread.tacv2/messages", chatid);
            request = new RestRequest(callurl, Method.Post);
            request.AddHeader("Authorization", btoken);
            request.AddHeader("Content-type", "application/json");
            request.AddParameter(
               "application/json",
               "{ \"body\": {\"content\": \"Hello\" } }", // <- your JSON string
               ParameterType.RequestBody);
            //request.AddJsonBody(chatMessage); // AddJsonBody serializes the object automatically
            // https://stackoverflow.com/questions/31937939/restsharp-post-a-json-object
            response = client.Execute(request);
            Console.WriteLine(response.Content);
            jsontext = response.Content;

            //https://docs.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0&tabs=http


        }
    }
}
