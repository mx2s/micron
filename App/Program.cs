using System;
using BaseFramework;
using Nancy.Hosting.Self;

namespace App {
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