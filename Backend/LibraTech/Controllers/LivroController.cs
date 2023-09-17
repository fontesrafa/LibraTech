using LibraTech.Context;
using LibraTech.Data;
using LibraTech.Models;
using LibraTech.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LibraTech.Controllers
{
    [ApiController]
    [Route("livro")]
    public class LivroController : ControllerBase
    {
        private readonly LibratechContext _context;

        public LivroController(LibratechContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<LivroDTO>> GetLivros()
        {
            return Ok(Biblioteca.ListaLivro);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LivroDTO> GetLivro(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Livro? livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }
            
            return Ok(Biblioteca.ListaLivro.First(u=>u.Id==id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LivroDTO> Create(Livro livro)
        {
            if (livro == null)
            {
                return BadRequest("Dados invalidos.");
            }

            try
            {
                _context.Add(livro);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetLivro), new { id = livro.Id, livro }, livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Update(Livro livroAtualizado)
        {
            _context.Entry(livroAtualizado).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!LivroExiste(livroAtualizado.Id)) 
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var livro = _context.Livros.Find(id);

            if(livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return NoContent();
        }

        private bool LivroExiste(int id)
        {
            return _context.Livros.Any(x => x.Id == id);
        }
    }
}