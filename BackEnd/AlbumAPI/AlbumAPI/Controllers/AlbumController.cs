using AlbumAPI.Helpers;
using AlbumAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbumAPI.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("[controller]")]
  [Produces("application/json")]
  public class AlbumController : ControllerBase
    {
        private readonly JsonHelper jsonHelper;
    private readonly ImageHelper imageHelper;
    public AlbumController()
        {
            jsonHelper = new JsonHelper();
      imageHelper = new ImageHelper();
        }

    [Route("GetAlbuns")]
    [HttpGet]
    public List<Album> GetAlbuns()
    {
      try
      {
        return jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
      return null;
    }

    [Route("GetAlbum/{id}")]
    [HttpGet]
    public Album GetAlbum(string id)
    {
        try
        {
            return jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json").Find(x => x.ID.Equals(id));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
      return null;
    }

    [Route("Post")]
    [HttpPost]
    public Album Post([FromBody]Album album)
    {

      try
      {
        var lista = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");

                var totalJaAdicionados = 0;

                if (lista.Count == 0)
                {
                    totalJaAdicionados = 0;
                }
                else
                {
                    totalJaAdicionados = lista.Last().TotalJaAdicionados;
                }

                var albumCriado = new Album()
                {
                    Nome = album.Nome,
                    ID = Guid.NewGuid().ToString(),
                    CriadoEm = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt"),
                    Fotos = null,
                    TotalJaAdicionados = totalJaAdicionados + 1
                };

        lista.Add(albumCriado);

        jsonHelper.WriteAlbunsJsonFile(lista, "srcAlbuns.json");

        return albumCriado;
      }
      catch (Exception)
      {
        return null;
        throw;
      }
      
    }

    [Route("Delete/{id}")]
    [HttpDelete]
    public bool Delete(string id)
    {
      var lista = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");

      var album = lista.Find(x => x.ID == id);

      if (album != null && album.Fotos != null)
      {

        album.Fotos.ForEach(e =>
        {
          imageHelper.ExcluirFotoDaPasta(e.Path);
        });
      }

      lista.RemoveAll(x => x.ID.Equals(id));

      return jsonHelper.WriteAlbunsJsonFile(lista, "srcAlbuns.json");
    }

    [HttpPut]
    public bool Edit(Album album)
    {

      try
      {
        var lista = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");

        var novoAlbum = lista.Find(x => x.ID.Equals(album.ID));


        if (novoAlbum != null)
        {
          novoAlbum.Nome = album.Nome;

          lista.RemoveAll(x => x.ID.Equals(album.ID));

          lista.Add(novoAlbum);

          return jsonHelper.WriteAlbunsJsonFile(lista, "srcAlbuns.json");
        }
        return false;
      }
      catch (Exception)
      {
        throw;
      }
   

      
    }
  }
}
