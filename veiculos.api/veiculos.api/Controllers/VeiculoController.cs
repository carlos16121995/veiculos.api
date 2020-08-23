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
                return Unauthorized("Este combustivel possui um veiculo ou abastecimento relacionado a ele. Remova o relacionamento antes de excluir.");
            }
            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }


        /* ----------------------------------------------------------------- TIPO VEICULO ----------------------------------------------------------------------------*/


        [HttpPost("[action]")]
        public ActionResult GravarTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            if ((tipoVeiculo.Id == 0) && (tipoVeiculo.Nome != "") && (tipoVeiculo.Nome.Length > 2) && (tipoVeiculo.Nome.Length <= 30))
            {
                int ret = tipoVeiculo.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public ActionResult AlterarTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            if ((tipoVeiculo.Id > 0) && (tipoVeiculo.Nome != "") && (tipoVeiculo.Nome.Length > 2) && (tipoVeiculo.Nome.Length <= 30))
            {
                int ret = tipoVeiculo.Alterar();
                if (ret > 0)
                {
                    return Ok("Alterado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarTipoVeiculo(int id)
        {
            TipoVeiculo tipoVeiculo = new TipoVeiculo().Buscar(id);

            if (tipoVeiculo == null)
            {
                return NotFound();
            }
            return Json(tipoVeiculo);
        }
        [HttpGet("[action]")]
        public ActionResult BuscarTipoVeiculo()
        {
            List<TipoVeiculo> tipoVeiculo = new TipoVeiculo().Buscar();

            if (tipoVeiculo == null)
            {
                return NotFound();
            }
            return Json(tipoVeiculo);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult ExcluirTipoVeiculo(int id)
        {

            int ret = new TipoVeiculo().Excluir(id);

            if (ret == -99)
            {
                return Unauthorized("Este tipo de veiculo possui um veiculo relacionado a ele. Remova o relacionamento antes de excluir.");
            }
            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }




        /* ----------------------------------------------------------------- VEICULO ----------------------------------------------------------------------------*/


        [HttpPost("[action]")]
        public ActionResult GravarVeiculo(Veiculo veiculo)
        {
            if ((veiculo.Id == 0) && (veiculo.Ano <= DateTime.Now.Year) && (veiculo.Placa.Length == 7) && (veiculo.Quilometragem > 0) && 
                (veiculo.MarcaVeiculoId > 0) && (veiculo.ModeloVeiculoId > 0) && (veiculo.UsuarioId > 0) && (veiculo.TipoCombustivelId > 0))
            {
                int ret = veiculo.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public ActionResult AlterarVeiculo(Veiculo veiculo)
        {
            if ((veiculo.Id > 0) && (veiculo.Ano <= DateTime.Now.Year) && (veiculo.Placa.Length == 7) && (veiculo.Quilometragem > 0) &&
                (veiculo.MarcaVeiculoId > 0) && (veiculo.ModeloVeiculoId > 0) && (veiculo.UsuarioId > 0) && (veiculo.TipoCombustivelId > 0))
            {
                int ret = veiculo.Alterar();
                if (ret > 0)
                {
                    return Ok("Alterado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarVeiculo(int id)
        {
            Veiculo veiculo = new Veiculo().Buscar(id);

            if (veiculo == null)
            {
                return NotFound();
            }
            return Json(veiculo);
        }
        [HttpGet("[action]")]
        public ActionResult BuscarVeiculo()
        {
            List<Veiculo> veiculo = new Veiculo().Buscar();

            if (veiculo == null)
            {
                return NotFound();
            }
            return Json(veiculo);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult ExcluirVeiculo(int id)
        {

            int ret = new Veiculo().Excluir(id);

            if (ret == -99)
            {
                return Unauthorized("Este veiculo possui um abastecimento relacionado a ele. Remova o relacionamento antes de excluir.");
            }
            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }

    }
}