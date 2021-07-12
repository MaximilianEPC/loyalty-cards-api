using LoyaltyCardsAPI.Entities;
using LoyaltyCardsAPI.Repositories.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost("{cardNumber}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Transaction))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create([FromRoute] int cardNumber, [FromQuery] int pointsEarned)
        {
            if (pointsEarned == 0)
            {
                return BadRequest("The amount of points was not specified or is equal to 0.");
            }

            var transaction = await _transactionRepository.AddAsync(cardNumber, pointsEarned);
            return Created("Create", transaction);
        }
    }
}
