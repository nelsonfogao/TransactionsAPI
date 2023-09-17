using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public double AvailableLimit { get; set; }
        public bool ActiveCard { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
