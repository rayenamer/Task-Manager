using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_taches.Domain.Dto
{
    public class ProjectRessourcesDto
    {
        public Guid IdProject { get; set; }
        public string? Nomp { get; set; }
        public Guid IdRessources { get; set; }
        public String? Nom { get; set; }
        public String? Etat { get; set; }
        public float? Cout { get; set; }
        public string? unit { get; set; }
    }
}
