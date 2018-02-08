using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tama.Models;

namespace Tama.Controllers
{
    public class TamaController : Controller
    {
        [HttpGet("/tamagotchi")]
        public ActionResult Index()
        {
            // List<Tamagotchi> allTama = Tamagotchi.GetAll();
            // return View(allTama);
            return View();
        }

        [HttpGet("/tamagotchi/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/tamagotchi")]
        public ActionResult Create()
        {
            string stringRest = Request.Form["new-rest"];
            string stringAttention = Request.Form["new-attention"];
            string stringFood = Request.Form["new-food"];
            int rest = int.Parse(stringRest);
            int attention = int.Parse(stringAttention);
            int food = int.Parse(stringFood);

            Tamagotchi newTamagotchi = new Tamagotchi(Request.Form["new-tamagotchi"], food, attention, rest);
            List<Tamagotchi> allTama = Tamagotchi.GetAll();
            // return View("Index", allTama);
            return View("Index");
            }

        [HttpGet("/tamagotchi/{id}")]
        public ActionResult Details(int id)
        {
            Tamagotchi tama = Tamagotchi.GetById(id);
            return View("Detail",tama);
        }

    }
}
