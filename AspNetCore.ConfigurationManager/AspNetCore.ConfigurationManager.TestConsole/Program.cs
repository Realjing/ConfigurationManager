using System;
using AspNetCore;

namespace AspNetCoreConfigurationManager.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var v = ConfigurationManager.GetConnectionString("Test");
            Console.WriteLine($"读取到：{v}");
            Console.ReadKey(true);
        }
    }
}
