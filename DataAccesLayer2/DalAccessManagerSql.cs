using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalAccessManagerSql : IDal
    {
        private static String _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\User\\Document\\Cours\\ZZ2\\C#\\ThronesTournamentConsole\\GameOfDomes.mdf;Integrated Security=True;Connect Timeout=30";

        public List<Character> ReturnCharacters()
        {
            DataTable results = new DataTable();
            List<Character> characters = new List<Character>();

            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Character;", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            foreach (DataRow row in results.Rows)
            {
                characters.Add(new Character(row.Field<String>(3), row.Field<String>(4), row.Field<int>(1)));
            }

            return characters;
        }

        public List<House> ReturnHouses()
        {
            throw new NotImplementedException();
        }

        public List<House> ReturnHouseWithMoreThanx(int x)
        {
            throw new NotImplementedException();
        }

        public List<Territory> ReturnTerritories()
        {
            throw new NotImplementedException();
        }

        public Character ReturnCharacter(String firstName)
        {
            DataTable results = new DataTable();
            Character character;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Character WHERE FirstName = '"+firstName+"';", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            
            DataRow row = results.Rows[0];
            character = new Character(row.Field<String>(3), row.Field<String>(4),row.Field<int>(1) );

            return character;
        }

        public Boolean UpdateCharacter(int id, Character character)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Character SET Bravoury = '" + character.Bravoury + "', Crazyness = '" + character.Crazyness + "', FirstName = '" + character.FirstName + "', LastName = '" + character.LastName + "', Classe = '" + character.Classe + "', Pv = '" + character.Pv + "';", sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
