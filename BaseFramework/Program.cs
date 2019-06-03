using System;
using Core.DL.Config;

namespace BaseFramework {
    class Program {
        static void Main(string[] args) {
            var config = AppConfig.Get();

            Console.WriteLine("yep");
        }
    }
}