using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PresentationLayer.Models;
using PresentationLayer.Services.BaseServices.Interfaces;

namespace VideoCatalog.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IRegisseurService _regisseurService;

        public FilmController(IFilmService filmService, IRegisseurService regisseurService)
        {
            _filmService = filmService;
            _regisseurService = regisseurService;
        }

        public async Task<ActionResult> Index(int page = 1)
        {
            var result = await _filmService.GetFilmPageAsync(page);
            return View(result);
        }
        public async Task<ActionResult> SingleFilm(string filmId)
        {
            var result = await _filmService.GetFilmByIdAsync(filmId);
            return View(result);
        }
        
        [HttpGet]
        public async Task<ActionResult> UpdateFilm(string filmId)
        {
            var data = await _filmService.GetFilmByIdAsync(filmId);
            FilmViewModelEdit result = new FilmViewModelEdit
            {
                Id = data.Id,
                Description = data.Description,
                Name = data.Name, 
                YearManufacture = data.YearManufacture
            };

            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> EditFilm(FilmViewModelEdit modelEdit)
        {
            await _filmService.UpdateFilmAsync(modelEdit);
            return Redirect("index");
        }
        [HttpGet]
        public ActionResult CreateFilm()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateFilm(FilmCreateModel model)
        {
            model.UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            await _filmService.CreateFilmAsync(model);
            return Redirect("index");
        }
        // GET: FilmController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: FilmController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController1/Edit/5
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

        // GET: FilmController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmController1/Delete/5
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
    }
}
