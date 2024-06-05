using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialEspecializada.Domain.Entities
{
    public class GrupoUsuario
    {
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
