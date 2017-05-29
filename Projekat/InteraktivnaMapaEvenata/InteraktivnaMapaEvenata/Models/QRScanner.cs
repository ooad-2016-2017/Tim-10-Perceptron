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
        Promotion CurrentPromotion { get; set; }
        Owner Owner { get; set; }
    }
}
