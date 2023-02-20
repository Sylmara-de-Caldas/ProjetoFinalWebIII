using Dapper;
using Events.Service.Entity;
using Events.Service.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private string _stringConnection { get; set; }
        public EventReservationRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        public bool IncluirReserva(EventReservationEntity eventReservationEntity)
        {
            string query = "INSERT INTO EventReservation (idEvent, personName, quantity)" +
                            "VALUES (@idEvent, @personName, @quantity)";

            DynamicParameters parameters = new(eventReservationEntity);


            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;

        }

        public bool AtualizarQuantidadeReserva(long idReservation, int quantity)
        {
            string query = "UPDATE EventReservation SET quantity = @quantity WHERE idReservation = @idReservation";

            DynamicParameters param = new();
            param.Add("quantity", quantity);
            param.Add("idReservation", idReservation);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, param);

            return linhasAfetadas > 0;
        }

        public bool RemoverReserva(long idReservation)
        {
            string query = "DELETE FROM EventReservation WHERE idReservation = @idReservation";

            DynamicParameters param = new();
            param.Add("idReservation", idReservation);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, param);

            return linhasAfetadas > 0;
        }

        public List<EventReservationEntity> ConsultarReserva(string personName, string title)
        {
            string query = "SELECT EventReservation.idEvent, EventReservation.personName, EventReservation.quantity " +
                           "FROM EventReservation INNER JOIN CityEvent ON EventReservation.idEvent = CityEvent.idEvent " +
                           "WHERE EventReservation.personName = @personName AND CityEvent.title LIKE @title";

            DynamicParameters param = new();
            param.Add("personName", personName);
            param.Add("title", "%" + title + "%");

            using MySqlConnection conn = new(_stringConnection);

            return (conn.Query<EventReservationEntity>(query, param)).ToList();
        }
    }
}
