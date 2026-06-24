namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    private EntidadeBase[] registros = new EntidadeBase[100];

    public void Cadastrar(EntidadeBase novaRegistro)
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
    public bool Editar(int idSelecionado, EntidadeBase entidadeAtualizada)
    {
        EntidadeBase? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.Atualizar(entidadeAtualizada);

        return true;
    }
    public bool Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase obj = registros[i];

            if (obj == null)
                continue;

            if (obj.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }
    public EntidadeBase? SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase obj = registros[i];

            if (obj == null)
                continue;

            if (obj.Id == idSelecionado)
                return obj;
        }

        return null;
    }
    public EntidadeBase[] SelecionarTodos()
    {
        return registros;
    }
}
