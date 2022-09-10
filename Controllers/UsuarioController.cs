using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API01.Controllers
{  [ApiController]
   [Route("[controller]")]
   public class UsuarioController : ControllerBase     
    {   [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            var obj = new
            {
               Data = DateTime.Now.ToLongDateString(),
               Hora = DateTime.Now.ToShortDateString()
            };
            return Ok(obj); 
        }   
    
    }
}