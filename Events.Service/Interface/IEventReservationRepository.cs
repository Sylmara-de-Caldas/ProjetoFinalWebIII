using Events.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service.Interface
{
    public interface IEventReservationRepository
    {
        bool IncluirReserva(EventReservationEntity eventReservationEntity);
        bool AtualizarQuantidadeReserva(long idReservation, int quantity);
        bool RemoverReserva(long idReservation);
        List<EventReservationEntity> ConsultarReserva(string personName, string title);
    }
}
