using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.Web.Request;

public record UsuarioRequest([Required] string nome, [Required] string email, [Required] string login, [Required] string senha);

