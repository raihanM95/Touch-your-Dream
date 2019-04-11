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
    public class AdvisorController : ControllerBase
    {
        AdvisorDataAccessLayer advisordb = new AdvisorDataAccessLayer();

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;

        public AdvisorController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        
        [HttpPost]
        [Route("Register")]
        //POST : /api/Advisor/Register
        public async Task<Object> Register(Advisor advisor)
        {
            var user = new ApplicationUser()
            {
                UserName = advisor.UserName,
                Email = advisor.Email,
                Name = advisor.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(user, advisor.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/Advisor/Login
        public async Task<IActionResult> Login(Advisor advisor)
        {
            var user = await _userManager.FindByNameAsync(advisor.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, advisor.Password))
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
        //GET : /api/Advisor/Log
        public async Task<Object> getAdvisorLog()
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
        [Route("addAdvisorInfo")]
        //POST : /api/Advisor/addAdvisorInfo
        public int addAdvisorInfo([FromBody] Advisor advisor)
        {
            return advisordb.addAdvisorInfo(advisor);
        }

        [HttpGet]
        [Route("advisorList")]
        //GET : /api/Advisor/advisorList
        public IEnumerable<Advisor> advisorList()
        {
            return advisordb.showAdvisorList();
        }

        [HttpGet]
        [Route("advisorDetails/{id}")]
        public Advisor advisorDetails(int id)
        {
            return advisordb.advisorDetails(id);
        }

        [HttpPut]
        [Route("updateAdvisorInfo")]
        public int updateAdvisorInfo([FromBody] Advisor advisor)
        {
            return advisordb.updateAdvisorInfo(advisor);
        }

        [HttpDelete]
        [Route("removeAdvisor/{id}")]
        //DELETE : /api/Advisor/removeAdvisor
        public int removeAdvisor(int id)
        {
            return advisordb.removeAdvisor(id);
        }
    }
}