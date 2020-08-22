using System;
using System.Collections.Generic;

namespace veiculos.api.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Abastecimento = new HashSet<Abastecimento>();
        }

        public int Id { get; set; }
        public string Ano { get; set; }
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
    }
}
