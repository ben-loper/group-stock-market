using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public int NumberOfShares { get; set; }
        public int UserId { get; set; }
    }
}
