using System;
using System.Collections.Generic;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalAccessManagerSql : IDal
    {
        private static String _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\User\\Document\\GameOfDomes.mdf;Integrated Security=True;Connect Timeout=30";

        public DataTable ReturnCharacters()
        {
            DataTable results = new DataTable();

            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM cat;", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }
            return results;
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
    }
}
