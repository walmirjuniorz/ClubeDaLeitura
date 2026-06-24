using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa : TelaBase
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;

    public TelaCaixa(
        string nomeEntidade,
        RepositorioCaixa repositorioCaixa,
        RepositorioRevista repositorioRevista) : base(nomeEntidade, repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
    }
    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Caixa");
        Console.WriteLine("---------------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Caixa caixaAtualizada = (Caixa)ObterDadosCadastrais();

        EntidadeBase[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = (Caixa)caixas[i];

            if (c == null)
                continue;

            if (c.Id != idSelecionado && c.Etiqueta.ToLower() == caixaAtualizada.Etiqueta.ToLower())
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe uma caixa com a etiqueta \"{caixaAtualizada.Etiqueta}\"!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();

                return;
            }
        }

        repositorioCaixa.Editar(idSelecionado, caixaAtualizada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{caixaAtualizada.Etiqueta}\" foi editado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    // Não permitir excluir uma caixa caso tenha revistas vinculadas
    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Caixa");
        Console.WriteLine("---------------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            if (r.Caixa.Id == idSelecionado)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Não é possível excluir uma caixa com revistas vinculadas!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();

                return;
            }
        }

        repositorioCaixa.Excluir(idSelecionado);

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
            Console.WriteLine("Visualização de Caixas");
            Console.WriteLine("---------------------------------");
        }

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

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Informe a etiqueta da caixa: ");
        string? etiqueta = Console.ReadLine();

        Console.Write("Informe a cor da caixa: ");
        string? cor = Console.ReadLine();

        Console.Write("Informe o tempo de empréstimo das revistas da caixa: ");
        int diasDeEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        return novaCaixa;
    }
}
