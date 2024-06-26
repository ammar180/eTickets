﻿using eTickets.Models;
namespace eTickets.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.EnsureCreated();

        //Actors
        if (!context.Actors.Any())
        {
            context.Actors.AddRange(new List<Actor>()
                {
                    new Actor()
                    {
                        FullName = "Actor 1",
                        Bio = "This is the Bio of the first actor",
                        Profilepicture = "http://dotnethow.net/images/actors/actor-1.jpeg"

                    },
                    new Actor()
                    {
                        FullName = "Actor 2",
                        Bio = "This is the Bio of the second actor",
                        Profilepicture = "http://dotnethow.net/images/actors/actor-2.jpeg"
                    },
                    new Actor()
                    {
                        FullName = "Actor 3",
                        Bio = "This is the Bio of the second actor",
                        Profilepicture = "http://dotnethow.net/images/actors/actor-3.jpeg"
                    },
                    new Actor()
                    {
                        FullName = "Actor 4",
                        Bio = "This is the Bio of the second actor",
                        Profilepicture = "http://dotnethow.net/images/actors/actor-4.jpeg"
                    },
                    new Actor()
                    {
                        FullName = "Actor 5",
                        Bio = "This is the Bio of the second actor",
                        Profilepicture = "http://dotnethow.net/images/actors/actor-5.jpeg"
                    }
                });
            context.SaveChanges();
        }
        //Cinema
        if (!context.Cinemas.Any())
        {
            context.Cinemas.AddRange(new List<Cinema>()
                {
                    new Cinema()
                    {
                        CinemasName = "Cinema 1",
                        logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        CinemasName = "Cinema 2",
                        logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        CinemasName = "Cinema 3",
                        logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        CinemasName = "Cinema 4",
                        logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        CinemasName = "Cinema 5",
                        logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                }
            );
            context.SaveChanges();
        }
        //Producers
        if (!context.Producers.Any())
        {
            context.Producers.AddRange(new List<Producer>()
                {
                    new Producer()
                    {
                        Name = "Producer 1",
                        Bio = "This is the Bio of the first actor",
                        ProfilepictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                    },
                    new Producer()
                    {
                        Name = "Producer 2",
                        Bio = "This is the Bio of the second actor",
                        ProfilepictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                    },
                    new Producer()
                    {
                        Name = "Producer 3",
                        Bio = "This is the Bio of the second actor",
                        ProfilepictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                    },
                    new Producer()
                    {
                        Name = "Producer 4",
                        Bio = "This is the Bio of the second actor",
                        ProfilepictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                    },
                    new Producer()
                    {
                        Name = "Producer 5",
                        Bio = "This is the Bio of the second actor",
                        ProfilepictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                    }
                });
            context.SaveChanges();
        }
        //Movies
        if (!context.Movies.Any())
        {
            context.Movies.AddRange(new List<Movie>()
                {
                    new Movie()
                    {
                        MovieName = "Life",
                        Description = "This is the Life movie description",
                        Price = 39.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(10),
                        CinemasId = 3,
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Documentary
                    },
                    new Movie()
                    {
                        MovieName = "The Shawshank Redemption",
                        Description = "This is the Shawshank Redemption description",
                        Price = 29.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(3),
                        CinemasId = 1,
                        ProducerId = 1,
                        MovieCategory = MovieCategory.Action
                    },
                    new Movie()
                    {
                        MovieName = "Ghost",
                        Description = "This is the Ghost movie description",
                        Price = 39.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        CinemasId = 4,
                        ProducerId = 4,
                        MovieCategory = MovieCategory.Horror
                    },
                    new Movie()
                    {
                        MovieName = "Race",
                        Description = "This is the Race movie description",
                        Price = 39.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-5),
                        CinemasId = 1,
                        ProducerId = 2,
                        MovieCategory = MovieCategory.Documentary
                    },
                    new Movie()
                    {
                        MovieName = "Scoob",
                        Description = "This is the Scoob movie description",
                        Price = 39.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-2),
                        CinemasId = 1,
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Catroon
                    },
                    new Movie()
                    {
                        MovieName = "Cold Soles",
                        Description = "This is the Cold Soles movie description",
                        Price = 39.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                        StartDate = DateTime.Now.AddDays(3),
                        EndDate = DateTime.Now.AddDays(20),
                        CinemasId = 1,
                        ProducerId = 5,
                        MovieCategory = MovieCategory.Drama
                    }
                });
            context.SaveChanges();
        }
        //Actors & Movies
        if (!context.Actors_Movies.Any())
        {
            context.Actors_Movies.AddRange(new List<Actor_Movie>()
                {
                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 1
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 1
                    },

                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 2
                    },

                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 3
                    },
                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 3
                    },
                    new Actor_Movie()
                    {
                        ActorId = 5,
                        MovieId = 3
                    },


                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 4
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 4
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 4
                    },


                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 5
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 5
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 5
                    },
                    new Actor_Movie()
                    {
                        ActorId = 5,
                        MovieId = 5
                    },


                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 6
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 6
                    },
                    new Actor_Movie()
                    {
                        ActorId = 5,
                        MovieId = 6
                    },
                });
            context.SaveChanges();
        }

    }

    //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    //{
    //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
    //    {

    //        //Roles
    //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
    //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
    //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
    //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

    //        //Users
    //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    //        string adminUserEmail = "admin@etickets.com";

    //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
    //        if (adminUser == null)
    //        {
    //            var newAdminUser = new ApplicationUser()
    //            {
    //                FullName = "Admin User",
    //                UserName = "admin-user",
    //                Email = adminUserEmail,
    //                EmailConfirmed = true
    //            };
    //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
    //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
    //        }


    //        string appUserEmail = "user@etickets.com";

    //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
    //        if (appUser == null)
    //        {
    //            var newAppUser = new ApplicationUser()
    //            {
    //                FullName = "Application User",
    //                UserName = "app-user",
    //                Email = appUserEmail,
    //                EmailConfirmed = true
    //            };
    //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
    //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
    //        }
    //    }
    //}
}