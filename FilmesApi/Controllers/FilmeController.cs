using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly List<Filme> _filmes = new List<Filme>();

        [HttpPost]
        public void AdicionarFilme([FromBody]Filme filme)
        {
            _filmes.Add(filme);
            Console.WriteLine(filme.Titulo);

        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilme()
        {
            return _filmes;
        }
    }
}
