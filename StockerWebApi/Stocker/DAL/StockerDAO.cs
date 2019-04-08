using System;
using System.Collections.Generic;
using System.Text;
using Stocker.Models;
using System.Data.SqlClient;
using VendingService.Models;

namespace Stocker.DAL
{
    public class StockerDAO : IStockerDAO
    {
        private string _connectionString;
        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";

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

                SqlCommand cmd = new SqlCommand("SELECT Symbol, NumberOfShares FROM Portfolio WHERE UserId = id ORDER BY Symbol;", conn);

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

        public bool AddTransaction(int userId, string symbol, int numberOfShares, decimal price, string buyOrSell)
        {
            bool result = false;
            int id = 0;
            DateTime now = DateTime.Now;

            // define my sql statement
            string SqlAddTransaction = $"Insert Into Transactions (Symbol, NumberOfShares, Price, Date, BuyOrSell, UserId) " +
                                       $"Values (@Symbol, @NumberOfShares, @Price, @Date, @BuyOrSell, @UserId);" +
                                       _getLastIdSQL;

            // create my connection object
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // open connection
                conn.Open();

                // create my command object
                SqlCommand cmd = new SqlCommand(SqlAddTransaction, conn);
                cmd.Parameters.AddWithValue("@Symbol", symbol);
                cmd.Parameters.AddWithValue("@NumberOfShares", numberOfShares);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Date", now);
                cmd.Parameters.AddWithValue("@BuyOrSell", buyOrSell);
                cmd.Parameters.AddWithValue("@UserId", userId);

                // execute command
                id = (int)cmd.ExecuteScalar();

                if(id != 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public int AddUserItem(UserItem item)
        {
            const string sql = "INSERT [User] (FirstName, LastName, Username, Hash, Salt) " +
                               "VALUES (@FirstName, @LastName, @Username, @Hash, @Salt);";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@FirstName", item.FirstName);
                cmd.Parameters.AddWithValue("@LastName", item.LastName);
                cmd.Parameters.AddWithValue("@Username", item.Username);
                cmd.Parameters.AddWithValue("@Hash", item.Hash);
                cmd.Parameters.AddWithValue("@Salt", item.Salt);
                item.Id = (int)cmd.ExecuteScalar();
            }

            return item.Id;
        }

        public UserItem GetUserItem(int userId)
        {
            UserItem user = null;
            const string sql = "SELECT * From [User] WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = GetUserItemFromReader(reader);
                }
            }

            if (user == null)
            {
                throw new Exception("User does not exist.");
            }

            return user;
        }

        private UserItem GetUserItemFromReader(SqlDataReader reader)
        {
            UserItem item = new UserItem();

            item.Id = Convert.ToInt32(reader["Id"]);
            item.FirstName = Convert.ToString(reader["FirstName"]);
            item.LastName = Convert.ToString(reader["LastName"]);
            item.Username = Convert.ToString(reader["Username"]);
            item.Salt = Convert.ToString(reader["Salt"]);
            item.Hash = Convert.ToString(reader["Hash"]);

            return item;
        }






    }
    
}
