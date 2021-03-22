using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Context
{
    public class BookContext: DbContext
    {
        public IConfiguration config { get; set; }
        public BookContext(IConfiguration iConfig)
        {
            config = iConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=WISGNDT024; Database=BookDB; trusted_connection=true;");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
