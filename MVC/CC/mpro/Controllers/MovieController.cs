using System.Web.Mvc;
using MoviesApp.Models;
using MoviesApp.Repository;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo = new MovieRepository();

  
        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

       
        public ActionResult Filter()
        {
            return View();
        }

       
        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            ViewBag.DirectorName = directorName;
            return View(movies);
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            ViewBag.Year = year;
            return View(movies);
        }

        
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

    
        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

       
        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
