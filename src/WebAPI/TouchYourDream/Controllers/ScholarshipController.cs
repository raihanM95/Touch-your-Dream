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
    public class ScholarshipController : ControllerBase
    {
        ScholarshipDataAccessLayer scholarshipdb = new ScholarshipDataAccessLayer();

        [HttpPost]
        [Route("entrySGuideline")]
        //POST : /api/Scholarship/entrySGuideline
        public int entrySGuideline([FromBody] Scholarship scholarship)
        {
            return scholarshipdb.entrySGuideline(scholarship);
        }

        [HttpGet]
        [Route("suggestSGuideline/{Scholarship}")]
        public Scholarship suggestSGuideline(string Scholarship)
        {
            return scholarshipdb.suggestSGuideline(Scholarship);
        }

        [HttpPut]
        [Route("updateSGuideline")]
        public int updateSGuideline([FromBody] Scholarship scholarship)
        {
            return scholarshipdb.updateSGuideline(scholarship);
        }

        [HttpDelete]
        [Route("removeScholarship/{id}")]
        //DELETE : /api/Scholarship/removeScholarship
        public int removeScholarship(int id)
        {
            return scholarshipdb.removeScholarship(id);
        }
    }
}