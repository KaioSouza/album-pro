using System;
using System.Collections.Generic;

namespace AlbumAPI.Models
{
  public class Album
  {
        public int TotalJaAdicionados { get; set; }
        public string ID { get; set; }
    public string Nome { get; set; }
    public string CriadoEm { get; set; }
    public List<Foto> Fotos { get; set; }
  }
}
