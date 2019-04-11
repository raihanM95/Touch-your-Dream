using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TouchYourDream.Models;

namespace TouchYourDream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDataAccessLayer studentdb = new StudentDataAccessLayer();

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;

        public StudentController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/Student/Register
        public async Task<Object> Register(Student student)
        {
            var user = new ApplicationUser()
            {
                UserName = student.UserName,
                Email = student.Email,
                Name = student.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(user, student.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/Student/Login
        public async Task<IActionResult> Login(Student student)
        {
            var user = await _userManager.FindByNameAsync(student.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, student.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpGet]
        [Authorize]
        [Route("Log")]
        //GET : /api/Student/Log
        public async Task<Object> getStudentLog()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Name,
                user.Email,
                user.UserName
            };
        }

        [HttpPost]
        [Route("addStudentInfo")]
        //POST : /api/Student/addStudentInfo
        public int addAdvisorInfo([FromBody] Student student)
        {
            return studentdb.addStudentInfo(student);
        }

        [HttpGet]
        [Route("studentList")]
        //GET : /api/Student/studentList
        public IEnumerable<Student> studentList()
        {
            return studentdb.showStudentList();
        }

        [HttpGet]
        [Route("studentDetails/{id}")]
        public Student studentDetails(int id)
        {
            return studentdb.studentDetails(id);
        }

        [HttpPut]
        [Route("updateStudentInfo")]
        public int updateStudentInfo([FromBody] Student student)
        {
            return studentdb.updateStudentInfo(student);
        }

        [HttpDelete]
        [Route("removeStudent/{id}")]
        //DELETE : /api/Student/removeStudent
        public int removeStudent(int id)
        {
            return studentdb.removeStudent(id);
        }
    }
}