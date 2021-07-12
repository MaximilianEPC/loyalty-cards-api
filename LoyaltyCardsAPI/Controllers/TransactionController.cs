using LoyaltyCardsAPI.Dtos.Transaction;
using LoyaltyCardsAPI.Entities;
using LoyaltyCardsAPI.Repositories.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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

            try
            {
                var transaction = await _transactionRepository.AddAsync(cardNumber, pointsEarned);
                return Created("Create", transaction);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{cardNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LoyaltyPointsBalance>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LoyaltyPointsBalance> GetPointsBalance([FromRoute] int cardNumber)
        {
            try
            {
                var result = _transactionRepository.GetPointsBalance(cardNumber);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult GetTransactionHistory()
        {
            var transactions = _transactionRepository.GetAll();

            XmlSerializer xmlSerializer = new XmlSerializer(transactions.GetType());
            FileStream file = System.IO.File.Create("./transactions.xml");

            xmlSerializer.Serialize(file, transactions);

            file.Close();

            return File(System.IO.File.ReadAllBytes("./transactions.xml"), "application/xml");
        }
    }
}
