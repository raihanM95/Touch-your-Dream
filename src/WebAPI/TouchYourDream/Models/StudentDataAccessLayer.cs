using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class StudentDataAccessLayer
    {
        string ConnnectionString = "Server=DESKTOP-ON380RK; Database=TouchYourDream; Trusted_Connection=True; MultipleActiveResultSets=True;";


        public int addStudentInfo(Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("addStudentInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);

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

        public IEnumerable<Student> showStudentList()
        {
            try
            {
                List<Student> studentList = new List<Student>();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("getStudentList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.Id = Convert.ToInt32(rdr["Id"]);
                        student.FullName = rdr["Name"].ToString();
                        student.VarsityName = rdr["VarsityName"].ToString();
                        student.DeptName = rdr["DeptName"].ToString();
                        student.ImagePath = rdr["Image"].ToString();

                        studentList.Add(student);
                    }
                    con.Close();
                }
                return studentList;
            }
            catch
            {
                throw;
            }
        }

        public Student studentDetails(int id)
        {
            try
            {
                Student student = new Student();
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    string sqlQuery = "SELECT * FROM Student WHERE Id = " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.FullName = rdr["Name"].ToString();
                        student.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        student.Gender = rdr["Gender"].ToString();
                        student.Email = rdr["Email"].ToString();
                        student.Phone = rdr["Phone"].ToString();
                        student.VarsityName = rdr["VarsityName"].ToString();
                        student.DeptName = rdr["DeptName"].ToString();
                        student.Address = rdr["Address"].ToString();
                        student.ImagePath = rdr["Image"].ToString();
                    }
                }
                return student;
            }
            catch
            {
                throw;
            }
        }

        public int updateStudentInfo(Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateStudentInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StdntId", student.Id);
                    cmd.Parameters.AddWithValue("@Name", student.FullName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Phone", student.Phone);
                    cmd.Parameters.AddWithValue("@VarsityName", student.VarsityName);
                    cmd.Parameters.AddWithValue("@DeptName", student.DeptName);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@Image", student.ImagePath);

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

        public int removeStudent(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnnectionString))
                {
                    SqlCommand cmd = new SqlCommand("removeStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StdntId", id);

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
