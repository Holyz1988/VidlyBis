using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        /// <summary>
        /// Renvoi la liste des clients 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // ->On récupère les clients
            IList<Customer> customers = GetCustomers();

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
            IList<Customer> customers = GetCustomers();
            Customer customer = customers.Where(c => c.Id == customerId)
                                    .SingleOrDefault();

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