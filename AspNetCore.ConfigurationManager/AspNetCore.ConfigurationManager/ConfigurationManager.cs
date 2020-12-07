using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace AspNetCore
{
    /// <summary>
    /// 功能描述    ：ConfigurationManager -默认读取根目录下appsettings.json配置文件 
    /// 创 建 者    ：jinghe
    /// 创建日期    ：2020/8/16 19:35:59 
    /// 版权说明    ：Copyright ©-
    /// </summary>
    public class ConfigurationManager
    {
        private readonly static IConfigurationRoot _configurationRoot;
        private static IConfigurationBuilder _createConfigurationBuilder
        {
            get
            {
                return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        static ConfigurationManager()
        {
            _configurationRoot = _createConfigurationBuilder.Build();
        }

        /// <summary>
        /// 默认从-appsettings.json-读取特定节点node值-转string[]
        /// </summary>
        /// <param name="node">节点名称（若存在父子级，则书写方式为:"父node:子node"）</param>
        /// <returns></returns>
        public static string[] GetConnectionStrings(string node)
        {
            return _configurationRoot
                    .GetSection(node)
                    .GetChildren()
                    .Select(s => s.Value).ToArray();
        }

        /// <summary>
        /// 默认从-appsettings.json-读取特定节点node值-转string
        /// </summary>
        /// <param name="node">节点名称（若存在父子级，则书写方式为:"父node:子node"）</param>
        /// <returns></returns>
        public static string GetConnectionString(string node)
        {
            return _configurationRoot[node];
        }

        /// <summary>
        /// 默认从-appsettings.json-读取特定节点node值-转泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node">节点名称（若存在父子级，则书写方式为:"父node:子node"）</param>
        /// <returns></returns>
        public static T GetValue<T>(string node) where T : class, new()
        {
            return _configurationRoot.GetSection(node).Get<T>();
        }

        /// <summary>
        /// 从指定文件中-读取特定节点node值-转泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">json文件全路径-否则抛出异常</param>
        /// <param name="node">节点名称（若存在父子级，则书写方式为:"父node:子node"）</param>
        /// <returns></returns>
        public static T GetValue<T>(string filePath, string node) where T : class, new()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true);
            return builder.Build().GetSection(node).Get<T>();
        }
    }
}
