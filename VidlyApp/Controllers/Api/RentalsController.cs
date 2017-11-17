using System;
using System.Linq;
using System.Web.Http;
using VidlyApp.DTOs;
using VidlyApp.Models;

namespace VidlyApp.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailability == 0)
                {
                    return BadRequest();
                }

                movie.NumberAvailability--;

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
