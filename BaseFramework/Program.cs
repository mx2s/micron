using System;
using Nancy.Hosting.Self;

namespace BaseFramework {
    class Program {
        static void Main(string[] args) {
            var host = new NancyHost(new Uri("http://localhost:8000"));
            Console.WriteLine("starting server");
            host.Start();
            Console.WriteLine("server started");

            Console.Write("Press enter to stop server...");
            Console.ReadLine();
            
            host.Stop();
        }
    }
}