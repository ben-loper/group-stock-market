using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.Models
{
    public class PastTransaction
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public int NumOfShares { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
    }
}
