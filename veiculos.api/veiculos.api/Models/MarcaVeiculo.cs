using System;
using System.Collections.Generic;
using System.Linq;

namespace veiculos.api.Models
{
    public partial class MarcaVeiculo
    {
        public MarcaVeiculo()
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
                    contexto.MarcaVeiculo.Add(this);
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
                    MarcaVeiculo marcaVeiculo = contexto.MarcaVeiculo.Where(p => p.Id == this.Id).FirstOrDefault();
                    marcaVeiculo.Nome = this.Nome; 
                    contexto.MarcaVeiculo.Attach(marcaVeiculo);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public MarcaVeiculo Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.MarcaVeiculo.Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<MarcaVeiculo> Buscar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.MarcaVeiculo.ToList();
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
                    Veiculo veiculo = contexto.Veiculo.Where(p => p.MarcaVeiculoId == id).FirstOrDefault();
                    if (veiculo == null)
                    {
                        MarcaVeiculo marcaVeiculo = contexto.MarcaVeiculo.Where(p => p.Id == id).FirstOrDefault();
                        contexto.MarcaVeiculo.Remove(marcaVeiculo);
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
