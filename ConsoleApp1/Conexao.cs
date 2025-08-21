
using Microsoft.Data.SqlClient;

public class Conexao

{

    public SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\PICHAU\\Documents\\Projetos do Raul C#\\Projeto um\\Atividade1(certa).mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True");

    public void Conectar()

    {

        conn.Open();

    }

    public void Desconectar()

    {

        conn.Close();

    }

}
