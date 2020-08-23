using System;
using System.Collections.Generic;
using System.Linq;

namespace veiculos.api.Models
{
    public partial class ModeloVeiculo
    {
        public ModeloVeiculo()
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
                    contexto.ModeloVeiculo.Add(this);
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
                    ModeloVeiculo modeloVeiculo = contexto.ModeloVeiculo.Where(p => p.Id == this.Id).FirstOrDefault();
                    modeloVeiculo.Nome = this.Nome;
                    contexto.ModeloVeiculo.Attach(modeloVeiculo);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public ModeloVeiculo Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.ModeloVeiculo.Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ModeloVeiculo> Buscar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.ModeloVeiculo.ToList();
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
                    Veiculo veiculo = contexto.Veiculo.Where(p => p.ModeloVeiculoId == id).FirstOrDefault();
                    if (veiculo == null)
                    {
                        ModeloVeiculo modeloVeiculo = contexto.ModeloVeiculo.Where(p => p.Id == id).FirstOrDefault();
                        contexto.ModeloVeiculo.Remove(modeloVeiculo);
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
