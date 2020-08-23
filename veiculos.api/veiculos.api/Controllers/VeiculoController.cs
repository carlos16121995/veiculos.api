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
    public class VeiculoController : Controller
    {

        [HttpPost("[action]")]
        public ActionResult GravarMarcaVeiculo(MarcaVeiculo marcaVeiculo)
        {
            if ((marcaVeiculo.Id == 0) && (marcaVeiculo.Nome != "") && (marcaVeiculo.Nome.Length > 2) && (marcaVeiculo.Nome.Length <= 30))
            {
                int ret = marcaVeiculo.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                } 
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public ActionResult AlterarMarcaVeiculo(MarcaVeiculo marcaVeiculo)
        {
            if ((marcaVeiculo.Id > 0) && (marcaVeiculo.Nome != "") && (marcaVeiculo.Nome.Length > 2) && (marcaVeiculo.Nome.Length <= 30))
            {
                int ret = marcaVeiculo.Alterar();
                if (ret > 0)
                {
                    return Ok("Alterado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarMarcaVeiculo(int id)
        {
            MarcaVeiculo marcaVeiculo = new MarcaVeiculo().Buscar(id);

            if (marcaVeiculo == null)
            {
                return NotFound();
            }
            return Json(marcaVeiculo);
        }
        [HttpGet("[action]")]
        public ActionResult BuscarMarcaVeiculo()
        {
            List<MarcaVeiculo> marcaVeiculo = new MarcaVeiculo().Buscar();

            if (marcaVeiculo == null)
            {
                return NotFound();
            }
            return Json(marcaVeiculo);
        }
        [HttpDelete]
        public IActionResult ExcluirMarcaVeiculo(int id)
        {

            int ret = new MarcaVeiculo().Excluir(id);

            if (ret == -99)
            {
                return Unauthorized("Esta marca possui um veiculo relacionado a ele. Remova o relacionamento antes de excluir.");
            }
            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }
    }
}