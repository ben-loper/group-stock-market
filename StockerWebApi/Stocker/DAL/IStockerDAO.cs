using Stocker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stocker.DAL
{
    public interface IStockerDAO
    {
        IList<Portfolio> GetPortfolio();
    }
}
