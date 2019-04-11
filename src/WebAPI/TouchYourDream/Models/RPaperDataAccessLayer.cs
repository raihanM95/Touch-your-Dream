using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class RPaperDataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int publishRPaper(ResearchPaper researchPaper)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("publishRPaper", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", researchPaper.Title);
                    cmd.Parameters.AddWithValue("@FileName", researchPaper.FileName);
                    cmd.Parameters.AddWithValue("@FilePath", researchPaper.FilePath);
                    cmd.Parameters.AddWithValue("@Date", researchPaper.Date);

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

        public IEnumerable<ResearchPaper> showAdvisorList()
        {
            try
            {
                List<ResearchPaper> rPaperList = new List<ResearchPaper>();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("getResearchPaperList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ResearchPaper rPaper = new ResearchPaper();
                        rPaper.Id = Convert.ToInt32(rdr["Id"]);
                        rPaper.Title = rdr["Title"].ToString();
                        rPaper.FileName = rdr["FileName"].ToString();
                        rPaper.FilePath = rdr["FilePath"].ToString();
                        rPaper.Date = Convert.ToDateTime(rdr["Date"]);

                        rPaperList.Add(rPaper);
                    }
                    con.Close();
                }
                return rPaperList;
            }
            catch
            {
                throw;
            }
        }

        public int deleteRPaper(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteRPaper", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RPId", id);

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
