using System;
using System.ServiceModel.Web;
using WcfRestJsonResponse.RestServices;

namespace WcfRestJsonResponse
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var uri = "http://localhost:8000";
            var host = new WebServiceHost(typeof(Service), new Uri(uri));

            host.Open();
            Console.WriteLine($"Service is up and running on {uri}");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            host.Close();
        }
    }
}