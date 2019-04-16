using StockrWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.DAL
{
    public interface ITransactionDAO
    {
        bool BuyStocks(Transaction transaction);

        List<Portfolio> GetPortfolio(int userId);
    }
}
