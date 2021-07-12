using LoyaltyCardsAPI.Entities;
using LoyaltyCardsAPI.Repositories.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoyaltyCardsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }
    }
}
