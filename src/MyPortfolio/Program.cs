using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RestSharp;
using RestSharp.Authenticators;

namespace MyPortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/eliseylenore/repos", Method.GET);
            request.AddHeader("Accept", "application / vnd.github.v3 + json");
            client.AddDefaultHeader("User-Agent", "eliseylenore");
            
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            Console.WriteLine(response.Content);
            Console.ReadLine();
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

            //var host = new WebHostBuilder()
                //.UseKestrel()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                //.UseStartup<Startup>()
                //.Build();

            //host.Run();
        }
    }


