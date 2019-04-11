using StockrWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.DAL
{
    public interface IPortfolioDAO
    {
        Portfolio FindById(int id, int userid);

        List<Portfolio> GetPortfolio(int userId);

        Portfolio CreatePortfolio(Portfolio portfolio);

        Portfolio UpdatePortfolio(Portfolio portfolio);

        void Delete(int id, int userid);
    }
}
