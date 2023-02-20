using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Entity
{
    public class EventReservationEntity
    {
        [Required]
        public long IdReservation { get; set; }
        
        [Required]
        public long IdEvent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do comprador obrigatório")]
        public string PersonName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Quantidade obrigatória")]
        public long Quantity { get; set; }

    }
}
