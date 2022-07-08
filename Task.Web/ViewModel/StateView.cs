using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task.Web.ViewModel
{
    public class StateView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }
        public string State_Name { get; set; }
        public Nullable<int> CountryId { get; set; }
    }
}