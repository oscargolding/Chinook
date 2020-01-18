using Chinook.Models;
using System;
using System.Linq;
using Chinook.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ChinookTests
{
    public class TestDatabase
    {


        /// <summary>
        /// Test how many are actually returned. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestItems()
        {
            var options = new DbContextOptionsBuilder<ChinookContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            // Now do the assignment (as is necessary)
            var _memoryContext = new ChinookContext(options);
            var _albContext = new AlbumService(_memoryContext);
            DataSeeder.SeedData(_memoryContext);

            var returning = await _albContext.ReturnAlbums();

            Assert.Equal(99, returning.ToList().Count);
        }

        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [Theory]
        public async Task TestRet(int value)
        {
            var options = new DbContextOptionsBuilder<ChinookContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            // Now do the assignment (as is necessary)
            var _memoryContext = new ChinookContext(options);
            var _albContext = new AlbumService(_memoryContext);

            DataSeeder.SeedData(_memoryContext);

            var returning = await _albContext.ReturnAlbums();


            Assert.Equal(value + 1, returning.ToList().ElementAt(value).id);
        }

    }
}
