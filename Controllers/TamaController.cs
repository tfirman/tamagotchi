using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tama.Models;
using System;

namespace Tama.Controllers
{
    public class TamaController : Controller
    {
        [HttpGet("/tamagotchi")]
        public ActionResult Index()
        {
            List<Tamagotchi> allTama = Tamagotchi.GetAll();
            return View(allTama);
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
            return View("Index", allTama);
            }

        [HttpGet("/tamagotchi/{id}")]
        public ActionResult Details(int id)
        {
            Tamagotchi tama = Tamagotchi.GetById(id);
            return View(tama);
        }

        [HttpGet("/tamagotchi/time")]
        public ActionResult Time()
        {
            Tamagotchi.TimePass();
            List<Tamagotchi> allTama = Tamagotchi.GetAll();
            return View("Index", allTama);
        }

        [HttpGet("/tamagotchi/{id}/play")]
        public ActionResult Play(int id)
        {
            Tamagotchi tama = Tamagotchi.GetById(id);
            Console.Write('1');
            tama.PlayTama();
            return View("Details", tama);
        }

        [HttpGet("/tamagotchi/feed")]
        public ActionResult Feed()
        {
            Tamagotchi.FeedTama();
            List<Tamagotchi> allTama = Tamagotchi.GetAll();
            return View("Index", allTama);

        }
        [HttpGet("/tamagotchi/nap")]
        public ActionResult Nap()
        {
            Tamagotchi.TamaRest();
            List<Tamagotchi> allTama = Tamagotchi.GetAll();
            return View("Index", allTama);
        }
    }
}
