using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ModifyPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Session["userID"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            else
            {
                Literal1.Text = Session["userID"].ToString();

            }

        }
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtConfirmPwd.Text = "";
        txtNewPwd.Text = "";
        txtOldPwd.Text = "";
    }
 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        amendPassword transfer = new amendPassword();
        string oldPwd = this.txtOldPwd.Text.Trim();
        string NewPwd = this.txtNewPwd.Text.Trim();
        string Old_password = transfer.EncryptPassword(oldPwd, "MD5").ToString();
        string New_password = transfer.EncryptPassword(NewPwd, "MD5").ToString();
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["VoteConnectionString"]);
        SqlCommand selectcmd = new SqlCommand("select * from Users where userId='" + Session["userID"].ToString() + "'and userPwd='"+Old_password+"'", conn);
            try
            {

                conn.Open();
                SqlDataReader sdr = selectcmd.ExecuteReader();
                if (sdr.Read())
                {
                    sdr.Close();
                    SqlCommand updatecmd = new SqlCommand("update Users set userPwd='" + New_password + "' where userId='" + Session["userID"].ToString() + "'", conn);
                    int i = updatecmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write("<script language=javascript>alert('成功修改密码!')</script>");



                    }
                    else
                    {

                        Response.Write("<script language=javascript>alert('修改密码失败!')</script>");
                    }


                }
                else
                {

                    Response.Write("<script language=javascript>alert('您输入的密码错误,检查后重新输入')</script>");
                }




            }


            catch (System.Exception ee)
            {
                Response.Write("<script language=javascript>alert('" + ee.Message.ToString() + "')</script>");


            }
            finally
            {
                conn.Close();

            }
        }

   
}
