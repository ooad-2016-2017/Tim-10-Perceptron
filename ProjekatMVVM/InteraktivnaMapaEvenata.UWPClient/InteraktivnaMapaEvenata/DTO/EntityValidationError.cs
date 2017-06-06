using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.DTO
{
    public class EntityValidationError
    {
        public string MessageBody { get; set; }

        public ModelStateDTO ModelStateDTO { get; set; }
    }
}
