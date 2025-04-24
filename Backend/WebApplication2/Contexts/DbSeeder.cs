using WebApplication2.Entities;

namespace WebApplication2.Contexts
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Programs.Any())
            {
                var program1 = new Programs
                {
                    Name = "Red Sea Adventure",
                    Price = 1500.00M,
                    Day = 3,
                    Night = 2,
                    Rating = 4,
                };

                var program2 = new Programs
                {
                    Name = "Luxor Historical Tour",
                    Price = 2200.00M,
                    Day = 4,
                    Night = 3,
                    Rating = 5,
                };

                var program3 = new Programs
                {
                    Name = "Sinai Mountain Hike",
                    Price = 1000.00M,
                    Day = 2,
                    Night = 1,
                    Rating = 3,
                };

                var program4 = new Programs
                {
                    Name = "Alexandria Sea Breeze",
                    Price = 1800.00M,
                    Day = 3,
                    Night = 2,
                    Rating = 4,
                };

                var program5 = new Programs
                {
                    Name = "Cairo City Exploration",
                    Price = 2000.00M,
                    Day = 5,
                    Night = 4,
                    Rating = 5,
                };

                context.Programs.AddRange(program1, program2, program3, program4, program5);
                context.SaveChanges();

                context.Program_Place.AddRange(
                    new Program_Places { Program_Id = program1.Program_Id, Name = "Hurghada Beach" },
                    new Program_Places { Program_Id = program1.Program_Id, Name = "Giftun Island" },
                    new Program_Places { Program_Id = program2.Program_Id, Name = "Karnak Temple" },
                    new Program_Places { Program_Id = program2.Program_Id, Name = "Valley of the Kings" },
                    new Program_Places { Program_Id = program3.Program_Id, Name = "Mount Sinai" },
                    new Program_Places { Program_Id = program4.Program_Id, Name = "Stanley Bridge" },
                    new Program_Places { Program_Id = program4.Program_Id, Name = "Qaitbay Citadel" },
                    new Program_Places { Program_Id = program5.Program_Id, Name = "Egyptian Museum" },
                    new Program_Places { Program_Id = program5.Program_Id, Name = "Pyramids of Giza" }
                );

                context.SaveChanges();
            }
        }
    }
}
