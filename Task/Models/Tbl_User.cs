using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Tbl_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Index(IsUnique = true)]
        public string Username { get; set; }
        public int RoleId { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public string UserNickName { get; set; }
        public string Password { get; set; }
        [Index(IsUnique = true)]
        public string Email { get; set; }
    }
}
