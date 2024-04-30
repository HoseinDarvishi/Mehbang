using FakeItEasy;
using FluentAssertions;
using MB.Api.Controllers;
using MB.Contracts.DTOs;
using MB.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MB.Tests.Controller
{
    public  class TransactionControllerTests
    {
        private readonly ITransactionService _transactionService;

        public TransactionControllerTests()
        {
            _transactionService = A.Fake<ITransactionService>();
        }

        [Fact]
        public void TransactionController_GetTransactionsReport_ReturnOK()
        {
            var controller = new TransactionController(_transactionService);

            var result = controller.GetTransactionsReport(CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Theory]
        [InlineData(1)]
        public void TransactionController_GetTransactionsReportByPersonId_ReturnOK(int personId)
        {
            var controller = new TransactionController(_transactionService);

            var result = controller.GetTransactionsReport(personId, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void TransactionController_GetMaxBuyer_ReturnOK()
        {
            var controller = new TransactionController(_transactionService);

            var result = controller.GetMaxBuyer(CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Theory]
        [InlineData("2020/10/11", "2020/10/11")]
        public void TransactionController_GetMaxBuyerInDate_ReturnOK(string startDate, string endDate)
        {
            var controller = new TransactionController(_transactionService);

            var period = new PeriodDateDto
            {
                Start_Date = startDate,
                End_Date = endDate
            };

            var result = controller.GetMaxBuyerInDate(period ,CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Theory]
        [InlineData("20", "")]
        public void TransactionController_GetMaxBuyerInDate_ReturnBadRequest(string startDate, string endDate)
        {
            var controller = new TransactionController(_transactionService);

            var period = new PeriodDateDto
            {
                Start_Date = startDate,
                End_Date = endDate
            };

            var result = controller.GetMaxBuyerInDate(period, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
