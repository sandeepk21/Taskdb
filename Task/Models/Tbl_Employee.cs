using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Tbl_Employee
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int EmployeeId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int GenderId { get; set; }
       public int CityId { get; set; }
       [Index(IsUnique = true)]
       public string Email { get; set; }
       public string Password { get; set; }
       public string Address { get; set; }
       public int Pincode { get; set; }
       public DateTime JoiningDate { get; set; }
       public DateTime? LastWorkingDate { get; set; }
       public int IsActive { get; set; }
    }
}
