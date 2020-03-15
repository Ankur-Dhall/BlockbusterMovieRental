using System.Collections.Generic;
using System.Web.Mvc;
using blockbuster.Models;
using System.Data.Entity;
using blockbuster.ViewModels;
using System.Linq;

namespace blockbuster.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0)
            {
                movie.DateAdded = System.DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDbset = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieDbset.Name = movie.Name;
                movieDbset.GenreId = movie.GenreId;
                movieDbset.ReleaseDate = movie.ReleaseDate;
                movieDbset.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList(),
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            Movie c = null;
            foreach (Movie i in _context.Movies.Include(m=>m.Genre))
            {
                if (i.Id == id)
                {
                    c = i;

                }
            }
            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }
    }
}