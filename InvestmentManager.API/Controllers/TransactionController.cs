using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            var createdTransaction = await _transactionService.AddTransactionAsync(transaction);
            return Ok(createdTransaction);
        }

        [HttpGet("asset/{assetId}")]
        public async Task<IActionResult> GetTransactionsByAsset(Guid assetId)
        {
            var transactions = await _transactionService.GetTransactionsByAssetIdAsync(assetId);
            return Ok(transactions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTransaction(Guid id)
        {
            var result = await _transactionService.RemoveTransactionAsync(id);
            if (!result) return NotFound("Transação não encontrada.");
            return Ok("Transação removida com sucesso.");
        }
    }
}
