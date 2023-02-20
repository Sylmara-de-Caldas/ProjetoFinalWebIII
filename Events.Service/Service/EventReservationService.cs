using Events.Service.Entity;
using Events.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Service
{
    public class EventReservationService : IEventReservationService
    {
        private IEventReservationRepository _eventReservationRepository { get; set; }
        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }
        public bool AtualizarQuantidadeReserva(long idReservation, int quantity)
        {
            return _eventReservationRepository.AtualizarQuantidadeReserva(idReservation, quantity);
        }

        public List<EventReservationEntity> ConsultarReserva(string personName, string title)
        {
            return _eventReservationRepository.ConsultarReserva(personName, title);
        }

        public bool IncluirReserva(EventReservationEntity eventReservationRepository)
        {
            return _eventReservationRepository.IncluirReserva(eventReservationRepository);
        }

        public bool RemoverReserva(long idReservation)
        {
            return _eventReservationRepository.RemoverReserva(idReservation);
        }
    }
}
