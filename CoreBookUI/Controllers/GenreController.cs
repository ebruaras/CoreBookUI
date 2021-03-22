using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBookUI.Controllers
{
    public class GenreController : Controller
    {
        private IBookService _bookService;
        public GenreController(IBookService _bookService)
        {
            this._bookService = _bookService;
        }
        public IActionResult Index()
        {
            List<Genre> getGenre = _bookService.GetAllGenre();
            return View(getGenre);
        }
        [HttpGet]
        public IActionResult NewGenre()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewGenre(Genre g)
        {
            _bookService.Add(g);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetById(int id)
        {
            var deger = _bookService.GetById(id);
            return View(deger);
        }
        public IActionResult Update(Genre g)
        {
            _bookService.Update(g);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var d = _bookService.Edit(id);
            ViewBag.send = d;
            var dgr = _bookService.Detail(id);
            return View(dgr);
        }
    }
}
