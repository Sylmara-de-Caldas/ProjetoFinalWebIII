using Events.Service.Entity;
using Events.Service.Interface;
using Events.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventReservationEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VerificarReserva(string personName, string title)
        {
            List<EventReservationEntity> Reservations = _eventReservationService.ConsultarReserva(personName, title);
            if (Reservations.LongCount() == 0)
            {
                return BadRequest();
            }

            return Ok(Reservations);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EventReservationEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarReserva(EventReservationEntity eventReservationEntity)
        {
            if (!(_eventReservationService.IncluirReserva(eventReservationEntity)))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(VerificarReserva), eventReservationEntity);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarQtdeReserva(long idReservation, int quantity)
        {
            if (!(_eventReservationService.AtualizarQuantidadeReserva(idReservation, quantity)))
            {
                return BadRequest();
            }

            return Ok(quantity);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirReserva(long idReservation)
        {
            if (!(_eventReservationService.RemoverReserva(idReservation)))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }

   
}
