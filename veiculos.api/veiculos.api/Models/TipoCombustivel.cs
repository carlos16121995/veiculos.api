using System;
using System.Collections.Generic;

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
    }
}
