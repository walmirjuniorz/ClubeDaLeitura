using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    public TelaPrincipal()
    {
        repositorioCaixa = new RepositorioCaixa();
        repositorioRevista = new RepositorioRevista();
        repositorioAmigo = new RepositorioAmigo();
        repositorioEmprestimo = new RepositorioEmprestimo();

        Caixa caixaTeste = new Caixa("Ação", "Vermelho", 5);
        Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);
        Amigo amigoTeste = new Amigo("Junior Testes", "Seu Oswaldo", "49988776655");
        Emprestimo emprestimoTeste = new Emprestimo(revistaTeste, amigoTeste);
        emprestimoTeste.Abrir();

        repositorioCaixa.Cadastrar(caixaTeste);
        repositorioRevista.Cadastrar(revistaTeste);
        repositorioAmigo.Cadastrar(amigoTeste);
        repositorioEmprestimo.Cadastrar(emprestimoTeste);
    }

    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar caixas de revistas");
        Console.WriteLine("2 - Gerenciar revistas");
        Console.WriteLine("3 - Gerenciar amigos");
        Console.WriteLine("4 - Gerenciar empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCaixa("Caixa", repositorioCaixa, repositorioRevista);

        if (opcaoMenuPrincipal == "2")
            return new TelaRevista("Revista", repositorioRevista, repositorioCaixa);

        if (opcaoMenuPrincipal == "3")
            return new TelaAmigo("Amigo", repositorioAmigo, repositorioEmprestimo);

        if (opcaoMenuPrincipal == "4")
            return new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        return null;
    }
}
