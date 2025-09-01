using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Models/OrderDTO.cs
namespace CustomerAPI.Models
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CompanyName { get; set; }
        public string ShipCountry { get; set; }
    }
}
