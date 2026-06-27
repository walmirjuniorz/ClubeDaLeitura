using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Utilidades;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;
/*
    ● Campos obrigatórios:
        ○ Nome (mínimo 3 caracteres, máximo 100)
        ○ Nome do responsável (mínimo 3 caracteres, máximo 100)
        ○ Telefone (formato validado: 10-11 dígitos)
    ● Não pode haver amigos com o mesmo nome e telefone
*/
public class Amigo : EntidadeBase
{
    public string Nome { get; private set; }
    public string NomeResposavel { get; private set; }
    public string Telefone { get; private set; }
    public Amigo(string nome, string nomeResposavel, string telefone)
    {
        Id = GeradorIds.ObterIdAmigo();

        Nome = nome;
        NomeResposavel = nomeResposavel;
        Telefone = telefone;
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;

        Nome = amigoAtualizado.Nome;
        NomeResposavel = amigoAtualizado.NomeResposavel;
        Telefone = amigoAtualizado.Telefone;
    }
}


