using Events.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [ApiController]
    [Route("controller")]
    [Consumes("application/json")] 
    [Produces("application/json")]
    public class EventReservationsController: ControllerBase
    {
        public List<Eventos> eventos = new List<Eventos>();

        private IEventReservationService _eventReservationService;
        public EventReservationsController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }
       
        [HttpGet]
        public ActionResult<>
    }

   
}
