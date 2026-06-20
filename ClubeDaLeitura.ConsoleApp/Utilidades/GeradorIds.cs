namespace ClubeDaLeitura.ConsoleApp.Utilidades;

public static class GeradorIds
{
    private static int contadorIdsCaixa = 1;

    public static int ObterIdCaixa()
    {
        return contadorIdsCaixa++;
    }
}
