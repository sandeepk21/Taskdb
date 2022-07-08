using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Web.ViewModel
{
    public class CityView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string City_Name { get; set; }
        public Nullable<int> StateId { get; set; }

        
    }
}