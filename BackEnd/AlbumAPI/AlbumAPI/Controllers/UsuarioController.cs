using System;
using System.Collections.Generic;
using AlbumAPI.Helpers;
using AlbumAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlbumAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsuarioController : ControllerBase
  {
    JsonHelper jsonHelper;

    private List<Usuario> Usuarios { get; set; }
    public UsuarioController()
    {
      jsonHelper = new JsonHelper();
    }

    [HttpPost]
    public Usuario Login(Usuario usuario)
    {

      var listaUsuarios = jsonHelper.ReadUsersJsonFile("srcUsuarios.json");

      var user = listaUsuarios.Find(x => x.UserName == usuario.UserName);

      if (user != null) if (user.Senha == usuario.Senha) return user;

      return null;
    }

    [Route("cadastrar")]
    [HttpPost]
    public Usuario Cadastrar([FromBody] Usuario usuario)
    {
      try
      {
        var listaUsuarios = jsonHelper.ReadUsersJsonFile("srcUsuarios.json");

        var guid = Guid.NewGuid().ToString();

        var user = new Usuario()
        {
          ID = guid,
          Nome = usuario.Nome,
          Email = usuario.Email,
          Perfil = usuario.Perfil,
          Senha = usuario.Senha,
          UserName = usuario.UserName
        };

        listaUsuarios.Add(user);

        jsonHelper.WriteUsersJsonFile(listaUsuarios, "srcUsuarios.json");

        return user;
      }
      catch (System.Exception ex)
      {
        return null;
        throw;
      }
    }






    public string Get() { return "API no AR"; }
    }
}
