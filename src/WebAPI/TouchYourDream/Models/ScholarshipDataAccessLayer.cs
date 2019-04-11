using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class ScholarshipDataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int entrySGuideline(Scholarship scholarship)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("entrySGuideline", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Scholarship", scholarship.ScholarshipS);
                    cmd.Parameters.AddWithValue("@Step", scholarship.Step);
                    cmd.Parameters.AddWithValue("@ToDo", scholarship.ToDo);

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

        public Scholarship suggestSGuideline(string Scholarship)
        {
            try
            {
                Scholarship scholarship = new Scholarship();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    string sqlQuery = "SELECT * FROM Scholarship WHERE Scholarship = " + Scholarship;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        scholarship.ScholarshipS = rdr["Scholarship"].ToString();
                        scholarship.Step = rdr["Step"].ToString();
                        scholarship.ToDo = rdr["ToDo"].ToString();
                    }
                }
                return scholarship;
            }
            catch
            {
                throw;
            }
        }

        public int updateSGuideline(Scholarship scholarship)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateJobWiseCGPA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SId", scholarship.Id);
                    cmd.Parameters.AddWithValue("@Scholarship", scholarship.ScholarshipS);
                    cmd.Parameters.AddWithValue("@Step", scholarship.Step);
                    cmd.Parameters.AddWithValue("@ToDo", scholarship.ToDo);

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

        public int removeScholarship(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("removeScholarship", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SId", id);

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
