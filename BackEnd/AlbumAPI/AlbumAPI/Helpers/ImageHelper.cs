using AlbumAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Helpers
{
  public class ImageHelper
  {
    JsonHelper jsonHelper;

    public ImageHelper()
    {
      jsonHelper = new JsonHelper();
    }
    public List<Foto>GetImagesFromAlbum(string idAlbum)
    {
      try
      {

        var albuns = jsonHelper.ReadAlbunsJsonFile("srcAlbuns.json");
        byte[] imageBytes = System.IO.File.ReadAllBytes(@"~\AlbumAPI\Fotos\js-logo.png");
        string base64String = Convert.ToBase64String(imageBytes);

        return null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
      return null;
    }

        public string GetBase64FromImage(string fileName, string filePath)
        {
            byte[] b = System.IO.File.ReadAllBytes($"{filePath}\\{fileName}");
            return "data:image/png;base64," + Convert.ToBase64String(b);
        }

    public void ExcluirFotoDaPasta(string filePath)
    {
      if (string.IsNullOrEmpty(filePath)) return;

      try
      {
        if (File.Exists(filePath))
        {
          File.Delete(filePath);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    

        public async Task<bool> SaveImageOnPaste(IFormFile file, string fileName, string filePath)
        {
            try
            {
                using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

  }
}
