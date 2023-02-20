using Events.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Interface
{
    public interface ICityEventsService
    {
        bool IncluirEvento(CityEventsEntity cityEventsEntity);
        bool AlterarEvento(CityEventsEntity cityEventsEntity, int idEvent);
        bool RemoverEvento(long id);
        List<CityEventsEntity> ConsultarEvento(string title);
        List<CityEventsEntity> ConsultarEventoLocal(string local, DateTime data);
        List<CityEventsEntity> ConsultarEventoPreco(decimal price, decimal price2, DateTime data);

    }
}
