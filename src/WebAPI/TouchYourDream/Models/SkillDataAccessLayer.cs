using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class SkillDataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int entryJobWiseSkill(Skill skill)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("entryJobWiseSkill", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@JobName", skill.JobName);
                    cmd.Parameters.AddWithValue("@SkillName", skill.SkillName);
                    cmd.Parameters.AddWithValue("@Value", skill.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Skill suggestSkill(string JobName)
        {
            try
            {
                Skill skill = new Skill();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    string sqlQuery = "SELECT * FROM Skill WHERE JobName = " + JobName;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        skill.JobName = rdr["JobName"].ToString();
                        skill.SkillName = rdr["SkillName"].ToString();
                        skill.Value = Convert.ToInt32(rdr["Value"]);
                    }
                }
                return skill;
            }
            catch
            {
                throw;
            }
        }

        public int updateJobWiseSkill(Skill skill)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateJobWiseSkill", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SkillId", skill.Id);
                    cmd.Parameters.AddWithValue("@JobName", skill.JobName);
                    cmd.Parameters.AddWithValue("@Subject", skill.SkillName);
                    cmd.Parameters.AddWithValue("@Value", skill.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int removeSkill(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("removeSkill", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SkillId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
