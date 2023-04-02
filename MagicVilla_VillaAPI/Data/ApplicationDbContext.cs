using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
			base(options)
		{

		}


		public DbSet<Villa> Villas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Bali Villa",
                    Details = "Ashran lives here.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "White House Villa",
                    Details = "George Bush lives here",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Villa()
                {
                    Id = 3,
                    Name = "Konoha Villa",
                    Details = "Naruto lives here",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Digimon Villa",
                    Details = "Agumon lives here",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Pokemon Villa",
                    Details = "Pikachu lives here",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                });
		}
    }
}

