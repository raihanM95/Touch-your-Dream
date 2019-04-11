using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }

        string FullName { get; set; }
        string Gender { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string VarsityName { get; set; }
        string DeptName { get; set; }
        string Address { get; set; }
        string ImagePath { get; set; }
    }
}
