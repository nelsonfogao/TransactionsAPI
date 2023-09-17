using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public Guid SellerId { get; set; }
        public double Value { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
