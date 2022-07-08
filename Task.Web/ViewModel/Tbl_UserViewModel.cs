using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task.Web.ViewModel
{
    public class Tbl_UserViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public string UserNickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
       //public  List<Tbl_UserViewModel> Userlist { get; set; }
    }
}