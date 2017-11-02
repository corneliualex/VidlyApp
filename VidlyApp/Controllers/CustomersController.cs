using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {

            //var customers = new List<Customer>();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

       
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            return View();
        }


        /*private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Alexander"
                },
                new Customer()
                {
                    Id=2,
                    Name="Corneliu"
                }
            };
        }*/
    }
}