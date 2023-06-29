using System;
using System.Runtime.Intrinsics.X86;
using System.Net;
using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
using System.Text.Json;
using pokeSharp.models;
using Microsoft.EntityFrameworkCore;
using pokeSharp;
namespace pokeSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class pokemonController : ControllerBase
{
    private readonly ILogger<pokemonController> _logger;
    public pokemonController(ILogger<pokemonController> _logger){
        this._logger = _logger;
    }

     static List<Pokemon> pokeList = new();

    [HttpGet]
     public async Task<IActionResult>GetConnection([FromServices] PokemonContext pokeContext)
     {
        pokeContext.Database.EnsureCreated();
        return Ok("conectado (?");
     }


    [HttpGet]
    [Route("pokeDb/{id}")]
    public async Task<IActionResult> GetPokemon([FromServices] PokemonContext pokeDb,[FromRoute] int id){
        try
        {
        var cokeList = pokeDb.Pokemons.Where(c => c.id == id).ToList();
        if(cokeList.Count != 0  ) return Ok(cokeList);
        throw new Exception("no hay nada chamigo");
        }
        catch (System.Exception e)
        {
            
           return BadRequest(e.Message);
        }
        
    }

    [HttpPost]
    [Route("pokeDb")]

    public async Task<IActionResult> PostPokemon([FromServices] PokemonContext pokeDb, [FromBody] Pokemon cokemon){
       List<_Type> pokeTypesList =  pokeDb.Types.Where(p => cokemon.TypesToReceive.Contains(p.TypeId)).ToList();
       
       
       if(pokeTypesList.Count != 0){
        cokemon.DateTime = DateTime.Now;
        cokemon.Types.AddRange(pokeTypesList);
        await pokeDb.AddAsync(cokemon);

        await pokeDb.SaveChangesAsync();
        return Ok("creado");
        }
        return BadRequest("salio mal kpo");
    }

    [HttpGet("{id?}")]
    public IActionResult Get(int? id)
    {
        try
        {
             if(id == null) return Ok(pokeList);
             _logger.LogInformation($"{id}");
             Pokemon pokemon = pokeList.FirstOrDefault(cokemon => cokemon.id == id)!;
             if(pokemon == null) return BadRequest("asd");
             return Ok(pokemon);
               
        }
        catch (System.Exception ex)
        {
            Object response = new{ data = ex.Message, message = "le erraste o rompiste algo"};
         return BadRequest(response);
        }
    }
    [HttpPost("{id}")]
    public async Task<IActionResult> Post(string id)
    {
        HttpClient client = new();
        {
            HttpResponseMessage response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            if(response.IsSuccessStatusCode){
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(responseBody);
                    // ese signito de ahi esta para avisar que el valor que devuelve Deserialize no sera nullo

                    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(responseBody)!;

                    if(!pokeList.Exists(e=> e.id == pokemon.id)){   
                        pokeList.Add(pokemon);
                    }
                    return Ok(pokemon);
            }
        return BadRequest("algo malio sal papu");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        //filter
        pokeList = pokeList.Where(e => e.id != id).ToList();
        return Ok(pokeList);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Pokemon ras, int id )  
    {
        //map
        pokeList = pokeList.Select(e=>{if(e.id == id){
            e.name = ras.name;
        }
        return e;
        }).ToList();
        return Ok(pokeList);
    }
}
