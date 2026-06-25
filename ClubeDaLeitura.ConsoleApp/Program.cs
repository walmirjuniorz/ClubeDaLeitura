using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

RepositorioCaixa repositorio = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

Caixa caixaTeste = new Caixa("Ação", "Vermelho", 5);
Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);
Amigo amigoTeste = new Amigo("Junior Testes", "Seu Oswaldo", "49988776655");

repositorio.Cadastrar(caixaTeste);
repositorioRevista.Cadastrar(revistaTeste);
repositorioAmigo.Cadastrar(amigoTeste);

TelaCaixa telaCaixa = new TelaCaixa("Caixa", repositorio, repositorioRevista);
TelaRevista telaRevista = new TelaRevista("Revista", repositorioRevista, repositorio);
TelaAmigo telaAmigo = new TelaAmigo("Amigo", repositorioAmigo);

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    // Menu Principal da Aplicação
    string? opcaoMenuPrincipal = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
    {
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1") // Caixas
        {
            string? opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaCaixa.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaCaixa.Editar();

            else if (opcaoMenuInterno == "3")
                telaCaixa.Excluir();

            else if (opcaoMenuInterno == "4")
                telaCaixa.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "2") // Revistas
        {
            string? opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaRevista.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaRevista.Editar();

            else if (opcaoMenuInterno == "3")
                telaRevista.Excluir();

            else if (opcaoMenuInterno == "4")
                telaRevista.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "3") // Amigos
        {
            string? opcaoMenuInterno = telaAmigo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaAmigo.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaAmigo.Editar();

            else if (opcaoMenuInterno == "3")
                telaAmigo.Excluir();

            else if (opcaoMenuInterno == "4")
                telaAmigo.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "4") // Empréstimos
        {

        }
    }
}
