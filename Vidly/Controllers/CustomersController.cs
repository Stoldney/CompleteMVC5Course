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
		public ActionResult Index()
		{
			var customers = GetCustomers();

			return View(customers);
		}

		public ActionResult Details(int id = 1)
		{
			var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		private IEnumerable<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				new Customer { Id = 1, Name = "Charlemon Duboise"},
				new Customer { Id = 2, Name = "Hans Gruber"},
				new Customer { Id = 3, Name = "Baxter Brixton" }
			};
		}
	}
}