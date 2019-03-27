using Microsoft.Extensions.Configuration;


namespace ConsCRUD
{
    class Program
    {
        public static string MongoString;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            MongoString = config["mongoString"];

            Applcation.Run();
        }
    }
}
