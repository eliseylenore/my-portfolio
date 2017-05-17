using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyPortfolio.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
        public string Html_Url { get; set; }
        public string Description { get; set; }
        public int Watchers { get; set; }

        public Project() { }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/eliseylenore/starred", Method.GET);
            request.AddParameter("sort", "stars");
            request.AddHeader("Accept", "application / vnd.github.v3 + json");
            client.AddDefaultHeader("User-Agent", "eliseylenore");

            var response = new RestResponse();


            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            //var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse[0]);
            string jsonOutput = jsonResponse.ToString();
            var githubList = JsonConvert.DeserializeObject<List<Project>>(jsonOutput);
            return githubList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
                
            });
            
            return tcs.Task;
        }
    }
}
