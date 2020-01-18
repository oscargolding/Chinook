using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Chinook.Models;
using Microsoft.IdentityModel.Tokens;

namespace ChinookTests
{
    public class DataSeeder
    {

    
        /// <summary>
        /// Important for wanting to seed a database with values. 
        /// </summary>
        /// <param name="chinContext"></param>
        public static void SeedData(ChinookContext chinContext)
        {
            for (var i = 1; i < 100; i++)
            {
                chinContext.Album.Add(new Album()
                {
                    AlbumId = i,
                    Title = "hey",
                    ArtistId = i
                });
            }

            chinContext.SaveChanges();
        }
    }
}
