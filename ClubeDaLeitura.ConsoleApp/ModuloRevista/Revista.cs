using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public enum StatusRevista
{
    Disponivel,
    Emprestada,
    Reservada
}
/*
    Regras de Negócio:
        ● Campos obrigatórios:
            ○ Título (2-100 caracteres)
            ○ Número da edição (número positivo)
            ○ Ano de publicação (ano válido)
            ○ Caixa (seleção obrigatória)

        ● O sistema deve armazenar e mostrar o status atual das revistas cadastradas
            (disponível/emprestada/reservada)
*/
public class Revista : EntidadeBase
{
    public string Titulo { get; private set; }
    public int NumeroEdicao { get; private set; }
    public int AnoPublicacao { get; private set; }
    public StatusRevista Status { get; private set; }
    public Caixa Caixa { get; private set; }

    public bool EstaDisponivel
    {
        get
        {
            return Status == StatusRevista.Disponivel;
        }
    }
    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {
        Id = GeradorIds.ObterIdRevista();

        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;

        Status = StatusRevista.Disponivel;
    }
    public void Emprestar()
    {
        Status = StatusRevista.Emprestada;
    }
    public void Devolver()
    {
        Status = StatusRevista.Disponivel;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Revista revistaAtualizada = (Revista)entidadeAtualizada;

        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }
}
