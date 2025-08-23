using ConsoleApp1;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

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
            string sql = """
                    INSERT INTO Aluno (
                    Nome, 
                    Idade,
                    Cpf, 
                    DataNascimento, 
                    Cep, 
                    Endereco, 
                    Numero,
                    Bairro,
                    Cidade,
                    Estado,
                    Nota1, 
                    Nota2
                    ) VALUES (
                    @Nome, 
                    @Idade, 
                    @Cpf, 
                    @DataNascimento,
                    @Cep,
                    @Endereco, 
                    @Numero,
                    @Bairro,
                    @Cidade,
                    @Estado,
                    @Nota1, 
                    @Nota2
                    );
                    """;

            using (SqlCommand comando = new SqlCommand(sql, _conn))
            {
                comando.Parameters.AddWithValue("@Nome", aluno.Nome);
                comando.Parameters.AddWithValue("@Idade", aluno.Idade);
                comando.Parameters.AddWithValue("@Cpf", aluno.Cpf);
                comando.Parameters.AddWithValue("@DataNascimento", aluno.DataNascimento.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Cep", aluno.Cep); // CORRIGIDO: era aluno.Endereco
                comando.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                comando.Parameters.AddWithValue("@Numero", aluno.Numero);
                comando.Parameters.AddWithValue("@Bairro", aluno.Bairro);
                comando.Parameters.AddWithValue("@Cidade", aluno.Cidade);
                comando.Parameters.AddWithValue("@Estado", aluno.Estado);
                comando.Parameters.AddWithValue("@Nota1", aluno.Nota1);
                comando.Parameters.AddWithValue("@Nota2", aluno.Nota2);

                if (comando.ExecuteNonQuery() > 0)
                {
                    return "Aluno inserido com sucesso!";
                }
                else
                {
                    return "Não foi possivel inserir Aluno!";
                }
            }
        }
        catch (Exception ex)
        {
            return "Erro ao inserir Aluno: " + ex.Message;
        }
    }

    public List<Aluno> BuscarAlunos()
    {
        try
        {
            string sql = "SELECT Nome, Idade, Cpf FROM Aluno";
            using (SqlCommand comando = new SqlCommand(sql, _conn))
            {
                List<Aluno> alunos = new List<Aluno>();

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                        var idadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                        var cpfDb = reader.GetString(reader.GetOrdinal("Cpf"));

                        alunos.Add(new Aluno()
                        {
                            Nome = nomeDb,
                            Idade = idadeDb,
                            Cpf = cpfDb
                        });
                    }
                }
                return alunos;
            }
        }
        catch (Exception ex)
        {
            // Tratamento adequado da exceção
            throw new Exception("Erro ao buscar alunos: " + ex.Message, ex);
        }
    }
}