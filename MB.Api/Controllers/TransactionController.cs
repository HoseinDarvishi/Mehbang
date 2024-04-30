using MB.Contracts.DTOs;
using MB.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;
 
namespace MB.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("[action]/{personId:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetTransactionsReport(int personId , CancellationToken ct )
        {
            var trs = await _transactionService.GetTransactionsAsync(personId, ct);
            return Ok(trs);
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetTransactionsReport(CancellationToken ct)
        {
            var trs = await _transactionService.GetTransactionsAsync(ct);
            return Ok(trs);
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetMaxBuyer(CancellationToken ct)
        {
            var trs = await _transactionService.GetMaxBuyerAsync(ct);
            return Ok(trs);
        }

        [HttpGet("[action]")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetMaxBuyerInDate([FromQuery]PeriodDateDto period , CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(period);

            var trs = await _transactionService.GetMaxBuyerAsync(period,ct);
            return Ok(trs);
        }
    }
}
