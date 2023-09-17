using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public double AvailableLimit { get; set; }
        public bool ActiveCard { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
