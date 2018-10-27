using Faktorin.Parsers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Faktorin
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var fullPath = Path.GetFullPath(path);
            var provider = ConfigureServices();
            var parsers = provider.GetServices<IParser>().ToArray();
            var watcher = new Watcher(parsers);

            watcher.Watch(fullPath);

            Console.WriteLine($"Watching path: {fullPath}");
            Console.Write("Press any key to exit...");
            Console.ReadKey();

            watcher.Stop();
        }

        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<IParser, HtmlParser>()
                .AddSingleton<IParser, CssParser>();

            return services.BuildServiceProvider();
        }
    }
}
