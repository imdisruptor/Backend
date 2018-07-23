using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Models.Entities;
using Backend.Services.Interfaces;
using Backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Api
{
    //[Produces("application/json")]
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;

        public MessagesController(ICatalogService catalogService, IMapper mapper)
        {
            _catalogService = catalogService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMessage([FromBody, Bind("Text", "CatalogId", "Subject")]MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var message = _mapper.Map<Message>(model);

            await _catalogService.CreateMessage(message);

            return Created("", _mapper.Map<MessageViewModel>(message));
        }

        [HttpPut("{messageId}")]
        public async Task<ActionResult> EditMessage(string messageId,[FromBody, Bind("Text", "CatalogId", "Subject")]MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var message = _mapper.Map<Message>(model);

            await _catalogService.EditMessage(messageId,message);

            return Ok(_mapper.Map<MessageViewModel>(message));
        }

        [HttpDelete("{messageId}")]
        public async Task<ActionResult> DeleteMessage(string messageId)
        {
            await _catalogService.DeleteMessage(messageId);

            return NotFound();
        }
    }
}