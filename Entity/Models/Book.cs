using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
   public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public DateTime Date { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
