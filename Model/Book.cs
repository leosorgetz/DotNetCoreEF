﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCoreEF.Model.Base;

namespace DotNetCoreEF.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public DateTime LaunchDate { get; set; }
    }
}

