using System;
using System.Collections.Generic;

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
    }
}
