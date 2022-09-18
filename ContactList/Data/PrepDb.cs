using ContactList.Models;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ContactList.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Contacts.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                
                context.Contacts.AddRange(
                    new Contact() { Name = "John", MobilePhone = "202-546-6547", JobTitle = "Microsoft", BirthDate = "1990-08-05" },
                    new Contact() { Name = "Mike", MobilePhone = "202-354-9548", JobTitle = "Google", BirthDate = "1987-10-09" },
                    new Contact() { Name = "Bob", MobilePhone = "202-847-9561", JobTitle = "Apple", BirthDate = "1992-03-15" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
