using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Model
{
    public class Customer
    {
        public int id { get; set; }
        public int addressId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
