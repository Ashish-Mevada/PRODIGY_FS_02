using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace _2_task
{
    public partial class EmpoyeeManagement : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\.net\2 task\App_Data\EmployeeDB.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    txtId.Text = 
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblId.Visible = false;
            txtId.Visible = false;
            if (Page.IsValid)
            {
                  // txtId.ReadOnly = true;
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Employees values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPosition.Text + "')";
                    
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Text = "Employees add successfully";

            }
        }

      

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblId.Visible = true;
            txtId.Visible = true;
            if (Page.IsValid)
            {
               
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update Employees set [Name] ='" + txtName.Text + "',[Email] ='" + txtEmail.Text + "',[Position] ='" + txtPosition.Text + "' where [Id] ='" + txtId.Text + "'";
                cmd.ExecuteNonQuery();
                 con.Close();
                lblMessage.Text = "Employees Update successfully";

            }
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblId.Visible = true;
            txtId.Visible = true;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from Employees where [Id]='" + txtId.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            lblMessage.Text = "Delete successfully";
          //  }
        }

       
    }
}