using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class SubjectDataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int entrySubjectInfo(Subject subject)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("entrySubjectInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Varsity", subject.Varsity);
                    cmd.Parameters.AddWithValue("@Subject", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@Job", subject.Job);
                    cmd.Parameters.AddWithValue("@Year", subject.Year);

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

        public IEnumerable<Subject> showSubjectInfo()
        {
            try
            {
                List<Subject> subjectInfoList = new List<Subject>();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("getSubjectInfoList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Subject subject = new Subject();
                        subject.Id = Convert.ToInt32(rdr["Id"]);
                        subject.Varsity = rdr["Varsity"].ToString();
                        subject.SubjectName = rdr["Subject"].ToString();
                        subject.Job = Convert.ToInt32(rdr["Job"]);
                        subject.Year = rdr["Year"].ToString();

                        subjectInfoList.Add(subject);
                    }
                    con.Close();
                }
                return subjectInfoList;
            }
            catch
            {
                throw;
            }
        }

        public int updateSubjectInfo(Subject subject)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateSubjectInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubId", subject.Id);
                    cmd.Parameters.AddWithValue("@Varsity", subject.Varsity);
                    cmd.Parameters.AddWithValue("@Subject", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@Job", subject.Job);
                    cmd.Parameters.AddWithValue("@Year", subject.Year);

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

        public int removeSubjectInfo(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("removeSubjectInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubId", id);

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
