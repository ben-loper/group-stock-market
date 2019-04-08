using System;
using System.Collections.Generic;
using System.Text;
using Stocker.Models;
using System.Data.SqlClient;

namespace Stocker.DAL
{
    public class StockerDAO : IStockerDAO
    {
        private string _connectionString;

        public StockerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<Portfolio> GetPortfolio()
        {
            IList<Portfolio> portfolios = new List<Portfolio>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT parkCode, parkName, state, parkDescription FROM park;", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ParkListViewModel park = new ParkListViewModel();
                    park.ParkCode = Convert.ToString(reader["parkCode"]);
                    park.ParkName = Convert.ToString(reader["parkName"]);
                    park.State = Convert.ToString(reader["state"]);
                    park.ParkDescription = Convert.ToString(reader["parkDescription"]);


                    portfolios.Add(park);
                }
            }

            return parks;
        }
    }
    }
}
