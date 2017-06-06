using InteraktivnaMapaEvenata.DTO;
using System;

namespace InteraktivnaMapaEvenata.Validation
{
    public class EntityValidationException : Exception
    {
        EntityValidationError EntityValidationError { get; set; }

        public EntityValidationException(EntityValidationError modelStateDTO)
        {
            EntityValidationError = modelStateDTO;
        }
    }
}
