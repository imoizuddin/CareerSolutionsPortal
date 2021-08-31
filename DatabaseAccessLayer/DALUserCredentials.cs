using BusinessAccessLayer.Register;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    class DALUserCredentials
    {
        string connectionString = "Data Source=WIN-JIKA3OO75OT\\SQLEXPRESS;Initial Catalog=CareerSolutions;Integrated Security=True";

        public BALUserRegister FindUserDetails(int userid)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[FindUser]", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            cmd.Parameters.AddWithValue("@userid", userid);

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

            SqlDataReader dr = cmd.ExecuteReader();
            BALUserRegister e = new BALUserRegister();
            e.UserId = userid;
            e.FullName = cmd.Parameters["@name"].Value.ToString();
            e.Email = cmd.Parameters["@email"].Value.ToString();
            e.Phone = Convert.ToInt32(cmd.Parameters["@phone"].Value.ToString());


            cn.Close();
            cn.Dispose();

            return e;
        }

        public void AddEmployer(BALUserRegister emp)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[AddUser]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            string name = emp.FullName;
            string email = emp.Email;
            string pass = emp.Password;
            int phone = emp.Phone;

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@phone", phone);

            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }


        public void UpdateEmployer(BALUserRegister c)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", c.UserId);
            cmd.Parameters.AddWithValue("@name", c.FullName);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void DeleteEmployer(int id)
        {

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("RemoveUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", id);
            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }
    }
}
