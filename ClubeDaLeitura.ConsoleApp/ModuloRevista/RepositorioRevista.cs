namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class RepositorioRevista
{
    private readonly Revista[] registros = new Revista[100];

    public void Cadastrar(Revista novaRevista)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaRevista;
                break;
            }
        }
    }

    public bool Editar(int idSelecionado, Revista revistaAtualizada)
    {
        Revista? revistaSelecionada = null;

        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = registros[i];

            if (r == null)
                continue;

            if (r.Id == idSelecionado)
            {
                revistaSelecionada = r;
                break;
            }
        }

        if (revistaSelecionada == null)
            return false;

        revistaSelecionada.Atualizar(revistaAtualizada);

        return true;
    }

    public bool Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = registros[i];

            if (r == null)
                continue;

            if (r.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public Revista[] SelecionarTodos()
    {
        return registros;
    }
}
