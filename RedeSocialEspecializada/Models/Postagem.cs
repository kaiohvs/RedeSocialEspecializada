using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialEspecializada.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string? Imagem { get; set; }
        public string? Video { get; set; }
        // Outros campos como imagens, vídeos, etc.
        public int UsuarioId { get; set; }
        public Usuario ?Usuario { get; set; }
        public int? GrupoId { get; set; }
        public Grupo ?Grupo { get; set; }
    }
}
