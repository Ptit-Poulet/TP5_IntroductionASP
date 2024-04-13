using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.DataAccessLayer.Factories
{
    public class ReservationsFactory
    {
        private Reservations CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string nom = mySqlDataReader["Nom"].ToString();
            string courriel = mySqlDataReader["Courriel"].ToString();
            int nbPersonne = (int)mySqlDataReader["NbPersonne"];
            DateTime dateReservation = (DateTime)mySqlDataReader["DateReservation"];
            int menuchoiceId = (int)mySqlDataReader["MenuChoiceId"];

            return new Reservations(id, nom, courriel, nbPersonne, dateReservation, menuchoiceId);
        }

        public Reservations CreateEmpty()
        {
            return new Reservations(0, string.Empty, string.Empty, 0, DateTime.Now , 0);
        }

        /// <summary>
        /// Retourne la liste de toutes les réservations
        /// </summary>
        /// <returns></returns>
        public List<Reservations> GetAll()
        {
            List<Reservations> reservations = new List<Reservations>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Reservations reservation = CreateFromReader(mySqlDataReader);
                    reservations.Add(reservation);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservations;
        }

        /// <summary>
        /// Retourne une réservation selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reservations Get(int id)
        {
            Reservations reservation = new Reservations();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations " +
                    "WHERE Id = @Id ORDER BY DateReservation DESC";

                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                     reservation = CreateFromReader(mySqlDataReader);
                    
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservation;
        }

        /// <summary>
        /// Ajout d'une réservation avec ses informations
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="courriel"></param>
        /// <param name="nbPersonne"></param>
        /// <param name="dateReservation"></param>
        /// <param name="menuchoiceId"></param>
        public void Add(string nom, string courriel, int nbPersonne, DateTime dateReservation, int menuchoiceId)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO tp5_reservations (Nom, Courriel, NbPersonne, DateReservation, MenuChoiceId) " +
                    "VALUES (@Nom, @Courriel, @NbPersonne, @DateReservation, @MenuChoiceId) ";

                mySqlCmd.Parameters.AddWithValue("@Nom", nom);
                mySqlCmd.Parameters.AddWithValue("@Courriel", courriel);
                mySqlCmd.Parameters.AddWithValue("@NbPersonne", nbPersonne);
                mySqlCmd.Parameters.AddWithValue("@DateReservation", dateReservation);
                mySqlCmd.Parameters.AddWithValue("@MenuChoiceId", menuchoiceId);

                mySqlCmd.ExecuteNonQuery();


            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }

        /// <summary>
        /// Supprimer une réservation selon son id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM tp5_reservations " +
                    "WHERE Id = @Id";

                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlCmd.ExecuteNonQuery();


            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }
    }
}
