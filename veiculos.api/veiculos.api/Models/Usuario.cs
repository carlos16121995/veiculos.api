using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using veiculos.api.Models;

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


        public bool Autenticar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    var ret = contexto.Usuario.Where(p => p.Email == this.Email && p.Senha == CalculateMD5Hash(this.Senha)).FirstOrDefault();

                    return ret == null ? false : true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public int Gravar()
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    var verificaCadastro = contexto.Usuario.Where(p => p.Email == this.Email).FirstOrDefault();
                    if (verificaCadastro == null)
                    {
                        this.Senha = CalculateMD5Hash(this.Senha);
                        contexto.Usuario.Add(this);
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
        public Usuario Buscar(int id)
        {
            try
            {
                using (veiculosapiContext contexto = new veiculosapiContext())
                {
                    return contexto.Usuario.Where(p => p.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
