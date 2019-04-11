using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class Student : IUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VarsityName { get; set; }
        public string DeptName { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}
