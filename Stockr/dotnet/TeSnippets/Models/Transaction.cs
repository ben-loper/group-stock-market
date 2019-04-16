using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public int NumOfShares { get; set; }
        public decimal Price { get; set; }
        public DateTime MyProperty
        {
            get
            {
                return DateTime.Now.Date;    
            }
        }
        public int UserId { get; set; }
    }
}
