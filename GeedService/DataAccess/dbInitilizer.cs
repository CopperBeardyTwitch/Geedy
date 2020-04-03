using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeedService.DataEntities;
using GeedService.Model;

namespace GeedService.DataAccess
{
    public static class DbInitilizer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.UserProfiles.Any())
            {
                
                return;
            }

            var users = new[]
            {
                new UserProfile
                {
                    UserId = "934f795c-917d-45cd-abc4-45e2dd4249d9",
                    Username = "Ginger",
                    Bio = "Fun loving and enjoy a intellegent conversation",
                    ImageUrl = "a image",
                    Joined = DateTime.Now.AddDays(-2),
                    FacebookId = "GingerFace",
                    InstagramId = "GingerInsta",
                    LinkedInId = "GinerLink",
                    TwitterId = "GingerTwit"
                },
                new UserProfile
                {
                    UserId = "97ccfb76-66f0-4123-847a-29afebfc5d5f",
                    Username = "bodie",
                    Bio = "Outdoor type, espcially sky diving",
                    ImageUrl = "some other  image",
                    FacebookId = "BodiFace",
                    InstagramId = "BodiInsta",
                    LinkedInId = "BodiLink",
                    TwitterId = "BodieTwit",
                    Joined = DateTime.Now.AddDays(-25)

                },
                new UserProfile
                {
                    UserId = "93343295c-917d-45cd-abc4-45e2dd4249d9",
                    Username = "flo",
                    Bio = "Fun loving conversation",
                    ImageUrl = "a image",
                    Joined = DateTime.Now.AddDays(-2),
                    FacebookId = "floFace",
                    InstagramId = "floInsta",
                    LinkedInId = null,
                    TwitterId = "floTwit"
                },
                new UserProfile
                {
                    UserId = "934f34211c-917d-45cd-abc4-45e2dd4249d9",
                    Username = "Slips",
                    Bio = " intellegent conversation",
                    ImageUrl = "a image",
                    Joined = DateTime.Now.AddDays(-2),
                    FacebookId = "SlipsFace",
                    InstagramId = "SlipsInsta",
                    LinkedInId = "SlipsLink",
                    TwitterId = "SlipsTwit"
                },
            };
            foreach (var user in users)
            {
                context.UserProfiles.Add(user);
            }

            context.SaveChanges();

           

            context.SaveChanges();

            var ratings = new[]
            {
                new Rating
                {
                    RaterUserName = "Ginger",
                    RatedUserName= "bodie",
                    GivenRating = 3,
                    TimeRated = DateTime.Now.AddDays(-1)
                },
                new Rating
                {
                    RaterUserName = "Ginger",
                    RatedUserName= "bodie",
                    GivenRating = 4,
                    TimeRated = DateTime.Now.AddHours(-1)
                },

                new Rating
                {
                    RaterUserName = "bodie",
                    RatedUserName= "Ginger",
                    GivenRating = 5,
                    TimeRated = DateTime.Now.AddHours(-1),
                },
                new Rating
                {
                    RaterUserName = "bodie",
                    RatedUserName= "Ginger",
                GivenRating = 3,
                TimeRated = DateTime.Now,
                },
                new Rating
                {
                RaterUserName = "flo",
                RatedUserName= "bodie",
                GivenRating = 3,
                TimeRated = DateTime.Now.AddDays(-1)
                },
                new Rating
                {
                    RaterUserName = "Ginger",
                    RatedUserName= "flo",
                    GivenRating = 4,
                    TimeRated = DateTime.Now.AddHours(-1)
                },

                new Rating
                {
                    RaterUserName = "slip",
                    RatedUserName= "Ginger",
                    GivenRating = 5,
                    TimeRated = DateTime.Now.AddHours(-1),
                },
                new Rating
                {
                    RaterUserName = "bodie",
                    RatedUserName= "slip",
                    GivenRating = 3,
                    TimeRated = DateTime.Now,
                },
                new Rating
                {
                RaterUserName = "Ginger",
                RatedUserName= "bodie",
                GivenRating = 3,
                TimeRated = DateTime.Now.AddDays(-1)
                },
                new Rating
                {
                    RaterUserName = "slip",
                    RatedUserName= "bodie",
                    GivenRating = 4,
                    TimeRated = DateTime.Now.AddHours(-1)
                },

                new Rating
                {
                    RaterUserName = "flo",
                    RatedUserName= "Ginger",
                    GivenRating = 5,
                    TimeRated = DateTime.Now.AddHours(-1),
                },
                new Rating
                {
                    RaterUserName = "bodie",
                    RatedUserName= "flo",
                    GivenRating = 3,
                    TimeRated = DateTime.Now,
                }
            };
            foreach (var rating in ratings)
            {
                context.Ratings.Add(rating);
            }

            context.SaveChanges();

            var followings = new[]
            {
                new Following
                {
                    FollowedUserName = "bodie",
                   FollowerUserName= "Ginger",
                },
                new Following
                {
                    FollowedUserName = "Ginger",
                    FollowerUserName= "bodie",
                  }
                ,
                new Following
                {
                    FollowedUserName = "bodie",
                    FollowerUserName= "flo",
                }
                ,
                new Following
                {
                    FollowedUserName = "bodie",
                    FollowerUserName= "slip",
                },
            };
            foreach (var following in followings)
            {
                context.Followings.Add(following);
            }

            context.SaveChanges();
        }
    }
}
