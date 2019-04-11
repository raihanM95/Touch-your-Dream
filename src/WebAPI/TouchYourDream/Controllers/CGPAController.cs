using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouchYourDream.Models;

namespace TouchYourDream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CGPAController : ControllerBase
    {
        CGPADataAccessLayer cgpadb = new CGPADataAccessLayer();

        [HttpPost]
        [Route("entryJobWiseCGPA")]
        //POST : /api/CGPA/entryJobWiseCGPA
        public int entryJobWiseCGPA([FromBody] CGPA cgpa)
        {
            return cgpadb.entryJobWiseCGPA(cgpa);
        }

        [HttpGet]
        [Route("suggestCGPA/{JobName}")]
        public CGPA suggestCGPA(string JobName)
        {
            return cgpadb.suggestCGPA(JobName);
        }

        [HttpPut]
        [Route("updateJobWiseCGPA")]
        public int updateJobWiseCGPA([FromBody] CGPA cgpa)
        {
            return cgpadb.updateJobWiseCGPA(cgpa);
        }

        [HttpDelete]
        [Route("removeCGPA/{id}")]
        //DELETE : /api/CGPA/removeCGPA
        public int removeCGPA(int id)
        {
            return cgpadb.removeCGPA(id);
        }
    }
}