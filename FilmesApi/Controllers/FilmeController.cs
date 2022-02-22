using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> _filmes = new List<Filme>();
        private static int id;

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody]Filme filme)
        {
            filme.Id = id++;
            _filmes.Add(filme);
         
            return CreatedAtAction(nameof(RecuperaFilmePorId), new {id = filme.Id}, filme);

        }

        [HttpGet]
        public IActionResult RecuperaFilme()
        {
            return Ok(_filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var response = _filmes.FirstOrDefault(x => x.Id == id);

            if (response == null) return Ok(response);
            
            return NotFound();


        }
    }
}
