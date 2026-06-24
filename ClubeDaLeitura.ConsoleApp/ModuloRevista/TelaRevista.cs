using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista : TelaBase
{
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioCaixa repositorioCaixa;

    public TelaRevista(
        string nomeEntidade,
        RepositorioRevista repositorioRevista,
        RepositorioCaixa repositorioCaixa) : base(nomeEntidade, repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }
    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Revista");
        Console.WriteLine("---------------------------------");

        // 1. Visualizar revistas cadastradas e obter o ID que deseja editar
        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        // 2. Obter os novos dados da revista
        Revista revistaAtualizada = (Revista)ObterDadosCadastrais();

        // 3. Editar a revista no repositório
        repositorioRevista.Editar(idSelecionado, revistaAtualizada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{revistaAtualizada.Titulo}\" foi editado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Revista");
        Console.WriteLine("---------------------------------");

        // 1. Visualizar revistas cadastradas e obter o ID que deseja excluir
        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        // 2. Excluir a revista no repositório
        repositorioRevista.Excluir(idSelecionado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro de ID \"{idSelecionado}\" foi excluído com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Revistas");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
            "Id", "Título", "Edição", "Ano", "Caixa"
        );

        EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
                r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta
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
        Console.Write("Informe o título da revista: ");
        string? titulo = Console.ReadLine();

        Console.Write("Informe o número da edição: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Informe o ano de publicação: ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        EntidadeBase[] registros = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = (Caixa)registros[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );
        }

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixa? caixaSelecionada = (Caixa?)repositorioCaixa.SelecionarPorId(idSelecionado);

        return new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);
    }
}
