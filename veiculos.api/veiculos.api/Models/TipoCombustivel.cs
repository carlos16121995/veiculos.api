using System;
using System.Collections.Generic;
using System.Linq;

namespace veiculos.api.Models
{
    public partial class TipoCombustivel
    {
        public TipoCombustivel()
        {
            Abastecimento = new HashSet<Abastecimento>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Abastecimento> Abastecimento { get; set; }
        public virtual ICollection<Veiculo> Veiculo { get; set; }


        public int Gravar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    contexto.TipoCombustivel.Add(this);
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
                    TipoCombustivel tipoCombustivel = contexto.TipoCombustivel.Where(p => p.Id == this.Id).FirstOrDefault();
                    tipoCombustivel.Nome = this.Nome;
                    contexto.TipoCombustivel.Attach(tipoCombustivel);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public TipoCombustivel Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.TipoCombustivel.Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<TipoCombustivel> Buscar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.TipoCombustivel.ToList();
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
                        TipoCombustivel tipoCombustivel = contexto.TipoCombustivel.Where(p => p.Id == id).FirstOrDefault();
                        contexto.TipoCombustivel.Remove(tipoCombustivel);
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
