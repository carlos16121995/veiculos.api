using System;
using System.Collections.Generic;

namespace veiculos.api.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Abastecimento = new HashSet<Abastecimento>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Abastecimento> Abastecimento { get; set; }
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
