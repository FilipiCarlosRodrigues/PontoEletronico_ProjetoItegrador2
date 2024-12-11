
using PontoEletronico.Modelos.Enums;

namespace PontoEletronico.Modelos.Modelos; 

public class Ponto
{
    public Ponto()
    {

    }

    public Ponto(int id, bool passado, DateTime dataHora, string localizacao, Usuario usuario, int usuarioId, TipoPonto tipoPonto)
    {
        Id = id;
        Passado = passado;
        DataHora = dataHora;
        Localizacao = localizacao;
        Usuario = usuario;
        UsuarioId = usuarioId;
        TipoPonto = tipoPonto;
    }

    public int Id { get; set; }
    public string? Comentario { get; set; } = string.Empty;
    public string? Anexo { get; set; }
    public bool Passado { get; set; }
    public DateTime DataHora { get; set; }
    public string Localizacao { get; set; }
    public virtual Usuario Usuario { get; set; }

    public int UsuarioId { get; set; }

    public TipoPonto TipoPonto { get; set; }

}
