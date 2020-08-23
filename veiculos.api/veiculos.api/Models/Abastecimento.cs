using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace veiculos.api.Models
{
    public partial class Abastecimento
    {
        public int Id { get; set; }
        public int Km { get; set; }
        public double Litro { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Posto { get; set; }
        public int TipoCombustivelId { get; set; }
        public int VeiculoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual TipoCombustivel TipoCombustivel { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Veiculo Veiculo { get; set; }




        public int Gravar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    contexto.Abastecimento.Add(this);
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
                    Abastecimento abastecimento = contexto.Abastecimento.Where(p => p.Id == this.Id).FirstOrDefault();
                    abastecimento.Km = this.Km;
                    abastecimento.Litro = this.Litro;
                    abastecimento.Valor = this.Valor;
                    abastecimento.Data = this.Data;
                    abastecimento.Posto = this.Posto;
                    abastecimento.UsuarioId = this.UsuarioId;
                    abastecimento.TipoCombustivelId = this.TipoCombustivelId;
                    contexto.Abastecimento.Attach(abastecimento);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public Abastecimento Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.Abastecimento.Include("Usuario").Include("TipoCombustivel").Include("Veiculo").Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Abastecimento> Buscar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.Abastecimento.Include("Usuario").Include("TipoCombustivel").Include("Veiculo").ToList();
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
                    Abastecimento abastecimento = contexto.Abastecimento.Where(p => p.Id == id).FirstOrDefault();
                    contexto.Abastecimento.Remove(abastecimento);
                    return contexto.SaveChanges();   
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
