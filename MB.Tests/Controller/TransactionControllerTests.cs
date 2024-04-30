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
        public async void TransactionController_GetTransactionsReport_ReturnOK()
        {
            var controller = new TransactionController(_transactionService);

            var result = await controller.GetTransactionsReport(CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Theory]
        [InlineData(1)]
        public async void TransactionController_GetTransactionsReportByPersonId_ReturnOK(int personId)
        {
            var controller = new TransactionController(_transactionService);

            var result = await controller.GetTransactionsReport(personId, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public async void TransactionController_GetMaxBuyer_ReturnOK()
        {
            var controller = new TransactionController(_transactionService);

            var result = await controller.GetMaxBuyer(CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Theory]
        [InlineData("2020/10/11", "2020/10/11")]
        public async void TransactionController_GetMaxBuyerInDate_ReturnOK(string startDate, string endDate)
        {
            var controller = new TransactionController(_transactionService);

            var period = new PeriodDateDto
            {
                Start_Date = startDate,
                End_Date = endDate
            };

            var result = await controller.GetMaxBuyerInDate(period ,CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
