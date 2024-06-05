using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialEspecializada.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Bio { get; set; }
        // Outros campos como senha, bio, etc.
        public List<Postagem> ?Postagens { get; set; }
        public List<GrupoUsuario> ?Grupos { get; set; }

    }
}
