﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
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
		// GET /api/movies
		public IEnumerable<MovieDto> GetMovies(string query = null)
		{
			var moviesQuery = _context.Movies
								.Include(m => m.Genre)
								.Where(m => m.NumberAvailable > 0);

			if (!string.IsNullOrWhiteSpace(query))
				moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

			return moviesQuery									
							.ToList()
							.Select(Mapper.Map<Movie, MovieDto>);			
		}

		// GET /api/movies/1
		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		// POST /api/movies
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			movie.DateAdded = DateTime.Now.Date;
			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		// PUT /api/movies/1
		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				BadRequest();

			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				NotFound();

			Mapper.Map(movieDto, movieInDb);
			_context.SaveChanges();

			return Ok();
		}

		// DELETE /api/movies/1
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				NotFound();

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
		#endregion

	}
}
