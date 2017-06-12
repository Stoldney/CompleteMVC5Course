using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "The Matrix" };

			var customers = new List<Customer>
			{
				new Customer {Name = "Stephanie"},
				new Customer {Name = "Charlemon"}
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);			
		}

		public ActionResult Edit(int id)
		{
			return Content("id = " + id);
		}

		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (string.IsNullOrEmpty(sortBy))
				sortBy = "Name";

			return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}

		[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

		
	}
}