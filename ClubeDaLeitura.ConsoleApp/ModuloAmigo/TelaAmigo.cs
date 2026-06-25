using ClubeDaLeitura.ConsoleApp.Compartilhado;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase
{
    private readonly RepositorioAmigo repositorioAmigo;

    public TelaAmigo(string nomeEntidade,
    RepositorioAmigo repositorioAmigo) : base(nomeEntidade, repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
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
