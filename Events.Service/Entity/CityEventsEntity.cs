using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Entity
{
    public class CityEventsEntity
    {
        public long IdEvent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Título do evento obrigatório")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Título do evento obrigatório")]
        public DateTime DateHourEvent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Local do evento obrigatório")]
        public string Local { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Status do evento obrigatório")]
        public string Status { get; set; }

    }
}
