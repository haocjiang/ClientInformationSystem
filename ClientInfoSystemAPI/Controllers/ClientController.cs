using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            if (clients.Any())
            {
                return Ok(clients);
            }
            return NotFound("Client Not Found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetClientDetails(int id)
        {
            var client = await _clientService.GetClientDetails(id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound("Client Not Found");
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddClient([FromBody] ClientRequestModel model)
        {
            var client = await _clientService.AddClient(model);
            return Ok(client);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteClient([FromBody] int id)
        {
            await _clientService.DeleteClient(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientRequestModel model)
        {
            await _clientService.UpdateClient(id, model);
            return Ok();
        }
    }
}
