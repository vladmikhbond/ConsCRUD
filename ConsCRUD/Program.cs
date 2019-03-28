using ConsCRUD.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ConsCRUD
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        public static ServiceProvider Services;

        static void Main(string[] args)
        {
            // configuration provider
            //
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            //
            // services 
            //
            IServiceCollection serviceCollection = new ServiceCollection();
            // select repo type
            string repoName = Configuration["repository"].ToLower();
            switch (repoName) {
                case "memo":
                    serviceCollection.AddSingleton<IRepo, RepoMemo>();
                    break;
                case "mongo":
                    serviceCollection.AddSingleton<IRepo>( 
                        _ => new RepoMongo(Configuration["conString:mongo"]));
                    break;
                case "ado":
                    serviceCollection.AddSingleton<IRepo>( 
                        _ => new RepoAdoNet(Configuration["conString:ado"]));
                    break;
                case "ef":
                    serviceCollection.AddSingleton<IRepo>( 
                        _ => new RepoEF(Configuration["conString:ado"]));
                    break;
            }
            Console.WriteLine("Repository: " + repoName);
            //
            // loop
            //
            using (Services = serviceCollection.BuildServiceProvider())
            {
                Applcation.Run();
            }
        }
    }
}
