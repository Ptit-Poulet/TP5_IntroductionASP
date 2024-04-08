using MySql.Data.MySqlClient;
using System.ComponentModel;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.DataAccessLayer.Factories
{
    public class MenuchoicesFactory
    {
        private Menuchoices CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string description = mySqlDataReader["Description"].ToString() ?? string.Empty;
  
            return new Menuchoices(id, description);
        }

        public Menuchoices CreateEmpty()
        {
            return new Menuchoices(0, string.Empty);
        }

        /// <summary>
        /// Retourne la liste complète des choix du menu
        /// </summary>
        /// <returns></returns>
        public List<Menuchoices> GetAll()
        {
            List<Menuchoices> menuchoices = new List<Menuchoices>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Menuchoices choice = CreateFromReader(mySqlDataReader);
                    menuchoices.Add(choice);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return menuchoices;
        }

        /// <summary>
        /// Retourne un choix du menu selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menuchoices Get(int id)
        {
            Menuchoices choice = new Menuchoices();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices WHERE Id = @Id";

                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    choice = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return choice;
        }

        /// <summary>
        /// Ajoute un choix dans le menu avec sa description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public void Add(string description)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO tp5_menuchoices (Description) " +
                    "VALUES (@Description) ";

                mySqlCmd.Parameters.AddWithValue("@Description", description);

                mySqlDataReader = mySqlCmd.ExecuteReader();
               
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

        }

        /// <summary>
        /// Supprime un choix du menu selon son id
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
                mySqlCmd.CommandText = "DELETE FROM tp5_menuchoices " +
                    "WHERE Id = @Id";

                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();

            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }

        /// <summary>
        /// Modifie la description d'un choix selon son id
        /// </summary>
        /// <param name="id"></param>
        public void Modify(int id, string description)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "UPDATE tp5_menuchoices " +
                    "SET Description = @Description" +
                    "WHERE Id = @Id";

                mySqlCmd.Parameters.AddWithValue("@Description", description);
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();

            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }
    }
}
