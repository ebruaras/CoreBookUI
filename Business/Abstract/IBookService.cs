using Entity;
using Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        List<Genre> GetAllGenre();
        void Add(Genre g);
        void Delete(int id);
        Genre GetById(int id);
        Genre Update(Genre g);
        List<Book> GetAllBook();
        List<SelectListItem> AddBook();
        void AddBook(Book b);
        void DeleteBook(int id);
        Book GetByIdBook(int id);
        Book UpdateBook(Book b);
        List<Book> Detail(int id);
        String Edit(int id);
        Admin Login(Admin a);
    }
}
