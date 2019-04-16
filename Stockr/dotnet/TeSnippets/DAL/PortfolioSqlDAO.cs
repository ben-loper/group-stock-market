using StockrWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.DAL
{
    public class PortfolioSqlDAO : IPortfolioDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for snippet objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public PortfolioSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// I will find a snippet by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Portfolio FindById(int id, int userid)
        {

            Portfolio portfolio = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Portfolio WHERE Id = @id AND UserId = @userid;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@userid", userid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        portfolio = MapRowToPortfolio(reader);
                    }
                }

                return portfolio;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// I will return a list of snippets for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Portfolio> GetPortfolio(int userId)
        {

            List<Portfolio> stock = new List<Portfolio>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Portfolio WHERE UserId = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        stock.Add(new Portfolio
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Symbol = Convert.ToString(reader["Symbol"]),
                            NumberOfShares = Convert.ToInt32(reader["NumberOfShares"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                        });

                    }
                }

                return stock;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// I will save a new snippet.
        /// </summary>
        /// <param name="snippet"></param>
        /// <returns></returns>
        public Portfolio CreatePortfolio(Portfolio portfolio)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Portfolio VALUES (@symbol, @numberOfShares, @userId);", conn);
                    cmd.Parameters.AddWithValue("@symbol", portfolio.Symbol);
                    cmd.Parameters.AddWithValue("@numberOfShares", portfolio.NumberOfShares);
                    cmd.Parameters.AddWithValue("@userId", portfolio.UserId);
                    cmd.ExecuteNonQuery();

                    return portfolio;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// I will update an exsiting snippet
        /// </summary>
        /// <param name="snippet"></param>
        public Portfolio UpdatePortfolio(Portfolio portfolio)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Portfolio SET Symbol = @symbol, NumberOfShares = @numberOfShares, WHERE Id = @id AND UserId = @userid;", conn);
                    cmd.Parameters.AddWithValue("id", portfolio.Id);
                    cmd.Parameters.AddWithValue("@symbol", portfolio.Symbol);
                    cmd.Parameters.AddWithValue("@numberOfShares", portfolio.NumberOfShares);
                    cmd.Parameters.AddWithValue("@userId", portfolio.UserId);

                    cmd.ExecuteNonQuery();

                    return portfolio;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// I will delete a snippet by it's id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id, int userid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Portfolio WHERE Id = @id AND UserId = @userid;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private Portfolio MapRowToPortfolio(SqlDataReader reader)
        {
            return new Portfolio()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Symbol = Convert.ToString(reader["Symbol"]),
                NumberOfShares = Convert.ToInt32(reader["NumberOfShares"]),
                UserId = Convert.ToInt32(reader["UserId"]),
            };
        }

        public List<Company> GetCompanyNames()
        {

            List<Company> company = new List<Company>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Company", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        company.Add(new Company
                        {
                            Name = Convert.ToString(reader["Name"]),
                            Symbol = Convert.ToString(reader["Symbol"]),
                            Sector = Convert.ToString(reader["Sector"]),
                        });
                    }
                }
                return company;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
