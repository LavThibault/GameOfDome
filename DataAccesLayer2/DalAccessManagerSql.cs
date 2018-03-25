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
                characters.Add(new Character(row.Field<int>(0), row.Field<String>(3), row.Field<String>(4), row.Field<int>(1)));
               
            }

            return characters;
        }

        public List<House> ReturnHouses()
        {
            DataTable results = new DataTable();
            List<House> houses = new List<House>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM House;", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            foreach (DataRow row in results.Rows)
            {
                houses.Add(new House(row.Field<int>(0), row.Field<String>(1), row.Field<int>(2), row.Field<int>(3)));
            }

            return houses;
        }

        public int NewCharacterId()
        {
            DataTable results = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT MAX(Id) FROM Character;", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            return results.Rows[0].Field<int>(0)+1;
        }

        public int NewHouseId()
        {
            DataTable results = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT MAX(Id) FROM House;", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            return results.Rows[0].Field<int>(0) + 1;
        }

        public House ReturnHouse(int id)
        {
            DataTable results = new DataTable();
            House house;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM House WHERE Id = " + id, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }


            DataRow row = results.Rows[0];
            house = new House(row.Field<int>(0), row.Field<String>(1), row.Field<int>(2), row.Field<int>(3));

            return house;
        }

        public List<Territory> ReturnTerritories()
        {
            throw new NotImplementedException();
        }

        public Character ReturnCharacter(int id)
        {
            DataTable results = new DataTable();
            Character character;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Character WHERE Id = "+id, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

            
            DataRow row = results.Rows[0];
            character = new Character(row.Field<int>(0),row.Field<String>(3), row.Field<String>(4),row.Field<int>(1) );

            return character;
        }

        public Boolean UpdateCharacter(int id, Character character)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Character SET Bravoury = " + character.Bravoury + ", Crazyness = " + character.Crazyness + ", FirstName = '" + character.FirstName + "', LastName = '" + character.LastName + "', Classe = '" + character.Classe + "', Pv = " + character.Pv + " WHERE Id = " + id + ";", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }

        public bool UpdateHouse(int id, House house)
        {
            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE House SET Name = '" + house.Name + "', NumberOfUnities = " + house.NumberOfUnities + ", Gold = " + house.Gold + " WHERE Id = " + id + ";", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }

        public bool AddCharacter(Character character)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Character (Id, Bravoury, Crazyness, FirstName, LastName, Classe, Pv) VALUES ( " + NewCharacterId() + ", " + character.Bravoury + ", " + character.Crazyness + ", '" + character.FirstName + "', '" + character.LastName + "', '" + character.Classe + "', " + character.Pv + ");", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }

        public bool DeleteCharacter(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Character WHERE Id = " + id + ";", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }

        public List<Character> returnCharactersFromHouse(int houseId)
        {
            DataTable results = new DataTable();
            List<Character> characters = new List<Character>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Character FROM CharacterFromHouse WHERE HOUSE="+houseId+";", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }

          foreach (DataRow row in results.Rows)
            {
                characters.Add(ReturnCharacter(row.Field<int>(0)));
            }

            return characters;
        }

        public bool AddHouse(House house)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO House (Id, Name, NumberOfUnities, Gold) VALUES ( " + NewHouseId() + ", '" + house.Name + "', " + house.NumberOfUnities + ", " + house.Gold + ");", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }

        public bool DeleteHouse(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM House WHERE Id = " + id + ";", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }

        public List<House> ReturnWinningHouse(int id)
        {
            DataTable results = new DataTable();
            List<House> houses = new List<House>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT House1 FROM Fight WHERE Id = " + id, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);

                DataRow row1 = results.Rows[0];
                houses.Add(new House(row1.Field<int>(0), row1.Field<String>(1), row1.Field<int>(2), row1.Field<int>(3)));

                SqlCommand sqlCommand2 = new SqlCommand("SELECT House2 FROM Fight WHERE Id = " + id, sqlConnection);
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
                sqlDataAdapter2.Fill(results);

                DataRow row2 = results.Rows[0];
                houses.Add(new House(row2.Field<int>(0), row2.Field<String>(1), row2.Field<int>(2), row2.Field<int>(3)));
            }

            return houses;
        }
    }
}
