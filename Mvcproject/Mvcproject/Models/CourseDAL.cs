using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mvcproject.Models
{
    public class CourseDAL
    {
       
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            public CourseDAL()
            {
                con = new SqlConnection(Startup.ConnectionString);
            }

            public List<Course> GetAllCourses()
            {


                List<Course> list = new List<Course>();
                string str = "select * from course";
                cmd = new SqlCommand(str, con);


                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Course c = new Course();
                        c.Id = Convert.ToInt32(dr["Id"]);
                        c.Name = dr["Name"].ToString();
                        c.Fees = Convert.ToDecimal(dr["Fees"]);
                        list.Add(c);
                    }
                    con.Close();
                    return list;
                }
                else
                {
                    con.Close();
                    return list;
                }



            }
            public Course GetCourseById(int Id)
            {
                Course c = new Course();

                string str = "select * from course where Id=@id";

                cmd = new SqlCommand(str, con);

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)

                {

                    while (dr.Read())

                    {



                        c.Id = Convert.ToInt32(dr["Id"]);

                        c.Name = dr["Name"].ToString();

                        c.Fees = Convert.ToDecimal(dr["Fees"]);



                    }

                    con.Close();

                    return c;

                }

                else

                {

                    con.Close();

                    return c;

                }






            }
            public int Save(Course cour)
            {

                string str = "insert into course values(@name,@fees)";

                cmd = new SqlCommand(str, con);

                con.Open();

                cmd.Parameters.AddWithValue("@name", cour.Name);

                cmd.Parameters.AddWithValue("@fees", cour.Fees);

                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            }
            public int Update(Course cour)
            {
                string str = "update course set Name=@name,Fees=@fees where Id=@id";

                cmd = new SqlCommand(str, con);

                con.Open();

                cmd.Parameters.AddWithValue("@id", cour.Id);

                cmd.Parameters.AddWithValue("@name", cour.Name);

                cmd.Parameters.AddWithValue("@fees", cour.Fees);

                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            }
            public int Delete(int id)
            {
                string str = "delete from course where Id=@id";

                cmd = new SqlCommand(str, con);

                con.Open();

                cmd.Parameters.AddWithValue("@id", id);

                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            }
        }

    }

