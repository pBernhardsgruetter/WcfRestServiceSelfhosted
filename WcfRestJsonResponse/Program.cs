using System;
using System.ServiceModel.Web;

namespace WcfRestJsonResponse
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000"));

            host.Open();
            Console.WriteLine("Service is up and running");
            Console.WriteLine("Press enter to quit ");
            Console.ReadLine();
            host.Close();
        }
    }
}