using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veiculos.api.Models;
using veiculos.api.Relatorio;

namespace veiculos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbastecimentoController : Controller
    {

        [HttpPost("[action]")]
        public ActionResult GravarAbastecimento(Abastecimento abastecimento)
        {
            if ((abastecimento.Id == 0) && (abastecimento.Km >= 0) && (abastecimento.Litro > 0) && (abastecimento.Valor > 0) &&
                (abastecimento.Data < DateTime.Now) && (abastecimento.Posto != "") && (abastecimento.TipoCombustivelId > 0) && 
                (abastecimento.VeiculoId > 0) && (abastecimento.UsuarioId > 0))
            {
                int ret = abastecimento.Gravar();
                if (ret > 0)
                {
                    return Ok("Cadastrado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public ActionResult AlterarAbastecimento(Abastecimento abastecimento)
        {
            if ((abastecimento.Id > 0) && (abastecimento.Km >= 0) && (abastecimento.Litro > 0) && (abastecimento.Valor > 0) &&
                (abastecimento.Data < DateTime.Now) && (abastecimento.Posto != "") && (abastecimento.TipoCombustivelId > 0) &&
                (abastecimento.VeiculoId > 0) && (abastecimento.UsuarioId > 0))
            {
                int ret = abastecimento.Alterar();
                if (ret > 0)
                {
                    return Ok("Alterado com sucesso!");
                }
            }

            return BadRequest();
        }
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarAbastecimento(int id)
        {
            Abastecimento abastecimento = new Abastecimento().Buscar(id);

            if (abastecimento == null)
            {
                return NotFound();
            }
            return Json(abastecimento);
        }
        [HttpGet("[action]")]
        public ActionResult BuscarAbastecimento()
        {
            List<Abastecimento> abastecimento = new Abastecimento().Buscar();

            if (abastecimento == null)
            {
                return NotFound();
            }
            return Json(abastecimento);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult ExcluirAbastecimento(int id)
        {

            int ret = new Abastecimento().Excluir(id);

            if (ret > 0)
            {
                return Ok("Excluido com sucesso!");
            }
            return BadRequest();

        }

        /* ----------------------------------------------------------------- Relatorio ----------------------------------------------------------------------------*/

        [HttpGet("[action]/{mes}/{ano}")]
        public IActionResult GerarRelatorio(int mes, int ano)
        {
            if (mes > 0 && mes < 13 && ano <= DateTime.Now.Year)
            {
                var ret = new RelatorioVeiculo().GerarRelatorio(mes, ano);
                return Json(ret);
            }
            return BadRequest();
        }

        [HttpGet("[action]/{veiculo}/{mes}/{ano}")]
        public IActionResult GerarRelatorio(int veiculo, int mes, int ano)
        {
            if (mes > 0 && mes < 13 && ano <= DateTime.Now.Year && veiculo > 0)
            {
                var ret = new RelatorioVeiculo().GerarRelatorio(veiculo, mes, ano);
                return Json(ret);
            }
            return BadRequest();
        }

    }
}