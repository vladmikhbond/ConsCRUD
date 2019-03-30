using ConsEF.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsEF
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        
        static void Main(string[] args)
        {
            // configuration provider
            //
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            //using (LibraryContext db = new LibraryContext())
            using (LibraryContext db = new LibraryContext(Configuration["conStr"]))
            {
                db.Books.Add(new Models.Book { Title = "Title1", Author = "Author1" });
                db.SaveChanges();
            }
        }
    }
}
