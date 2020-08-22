using System;
using System.Collections.Generic;

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
    }
}
