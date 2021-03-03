using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CompanyInfo.Model;



namespace CompanyInfo.DAL
{
    public class CompanyDAO
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-GCI2Q723\SQLEXPRESS01;Initial Catalog=Company_Info;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        string Qry = null;

        public bool AddCompany(CompanyDetails c)
        {
            try
            {
                Qry = "Insert into Company_Details values(@Company_ID,@Company_Name,@Company_Address,@Company_Contact,@Company_logo)";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@Company_ID", c.Cmp_id);
                cmd.Parameters.AddWithValue("@Company_Name", c.Cmp_name);
                cmd.Parameters.AddWithValue("@Company_Address", c.Cmp_address);
                cmd.Parameters.AddWithValue("@Company_Contact", c.Cmp_Contact);
                cmd.Parameters.AddWithValue("@Company_logo", c.Cmp_logo);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                
            }

        }
        public DataTable GetCompanies()
        {
            try
            {
                Qry = "Select * from Company_Details ";
                da = new SqlDataAdapter(Qry, con);
                dt = new DataTable("Company_Details");
                da.Fill(dt);
                return dt;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow GetCompanyById(string Company_ID)
        {
            try
            {

                Qry = "Select * from Company_Details where Company_ID =@Company_ID";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                
                
                da = new SqlDataAdapter(cmd);
                dt = new DataTable("Company_Details");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;

            } catch (Exception ex)
            {
                throw ex;
            }finally
            {
                con.Close();
            }

        }
        public void DeleteCompany(string Cmp_id)
        {
            try
            {
                Qry = "Delete from Company_Details where Company_ID =@Company_ID";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@Company_ID",Cmp_id);
                con.Open();
                cmd.ExecuteNonQuery();
             }
            catch (Exception ex)
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
