using StockrWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.DAL
{
    public class TransactionDAO : ITransactionDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for snippet objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public TransactionDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        

        /// <summary>
        /// I will save a new snippet.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool ExecuteTransaction(Transaction transaction)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Transactions(Symbol, NumberOfShares, Price, Date, UserId) VALUES (@symbol, @numberOfShares, @price, @date, @userId);", conn);
                    cmd.Parameters.AddWithValue("@symbol", transaction.Symbol);
                    cmd.Parameters.AddWithValue("@numberOfShares", transaction.NumOfShares);
                    cmd.Parameters.AddWithValue("@price", transaction.Price);
                    cmd.Parameters.AddWithValue("@date", transaction.Date);
                    cmd.Parameters.AddWithValue("@userId", transaction.UserId);
                    cmd.ExecuteNonQuery();

                   
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Portfolio> GetPortfolio(int userId)
        {
            List<Portfolio> results = new List<Portfolio>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT symbol, SUM(NumberOfShares) AS totalNumberOfShares FROM Transactions WHERE UserId = @userId GROUP BY Symbol HAVING SUM(NumberOfShares) > 0", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Portfolio
                        {
                            Symbol = Convert.ToString(reader["Symbol"]),
                            NumberOfShares = Convert.ToInt32(reader["totalNumberOfShares"]),
                        });

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return results;
        }

        List<PastTransaction> GetPastTransactions(int userId)
        {
            List<PastTransaction> results = new List<PastTransaction>();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Transactions WHERE UserId = @userId ORDER BY Date DESC", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new PastTransaction
                        {
                            ID = Convert.ToInt32(reader["Id"]),
                            Symbol = Convert.ToString(reader["Symbol"]),
                            NumOfShares = Convert.ToInt32(reader["NumberOfShares"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            UserId = Convert.ToInt32(reader["UserId"])
                        });

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return results;
        }
    }
}
