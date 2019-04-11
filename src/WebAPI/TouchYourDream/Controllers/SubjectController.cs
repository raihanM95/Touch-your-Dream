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
    public class SubjectController : ControllerBase
    {
        SubjectDataAccessLayer subjectdb = new SubjectDataAccessLayer();

        [HttpPost]
        [Route("entrySubjectInfo")]
        //POST : /api/Subject/entrySubjectInfo
        public int entrySubjectInfo([FromBody] Subject subject)
        {
            return subjectdb.entrySubjectInfo(subject);
        }

        [HttpGet]
        [Route("showSubjectInfo")]
        //GET : /api/Subject/showSubjectInfo
        public IEnumerable<Subject> showSubjectInfo()
        {
            return subjectdb.showSubjectInfo();
        }

        [HttpPut]
        [Route("updateSubjectInfo")]
        public int updateSubjectInfo([FromBody] Subject subject)
        {
            return subjectdb.updateSubjectInfo(subject);
        }

        [HttpDelete]
        [Route("removeSubjectInfo/{id}")]
        //DELETE : /api/Subject/removeSubjectInfo
        public int removeSubjectInfo(int id)
        {
            return subjectdb.removeSubjectInfo(id);
        }
    }
}