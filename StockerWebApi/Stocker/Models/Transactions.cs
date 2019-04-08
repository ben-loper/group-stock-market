using System;
using System.Collections.Generic;
using System.Text;

namespace Stocker.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public int NumberOfShares { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string BuySell { get; set; }
        public int UserId { get; set; }
    }
}
