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

namespace Backend.Controllers
{
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;

        public MessageController(ICatalogService catalogService, IMapper mapper)
        {
            _catalogService = catalogService;
            _mapper = mapper;
        }
        [HttpPost("{catalogId}")]
        public async Task<IActionResult> CreateMessage(string catalogId,[FromBody,Bind( "Text", "Subject")]MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var message = _mapper.Map<Message>(model);

            await _catalogService.CreateMessage(catalogId,message);

            return Created("", _mapper.Map<MessageViewModel>(message));
        }
    }
}