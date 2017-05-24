using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
//using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
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
            var customerlist = GetCustomers();
            
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

            var customer = GetCustomers()
                           .SingleOrDefault(c => c.Id == id);

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