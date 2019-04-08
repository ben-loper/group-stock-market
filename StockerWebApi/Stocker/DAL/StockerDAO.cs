using System;
using System.Collections.Generic;
using System.Text;

namespace Stocker.DAL
{
    public class StockerDAO : IStockerDAO
    {
        private string _connectionString;

        public StockerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }


    }
}
