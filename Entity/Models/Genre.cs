﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
