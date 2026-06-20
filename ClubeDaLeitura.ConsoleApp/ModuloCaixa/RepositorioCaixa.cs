namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class RepositorioCaixa
{
    private Caixa[] registros = new Caixa[100];

    public void Cadastrar(Caixa novaCaixa)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaCaixa;
                break;
            }
        }
    }

    public bool Editar(int idSelecionado, Caixa caixaAtualizada)
    {
        Caixa? caixaSelecionada = null;

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                caixaSelecionada = c;
                break;
            }
        }

        if (caixaSelecionada == null)
            return false;

        caixaSelecionada.Atualizar(caixaAtualizada);

        return true;
    }

    public bool Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public Caixa[] SelecionarTodos()
    {
        return registros;
    }

    public Caixa? SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
                return c;
        }

        return null;
    }
}
