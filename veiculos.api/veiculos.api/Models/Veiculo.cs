using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace veiculos.api.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Abastecimento = new HashSet<Abastecimento>();
        }

        public int Id { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int Quilometragem { get; set; }
        public string Foto { get; set; }
        public int ModeloVeiculoId { get; set; }
        public int MarcaVeiculoId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoCombustivelId { get; set; }
        public int TipoVeiculoId { get; set; }

        public virtual MarcaVeiculo MarcaVeiculo { get; set; }
        public virtual ModeloVeiculo ModeloVeiculo { get; set; }
        public virtual TipoCombustivel TipoCombustivel { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Abastecimento> Abastecimento { get; set; }


        public int Gravar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    contexto.Veiculo.Add(this);
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
                    Veiculo veiculo = contexto.Veiculo.Where(p => p.Id == this.Id).FirstOrDefault();
                    veiculo.Ano = this.Ano;
                    veiculo.Placa = this.Placa;
                    veiculo.Quilometragem = this.Quilometragem;
                    veiculo.MarcaVeiculoId = this.ModeloVeiculoId;
                    veiculo.ModeloVeiculoId = this.ModeloVeiculoId;
                    veiculo.UsuarioId = this.UsuarioId;
                    veiculo.TipoCombustivelId = this.TipoCombustivelId;
                    contexto.Veiculo.Attach(veiculo);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public Veiculo Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.Veiculo.Include("MarcaVeiculo").Include("ModeloVeiculo").Include("Usuario").Include("TipoCombustivel").Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Veiculo> Buscar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.Veiculo.Include("MarcaVeiculo").Include("ModeloVeiculo").Include("Usuario").Include("TipoCombustivel").ToList();
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
                    Abastecimento abastecimento = contexto.Abastecimento.Where(p => p.VeiculoId == id).FirstOrDefault();
                    if (abastecimento == null)
                    {
                        Veiculo veiculo = contexto.Veiculo.Where(p => p.Id == id).FirstOrDefault();
                        contexto.Veiculo.Remove(veiculo);
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
