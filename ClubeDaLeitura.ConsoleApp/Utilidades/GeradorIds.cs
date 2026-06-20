namespace ClubeDaLeitura.ConsoleApp.Utilidades;

public static class GeradorIds
{
    private static int contadorIdsCaixa = 1;
    private static int contadorIdsRevista = 1;

    public static int ObterIdCaixa()
    {
        return contadorIdsCaixa++;
    }

    public static int ObterIdRevista()
    {
        return contadorIdsRevista++;
    }
}
