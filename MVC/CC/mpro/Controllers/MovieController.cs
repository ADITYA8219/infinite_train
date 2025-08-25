using System.Web.Mvc;
using MoviesApp.Models;
using MoviesApp.Repository;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repo = new MovieRepository();

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Add(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            System.Diagnostics.Debug.WriteLine("Deleting movie with ID: " + id);
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            return View(movies);
        }
    }
}
