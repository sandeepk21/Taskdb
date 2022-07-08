using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task.Web.ViewModel
{
    public class Mas_GenderViewModel
    {
        public int GenderId { get; set; }
        public string Gender_Name { get; set; }
    }
}