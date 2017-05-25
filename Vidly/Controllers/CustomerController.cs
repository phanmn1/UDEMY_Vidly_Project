using System;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
//using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context; 

        public CustomerController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }
        // GET: Customer
        //[Route("Customers/")]
        public ActionResult Index()
        {
            /*
            var customers = new List<Customer> {
                 new Customer { Name = "John Smith", Id = 1},
                 new Customer { Name = "Mary Williams", Id = 2 }
                };

            var customerlist = new RandomMovieViewModel
            {
                Customers = customers
            };

            */
            //Customers Property is a context in DBSet so we can get all 
            //customers in the database
            var customerlist = _context.Customers.Include(c => c.MembershipType).ToList(); 
                //GetCustomers();
            
            return View(customerlist);
        }


        //No need all routes for this exercise are already in the form of {controller}/{action}/{id}
        //[Route("Customers/Details/{id:regex(\\d{1}):range(1, 2)}")]
        public ActionResult Details(int id)
        {

            /*
            var customers = new List<Customer> {
                 new Customer { Name = "John Smith", Id = 1},
                 new Customer { Name = "Mary Williams", Id = 2 }
                };


            foreach(var customer in customers)
            {
               if(customer.Id == id)
                {
                    var customerlist = new RandomMovieViewModel
                    {
                        Customers = new List<Customer> { new Customer { Name = customer.Name, Id = customer.Id } }

                    };
                    return View(customerlist);
                }   
            }

            
            
            var customerlist = new RandomMovieViewModel
            {
                Customers = customers
            }; */

            var customer = _context.Customers
                           .SingleOrDefault(c => c.Id == id);//single or default already queries database

            if (customer == null)
            {
                return HttpNotFound();
            }



            return View(customer); 
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
                {
                   new Customer { Name = "John Smith", Id = 1},
                  new Customer { Name = "Mary Williams", Id = 2 }
                };
        }

    }
}