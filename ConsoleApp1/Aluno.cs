using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Nome { get; internal set; }




        public static implicit operator Aluno(List<Aluno> v)
        {
            throw new NotImplementedException();
        }
    }
}