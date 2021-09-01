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
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _interactionService;
        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInteractions()
        {
            var interaction = await _interactionService.GetAllInteractions();
            if (!interaction.Any())
            {
                return NotFound("No interaction Found");
            }
            return Ok(interaction);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetInteractionDetails(int id)
        {
            var interaction = await _interactionService.GetInteractionDetails(id);
            if (interaction == null)
            {
                return NotFound("No interaction Found");
            }
            return Ok(interaction);
        }

        [HttpGet]
        [Route("Client/{id:int}")]
        public async Task<IActionResult> GetInteractionsByClientId(int id)
        {
            var interactions = await _interactionService.GetInteractionByClient(id);
            if (interactions.Any())
            {
                return Ok(interactions);
            }
            return NotFound("Interaction Not Found");
        }

        [HttpGet]
        [Route("Employee/{id:int}")]
        public async Task<IActionResult> GetInteractionsByEmployeeId(int id)
        {
            var interactions = await _interactionService.GetInteractionByEmployee(id);
            if (interactions.Any())
            {
                return Ok(interactions);
            }
            return NotFound("Interaction Not Found");
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddInteraction([FromBody] InteractionRequestModel model)
        {
            var interaction = await _interactionService.AddInteraction(model);
            return Ok(interaction);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteInteraction([FromBody] int id)
        {
            await _interactionService.DeleteInteraction(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateInteraction(int id, [FromBody] InteractionRequestModel model)
        {
            await _interactionService.UpdateInteraction(id, model);
            return Ok();
        }
    }
}
