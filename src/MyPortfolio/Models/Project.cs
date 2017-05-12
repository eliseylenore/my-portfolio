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
        public static JArray GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/eliseylenore/repos", Method.GET);
            request.AddParameter("sort", "stars");
            request.AddHeader("Accept", "application / vnd.github.v3 + json");
            client.AddDefaultHeader("User-Agent", "eliseylenore");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            return jsonResponse;
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
