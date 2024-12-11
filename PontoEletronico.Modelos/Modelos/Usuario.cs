using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Modelos.Modelos; 

public class Usuario
{
    public Usuario()
    {
    }

    public Usuario(int id, string nome, string email, string senha, string login)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        Login = login;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Login { get; set; }

}

