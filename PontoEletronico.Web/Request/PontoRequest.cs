using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.Web.Request;

public record PontoRequest([Required] DateTime Date, [Required] string localizacao, string comentario, bool passado, [Required] int UsuarioIF, string anexo);

