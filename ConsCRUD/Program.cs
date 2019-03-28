using ConsCRUD.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsCRUD
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        public static ServiceProvider Services;

        static void Main(string[] args)
        {
            // configuration provider
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            // services provider
            IServiceCollection serviceCollection = new ServiceCollection();
            ///////
            //
            // serviceCollection.AddSingleton<IRepo, RepoMemo>();
            //
            // serviceCollection.AddSingleton<IRepo>(
            //     (_) => new RepoMongo(Configuration["mongoString"]));
            //
            //serviceCollection.AddSingleton<IRepo>(
            //    (_) => new RepoAdoNet(Configuration["adoString"]));
            //
            serviceCollection.AddSingleton<IRepo>(
                  (_) => new RepoEF(Configuration["adoString"]));
            //
            ///////
            using (Services = serviceCollection.BuildServiceProvider())
            {
                Applcation.Run();
            }
        }
    }
}
