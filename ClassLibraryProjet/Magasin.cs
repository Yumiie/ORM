using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryProjet
{
    public class Magasin
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nom du magasin")]
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }


        public virtual ICollection<Salade> Salades { get; set; }

    }
}
