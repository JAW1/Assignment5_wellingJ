using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models
{
    //this class is to create starting data for the database
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            Amazon2DBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<Amazon2DBContext>();
            
            //checking for pending migrations
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Libraries.Any())
            {
                context.Libraries.AddRange(
                    new Library
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        Isbn = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        NumPages = 1488
                    },
                    new Library
                    {
                        Title = "Teams of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        Isbn = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        NumPages = 944
                    },
                    new Library
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        Isbn = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        NumPages = 832
                    },
                    new Library
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleName = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        Isbn = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        NumPages = 864
                    },
                    new Library
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        Isbn = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        NumPages = 528
                    },
                    new Library
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        Isbn = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        NumPages = 288
                    },
                    new Library
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        NumPages = 304
                    },
                    new Library
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        NumPages = 240
                    },
                    new Library
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        Isbn = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        NumPages = 400
                    },
                    new Library
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        Isbn = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        NumPages = 642
                    },

                    //New Data
                    new Library
                    {
                        Title = "Robinson Crusoe",
                        AuthorFirstName = "Daniel",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Defoe",
                        Publisher = "William Taylor",
                        Isbn = "978-1503292380",
                        Classification = "Fiction",
                        Category = "Survival",
                        Price = 6.99,
                        NumPages = 158
                    },
                    new Library
                    {
                        Title = "The Alchemist",
                        AuthorFirstName = "Paulo",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Coelho",
                        Publisher = "HarperOne",
                        Isbn = "978-0062315005",
                        Classification = "Fiction",
                        Category = "Adventure",
                        Price = 10.47,
                        NumPages = 208
                    },
                    new Library
                    {
                        Title = "The Return of the King",
                        AuthorFirstName = "J.R.R",
                        //author middle name doesn't exist so it will be an empty string
                        AuthorMiddleName = "",
                        AuthorLastName = "Tolkien",
                        Publisher = "Del Rey",
                        Isbn = "978-0345339737",
                        Classification = "Fiction",
                        Category = "Classic Literature",
                        Price = 8.99,
                        NumPages = 512
                    }
                );
                //this saves the seeded data
                context.SaveChanges();
            }
        }
    }
}
