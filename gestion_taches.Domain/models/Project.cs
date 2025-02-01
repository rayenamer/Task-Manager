using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_taches.Domain.models
{
    public class Project
    {
        public Guid IdProject { get; set; }
        public string? Nomp { get; set; }
        public String? Description { get; set; }
        public int Priorité { get; set; }
        public float BudgetAllouee { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateTime DateFin {  get; set; }
        public ICollection<Ressources>? Ressources { get; set; }
      
        public DateTime DateFinPrevue { get; set; }
        

    }
}
