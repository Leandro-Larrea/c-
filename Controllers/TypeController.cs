using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pokeSharp.models;

namespace pokeSharp.Controllers
{
    [Route("[controller]")]
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;

        public TypeController(ILogger<TypeController> logger)
        {
            _logger = logger;
        }

       [HttpPost]
       public async Task<IActionResult> Post([FromServices] PokemonContext dbConection, [FromBody] _Type type){

        type.TypeId = Guid.NewGuid();

        await dbConection.AddAsync(type);
        await dbConection.SaveChangesAsync();
        return Ok("type guardado");
       }
    }
}