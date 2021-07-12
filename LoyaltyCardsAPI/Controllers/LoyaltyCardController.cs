using LoyaltyCardsAPI.Entities;
using LoyaltyCardsAPI.Repositories.LoyaltyCards;
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
        public ActionResult<IEnumerable<LoyaltyCard>> GetAll()
        {
            return Ok(_loyaltyCardRepository.GetAll());
        }
    }
}
