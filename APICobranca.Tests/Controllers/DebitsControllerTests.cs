using Microsoft.VisualStudio.TestTools.UnitTesting;
using APICobranca.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Http;

namespace APICobranca.Controllers.Tests
{
    [TestClass()]
    public class DebitsControllerTests
    {
        [TestMethod()]
        public void GetDebitsTest()
        {
            Mappers.MapperConfig.RegisterMappings();
            DebitsController debitsController = new DebitsController();

            var debits = debitsController.GetDebits("9876543210987654");

            Assert.IsTrue(debits.Count() > 0);
        }

        [TestMethod()]
        public void GetDebitsByDateTest()
        {
            Mappers.MapperConfig.RegisterMappings();
            DebitsController debitsController = new DebitsController();

            var debits = debitsController.GetDebits(initialDate: DateTime.Now.AddDays(-1).Date, finalDate: DateTime.Now);

            Assert.IsTrue(debits.Count() > 0);
        }

        [TestMethod()]
        public void GetDebitsNotFoundTest()
        {
            Mappers.MapperConfig.RegisterMappings();
            DebitsController debitsController = new DebitsController();

            Assert.ThrowsException<HttpResponseException>(() => debitsController.GetDebits("0"));
        }

        [TestMethod()]
        public async Task PostDebitAsyncTest()
        {
            Mappers.MapperConfig.RegisterMappings();
            DebitsController debitsController = new DebitsController();

            var dtoDebit = CreateDTO();

            var result = await debitsController.PostDebit(dtoDebit) as CreatedAtRouteNegotiatedContentResult<DTOs.Debit>;

            Assert.AreEqual(dtoDebit.CardId, result.Content.CardId);
        }

        [TestMethod()]
        public async Task PostDebitBadRequestTest()
        {
            Mappers.MapperConfig.RegisterMappings();
            DebitsController debitsController = new DebitsController();

            var dtoDebit = new DTOs.Debit
            {
                CardId = "0",
                Code = "0",
                Value = 0M
            };

            var result = await debitsController.PostDebit(dtoDebit) as BadRequestErrorMessageResult;

            Assert.AreEqual("Requisiçâo inválida.", result.Message);
        }

        private DTOs.Debit CreateDTO()
        {
            DTOs.Debit debit = new DTOs.Debit
            {
                CardId = "9876543210987654",
                Code = "2100-B",
                Value = 15.00M
            };

            return debit;
        }
    }
}