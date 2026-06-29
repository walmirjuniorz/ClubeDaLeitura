using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase, ITelaOpcoes
{
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioEmprestimo repositorioEmprestimo;

    public TelaAmigo(string nomeEntidade,
    RepositorioAmigo repositorioAmigo,
    RepositorioEmprestimo repositorioEmprestimo) : base(nomeEntidade, repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioEmprestimo = repositorioEmprestimo;
    }
    public override string? ObterOpcaoMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Amigo");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Amigo");
        Console.WriteLine("2 - Editar Amigo");
        Console.WriteLine("3 - Excluir Amigo");
        Console.WriteLine("4 - Visualizar Amigos");
        Console.WriteLine("5 - Visualizar Empréstimos de um Amigo");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void VisualizarEmprestimoAmigos()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Empréstimo de Amigo");
        Console.WriteLine("---------------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do amigo que deseja ver os empréstimos: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Amigo? amigoSelecionado = (Amigo?)repositorioAmigo.SelecionarPorId(idSelecionado);

        if (amigoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O Empréstimo \"{idSelecionado}\" nao foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Emprésimo de \"{amigoSelecionado.Nome}\"");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15}",
            "Id", "Revista", "Abertura", "Conclusao Prev.", "Status"
            );

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            if (e.Amigo.Id != amigoSelecionado.Id)
                continue;

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15}",
                e.Id,
                e.Revista.Titulo,
                e.DataAbertura.ToShortDateString(),
                e.DataConclusaoPrevista.ToShortDateString(),
                e.Status.ToString()
                );
        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Amigos");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
            "Id", "Nome", "Responsavel", "Telefone"
            );

        EntidadeBase[] amigos = repositorioAmigo.SelecionarTodos();

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo a = (Amigo)amigos[i];

            if (a == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
                a.Id, a.Nome, a.NomeResposavel, a.Telefone
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do amigo: ");
        string? nome = Console.ReadLine();

        Console.Write("Informe o nome do responsável do amigo: ");
        string? nomeResposavel = Console.ReadLine();

        Console.Write("Informe o telefone do amigo (ou responsável): ");
        string? telefone = Convert.ToString(Console.ReadLine());

        return new Amigo(nome, nomeResposavel, telefone);
    }
}
