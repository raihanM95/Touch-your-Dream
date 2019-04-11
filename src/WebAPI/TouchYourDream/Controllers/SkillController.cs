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
    public class SkillController : ControllerBase
    {
        SkillDataAccessLayer skilldb = new SkillDataAccessLayer();

        [HttpPost]
        [Route("entryJobWiseSkill")]
        //POST : /api/Skill/entryJobWiseSkill
        public int entryJobWiseSkill([FromBody] Skill skill)
        {
            return skilldb.entryJobWiseSkill(skill);
        }
        
        [HttpGet]
        [Route("suggestSkill/{JobName}")]
        public Skill suggestSkill(string JobName)
        {
            return skilldb.suggestSkill(JobName);
        }

        [HttpPut]
        [Route("updateJobWiseSkill")]
        public int updateJobWiseSkill([FromBody] Skill skill)
        {
            return skilldb.updateJobWiseSkill(skill);
        }

        [HttpDelete]
        [Route("removeSkill/{id}")]
        //DELETE : /api/Skill/removeSkill
        public int removeSkill(int id)
        {
            return skilldb.removeSkill(id);
        }
    }
}