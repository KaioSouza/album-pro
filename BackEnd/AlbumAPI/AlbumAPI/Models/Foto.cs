using System;

namespace AlbumAPI.Models
{
  public class Foto
  {
        public int TotalJaAdicionados { get; set; }
        public string ID { get; set; }
    public string AlbumID { get; set; }
    public string Nome { get; set; }
    public string CriadoEm { get; set; }
    public string Path { get; set; }
    public string Base64String { get; set; }
    public string FileName { get; set; }
  }
}
