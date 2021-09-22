using System;
using System.Collections.Generic;

#nullable disable

namespace Gufi.webAPI.Domains
{
    public partial class ImagemPerfil
    {
        public int IdImagemPerfil { get; set; }
        public int IdUsario { get; set; }
        public byte[] Binario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataUpload { get; set; }

        public virtual Usuario IdUsarioNavigation { get; set; }
    }
}
