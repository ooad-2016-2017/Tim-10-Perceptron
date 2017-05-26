using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class QRScanner : User
    {
        [Required]
        Promotion CurrentPromotion { get; set; }

        [Required]
        Owner Owner { get; set; }

    }
}
