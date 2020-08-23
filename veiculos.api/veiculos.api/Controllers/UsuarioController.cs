using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veiculos.api.Models;

namespace veiculos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            if ((usuario.Id == 0) && (usuario.Nome != "") && (usuario.Nome.Length > 4) && (usuario.Nome.Length <= 60) && (usuario.Email != "") && (usuario.Email.Contains("@")) && (usuario.Senha != "") && (usuario.Senha.Length > 4) && (usuario.Senha.Length <= 10))
            {
                int ret = usuario.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                }
                if (ret == -99)
                {
                    return Unauthorized("Este email já tem uma conta vinculada a ele");
                }
            }

            return BadRequest();
        }
     
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Usuario usuario = new Usuario().Buscar(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return Json(usuario);
        }
    }
}