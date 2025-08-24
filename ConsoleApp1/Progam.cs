using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static AlunoRepositorio alunoRepositorio;

    private static void Main(string[] args)
    {
        Conexao db = new Conexao();
        db.Conectar();

        alunoRepositorio = new AlunoRepositorio(db.conn);

        int opcoes = 0;

        while (opcoes != 5)
        {
            opcoes = Menu();
            Console.Clear();

            switch (opcoes)
            {
                case 1:
                    CadastrarAluno();
                    break;
                case 2:
                    BuscarAluno();
                    break;
                case 3:
                    // Implementar alteração
                    break;
                case 4:
                    // Implementar exclusão
                    break;
                case 5:
                    Console.WriteLine("ENCERRANDO PROGRAMA....");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static int Menu()
    {
        Console.WriteLine("MENU DE OPÇÕES");
        Console.WriteLine("===================");
        Console.WriteLine("[1] Cadastrar Aluno");
        Console.WriteLine("[2] Consultar Aluno");
        Console.WriteLine("[3] Alterar dados do aluno");
        Console.WriteLine("[4] Excluir Aluno");
        Console.WriteLine("[5] Sair");
        Console.Write("Escolha uma opção: ");

        int opcoes;
        while (!int.TryParse(Console.ReadLine(), out opcoes) || opcoes < 1 || opcoes > 5)
        {
            Console.Write("Opção inválida! Escolha entre 1 e 5: ");
        }

        return opcoes;
    }

    static void CadastrarAluno()
    {
        try
        {
            Aluno aluno = new Aluno();

            Console.WriteLine("Preencha os dados solicitados do Aluno");

            Console.Write("Nome Completo: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Idade: ");
            aluno.Idade = int.Parse(Console.ReadLine());

            Console.Write("CPF: ");
            aluno.Cpf = Console.ReadLine();

            Console.Write("CEP: ");
            aluno.Cep = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Endereço: ");
            aluno.Endereco = Console.ReadLine();

            Console.Write("Bairro: ");
            aluno.Bairro = Console.ReadLine();

            Console.Write("Número: ");
            aluno.Numero = Console.ReadLine();

            Console.Write("Cidade: ");
            aluno.Cidade = Console.ReadLine();

            Console.Write("Estado: ");
            aluno.Estado = Console.ReadLine();

            Console.Write("Nota 1: ");
            aluno.Nota1 = double.Parse(Console.ReadLine());

            Console.Write("Nota 2: ");
            aluno.Nota2 = double.Parse(Console.ReadLine());

            var retorno = alunoRepositorio.InserirAluno(aluno);

            Console.WriteLine(retorno);
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void BuscarAluno()
    {
        try
        {
            Console.Write("Informe o nome do aluno que deseja buscar: ");
            string nomeBusca = Console.ReadLine();

            var alunos = alunoRepositorio.BuscarAlunos();

            // Filtrar alunos pelo nome (busca parcial)
            var alunosFiltrados = alunos.Where(a => a.Nome.Contains(nomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

            if (alunosFiltrados.Count == 0)
            {
                Console.WriteLine("Nenhum aluno encontrado com esse nome.");
            }
            else
            {
                foreach (var aluno in alunosFiltrados)
                {
                    Console.WriteLine($"\nDados de {aluno.Nome}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                    Console.WriteLine($"CPF: {aluno.Cpf}");
                    Console.WriteLine($"Endereço: {aluno.Endereco}");
                    Console.WriteLine($"CEP: {aluno.Cep}");
                    Console.WriteLine($"Número: {aluno.Numero}");
                    Console.WriteLine($"Bairro: {aluno.Bairro}");
                    Console.WriteLine($"Cidade: {aluno.Cidade}");
                    Console.WriteLine($"Estado: {aluno.Estado}");
                    Console.WriteLine($"Nota 1: {aluno.Nota1}");
                    Console.WriteLine($"Nota 2: {aluno.Nota2}");
                    Console.WriteLine($"Data de Nascimento: {aluno.DataNascimento:dd/MM/yyyy}");
                    Console.WriteLine("------------------------");
                }
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar: {ex.Message}");
            Console.ReadKey();
        }
    }
}