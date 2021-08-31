using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessAccessLayer.Register;
using BusinessAccessLayer;
using System.Data.SqlClient;



namespace DatabaseAccessLayer
{
    public class DALEmployerCredentials
    {
        string connectionString = "Data Source=WIN-JIKA3OO75OT\\SQLEXPRESS;Initial Catalog=CareerSolutions;Integrated Security=True";

        public BALEmployerRegister FindEmployeeDetails(int empid)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[FindEmployee]", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            cmd.Parameters.AddWithValue("@empid", empid);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@name";
            p1.SqlDbType = SqlDbType.NVarChar;
            p1.Size = 50;
            p1.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@email";
            p2.SqlDbType = SqlDbType.NVarChar;
            p2.Direction = ParameterDirection.Output;
            p2.Size = 50;
            cmd.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@phone";
            p3.SqlDbType = SqlDbType.BigInt;
            p3.Direction = ParameterDirection.Output;
            p3.Size = 50;
            cmd.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@companyName";
            p4.SqlDbType = SqlDbType.NVarChar;
            p4.Direction = ParameterDirection.Output;
            p4.Size = 50;
            cmd.Parameters.Add(p4);


            SqlDataReader dr = cmd.ExecuteReader();
            BALEmployerRegister e = new BALEmployerRegister();
            e.EmpId = empid;
            e.FullName = cmd.Parameters["@name"].Value.ToString();
            e.Email = cmd.Parameters["@email"].Value.ToString();
            e.Phone = Convert.ToInt32(cmd.Parameters["@phone"].Value.ToString());
            e.CompanyName = cmd.Parameters["@companyName"].Value.ToString();


            cn.Close();
            cn.Dispose();

            return e;
        }

        public void AddEmployer(BALEmployerRegister emp)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[AddEmployee]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            string name = emp.FullName;
            string email = emp.Email;
            string pass = emp.Password;
            int phone = emp.Phone;
            string companyName = emp.CompanyName;

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@companyName", companyName);

            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }

        public int CheckEmployer(BALEmployerLogin emp)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT [dbo].[fn_validateEmployee](@p_mailId,@p_pwd)", cn);
            cmd.Parameters.AddWithValue("@p_mailId", emp.Email);
            cmd.Parameters.AddWithValue("@p_pwd", emp.Password);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int id = Convert.ToInt32(dr[0]);

            cn.Close();
            cn.Dispose();
            return id;
        }

        public void UpdateEmployer(BALEmployerRegister c)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UpdateCategoryData", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", c.EmpId);
            cmd.Parameters.AddWithValue("@name", c.FullName);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cmd.Parameters.AddWithValue("@companyName", c.CompanyName);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void DeleteEmployer(int id)
        {

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("RemoveCategory", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", id);
            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }
    }
}
