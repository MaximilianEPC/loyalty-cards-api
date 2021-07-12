using LoyaltyCardsAPI.Dtos.LoyaltyCard;
using LoyaltyCardsAPI.Entities;
using LoyaltyCardsAPI.Repositories.LoyaltyCards;
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
    public class LoyaltyCardController : ControllerBase
    {
        private readonly ILoyaltyCardRepository _loyaltyCardRepository;
        
        public LoyaltyCardController(ILoyaltyCardRepository loyaltyCardRepository)
        {
            _loyaltyCardRepository = loyaltyCardRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LoyaltyCard>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<LoyaltyCard>> GetAll()
        {
            return Ok(_loyaltyCardRepository.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoyaltyCard))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Issue(CreateLoyaltyCardDto loyaltyCardDto)
        {
            var loyaltyCard = await _loyaltyCardRepository.AddAsync(loyaltyCardDto);
            return Created("Issue", loyaltyCard);
        }
    }
}
