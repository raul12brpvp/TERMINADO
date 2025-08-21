using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Data
{
    public class AlunoRepositorio
    {
        private SqlConnection _conn;
        public AlunoRepositorio(SqlConnection conn)
        {
            _conn = conn;
        }
        public string InserirAluno(Aluno aluno)
        {
            try
            {
                string sql = @"INSERT INTO Aluno (Nome, Idade, Cpf, Endereco, Cep, Numero, Bairro, Cidade, Estado, Nota1, Nota2, DataNascimento) 
                              VALUES(@Nome, @Idade, @Cpf, @Endereco, @Cep, @Numero, @Bairro, @Cidade, @Estado, @Nota1, @Nota2, @DataNascimento)";
                SqlCommand comando = new SqlCommand(sql, _conn);

                comando.ExecuteNonQuery();

                return "Aluno inserido com sucesso!";
            }
            catch (Exception e)
            {

                return "Erro ao inserir Aluno";
            }
        }
        public List<Aluno> BuscarAlunos()
        {
            try
            {
                string sql = "select Nome, Idade, Cpf from Aluno";
                SqlCommand comando = new SqlCommand(sql, _conn);

                List<Aluno> alunos = new List<Aluno>();

                using (var reader = comando.ExecuteReader())
                {
                    //cria um leitor do ADO.net

                    while (reader.Read())
                    {///vai lendo cada item do resultado do select
                     ///retorna cada item encontrado
                        var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                        var idadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                        var cpfDb = reader.GetString(reader.GetOrdinal("Cpf"));
                        var enderecoDb = reader.GetString(reader.GetOrdinal("Endereco"));
                        var cepDb = reader.GetString(reader.GetOrdinal("Cep"));
                        var numeroDb = reader.GetString(reader.GetOrdinal("Numero"));
                        var bairroDb = reader.GetString(reader.GetOrdinal("Bairro"));
                        var cidadeDb = reader.GetString(reader.GetOrdinal("Cidade"));
                        var estadoDb = reader.GetString(reader.GetOrdinal("Estado"));
                        var nota1Db = reader.GetDouble(reader.GetOrdinal("Nota1"));
                        var nota2Db = reader.GetDouble(reader.GetOrdinal("Nota2"));
                        var datanascimentoDb = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        var idDb = reader.GetInt32(reader.GetOrdinal("Id"));

                        alunos.Add(new Aluno()
                        {
                            Nome = nomeDb,
                            Idade = idadeDb,
                            Cpf = cpfDb,
                            Endereco = enderecoDb,
                            Cep = cepDb,
                            Numero = numeroDb, 
                            Bairro = bairroDb,
                            Cidade = cidadeDb,
                            Estado = estadoDb,
                            Nota1 = nota1Db,
                            Nota2 = nota2Db,
                            DataNascimento = datanascimentoDb,
                            Id = idDb

                        });

                    }
                    return alunos;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}