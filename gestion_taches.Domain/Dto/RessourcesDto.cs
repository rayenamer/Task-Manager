using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_taches.Domain.Dto
{
    public class RessourcesDto
    {
        public Guid IdRessources { get; set; }
        public String? Nom { get; set; }
        public String? Etat { get; set; }
        public Guid IdP { get; set; }
        public string? Nomp { get; set; }
    }
}
