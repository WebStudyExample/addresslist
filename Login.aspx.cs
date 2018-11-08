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

public partial class Login : System.Web.UI.Page
{
    amendPassword transfer;
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
       
        transfer = new amendPassword();
        string NewPwd = this.txtUserPwd.Text.Trim();
        //string Oldpwd = transfer.EncryptPassword(NewPwd, "MD5").Trim();
        string sqlQuery = "select userId,userPwd from Users where userId='" + txtUserName.Text.Trim() + "'";
        
        //string pwdQuery = "select userPwd from Users where userId='" + txtUserName.Text + "'";
        //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["VoteConnectionString"]);
        //SqlCommand cmd = new SqlCommand(sqlQuery, conn);

        DataBase DB = new DataBase();
        DataTable dt = DB.DataSelect(sqlQuery);
        try
        {
            //conn.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();
            int Row = dt.Rows.Count;
             if (Row==0)
            {
                //string pwd1 = sdr["userPwd"].ToString();
                //string tt = transfer.EncryptPassword(pwd1, "MD5");
                //if (tt == Oldpwd)
                //    if (sdr["userPwd"].ToString() == Oldpwd)
                //{
                //    conn.Close();
                //    Session["userID"] = txtUserName.Text.Trim();
                //    Response.Redirect("TreeAddress/Tree.aspx");


                ////}
                //else
                //{
                //    //Response.Write("<script language=javascript>alert('密码错误!')</script>");



                //}
                Response.Write(amendPassword.Show_MessageBox("没有此用户!"));
                this.txtUserName.Text = "";
                this.txtUserName.Focus();
                return;



            }
            else
            {
                //Response.Write("<script language=javascript>alert('用户名错误或不存在')</script>");
                string sel_userid = dt.Rows[0]["UserID"].ToString();
                string sel_Pwd = dt.Rows[0]["userPwd"].ToString().Trim();
                string confirm_pwd = transfer.EncryptPassword(NewPwd, "MD5").Trim();
                if (sel_Pwd != confirm_pwd)
                {
                    Response.Write(amendPassword.Show_MessageBox("用户密码错误!"));
                    this.txtUserPwd.Text.Trim();
                    this.txtUserPwd.Focus();
                    return;


                }
                else
                {
                    
                    Session["userID"] = txtUserName.Text.Trim();
                    
                    Response.Redirect("TreeAddress/Tree.aspx");
                
                
                }



            }

        }
        catch (System.Exception ee)
        {
            Response.Write("script language=javascript>alert('" + ee.Message.ToString() + "')</script>");




        }
     
    }
   
}
