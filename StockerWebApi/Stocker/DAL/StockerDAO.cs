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

        public IList<Portfolio> GetPortfolio(int id)
        {
            IList<Portfolio> portfolio = new List<Portfolio>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Symbol, NumberOfShares FROM Portfolio WHERE UserId = id;", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Portfolio stock = new Portfolio();
                    stock.Symbol = Convert.ToString(reader["Symbol"]);
                    stock.NumberOfShares = Convert.ToInt32(reader["NumberOfShares"]);

                    portfolio.Add(stock);
                }
            }

            return portfolio;
        }
    }
    }
}
