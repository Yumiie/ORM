using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCavecEntity.Models
{

    [MetadataType(typeof(ShipperMetaData))]
    public partial class Shipper
    {

    }

    class ShipperMetaData
    {
        [Display(Name = "Société")]
        [Required]
        public string CompanyName { get; set; }

        [Display(Name = "Téléphone")]
        [Required]
        [RegularExpression("^0.*$", ErrorMessage = "Le Numéro doit commencer par un 0")]
        public string Phone { get; set; }

    }
}