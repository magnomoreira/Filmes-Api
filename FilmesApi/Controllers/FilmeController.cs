using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FilmeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var responseFilme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(responseFilme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = responseFilme.Id }, filme);

        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilme()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = _context
                           .Filmes
                           .AsNoTracking()
                           .FirstOrDefault(x => x.Id == id);

            if (filme != null)
            {
                var responseFilme = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(responseFilme);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizandoFilme([FromBody] UpdateFilmeDto filmeDto, int id)
        {
            var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme != null) return NotFound();

            _mapper.Map(filmeDto, filme);
            
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if( result != null)
            {
                _context.Filmes.Remove(result);
                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }   
    }
}
