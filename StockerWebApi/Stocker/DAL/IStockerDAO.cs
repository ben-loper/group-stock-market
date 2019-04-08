using Stocker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stocker.DAL
{
    public interface IStockerDAO
    {
        IList<Portfolio> GetPortfolio(int id);

        bool AddTransaction(int userId, string symbol, int numberOfShares, decimal price, string buyOrSell);
    }
}
