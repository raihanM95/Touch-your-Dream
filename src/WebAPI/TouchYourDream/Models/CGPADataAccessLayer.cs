using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class CGPADataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int entryJobWiseCGPA(CGPA cgpa)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("entryJobWiseCGPA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@JobName", cgpa.JobName);
                    cmd.Parameters.AddWithValue("@Semester", cgpa.Semester);
                    cmd.Parameters.AddWithValue("@CGPA", cgpa.CGPAS);

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

        public CGPA suggestCGPA(string JobName)
        {
            try
            {
                CGPA cgpa = new CGPA();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    string sqlQuery = "SELECT * FROM CGPA WHERE JobName = " + JobName;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        cgpa.JobName = rdr["JobName"].ToString();
                        cgpa.Semester = rdr["Semester"].ToString();
                        cgpa.CGPAS = Convert.ToInt32(rdr["CGPA"]);
                    }
                }
                return cgpa;
            }
            catch
            {
                throw;
            }
        }

        public int updateJobWiseCGPA(CGPA cgpa)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateJobWiseCGPA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CGPAId", cgpa.Id);
                    cmd.Parameters.AddWithValue("@JobName", cgpa.JobName);
                    cmd.Parameters.AddWithValue("@Semester", cgpa.Semester);
                    cmd.Parameters.AddWithValue("@CGPA", cgpa.CGPAS);

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

        public int removeCGPA(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("removeCGPA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CGPAId", id);

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
