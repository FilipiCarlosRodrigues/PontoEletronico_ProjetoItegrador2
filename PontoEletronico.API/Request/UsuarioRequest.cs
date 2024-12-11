using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.API.Request; 

public record UsuarioRequest([Required] string nome, [Required] string email, [Required] string login, [Required] string senha);

