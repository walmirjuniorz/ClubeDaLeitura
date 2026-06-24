using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

RepositorioCaixa repositorio = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();

Caixa caixaTeste = new Caixa("Ação", "Vermelho", 5);
Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);

repositorio.Cadastrar(caixaTeste);
repositorioRevista.Cadastrar(revistaTeste);

TelaCaixa telaCaixa = new TelaCaixa("Caixa", repositorio, repositorioRevista);
TelaRevista telaRevista = new TelaRevista("Revista", repositorioRevista, repositorio);

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

        }

        else if (opcaoMenuPrincipal == "4") // Empréstimos
        {

        }
    }
}
