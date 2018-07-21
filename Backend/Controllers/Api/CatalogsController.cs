using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Models.Entities;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Api
{
    public class CatalogsController : Controller
    {
        [HttpPost]
        public Task<IActionResult> CreateCatalog([Bind("Title,ParentCatalogId,Id")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                //CreateCatalog - service
                return Ok(/*new MessageViewModel { MessageTitle = "New catalog", MessageText = "Succesfully created" }*/ );
            } else
            {
                return BadRequest();
            }
            
        }
    }
}