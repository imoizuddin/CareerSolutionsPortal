using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class DALJobDetails
    {
        string connectionString = "Data Source=WIN-JIKA3OO75OT\\SQLEXPRESS;Initial Catalog=CareerSolutions;Integrated Security=True";
        public List<BALJobModel> GetJobs()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[JobDetails]", connection);
            connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            List<BALJobModel> categories = new List<BALJobModel>();
            while (data.Read())
            {
                BALJobModel c = new BALJobModel();

                c.JobId = Convert.ToInt32(data["JobId"]);
                c.EmployeeId = Convert.ToInt32(data[1].ToString());
                c.CompanyName = data[2].ToString();
                c.JobProfile = data[3].ToString();
                c.Description = data[3].ToString();
                c.Location = data[3].ToString();
                c.Salary = Convert.ToInt32(data[3].ToString());
                c.JobPostedDate = Convert.ToDateTime(data[3].ToString());
                categories.Add(c);
            }
            connection.Close();
            connection.Dispose();
            return categories;
        }
        public BALJobModel FindJobDetails(int jobid)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[FindJobDetails]", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            cmd.Parameters.AddWithValue("@jobid", jobid);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@empid";
            p1.SqlDbType = SqlDbType.Int;
            p1.Size = 50;
            p1.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@companyName";
            p2.SqlDbType = SqlDbType.NVarChar;
            p2.Direction = ParameterDirection.Output;
            p2.Size = 50;
            cmd.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@jobprofilename";
            p3.SqlDbType = SqlDbType.NVarChar;
            p3.Direction = ParameterDirection.Output;
            p3.Size = 50;
            cmd.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@description";
            p4.SqlDbType = SqlDbType.NVarChar;
            p4.Direction = ParameterDirection.Output;
            p4.Size = 50;
            cmd.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@location";
            p5.SqlDbType = SqlDbType.NVarChar;
            p5.Direction = ParameterDirection.Output;
            p5.Size = 50;
            cmd.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@salary";
            p6.SqlDbType = SqlDbType.BigInt;
            p6.Direction = ParameterDirection.Output;
            p6.Size = 50;
            cmd.Parameters.Add(p6);

            SqlParameter p7 = new SqlParameter();
            p7.ParameterName = "@posteddate";
            p7.SqlDbType = SqlDbType.NVarChar;
            p7.Direction = ParameterDirection.Output;
            p7.Size = 50;
            cmd.Parameters.Add(p7);


            SqlDataReader dr = cmd.ExecuteReader();
            BALJobModel e = new BALJobModel();
            e.JobId = jobid;
            e.EmployeeId = Convert.ToInt32(cmd.Parameters["@empid"].Value.ToString());
            e.CompanyName = cmd.Parameters["@companyName"].Value.ToString();
            e.JobProfile = cmd.Parameters["@jobprofilename"].Value.ToString();
            e.Description = cmd.Parameters["@description"].Value.ToString();
            e.Location = cmd.Parameters["@location"].Value.ToString();
            e.Salary = Convert.ToInt32(cmd.Parameters["@salary"].Value.ToString());
            e.JobPostedDate = Convert.ToDateTime(cmd.Parameters["@posteddate"].Value.ToString());


            cn.Close();
            cn.Dispose();

            return e;
        }

        public void AddJob(BALJobModel job)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[AddJobDetails]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            string companyName = job.CompanyName;
            string jobProfile = job.JobProfile;
            string description = job.Description;
            string location = job.Location;
            int salary = job.Salary;
            DateTime postedDate = job.JobPostedDate;

            cmd.Parameters.AddWithValue("@companyName", companyName);
            cmd.Parameters.AddWithValue("@jobprofilename", jobProfile);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@location", location);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@posteddate", postedDate);

            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }


        public void UpdateJob(BALJobModel c)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UpdateJobDetails", cn);
            cmd.CommandType = CommandType.StoredProcedure;


            //cmd.Parameters.AddWithValue("@empid", c.EmployeeId);
            cmd.Parameters.AddWithValue("@companyName", c.CompanyName);
            cmd.Parameters.AddWithValue("@jobprofilename", c.JobProfile);
            cmd.Parameters.AddWithValue("@description", c.Description);
            cmd.Parameters.AddWithValue("@location", c.Location);
            cmd.Parameters.AddWithValue("@salary", c.Salary);
            cmd.Parameters.AddWithValue("@posteddate", c.JobPostedDate);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void DeleteJob(int id)
        {

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("RemoveJob", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@jobid", id);
            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }
    }
}
