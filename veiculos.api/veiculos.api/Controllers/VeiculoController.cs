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

        /* ----------------------------------------------------------------- MARCA VEICULO ----------------------------------------------------------------------------*/

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
        [HttpDelete("[action]/{id}")]
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

        /* ----------------------------------------------------------------- MODELO VEICULO ----------------------------------------------------------------------------*/


        [HttpPost("[action]")]
        public ActionResult GravarModeloVeiculo(ModeloVeiculo modeloVeiculo)
        {
            if ((modeloVeiculo.Id == 0) && (modeloVeiculo.Nome != "") && (modeloVeiculo.Nome.Length > 2) && (modeloVeiculo.Nome.Length <= 30))
            {
                int ret = modeloVeiculo.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public ActionResult AlterarModeloVeiculo(ModeloVeiculo modeloVeiculo)
        {
            if ((modeloVeiculo.Id > 0) && (modeloVeiculo.Nome != "") && (modeloVeiculo.Nome.Length > 2) && (modeloVeiculo.Nome.Length <= 30))
            {
                int ret = modeloVeiculo.Alterar();
                if (ret > 0)
                {
                    return Ok("Alterado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarModeloVeiculo(int id)
        {
            ModeloVeiculo modeloVeiculo = new ModeloVeiculo().Buscar(id);

            if (modeloVeiculo == null)
            {
                return NotFound();
            }
            return Json(modeloVeiculo);
        }
        [HttpGet("[action]")]
        public ActionResult BuscarModeloVeiculo()
        {
            List<ModeloVeiculo> modeloVeiculo = new ModeloVeiculo().Buscar();

            if (modeloVeiculo == null)
            {
                return NotFound();
            }
            return Json(modeloVeiculo);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult ExcluirModeloVeiculo(int id)
        {

            int ret = new ModeloVeiculo().Excluir(id);

            if (ret == -99)
            {
                return Unauthorized("Este modelo possui um veiculo relacionado a ele. Remova o relacionamento antes de excluir.");
            }
            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }


        /* ----------------------------------------------------------------- TIPO COMBUSTIVEL ----------------------------------------------------------------------------*/


        [HttpPost("[action]")]
        public ActionResult GravarTipoCombustivel(TipoCombustivel tipoCombustivel)
        {
            if ((tipoCombustivel.Id == 0) && (tipoCombustivel.Nome != "") && (tipoCombustivel.Nome.Length > 2) && (tipoCombustivel.Nome.Length <= 30))
            {
                int ret = tipoCombustivel.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public ActionResult AlterarTipoCombustivel(TipoCombustivel tipoCombustivel)
        {
            if ((tipoCombustivel.Id > 0) && (tipoCombustivel.Nome != "") && (tipoCombustivel.Nome.Length > 2) && (tipoCombustivel.Nome.Length <= 30))
            {
                int ret = tipoCombustivel.Alterar();
                if (ret > 0)
                {
                    return Ok("Alterado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarTipoCombustivel(int id)
        {
            TipoCombustivel tipoCombustivel = new TipoCombustivel().Buscar(id);

            if (tipoCombustivel == null)
            {
                return NotFound();
            }
            return Json(tipoCombustivel);
        }
        [HttpGet("[action]")]
        public ActionResult BuscarTipoCombustivel()
        {
            List<TipoCombustivel> tipoCombustivel = new TipoCombustivel().Buscar();

            if (tipoCombustivel == null)
            {
                return NotFound();
            }
            return Json(tipoCombustivel);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult ExcluirTipoCombustivel(int id)
        {

            int ret = new TipoCombustivel().Excluir(id);

            if (ret == -99)
            {
                return Unauthorized("Este combustivel possui um veiculo relacionado a ele. Remova o relacionamento antes de excluir.");
            }
            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }


    }
}