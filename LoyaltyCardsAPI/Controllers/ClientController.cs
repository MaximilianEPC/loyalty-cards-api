using LoyaltyCardsAPI.Dtos.Client;
using LoyaltyCardsAPI.Entities;
using LoyaltyCardsAPI.Repositories.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateClientDto clientDto)
        {
            var client = await _clientRepository.AddAsync(clientDto);
            return Created("Create", client);
        }
    }
}
