using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : ITelaOpcoes
{
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioRevista repositorioRevista;

    public TelaEmprestimo(
        RepositorioEmprestimo repositorioEmprestimo,
        RepositorioAmigo repositorioAmigo,
        RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
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
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Abertura de Empréstimos");
        Console.WriteLine("---------------------------------");

        VisualizarRevistas();

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o ID da revista que deseja emprestar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        VisualizarAmigos();

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o ID do amigo que ira receber a revista: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());

        Revista? revistadaSelecionada = (Revista?)repositorioRevista.SelecionarPorId(idRevista);
        Amigo? amigoSelecionado = (Amigo?)repositorioAmigo.SelecionarPorId(idAmigo);

        if (revistadaSelecionada == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"A revista \"{idRevista}\" nao foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }
        if (!revistadaSelecionada.EstaDisponivel)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"A revista \"{revistadaSelecionada.Titulo}\" está indisponível!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }
        if (amigoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O amigo \"{idAmigo}\" nao foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            if (e.Amigo.Id == amigoSelecionado.Id && e.EstaAberto)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O amigo \"{amigoSelecionado.Nome}\" já tem um empréstimo aberto!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();
                return;
            }
        }

        Emprestimo novoEmprestimo = new Emprestimo(revistadaSelecionada, amigoSelecionado);

        novoEmprestimo.Abrir();
        revistadaSelecionada.Emprestar();

        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O Empréstimo \"{novoEmprestimo.Id}\" foi aberto com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public void Concluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Conclusao de Empréstimos");
        Console.WriteLine("---------------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o ID do empréstimo que deseja concluir: ");
        int idEmprestimo = Convert.ToInt32(Console.ReadLine());

        Emprestimo? emprestimo = (Emprestimo?)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

        if (emprestimo == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O Empréstimo \"{idEmprestimo}\" nao foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }

        if (!emprestimo.EstaAberto)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O Empréstimo \"{idEmprestimo}\" já está concluido!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }

        emprestimo.Concluir();

        repositorioEmprestimo.Editar(idEmprestimo, emprestimo);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O Empréstimo \"{emprestimo.Id}\" foi aberto com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
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
            "{0, -5} | {1, -15} | {2, -15} | {3, -12} | {4, -15} | {5, -13}",
            "Id", "Revista", "Amigo", "Abertura", "Conclusao Prev.", "Status"
            );

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -12} | {4, -15} | {5, -13}",
                e.Id,
                e.Revista.Titulo,
                e.Amigo.Nome,
                e.DataAbertura.ToShortDateString(),
                e.DataConclusaoPrevista.ToShortDateString(),
                e.Status.ToString()
                );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
    public void VisualizarRevistas()
    {
        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15} | {5, -12}",
            "Id", "Título", "Edição", "Ano", "Caixa", "Status"
        );

        EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15} | {5, -12}",
                r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status.ToString()
            );
        }
    }
    public void VisualizarAmigos()
    {
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
    }
}
