namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    public string? ObterOpcaoMenuPrincipal()
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

        return opcaoMenuPrincipal;
    }
}
