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
            // serviceCollection.AddTransient<IRepo>(
            //     (_) => new RepoMongo(Configuration["mongoString"]));
            //
            // serviceCollection.AddTransient<IRepo, RepoMemo>();
            //
            //serviceCollection.AddTransient<IRepo>(
            //    (_) => new RepoAdoNet(Configuration["adoString"]));
            //
            serviceCollection.AddTransient<IRepo>(
                  (_) => new RepoEF(Configuration["adoString"]));
            //
            ///////
            Services = serviceCollection.BuildServiceProvider();
                  
            Applcation.Run();
        }
    }
}
