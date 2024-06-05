using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialEspecializada.Domain.Entities
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Desc { get; set; }
        public string Categoria { get; set; }
        // Outros campos como descrição, categoria, etc.
        public List<Postagem> Postagens { get; set; }
        public List<GrupoUsuario> Membros { get; set; }
    }
}
