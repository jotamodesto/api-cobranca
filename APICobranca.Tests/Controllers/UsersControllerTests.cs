using Microsoft.VisualStudio.TestTools.UnitTesting;
using APICobranca.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net.Http;

namespace APICobranca.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        [TestMethod()]
        public void GetUsersTest()
        {
            Mappers.MapperConfig.RegisterMappings();

            UsersController usersController = new UsersController();

            var users = usersController.GetUsers();

            Logger.LogMessage("Users returned: " + users.Count().ToString());

            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod()]
        public async Task PostUserAsyncTest()
        {
            Mappers.MapperConfig.RegisterMappings();

            UsersController usersController = new UsersController();

            var dtoUser = CreateDTO();

            var result = await usersController.PostUser(dtoUser) as CreatedAtRouteNegotiatedContentResult<DTOs.User>;

            Assert.AreEqual(dtoUser.Email, result.Content.Email);
        }

        [TestMethod()]
        public async Task PostUserBadRequestTest()
        {
            Mappers.MapperConfig.RegisterMappings();

            UsersController usersController = new UsersController();

            var dtoUser = CreateDTO();

            var result = await usersController.PostUser(dtoUser) as BadRequestErrorMessageResult;

            Assert.AreEqual("E-mail já existente.", result.Message);
        }

        private DTOs.User CreateDTO()
        {
            DTOs.User dtoUser = new DTOs.User
            {
                Name = "Foo Bar 3",
                CardId = "1234567890123458",
                Email = "foo3@bar.com",
                Password = "foobar3"
            };

            return dtoUser;
        }
    }
}