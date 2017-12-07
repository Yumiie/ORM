using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryProjet
{
    public  class Fabricant
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nom du Fabricant")]
        [Required]
        [StringLength(30)]
        public string Nom { get; set; }


        public virtual ICollection<Salade> Salades { get; set; }

    }
}
