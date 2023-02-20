using Events.Service.Entity;
using Events.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Service
{
    public class CityEventsService : ICityEventsService
    {
        private ICityEventsRepository _cityEventRepository { get; set; }
        public CityEventsService(ICityEventsRepository cityEventRepository)
        {
            _cityEventRepository = cityEventRepository;
        }
        public bool IncluirEvento(CityEventsEntity cityEventsEntity)
        {
            return _cityEventRepository.IncluirEvento(cityEventsEntity);
        }

        public bool AlterarEvento(CityEventsEntity cityEventsEntity, int idEvent)
        {
            return _cityEventRepository.AlterarEvento(cityEventsEntity, idEvent);
        }

        public List<CityEventsEntity> ConsultarEvento(string title)
        {
            return _cityEventRepository.ConsultarEvento(title);
        }

        public List<CityEventsEntity> ConsultarEventoLocal(string local, DateTime data)
        {
            return _cityEventRepository.ConsultarEventoLocal(local, data);
        }

        public List<CityEventsEntity> ConsultarEventoPreco(decimal price1, decimal price2, DateTime data)
        {
            return _cityEventRepository.ConsultarEventoPreco(price1, price2, data);
        }

        public bool RemoverEvento(long idEvent)
        {
            return _cityEventRepository.RemoverEvento(idEvent);
        }
    }
}
