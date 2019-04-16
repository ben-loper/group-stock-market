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
        public bool BuyStocks(Transaction transaction)
        {
            bool result = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Portfolio VALUES (@symbol, @numberOfShares, @userId);", conn);
                    cmd.Parameters.AddWithValue("@symbol", transaction.Symbol);                    
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


            return results;
        }
    }
}
