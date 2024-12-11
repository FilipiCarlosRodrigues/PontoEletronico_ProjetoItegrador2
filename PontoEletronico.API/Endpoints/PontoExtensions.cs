using Microsoft.AspNetCore.Mvc;
using PontoEletronico.API.Response;
using PontoEletronico.Dados.Banco;
using PontoEletronico.Modelos.Modelos;

namespace PontoEletronico.API.Endpoints;

public static class PontoExtensions
{
    public static void AddEndPointsPonto(this WebApplication app)
    {
        app.MapGroup("/Ponto")
        .WithTags("Ponto");

        app.MapGet("/Ponto", ([FromServices] DAL<Ponto> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Ponto/{id}", ([FromServices] DAL<Ponto> dal, int id) =>
        {
            var ponto = dal.RecuperarPor(a => a.Id == id);
            if (ponto is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(ponto);
        });

        app.MapPost("/Ponto", ([FromServices] DAL<Ponto> dal, [FromBody] Ponto ponto) =>
        {
            dal.Adicionar(ponto);
            return Results.Ok();
        });

        app.MapDelete("/Ponto/{id}", ([FromServices] DAL<Ponto> dal, int id) =>
        {
            var ponto = dal.RecuperarPor(a => a.Id == id);
            if (ponto is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(ponto);
            return Results.NoContent();
        });

        app.MapPut("/Ponto", ([FromServices] DAL<Ponto> dal, [FromBody] Ponto ponto) =>
        {
            var atualizarPonto = dal.RecuperarPor(a => a.Id == ponto.Id);
            if (atualizarPonto is null)
            {
                return Results.NotFound();
            }

            atualizarPonto.Comentario = ponto.Comentario;
            atualizarPonto.DataHora = ponto.DataHora;
            atualizarPonto.TipoPonto = ponto.TipoPonto;
            
            dal.Atualizar(atualizarPonto);
            return Results.Ok();

        });
    }

    private static ICollection<PontoResponse> EntityListToResponseList(IEnumerable<Ponto> listaDePontos)
    {
        return listaDePontos.Select(a => EntityToResponse(a)).ToList();
    }

    private static PontoResponse EntityToResponse(Ponto ponto)
    {
        return new PontoResponse(ponto.Id, ponto.Passado, ponto.Anexo, ponto.Localizacao, ponto.DataHora, ponto.TipoPonto, ponto.UsuarioId, ponto.Usuario.Nome, ponto.Comentario);
    }
}
