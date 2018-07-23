using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Services.Interfaces;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Api
{
    [Route("[controller]")]
    public class CatalogsController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;

        public CatalogsController(ICatalogService catalogService, IMapper mapper)
        {
            _catalogService = catalogService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCatalog([FromBody, Bind("Title", "ParentCatalogId")]CatalogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var catalog = _mapper.Map<Catalog>(model);

            if(!string.IsNullOrWhiteSpace(model.ParentCatalogId))
            {
                var parentCatalog = _catalogService.FindCatalogId(model.ParentCatalogId);

                catalog.ParentCatalog = parentCatalog;
            }

            await _catalogService.CreateCatalogAsync(catalog);

            return Created("", _mapper.Map<CatalogViewModel>(catalog));
        }
        [HttpPut("{catalogId}")]
        public async Task<IActionResult> EditCatalog(string catalogId, [FromBody, Bind("Title","ParentCatalogId")]CatalogViewModel model)
        {                               
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var catalog = _mapper.Map<Catalog>(model);

            await _catalogService.EditCatalogAsync(catalogId, catalog);

            return Ok(_mapper.Map<CatalogViewModel>(catalog));
        }
        
    }
}