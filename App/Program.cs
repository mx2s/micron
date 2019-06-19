using System;
using Nancy.Configuration;
using Nancy.Hosting.Self;

namespace App {
    public class Bootstrapper : Nancy.DefaultNancyBootstrapper {
        public override void Configure(INancyEnvironment environment) {
            var config = new Nancy.TraceConfiguration(enabled: false, displayErrorTraces: true);
            environment.AddValue(config);
        }
    }
    
    class Program {
        static void Main(string[] args) {
            var host = new NancyHost(new Bootstrapper(), new Uri("http://localhost:8000"));

            Console.WriteLine("starting server from BaseProject in DEBUG mode");
            host.Start();
            Console.WriteLine("server started");

            Console.Write("Press enter to stop server...");
            Console.ReadLine();
        }
    }
}