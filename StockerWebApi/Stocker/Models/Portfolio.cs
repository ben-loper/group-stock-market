using System;
using System.Collections.Generic;
using System.Text;

namespace Stocker.Models
{
    public class Portfolio
    {
        public string Symbol { get; set; }
        public int NumberOfShares { get; set; }
        public int UserId { get; set; }
    }
}
