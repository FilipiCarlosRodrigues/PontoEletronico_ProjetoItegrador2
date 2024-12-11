using PontoEletronico.Modelos.Enums;

namespace PontoEletronico.Web.Response;

public record PontoResponse(int id, bool passado, string anexo, string localizacao, DateTime datahora, TipoPonto tipoPonto, int UsuarioId, string NomeUsuario, string comentario);

