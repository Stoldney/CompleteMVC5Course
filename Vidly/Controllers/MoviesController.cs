﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		#region Fields
		private ApplicationDbContext _context;

		#endregion

		#region Initialization and Destruction
		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		#endregion

		#region Actions
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

		public ViewResult Index(int pageIndex = 1, string sortBy = "Name")
		{
			var movies = _context.Movies.Include(m => m.Genre);			
			return View(movies);
		}

		public ActionResult Details(int id = 1)
		{
			var movie = _context.Movies.Include(c => c.Genre)
						.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

		[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		} 
		#endregion
	}
}