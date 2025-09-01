using System.Linq;
using System.Web.Http;
using CustomerAPI.Models; 

namespace CustomerAPI.Controllers
{
    public class CustomerOrderController : ApiController
    {
        private Northwind1Entities3 db = new Northwind1Entities3();

        // 1. Get all orders for EmployeeID = 5 (Steven Buchanan)
        [HttpGet]
        [Route("api/orders/employee/5")]
        public IHttpActionResult GetOrdersForStevenBuchanan()
        {
            var orders = db.Orders
                .Where(o => o.EmployeeID == 5)
                .Select(o => new OrderDTO
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    CompanyName = o.Customer.CompanyName,
                    ShipCountry = o.ShipCountry
                })
                .ToList();

            return Ok(orders);
        }

        // 2. Call stored procedure: GetCustomersByCountry
        [HttpGet]
        [Route("api/customers/by-country/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();
            return Ok(customers);
        }
    }
}
