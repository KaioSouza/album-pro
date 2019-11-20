using System;
using System.Collections.Generic;
using System.IO;
using AlbumAPI.Models;
using Nancy.Json;
using Newtonsoft.Json;

namespace AlbumAPI.Helpers
{
  public class JsonHelper
  {
    public List<Album> ReadAlbunsJsonFile(string fileName)
    {
      List<Album> lista = new List<Album>();
      try
      {
        string filePath = System.IO.Path.GetFullPath(fileName);
        using (StreamReader sr = new StreamReader(filePath))
        {
          string jsonString = sr.ReadToEnd();
          JavaScriptSerializer serializer = new JavaScriptSerializer();
          lista = serializer.Deserialize<List<Album>>(jsonString);
        }
        if (lista == null)
        {
          return new List<Album>();
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
      return lista;
    }

    public List<Usuario> ReadUsersJsonFile(string fileName)
    {
      List<Usuario> lista = new List<Usuario>();
      try
      {
        string filePath = System.IO.Path.GetFullPath(fileName);
        using (StreamReader sr = new StreamReader(filePath))
        {
          string jsonString = sr.ReadToEnd();
          JavaScriptSerializer serializer = new JavaScriptSerializer();
          lista = serializer.Deserialize<List<Usuario>>(jsonString);
        }
        if (lista == null)
        {
          return new List<Usuario>();
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
      return lista;
    }

    public bool WriteUsersJsonFile(List<Usuario> lista, string fileName)
    {
      try
      {
        using (StreamWriter file = System.IO.File.CreateText(fileName))
        {
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(file, lista);
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
    public bool WriteAlbunsJsonFile(List<Album> lista, string fileName)
    {
      try
      {
        using (StreamWriter file = System.IO.File.CreateText(fileName))
        {
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(file, lista);
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
  }
}
