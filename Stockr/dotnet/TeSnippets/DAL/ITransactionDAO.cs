using StockrWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.DAL
{
    public interface ITransactionDAO
    {
        bool ExecuteTransaction(Transaction transaction);

        List<Portfolio> GetPortfolio(int userId);
    }
}
