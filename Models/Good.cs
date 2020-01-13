using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication4.Models
{
    public class Good
    {
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
        [Display(Name ="Название")]
        public string Title { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Цена")]
        [UIHint("decimal")]
        public double Price { get; set; }
    }
}