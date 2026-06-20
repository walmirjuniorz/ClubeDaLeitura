using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

/*
    ● Campos obrigatórios:
        ○ Etiqueta (texto único, máximo 50 caracteres)
        ○ Cor (seleção de paleta ou hexadecimal)
        ○ Dias de empréstimo (número, padrão 7)

    ● Não pode haver etiquetas duplicadas
    ● Não permitir excluir uma caixa caso tenha revistas vinculadas
    ● Cada caixa define o prazo máximo para empréstimo de suas revistas
*/
public class Caixa
{
    public int Id { get; private set; }
    public string Etiqueta { get; private set; }
    public string Cor { get; private set; }
    public int DiasDeEmprestimo { get; private set; }

    // Construtor de Classe
    // Toda instância que for criada PRECISA conter essas informações
    public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
    {
        Id = GeradorIds.ObterIdCaixa();

        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }

    public void Atualizar(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }
}
