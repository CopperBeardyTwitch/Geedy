using System;
using System.Net.Http;
using System.Threading.Tasks;
using GeedService.Controllers;
using GeedService.DataAccess;
using GeedService.DataEntities;
using GeedService.Interfaces;
using GeedService.Model;
using GeedService.Models;
using GeedService.Repositories;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace GeedService.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task Get_User_By_Id_Expect_Single_User()
        {
            var user = new User
            {
                Username = "Ginger",
                Bio = "Fun loving and enjoy a intellegent conversation",
                ImageUrl = "a image",
                FacebookId = "GingerFace",
                InstagramId = "GingerInsta",
                LinkedInId = "GinerLink",
                TwitterId = "GingerTwit"
            };
           
            var mockcontext = new Mock<ApplicationDbContext>();
       //  var mockRepo = new Mock<IUserRepository>();
      //   mockRepo.Setup(p => p.GetUserById("934f795c-917d-45cd-abc4-45e2dd4249d9")).Returns(Task.FromResult(user));
      //  var controller = new UserController(mockRepo.Object);
      var repo =  new UserRepository(mockcontext.Object);
           //act
           var result = await repo.GetUserById("934f795c-917d-45cd-abc4-45e2dd4249d9");
           
          Assert.Equal(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(result));
        }
    }
}
