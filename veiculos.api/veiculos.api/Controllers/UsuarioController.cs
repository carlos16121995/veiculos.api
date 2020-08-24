using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using veiculos.api.Models;

namespace veiculos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IConfiguration _config;
        public UsuarioController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost("[action]")]
        public ActionResult Logar(Usuario usuario)
        {
            if ((usuario.Email != "") && (usuario.Email.Contains("@")) && (usuario.Senha != "") && (usuario.Senha.Length > 4) && (usuario.Senha.Length <= 10))
            {
                if (usuario.Autenticar())
                {
                    var tokenString = GerarTokenJWT();
                    return Ok(new { token = tokenString });
                }

                return Unauthorized();
            }

            return BadRequest();
        }

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                                             expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

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
        [Authorize]
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