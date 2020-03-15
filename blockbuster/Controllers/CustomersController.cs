using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using blockbuster.Models;
using blockbuster.ViewModels;

namespace blockbuster.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer Customer)
        {
            if(!ModelState.IsValid)
            {

                var viewModel = new CustomerFormViewModel()
                {
                    Customer = Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(Customer.Id == 0)
            {
                _context.Customers.Add(Customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(e=>e.Id == Customer.Id);
                customerInDb.Name = Customer.Name;
                customerInDb.Birthday = Customer.Birthday;
                customerInDb.IsSubscribedToNewsletter = Customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = Customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
        }


        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes;
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }


        public ViewResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            Customer c = null;
            foreach (Customer i in _context.Customers.Include(e=>e.MembershipType))
            {
                if (i.Id == id)
                {
                    c = i;

                }
            }
            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }
    }
}