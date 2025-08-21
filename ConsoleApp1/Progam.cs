using ConsoleApp1;
using ConsoleApp1.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        Conexao db = new Conexao();

        db.Conectar();

        AlunoRepositorio alunoRepositorio = new AlunoRepositorio(db.conn);

        int opcoes = 0;

        while (opcoes != 5)
        {
            opcoes = Menu();
            Console.Clear();
            switch (opcoes)
            {
                case 1:
                    CadastrarAluno();
                    Console.Clear();
                    break;
                case 2:
                    BuscarAluno();
                    Console.Clear();
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    Console.WriteLine("ENCERRANDO PROGRAMA....");
                    break;
            }
        }
        Console.ReadKey();
        static int Menu()
        {
            Console.WriteLine("MENU DE OPÇÕES");
            Console.WriteLine("===================");
            Console.WriteLine("[1] Cadastrar Aluno");
            Console.WriteLine("[2] Consultar Aluno");
            Console.WriteLine("[3] Alterar dados do aluno");
            Console.WriteLine("[4] Excluir Aluno");
            Console.WriteLine("[5] Sair");

            int opcoes = int.Parse(Console.ReadLine());
            return opcoes;
        }

        void CadastrarAluno()
        {
            Aluno aluno = new Aluno();

            Console.WriteLine("Preencha os dados solicitados do Aluno");

            Console.WriteLine("Nome Completo");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Idade");
            aluno.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Cpf");
            aluno.Cpf = Console.ReadLine();


            Console.WriteLine("Cep");
            aluno.Cep = Console.ReadLine();

            Console.WriteLine("Data de Nascimento");
            aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Endereço");
            aluno.Endereco = Console.ReadLine();

            Console.WriteLine("Bairo");
            aluno.Bairro = Console.ReadLine();


            Console.WriteLine("Numero");
            aluno.Numero = Console.ReadLine();


            Console.WriteLine("Cidade");
            aluno.Cidade = Console.ReadLine();


            Console.WriteLine("Estado");
            aluno.Estado = Console.ReadLine();


            Console.WriteLine("Nota 1");
            aluno.Nota1 = double.Parse(Console.ReadLine());


            Console.WriteLine("Nota 2");
            aluno.Nota2 = double.Parse(Console.ReadLine());


            var retorno = alunoRepositorio.InserirAluno(aluno);

            Console.WriteLine(retorno);
            Console.WriteLine();

        }

        void BuscarAluno()
        {
            Aluno aluno = new Aluno();

            Console.WriteLine("Informe o nome do aluno que deseja buscar");
            aluno.Nome = Console.ReadLine();

            var alunos = alunoRepositorio.BuscarAlunos();

            aluno = alunos;
            Console.WriteLine($"Dados de {aluno.Nome}");
            Console.WriteLine($"Dados de {aluno.Idade}");
            Console.WriteLine($"Dados de {aluno.Cpf}");
            Console.WriteLine($"Dados de {aluno.Endereco}");
            Console.WriteLine($"Dados de {aluno.Cep}");
            Console.WriteLine($"Dados de {aluno.Numero}");
            Console.WriteLine($"Dados de {aluno.Bairro}");
            Console.WriteLine($"Dados de {aluno.Cidade}");
            Console.WriteLine($"Dados de {aluno.Estado}");
            Console.WriteLine($"Dados de {aluno.Nota1}");
            Console.WriteLine($"Dados de {aluno.Nota2}");
            Console.WriteLine($"Dados de {aluno.DataNascimento}");
            Console.WriteLine("Pressione qualquer tecla para continuar...");

            Console.ReadLine();
        }
    }
}