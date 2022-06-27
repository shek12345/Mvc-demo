using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//DAL=data access layer

namespace Mvcproject.Models
{
    public class EmployeeDAL
    {
        

            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            public EmployeeDAL()
            {
                con = new SqlConnection(Startup.ConnectionString);
            }

            public List<Employee> GetAllEmployees()
            {


                List<Employee> list = new List<Employee>();
                string str = "select * from employee";
                cmd = new SqlCommand(str, con);


                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Employee e = new Employee();
                        e.Id = Convert.ToInt32(dr["Id"]);
                        e.Name = dr["Name"].ToString();
                        e.Salary = Convert.ToDecimal(dr["Salary"]);
                        list.Add(e);
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
            public Employee GetEmployeeById(int Id)
            {
                Employee e = new Employee();

                string str = "select * from employee where Id=@id";

                cmd = new SqlCommand(str, con);

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)

                {

                    while (dr.Read())

                    {



                        e.Id = Convert.ToInt32(dr["Id"]);

                        e.Name = dr["Name"].ToString();

                        e.Salary = Convert.ToDecimal(dr["Salary"]);



                    }
                
                    con.Close();
                
                      return e;

                }

                else

                {

                    con.Close();

                    return e;

                }






            }
            public int Save(Employee emp)
            {

                string str = "insert into employee values(@name,@salary)";

                cmd = new SqlCommand(str, con);

                con.Open();

                cmd.Parameters.AddWithValue("@name", emp.Name);

                cmd.Parameters.AddWithValue("@salary", emp.Salary);

                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            }
            public int Update(Employee emp)
            {
                string str = "update course set Name=@name,Salary=@salary where Id=@id";

                cmd = new SqlCommand(str, con);

                con.Open();

                cmd.Parameters.AddWithValue("@id", emp.Id);

                cmd.Parameters.AddWithValue("@name", emp.Name);

                cmd.Parameters.AddWithValue("@salary",emp.Salary);

                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            }
            public int Delete(int id)
            {
                string str = "delete from employee where Id=@id";

                cmd = new SqlCommand(str, con);

                con.Open();

                cmd.Parameters.AddWithValue("@id", id);

                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            }
        }
    }

