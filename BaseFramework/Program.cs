using System;
using BaseFramework.Scripts.DL.Model.User;
using Core.DL.Config;

namespace BaseFramework {
    class Program {
        static void Main(string[] args) {
            var config = AppConfig.Get();
            
            User.Create("somemmail@bk.de", "user2", "123");
            
            Console.WriteLine("yep");
        }
    }
}