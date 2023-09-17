using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Seller
    {
        public Guid SellerId { get; set; }
        public Guid Name { get; set; }
        public Guid Address { get; set; }
    }
}
