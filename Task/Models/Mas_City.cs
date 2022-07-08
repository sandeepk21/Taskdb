using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Mas_City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string City_Name { get; set; }
        public Nullable<int> StateId { get; set; }

        public virtual Mas_State Mas_State { get; set; }
    }
}
