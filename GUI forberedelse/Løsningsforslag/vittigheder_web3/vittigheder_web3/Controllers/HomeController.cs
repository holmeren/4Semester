using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using vittigheder_web3.Models;

namespace vittigheder_web3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllJokes()
        {
            var jokes = db.Jokes.Include("Tags").OrderByDescending(j => j.Date).AsNoTracking().ToList();
            
            return View(jokes);
        }

        public ActionResult AddJoke(string objektString)
        {
            var joke = JsonConvert.DeserializeObject<Joke>(objektString);
            joke.Date = DateTime.Now;

            db.Jokes.Add(joke);
            db.SaveChanges();

            return null;
        }

        [HttpGet]
        public ActionResult GetJokesBasedOnCategory(string category)
        {
            var catJokes = new List<Joke>();
            var jokes =
                db.Jokes.Include("Tags")
                    .AsNoTracking()
                    .ToList();

            foreach (var item in jokes)
            {
                foreach (var tag in item.Tags)
                {
                    if (tag.TagString.ToLower() == category.ToLower())
                    {
                        catJokes.Add(item);
                    }
                }
            }

            return Json(catJokes, JsonRequestBehavior.AllowGet);
        }

        private JokeContext db = new JokeContext();
    }
}