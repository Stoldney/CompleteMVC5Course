using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class NewRentalsController : ApiController
	{
		#region Fields
		private ApplicationDbContext _context;
		#endregion

		#region Initialization and Destrustion
		public NewRentalsController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		#endregion

		[HttpPost]
		public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
		{
			var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);				

			var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();			

			foreach (var movie in movies)
			{
				if (movie.NumberAvailable == 0)
					return BadRequest("Movie is not available");

				movie.NumberAvailable--;

				var rental = new Rental
				{
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				};

				_context.Rentals.Add(rental);
			}

			_context.SaveChanges();

			return Ok();
		}
	}
}