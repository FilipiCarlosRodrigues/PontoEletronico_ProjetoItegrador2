using Microsoft.AspNetCore.Mvc;
using PontoEletronico.API.Endpoints;
using PontoEletronico.Dados.Banco;
using PontoEletronico.Modelos.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PontoEletronicoContext>();

builder.Services.AddTransient<DAL<Usuario>>();
builder.Services.AddTransient<DAL<Ponto>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.AddEndpointsUsuarios();
app.AddEndPointsPonto();
app.UseSwagger();
app.UseSwaggerUI(); 
     
app.Run();
