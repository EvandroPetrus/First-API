using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API01.Context;
using API01.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API01.Controllers {
   [ApiController]
   [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        [HttpPost()]       //CRUD = Create
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
             var contato = _context.Contatos.Find(id);
             
             if (contato == null)
             {
                return NotFound();
             }
             
             return Ok(contato);
        }
        
        [HttpGet("ObterPorNome")]
       public IActionResult ObterPorNome(string nome)
       {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            if (contatos == null)
            {
                return NotFound();
            }
            return Ok(contatos);
       }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarContato(int id, Contato contato)
        {
            var contatoBancoDeDados = _context.Contatos.Find(id);

            if(contatoBancoDeDados == null)
            {
               return NotFound();
            }
            
            contatoBancoDeDados.Nome = contato.Nome;
            contatoBancoDeDados.Telefone = contato.Telefone;
            contatoBancoDeDados.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBancoDeDados);
            _context.SaveChanges();

            return Ok(contatoBancoDeDados);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarContato(int id)
        {
            var contatoBancoDeDados = _context.Contatos.Find(id);

            if(contatoBancoDeDados == null)
            {
                return NotFound();
            }
            
            _context.Contatos.Remove(contatoBancoDeDados);
            _context.SaveChanges();
            return NoContent();
        }
       
    }

}