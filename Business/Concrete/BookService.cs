using Business.Abstract;
using Entity;
using Entity.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
   public class BookService: IBookService
    {
        public IConfiguration config { get; set; }
        public BookService(IConfiguration iConfig)
        {
            config = iConfig;
        }
        public List<Genre> GetAllGenre()
        {
            using(BookContext db=new BookContext(config))
            {
                return db.Genres.ToList();
            }
        }
        public void Add(Genre g)
        {
            using (BookContext db = new BookContext(config))
            {
                db.Genres.Add(g);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (BookContext db = new BookContext(config))
            {
               var dlt= db.Genres.Find(id);
                db.Remove(dlt);
                db.SaveChanges();
            }
        }
        public Genre GetById(int id)
        {
            using (BookContext db = new BookContext(config))
            {
                var gnr = db.Genres.Find(id);
                return gnr;
            }
        }
        public Genre Update(Genre g)
        {
            using (BookContext db = new BookContext(config))
            {
                var gnr = db.Genres.Find(g.ID);
                gnr.Name = g.Name;
                db.SaveChanges();
                return gnr;
            }
        }
        public List<Book> GetAllBook()
        {
            using (BookContext db = new BookContext(config))
            {
                return db.Books.Include(x=>x.Genre).ToList();
            }
        }
        public List<SelectListItem> AddBook()
        {
            using (BookContext db = new BookContext(config)) {
                List<SelectListItem> deger = (from x in db.Genres.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
                return deger;
                                           
                    }
           
        }
        public void AddBook(Book b)
        {
            using (BookContext db = new BookContext(config))
            {
                var book = db.Genres.Where(x => x.ID == b.Genre.ID).FirstOrDefault();
                b.Genre = book;
                db.Books.Add(b);
                db.SaveChanges();
            }
        }
        public void DeleteBook(int id)
        {
            using (BookContext db = new BookContext(config))
            {
                var dlt = db.Books.Find(id);
                db.Remove(dlt);
                db.SaveChanges();
            }
        }
        public Book GetByIdBook(int id)
        {
            using (BookContext db = new BookContext(config))
            {
                var bk = db.Books.Find(id);
                return bk;
            }
        }
        public Book UpdateBook(Book b)
        {
            using (BookContext db = new BookContext(config))
            {
                var bk = db.Books.Find(b.ID);
                bk.Name = b.Name;
                bk.Author = b.Author;
                bk.Date = b.Date;
                bk.Page = b.Page;
                bk.GenreID = b.Genre.ID;
                db.SaveChanges();
                return bk;
            }
        }
    }
}
