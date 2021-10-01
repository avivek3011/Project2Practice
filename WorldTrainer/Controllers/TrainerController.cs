using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Repositories;
using WorldTrainer.Models;

namespace WorldTrainer.Controllers
{


    public class TrainerController : Controller
    {
        ITrainerRepo repo;

        const string Username = "";
        const string TrainerId = "";

        public TrainerController(ITrainerRepo _repo)
        {
                repo = _repo;
        }

        // GET: TrainerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrainerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrainerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainerModel trainer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Add(Mapper.Map(trainer), Mapper.MapDetails(trainer));
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(TrainerModel tm)
        {
            var data = repo.Login(Mapper.MapLogin(tm));
            if (data != null)
            {
                HttpContext.Session.SetString(TrainerId, data.Id.ToString());
                //HttpContext.Session.SetString(Username, data.Username);

                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Message = "Username & Password is not Correct";
                return View();
            }
        }

        public IActionResult Display()
        {
            var id = HttpContext.Session.GetString(TrainerId);
            int Uid = Convert.ToInt32(id);
            ViewBag.experience = repo.GetExp(Uid);
            ViewBag.qualification = repo.GetQualification(Uid);
            var data = Mapper.Map(repo.Display(Uid));
            return View(data);
        }


        // GET: TrainerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrainerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(SkillModel skills)
        {
            var id = HttpContext.Session.GetString(TrainerId);
            int Uid = Convert.ToInt32(id);
            repo.AddSkill(Mapper.MapSkill(skills, Uid));
            return RedirectToAction("Display", "Trainer");
        }
    }
}
