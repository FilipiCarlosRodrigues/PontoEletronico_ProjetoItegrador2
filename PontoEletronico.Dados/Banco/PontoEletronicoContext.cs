using Microsoft.EntityFrameworkCore;
using PontoEletronico.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Dados.Banco; 

public class PontoEletronicoContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Ponto> Pontos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PontoEletronico;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public PontoEletronicoContext(DbContextOptions options) : base(options) //contrutor para receber algumas opções de configurações 
    {

    }
    public PontoEletronicoContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();

    }
}
