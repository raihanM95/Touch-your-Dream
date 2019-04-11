using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class AdvisorDataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int addAdvisorInfo(Advisor advisor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("addAdvisorInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", advisor.FullName);
                    cmd.Parameters.AddWithValue("@Email", advisor.Email);

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

        public IEnumerable<Advisor> showAdvisorList()
        {
            try
            {
                List<Advisor> advisorList = new List<Advisor>();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("getAdvisorList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Advisor advisor = new Advisor();
                        advisor.Id = Convert.ToInt32(rdr["Id"]);
                        advisor.FullName = rdr["Name"].ToString();
                        advisor.VarsityName = rdr["VarsityName"].ToString();
                        advisor.DeptName = rdr["DeptName"].ToString();
                        advisor.ImagePath = rdr["Image"].ToString();

                        advisorList.Add(advisor);
                    }
                    con.Close();
                }
                return advisorList;
            }
            catch
            {
                throw;
            }
        }

        public Advisor advisorDetails(int id)
        {
            try
            {
                Advisor advisor = new Advisor();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    string sqlQuery = "SELECT * FROM Advisor WHERE Id = " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        advisor.FullName = rdr["Name"].ToString();
                        advisor.Gender = rdr["Gender"].ToString();
                        advisor.Email = rdr["Email"].ToString();
                        advisor.Phone = rdr["Phone"].ToString();
                        advisor.VarsityName = rdr["VarsityName"].ToString();
                        advisor.DeptName = rdr["DeptName"].ToString();
                        advisor.Designation = rdr["Designation"].ToString();
                        advisor.Address = rdr["Address"].ToString();
                        advisor.ImagePath = rdr["Image"].ToString();
                    }
                }
                return advisor;
            }
            catch
            {
                throw;
            }
        }

        public int updateAdvisorInfo(Advisor advisor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateAdvisorInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdvId", advisor.Id);
                    cmd.Parameters.AddWithValue("@Name", advisor.FullName);
                    cmd.Parameters.AddWithValue("@Gender", advisor.Gender);
                    cmd.Parameters.AddWithValue("@Email", advisor.Email);
                    cmd.Parameters.AddWithValue("@Phone", advisor.Phone);
                    cmd.Parameters.AddWithValue("@VarsityName", advisor.VarsityName);
                    cmd.Parameters.AddWithValue("@DeptName", advisor.DeptName);
                    cmd.Parameters.AddWithValue("@Designation", advisor.Designation);
                    cmd.Parameters.AddWithValue("@Address", advisor.Address);
                    cmd.Parameters.AddWithValue("@Image", advisor.ImagePath);

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

        public int removeAdvisor(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("removeAdvisor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdvId", id);

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
