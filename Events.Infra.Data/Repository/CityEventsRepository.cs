using Dapper;
using Events.Service.Entity;
using Events.Service.Interface;
using MySqlConnector;

namespace Events.Infra.Data.Repository
{
    public class CityEventsRepository: ICityEventsRepository
    {
        private string _stringConnection { get; set; }
        public CityEventsRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        public bool IncluirEvento(CityEventsEntity cityEventEntity)
        {
            string query = "INSERT INTO CityEvent (title, description, dateHourEvent, local, address, price, status)" +
                           "VALUES (@title, @description, @dateHourEvent, @local, @address, @price, @status)";

            DynamicParameters param = new(cityEventEntity);

            using MySqlConnection conn = new(_stringConnection);

            int? linhasAfetadas = conn.Execute(query, param);

            return linhasAfetadas > 0;
        }

        public bool AlterarEvento(CityEventsEntity cityEventEntity, int idEvent)
        {
            string query = "UPDATE CityEvent SET title = @title, description = @description, dateHourEvent = @dateHourEvent," +
                            "local = @local, address = @address, price = @price, status = @status where idEvent = @idEvent";

            DynamicParameters param = new();
            param.Add("@title", cityEventEntity.Title);
            param.Add("@description", cityEventEntity.Description);
            param.Add("@dateHourEvent", cityEventEntity.DateHourEvent);
            param.Add("@local", cityEventEntity.Local);
            param.Add("@address", cityEventEntity.Address);
            param.Add("@price", cityEventEntity.Price);
            param.Add("@status", cityEventEntity.Status);
            param.Add("@idEvent", idEvent);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, param);

            return linhasAfetadas > 0;
        }

        public List<CityEventsEntity> ConsultarEvento(string title)
        {
            string query = "SELECT * FROM CityEvent WHERE title LIKE @title";

            DynamicParameters param = new();
            param.Add("title", "%" + title + "%");

            using MySqlConnection conn = new(_stringConnection);

            return (conn.Query<CityEventsEntity>(query, param)).ToList();
        }

        public List<CityEventsEntity> ConsultarEventoLocal(string local, DateTime data)
        {
            string query = "SELECT * FROM CityEvent WHERE CAST(dateHourEvent AS date) = @dateEvent AND local LIKE @local";

            DynamicParameters param = new();
            param.Add("local", "%" + local + "%");
            param.Add("dateEvent", data.Date);

            using MySqlConnection conn = new(_stringConnection);

            return (conn.Query<CityEventsEntity>(query, param)).ToList();
        }

        public List<CityEventsEntity> ConsultarEventoPreco(decimal price1, decimal price2, DateTime data)
        {
            string query = "SELECT * FROM CityEvent WHERE price BETWEEN @price1 AND @price2 AND CAST(dateHourEvent AS date) = @dateEvent";

            if (price2 < price1)
            {
                decimal x;
                x = price1;
                price1 = price2;
                price2 = x;
            }

            DynamicParameters param = new();
            param.Add("price1", price1);
            param.Add("price2", price2);
            param.Add("dateEvent", data.Date);

            using MySqlConnection conn = new(_stringConnection);

            return (conn.Query<CityEventsEntity>(query, param)).ToList();
        }
        public bool RemoverEvento(long idEvent)
        {
            string query = "DELETE FROM CityEvent WHERE idEvent = @idEvent";

            DynamicParameters param = new();
            param.Add("idEvent", idEvent);

            EventReservationRepository eventReservation = new();

            int linhasAfetadas;

            using MySqlConnection conn = new(_stringConnection);
            linhasAfetadas = conn.Execute(query, param);

            return linhasAfetadas > 0;
        }
    }
}