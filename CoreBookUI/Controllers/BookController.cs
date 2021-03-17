using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBookUI.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService _bookService)
        {
            this._bookService = _bookService;
        }
        public IActionResult Index()
        {
            var books = _bookService.GetAllBook().ToList();
            return View(books);
        }
        [HttpGet]
        public IActionResult NewBook()
        {
           List<SelectListItem> dgr= _bookService.AddBook();
            ViewBag.s = dgr;
            return View();
        }
        [HttpPost]
        public IActionResult NewBook(Book b)
        {
            _bookService.AddBook(b);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetById(int id)
        {
            List<SelectListItem> dgr = _bookService.AddBook();
            ViewBag.s = dgr;
            var deger = _bookService.GetByIdBook(id);
            return View(deger);
        }
        public IActionResult Update(Book b)
        {
            _bookService.UpdateBook(b);
            return RedirectToAction("Index");
        }
    }
}
