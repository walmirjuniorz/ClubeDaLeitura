using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Utilidades;
namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public enum StatusEmprestimo
{
    Indefinido,
    Aberto,
    Concluído,
    Atrasado
}
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
    public StatusEmprestimo Status { get; set; }
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
    public bool EstaAberto
    {
        get
        {
            return Status == StatusEmprestimo.Aberto;

        }
    }
    public Emprestimo(Revista revista, Amigo amigo)
    {
        Id = GeradorIds.ObterIdsEmprestimo();
        DataAbertura = DateTime.Now;

        Revista = revista;
        Amigo = amigo;
    }
    public void Abrir()
    {
        Status = StatusEmprestimo.Aberto;
        Revista.Emprestar();
    }
    public void Concluir()
    {
        Status = StatusEmprestimo.Concluído;
        Revista.Devolver();
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)entidadeAtualizada;

        Status = emprestimoAtualizado.Status;
    }
}
