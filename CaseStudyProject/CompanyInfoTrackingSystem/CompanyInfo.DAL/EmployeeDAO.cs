using System;
using System.Collections.Generic;
using System.Text;
using CompanyInfo.Model;
using System.Data;
using System.Data.SqlClient;

namespace CompanyInfo.DAL
{
   public class EmployeeDAO
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-GCI2Q723\SQLEXPRESS01;Initial Catalog=Company_Info;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        string Qry = null;

        public bool AddEmployee(EmployeeDetails e)
        {
            try
            {
                Qry = "Insert into Company_Details values(@Company_ID,@Company_Name,@Emp_ID,@Emp_Name,@Emp_Address,@Emp_Date_of_Birth,@Emp_Contact,@Emp_Profession,@Emp_Date_of_joining,@Emp_Resume,@Emp_Offer_letter)";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@Company_ID", e.Cmp_Id);
                cmd.Parameters.AddWithValue("@Company_Name", e.Cmp_Name);
                cmd.Parameters.AddWithValue("@Emp_ID", e.Emp_ID);
                cmd.Parameters.AddWithValue("@Emp_Name", e.Emp_Name);
                cmd.Parameters.AddWithValue("@Emp_Address", e.Emp_Address);
                cmd.Parameters.AddWithValue("@Emp_Date_of_Birth", e.Emp_DOB);
                cmd.Parameters.AddWithValue("@Emp_Contact", e.Emp_Contact);
                cmd.Parameters.AddWithValue("@Emp_Profession",e.Emp_Profession);
                cmd.Parameters.AddWithValue("@Emp_Date_of_joining", e.Emo_DOJ);
                cmd.Parameters.AddWithValue("@Emp_Resume", e.Emp_resume);
                cmd.Parameters.AddWithValue("@Emp_Offer_letter", e.Offer_letter);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;



            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable GetEmployees()
        {
            try
            {
                Qry = "Select * from Employee_Management";
                da = new SqlDataAdapter(Qry, con);
                dt = new DataTable("Employee_Management");
                da.Fill(dt);
                return dt;

            }catch(Exception ex)
            {
                throw ex;

            }
        }
        public DataRow GetEmployeeById(string Emp_id)
        {
            try
            {
                Qry = "Select * from Employee_Management where Emp_ID=@Emp_ID";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@Emp_ID", Emp_id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable("Employee_Management");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteEmployee(string Emp_id)
        {
            try
            {
                Qry = "Delete from Employee_Management where Emp_ID=@Emp_ID";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@Emp_ID", Emp_id);
                con.Open();
                cmd.ExecuteNonQuery();

            }catch(Exception ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }
        }
    }
}
