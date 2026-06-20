namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    private object[] registros = new object[100];

    public void Cadastrar(object novaRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaRegistro;
                break;
            }
        }
    }
}
