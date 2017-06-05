using InteraktivnaMapaEvenata.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Validation
{
    public class EntityValidationException : Exception
    {
        EntityValidationErrorDTO EntityValidationErrorDTO { get; set; }

        public EntityValidationException(EntityValidationErrorDTO errorDTO)
        {
            EntityValidationErrorDTO = errorDTO;
        }
    }
}
