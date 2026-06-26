using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Utilidades;
namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
/*
    ● Campos obrigatórios:
        ○ Amigo
        ○ Revista (disponível no momento)
        ○ Data empréstimo (automática)
        ○ Data devolução (calculada conforme caixa)
        ○ Status possíveis: Aberto / Concluído / Atrasado
*/
public class Emprestimo : EntidadeBase
{
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime DataAbertura { get; private set; }
    public DateTime DataConclusaoPrevista
    {
        get
        {
            int diasdeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

            // data de abertura + dias da caixa
            DateTime DataConclusaoPrevista = DataAbertura.AddDays(diasdeEmprestimo);

            return DataConclusaoPrevista;
        }
    }
    public Emprestimo(Revista revista, Amigo amigo)
    {
        Id = GeradorIds.ObterIdsEmprestimo();
        DataAbertura = DateTime.Now;

        Revista = revista;
        Amigo = amigo;
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
