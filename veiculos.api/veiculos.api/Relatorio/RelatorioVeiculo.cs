using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using veiculos.api.Models;

namespace veiculos.api.Relatorio
{
    public class RelatorioVeiculo
    {
        public int VeiculoId { get; set; }
        public double MediaKm { get; set; }
        public Dictionary<string, string> ValorPago { get; set; }
        public Dictionary<string, string> LitrosAbastecidos { get; set; }
        public Dictionary<string, string> QuilometrosRodados { get; set; }

        public virtual Veiculo Veiculo { get; set; }


        public List<RelatorioVeiculo> GerarRelatorio(int mes, int ano)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    DateTime inicioRelatorio = new DateTime(ano - 1, mes, 01);
                    DateTime fimRelatorio = new DateTime(ano, mes, 01);
                    List<RelatorioVeiculo> relatorios = new List<RelatorioVeiculo>();

                    var veiculos = (from v in contexto.Set<Veiculo>()
                                    join a in contexto.Set<Abastecimento>().Where(p => p.Data >= inicioRelatorio && p.Data <= fimRelatorio)
                                    on v.Id equals a.VeiculoId
                                    select new { v }).Distinct().ToList();


                    foreach (var v in veiculos)
                    {
                        RelatorioVeiculo relatorio = new RelatorioVeiculo();
                        relatorio.VeiculoId = v.v.Id;

                        Dictionary<string, string> valores = new Dictionary<string, string>();
                        Dictionary<string, string> litros = new Dictionary<string, string>();
                        Dictionary<string, string> quilometros = new Dictionary<string, string>();

                        List<Abastecimento> abastecimentos = contexto.Abastecimento.Where(a => a.VeiculoId == relatorio.VeiculoId && a.Data >= inicioRelatorio && a.Data <= fimRelatorio).ToList();

                        for (int i = 1; i <= 12; i++ )
                        {
                            string key = new DateTime(1900, i, 1).ToString("MMMM", new CultureInfo("pt-BR"));

                            int km = abastecimentos.Where(t => t.Data.Month == i).Sum(x => x.Km);
                            quilometros.Add(key, km.ToString());

                            double litro = abastecimentos.Where(t => t.Data.Month == i).Sum(x => x.Litro);
                            litros.Add(key, litro.ToString());

                            decimal valor = abastecimentos.Where(t => t.Data.Month == i).Sum(x => x.Valor);
                            valores.Add(key, valor.ToString());
                        }

                        relatorio.MediaKm = (abastecimentos.Where(p => p.Data >= inicioRelatorio && p.Data <= fimRelatorio).Sum(x => x.Km) / abastecimentos.Where(p => p.Data >= inicioRelatorio && p.Data <= fimRelatorio).Sum(x => x.Litro));
                        relatorio.QuilometrosRodados = quilometros;
                        relatorio.LitrosAbastecidos = litros;
                        relatorio.ValorPago = valores;
                        relatorio.Veiculo = v.v;

                        relatorios.Add(relatorio);
                    }


                    return relatorios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RelatorioVeiculo GerarRelatorio(int veiculo, int mes, int ano)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    DateTime inicioRelatorio = new DateTime(ano - 1, mes, 01);
                    DateTime fimRelatorio = new DateTime(ano, mes, 01);

                   
                        RelatorioVeiculo relatorio = new RelatorioVeiculo();
                        relatorio.VeiculoId = veiculo;

                        Dictionary<string, string> valores = new Dictionary<string, string>();
                        Dictionary<string, string> litros = new Dictionary<string, string>();
                        Dictionary<string, string> quilometros = new Dictionary<string, string>();

                        List<Abastecimento> abastecimentos = contexto.Abastecimento.Where(a => a.VeiculoId == relatorio.VeiculoId && a.Data >= inicioRelatorio && a.Data <= fimRelatorio).ToList();

                        for (int i = 1; i <= 12; i++)
                        {
                            string key = new DateTime(1900, i, 1).ToString("MMMM", new CultureInfo("pt-BR"));

                            int km = abastecimentos.Where(t => t.Data.Month == i).Sum(x => x.Km);
                            quilometros.Add(key, km.ToString());

                            double litro = abastecimentos.Where(t => t.Data.Month == i).Sum(x => x.Litro);
                            litros.Add(key, litro.ToString());

                            decimal valor = abastecimentos.Where(t => t.Data.Month == i).Sum(x => x.Valor);
                            valores.Add(key, valor.ToString());
                        }

                        relatorio.MediaKm = (abastecimentos.Where(p => p.Data >= inicioRelatorio && p.Data <= fimRelatorio).Sum(x => x.Km) / abastecimentos.Where(p => p.Data >= inicioRelatorio && p.Data <= fimRelatorio).Sum(x => x.Litro));
                        relatorio.QuilometrosRodados = quilometros;
                        relatorio.LitrosAbastecidos = litros;
                        relatorio.ValorPago = valores;
                        relatorio.Veiculo = contexto.Veiculo.Where(a => a.Id == relatorio.VeiculoId).FirstOrDefault(); ;


                    return relatorio;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
