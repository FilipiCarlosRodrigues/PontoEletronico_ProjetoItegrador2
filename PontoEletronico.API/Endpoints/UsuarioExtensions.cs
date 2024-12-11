using Microsoft.AspNetCore.Mvc;
using PontoEletronico.API.Request;
using PontoEletronico.API.Response;
using PontoEletronico.Dados.Banco;
using PontoEletronico.Modelos.Modelos;

namespace PontoEletronico.API.Endpoints;

public static class UsuarioExtensions
{
    public static void AddEndpointsUsuarios(this WebApplication app)
    {
        var usuarios = app.MapGroup("/usuarios")
        .WithTags("API de Usuários");

        usuarios.MapGet("/Usuarios", ([FromServices] DAL<Usuario> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        usuarios.MapGet("/Usuarios/{nome}", ([FromServices] DAL<Usuario> dal, string nome) =>
        {
            var usuario = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (usuario is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(usuario);
        });

        usuarios.MapPost("/Usuarios", ([FromServices] DAL<Usuario> dal, [FromBody] UsuarioRequest usuarioRequest) =>
        {
            //dal.Adicionar(usuarioRequest);
            return Results.Ok();
        });

        usuarios.MapDelete("/Usuario/{id}", ([FromServices] DAL<Usuario> dal, int id) =>
        {
            var usuario = dal.RecuperarPor(a => a.Id == id);
            if (usuario is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(usuario);
            return Results.NoContent();
        });

        usuarios.MapPut("/Usuarios", ([FromServices] DAL<Usuario> dal, [FromBody] Usuario usuario) =>
        {
            var atualizarUsuario = dal.RecuperarPor(a => a.Id == usuario.Id);
            if (atualizarUsuario is null)
            {
                return Results.NotFound();
            }

            atualizarUsuario.Nome = usuario.Nome;
            atualizarUsuario.Email = usuario.Email;
            atualizarUsuario.Login = usuario.Login;
            atualizarUsuario.Senha = usuario.Senha;

            dal.Atualizar(atualizarUsuario);
            return Results.Ok();
        });
    }

    private static ICollection<UsuarioResponse> EntityListToResponseList(IEnumerable<Usuario> listaDeUsuarios)
    {
        return listaDeUsuarios.Select(a => EntityToResponse(a)).ToList();
    }

    private static UsuarioResponse EntityToResponse(Usuario usuario)
    {
        return new UsuarioResponse(usuario.Id, usuario.Nome ,usuario.Email, usuario.Login, usuario.Senha);
    }
}
