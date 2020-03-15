using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using blockbuster.Models;
using blockbuster.Dto;
using AutoMapper;
using System.Data.Entity;

namespace blockbuster.Controllers.Api
{
    public class ReturnController : ApiController
    {
        public ApplicationDbContext _context { get; set; }
        public ReturnController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult GetReturn(int id, string query = null)
        {
            var customerRentals = _context.Rentals.Include(x=>x.Movie).Include(y=>y.Customer).Where(x => x.Customer.Id == id && x.DateReturned == null);
            if (!String.IsNullOrWhiteSpace(query))
            {
                customerRentals = customerRentals.Where(x => x.Movie.Name.Contains(query));
            }
            var rentedMovies = customerRentals.ToList().Select(x=>x.Movie);
            var rentedMoviesDto = rentedMovies.Select(Mapper.Map<Movie, RentedMoviesDto>);            
            return Ok(rentedMoviesDto);
        }

        [HttpPut]
        public IHttpActionResult returnMovies(ReturnMoviesDto returnMoviesDto)
        {
            float totalCost = 0;
            int days, weeks;
            var returnedMovies = _context.Rentals
                .Include(m => m.Customer)
                .Include(x => x.Movie)
                .Include(a=>a.Customer.MembershipType)
                .Where(y=> returnMoviesDto.customerId == y.Customer.Id && returnMoviesDto.movieIds.Contains(y.Movie.Id))
                .ToList();
            float discount = returnedMovies[0].Customer.MembershipType.DiscountRate;
            foreach(var movie in returnedMovies)
            {
                if(movie.DateReturned == null)
                {
                    movie.DateReturned = DateTime.Now;
                    movie.Movie.NumberAvailable++;
                    days = (movie.DateReturned - movie.DateRented).Value.Days;
                    weeks = days % 7 == 0 ? days / 7 : days / 7 + 1;
                    totalCost += weeks * Price.price;
                }
            }
            _context.SaveChanges();
            totalCost = totalCost- ((discount / 100) * totalCost);
            return Ok(totalCost);
        }
    }
}