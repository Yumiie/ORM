using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProjet
{
    public class Salade
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nom de la salade")]
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column(TypeName ="nvarchar(max)")]
        public string Description { get; set; }


        public virtual Fabricant Fabricant { get; set; }
        public virtual ICollection<Magasin> Magasins { get; set; }




    }
}
