using System;
using System.IO;
using AspNetCore;

namespace AspNetCoreConfigurationManager.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //var v = ConfigurationManager.GetConnectionString("Test");
            //Console.WriteLine($"读取到：{v}");
            var t = ConfigurationManager.GetValue<Test>(Path.Combine($"{Directory.GetCurrentDirectory()}/dllconfig/appsettings.json"), "Test");
            Console.WriteLine($"读取到：{t.Value}");
            Console.ReadKey(true);
        }
    }
    public class Test
    {
        public string Value { get; set; }
    }
}
