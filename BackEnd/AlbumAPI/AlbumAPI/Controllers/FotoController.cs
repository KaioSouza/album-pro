using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlbumAPI.Helpers;
using AlbumAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlbumAPI.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class FotoController : ControllerBase
    {
        private readonly JsonHelper jsonHelper;
        ImageHelper imageHelper;
        public FotoController()
        {
            jsonHelper = new JsonHelper();
            imageHelper = new ImageHelper();
        }

    [Route("Post/{id}")]
    public async Task<Album> Post([FromRoute]string id)
        {
            try
            {

                var files = Request.Form.Files;

                var listaAlbuns = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");


                var album = listaAlbuns.Find(x => x.ID == id);

                var totalJaAdicionados = 0;

                if (album.Fotos == null)
                {
                    album.Fotos = new List<Foto>();
                }

                if (album.Fotos.Count == 0)
                {
                    totalJaAdicionados = 0;
                }
                else
                {
                    totalJaAdicionados = album.Fotos.Last().TotalJaAdicionados;
                }


                listaAlbuns.RemoveAll(x => x.ID.Equals(id));

                string pathToSave = System.IO.Path.GetFullPath("Fotos");

                foreach (var file in files)
                {

                    string fileName = Guid.NewGuid().ToString() + file.FileName;

                    bool result = await imageHelper.SaveImageOnPaste(file, fileName, pathToSave);

                    string base64 = imageHelper.GetBase64FromImage(fileName, pathToSave);

                    album.Fotos.Add(new Foto()
                    {
                        AlbumID = id,
                        Path = pathToSave,
                        ID = Guid.NewGuid().ToString(),
                        CriadoEm = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt"),
                        Nome = file.FileName,
                        FileName = fileName,
                        Base64String = base64,
                        TotalJaAdicionados = totalJaAdicionados + 1
                    });

                    totalJaAdicionados++;
                }

                listaAlbuns.Add(album);

                jsonHelper.WriteAlbunsJsonFile(listaAlbuns, "srcAlbuns.json");


                return listaAlbuns.Find(x => x.ID.Equals(id));
            }


            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

    public async Task<bool> Put([FromBody] Foto foto)
    {
      try
      {
        
        var listaAlbuns = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");

        var album = listaAlbuns.Find(x => x.ID.Equals(foto.AlbumID));

        var fotoAtual = album.Fotos.Find(x => x.ID == foto.ID);

        fotoAtual.Nome = foto.Nome;

        album.Fotos.RemoveAll(x => x.ID == foto.ID);

        album.Fotos.Add(fotoAtual);

        listaAlbuns.RemoveAll(x => x.ID == foto.AlbumID);

        listaAlbuns.Add(album);

        jsonHelper.WriteAlbunsJsonFile(listaAlbuns, "srcAlbuns.json");

        return true;
      }
      catch (Exception)
      {
        return false;
        throw;
      }
    }

    [Route("delete")]
    public bool Delete([FromBody] Foto foto)
    {
      try
      {
        var listaAlbuns = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");

        var album = listaAlbuns.Find(x => x.ID == foto.AlbumID);

        album.Fotos.RemoveAll(x => x.ID == foto.ID);

        listaAlbuns.RemoveAll(x => x.ID == foto.AlbumID);

        listaAlbuns.Add(album);

        imageHelper.ExcluirFotoDaPasta(foto.Path);

        return jsonHelper.WriteAlbunsJsonFile(listaAlbuns, "srcAlbuns.json");
      }
      catch (Exception)
      {
        return false;
        throw;
      }
    }
  }


}
