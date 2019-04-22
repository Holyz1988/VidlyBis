using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            // ->Il faut disposer de l'objet Context
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        /// <summary>
        /// Renvoi la liste des clients 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // ->On récupère les clients
            //IList<Customer> customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            // ->On test si l'objet client est null
            if (customers == null)
                return new HttpNotFoundResult();

            // -> Retour de fonction
            return View(customers);
        }

        // Customers/details/id
        /// <summary>
        /// Renvoi le detail d'un client
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Route("customers/details/{customerId}")]
        public ActionResult Details(int? customerId)
        {
            // ->Test si l'identifiant du client existe
            if (!customerId.HasValue)
                return new HttpNotFoundResult();

            // -> On récupère le client qui possède le bon identifiant
            //IList<Customer> customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            Customer customer = customers.SingleOrDefault(c => c.Id == customerId);

            // -> On test si l'objet est null
            if (customer == null)
                return new HttpNotFoundResult();

            // ->Retour de fonction
            return View(customer);
        }

        /// <summary>
        /// Récupère la liste des clients
        /// </summary>
        /// <returns></returns>
        private IList<Customer> GetCustomers()
        {
            // -> Retour de fonction
            return new List<Customer>
            {
                new Customer { FirstName = "Amine", LastName = "Zeghad", Id = 1},
                new Customer { FirstName = "Nadia", LastName = "Zeghad", Id = 2},
                new Customer { FirstName = "Rachid", LastName = "Zeghad", Id = 3},
            };
        }
    }
}