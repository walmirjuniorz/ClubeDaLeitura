using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

/*
    Regras de Negócio:
        ● Campos obrigatórios:
            ○ Título (2-100 caracteres)
            ○ Número da edição (número positivo)
            ○ Ano de publicação (ano válido)
            ○ Caixa (seleção obrigatória)
*/
public class Revista
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public int NumeroEdicao { get; private set; }
    public int AnoPublicacao { get; private set; }
    public Caixa Caixa { get; private set; }

    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {
        Id = GeradorIds.ObterIdRevista();

        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    public void Atualizar(Revista revistaAtualizada)
    {
        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }
}
