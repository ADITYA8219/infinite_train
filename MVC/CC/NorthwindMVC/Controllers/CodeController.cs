using System.Linq;
using System.Web.Mvc;
using NorthwindMVC.Models;

namespace NorthwindMVC.Controllers
{
    public class CodeController : Controller
    {
        Northwind1Entities2 db = new Northwind1Entities2();

        public ActionResult GermanCustomers()
        {
            var germanCustomers = db.Customers
                                     .Where(c => c.Country == "Germany")
                                     .ToList();
            return View(germanCustomers);
        }

        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();
            return View(customer);
        }
    }
}
