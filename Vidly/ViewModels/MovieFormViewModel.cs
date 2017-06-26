using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		#region Initialization and Destruction
		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
			GenreId = movie.GenreId;
		}
		#endregion

		#region Properties
		public IEnumerable<Genre> Genres { get; set; }

		public int? Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte? GenreId { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Number in Stock")]
		[Range(1, 20, ErrorMessage = "Number in stock should be between 1 and 20.")]
		public int? NumberInStock { get; set; }

		public string Title
		{
			get
			{
				return Id != 0 ? "Edit Movie" : "New Movie";
			}
		} 
		#endregion
	}
}