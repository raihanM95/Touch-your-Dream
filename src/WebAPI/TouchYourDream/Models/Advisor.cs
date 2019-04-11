using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class Advisor : IUser
    {
        //[Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //[Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string VarsityName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DeptName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Designation { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ImagePath { get; set; }
    }
}
