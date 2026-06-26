using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo
{
    private readonly RepositorioEmprestimo repositorioEmprestimo;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
    }
    public string? ObterOpcaoMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Empréstimos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Abrir Empréstimo");
        Console.WriteLine("2 - Concluir Empréstimo");
        Console.WriteLine("3 - Visualizar Empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }
    public void Abrir()
    {
        throw new NotImplementedException();
    }
    public void Concluir()
    {
        throw new NotImplementedException();
    }
    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Empréstimos");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -15} | {4, - 15}",
            "Id", "Revista", "Amigo", "Abertura", "Conclusao Prev."
            );

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -15} | {4, - 15}",
                e.Id, e.Revista.Titulo, e.Amigo.Nome,
                e.DataAbertura.ToShortDateString(), e.DataConclusaoPrevista.ToShortDateString()
                );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
}
