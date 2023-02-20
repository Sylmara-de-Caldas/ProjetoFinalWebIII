using Events.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Interface
{
    public interface ICityEventsRepository
    {
        bool IncluirEvento(CityEventsEntity cityEventEntity);
        bool AlterarEvento(CityEventsEntity cityEventEntity, int idEvent);
        List<CityEventsEntity> ConsultarEvento(string title);
        List<CityEventsEntity> ConsultarEventoLocal(string local, DateTime data);
        List<CityEventsEntity> ConsultarEventoPreco(decimal price1, decimal price2, DateTime data);
        bool RemoverEvento(long id);


    }
}

