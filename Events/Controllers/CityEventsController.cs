using Events.Service.Entity;
using Events.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Events.Controllers
{
    [ApiController]
    [Route("controller")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventsController : ControllerBase
    {
        private ICityEventsService _cityEventsService { get; set; }
        public CityEventsController(ICityEventsService cityEventsService)
        {
            _cityEventsService = cityEventsService;
        }


        [HttpGet("Titulo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityEventsEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(string title)
        {
            List<CityEventsEntity> cityEvents = _cityEventsService.ConsultarEvento(title);

            if (cityEvents.LongCount() == 0)
            {
                return BadRequest();
            }

            return Ok(cityEvents);
        }

        [HttpGet("Local")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityEventsEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorLocal(string local, DateTime data)
        {
            List<CityEventsEntity> cityEvents = _cityEventsService.ConsultarEventoLocal(local, data);

            if (cityEvents.LongCount() == 0)
            {
                return BadRequest();
            }

            return Ok(cityEvents);
        }

        [HttpGet("Preco")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityEventsEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorPreco(decimal price1, decimal price2, DateTime data)
        {
            List<CityEventsEntity> cityEvents = _cityEventsService.ConsultarEventoPreco(price1, price2, data);

            if (cityEvents.LongCount() == 0)
            {
                return BadRequest();
            }

            return Ok(cityEvents);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CityEventsEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarEvento(CityEventsEntity cityevententity)
        {
            if (!(_cityEventsService.IncluirEvento(cityevententity)))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Consultar), cityevententity);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityEventsEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarEvento(CityEventsEntity cityEventEntity, int id)
        {
            if (!(_cityEventsService.AlterarEvento(cityEventEntity, id)))
            {
                return BadRequest();
            }

            return Ok(cityEventEntity);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirEvento(long idEvent)
        {
            if (!(_cityEventsService.RemoverEvento(idEvent)))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }

}
