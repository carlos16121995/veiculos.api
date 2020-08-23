using System;
using System.Collections.Generic;
using System.Linq;

namespace veiculos.api.Models
{
    public partial class TipoVeiculo
    {
        public TipoVeiculo()
        {
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Veiculo> Veiculo { get; set; }


        public int Gravar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    contexto.TipoVeiculo.Add(this);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int Alterar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    TipoVeiculo tipoVeiculo = contexto.TipoVeiculo.Where(p => p.Id == this.Id).FirstOrDefault();
                    tipoVeiculo.Nome = this.Nome;
                    contexto.TipoVeiculo.Attach(tipoVeiculo);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public TipoVeiculo Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.TipoVeiculo.Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<TipoVeiculo> Buscar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.TipoVeiculo.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int Excluir(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    Veiculo veiculo = contexto.Veiculo.Where(p => p.TipoCombustivelId == id).FirstOrDefault();
                    if (veiculo == null)
                    {
                        TipoVeiculo tipoVeiculo = contexto.TipoVeiculo.Where(p => p.Id == id).FirstOrDefault();
                        contexto.TipoVeiculo.Remove(tipoVeiculo);
                        return contexto.SaveChanges();
                    }
                    return -99;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
