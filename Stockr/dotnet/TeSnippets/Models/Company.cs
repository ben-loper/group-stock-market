using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockrWebApi.Models
{
    public class Company
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
    }
}
