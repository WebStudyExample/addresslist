using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["userID"] = "admin";
        if (Session["userID"] != null)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Main.aspx");
        }
    }
    amendPassword transfer;
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        transfer = new amendPassword();
        string NewPwd = this.PassWord.Text.Trim();
        string sqlQuery = "select userId,userPwd from Users where userId='" + UserName.Text.Trim() + "'";
        DataBase DB = new DataBase();
        DataTable dt = DB.DataSelect(sqlQuery);
        try
        {
            int Row = dt.Rows.Count;
            if (Row == 0)
            {
                Response.Write(amendPassword.Show_MessageBox("没有此用户!"));
                this.UserName.Text = "";
                this.UserName.Focus();
                return;
            }
            else
            {
                string sel_userid = dt.Rows[0]["UserID"].ToString();
                string sel_Pwd = dt.Rows[0]["userPwd"].ToString().Trim();
                string confirm_pwd = transfer.EncryptPassword(NewPwd, "MD5").Trim();
                if (sel_Pwd != confirm_pwd)
                {
                    Response.Write(amendPassword.Show_MessageBox("用户密码错误!"));
                    this.PassWord.Text.Trim();
                    this.PassWord.Focus();
                    return;
                }
                else
                {
                    Session["userID"] = UserName.Text.Trim();
                    Response.Redirect("Main.aspx");
                }
            }
        }
        catch (System.Exception ee)
        {
            Response.Write("script language=javascript>alert('" + ee.Message.ToString() + "')</script>");
        }
    }
}