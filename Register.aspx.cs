using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

public partial class Register : System.Web.UI.Page 
{
    private ArrayList alYear;
    private ArrayList alMonth;
    private ArrayList alDay;
    operation op = new operation();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (this.Session["userID"] = null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        //else
        //{
            if (!this.IsPostBack)
            {
                InitDate();
            
            
            }
        
    //    }
        }
    private void InitDate()
    {
        alYear = new ArrayList();
        alMonth = new ArrayList();
        alDay = new ArrayList();
        for (int i = 1950; i < 2100; i++)
            alYear.Add(i.ToString());
        for (int i = 1; i <= 12; i++)
            alMonth.Add(i.ToString());
        for (int i = 1; i < 32; i++)
            alDay.Add(i.ToString());
        ddlYear.DataSource = alYear;
        ddlYear.DataBind();
        ddlmonth.DataSource = alMonth;
        ddlmonth.DataBind();
        ddlDay.DataSource = alDay;
        ddlDay.DataBind();

    
    
    }
    protected void btnValidate_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "" || txtPwd.Text != "" || txtPwd2.Text != "" || txtUname.Text != "")
        {
            int i = userNameValidate();
        }
        else
        {
            Response.Write("<script language=javascript>alert('注意：带**号的内容为必填项，否则无法完成注册')</script>");
        }
    }
    private int userNameValidate()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["VoteConnectionString"]);
        SqlCommand cmd = new SqlCommand("select * from Users where userID='" + txtName.Text.Trim() + "'",conn);
        int i = 0;
        try
        {
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                i = 1;
                Response.Write("<script language=javascript>alert(' 此用户名已存在,请输入其他用户名!')</script>");
                //lblMessage.Text = "此用户名已存在,请输入其他用户名!";
                //lblMessage.Style["color"] = "red";



            }
            else
            {

                lblMessage.Text = "此用户名可用！";
                lblMessage.Style["color"] = "red";

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
        return i;

    
    
    
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        amendPassword transfer=new amendPassword();

        string NewPwd = this.txtPwd.Text.Trim();
        string pwd = transfer.EncryptPassword(NewPwd, "MD5").Trim();
        //string pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(NewPwd, "MD5");
     
        int i = userNameValidate();
        if (i == 0)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["VoteConnectionString"]);
            SqlCommand cmd = new SqlCommand("insert into Users Values(@userId,@userPwd,@userName,@userSex,@userBirth,@userPhone,@userMobilePhone,@userCode,@userAddress,@userEmail,@userQQ)", conn);
            cmd.Parameters.Add("@userPwd", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@userId", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@userSex", SqlDbType.VarChar, 2);
            cmd.Parameters.Add("@userBirth", SqlDbType.VarChar, 8);
            cmd.Parameters.Add("@userPhone", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@userMobilePhone", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@userCode", SqlDbType.VarChar, 6);
            cmd.Parameters.Add("@userAddress", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@userEmail", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@userQQ", SqlDbType.VarChar, 20);
            cmd.Parameters["@userid"].Value = txtName.Text;
            cmd.Parameters["@userPwd"].Value = pwd;
            cmd.Parameters["@userName"].Value = txtUname.Text;
            cmd.Parameters["@userSex"].Value = rltSex.SelectedItem.Text;
            cmd.Parameters["@userBirth"].Value = Convert.ToDateTime(ddlYear.SelectedValue + "-" + ddlmonth.SelectedValue + "-" + ddlDay.SelectedValue);
            cmd.Parameters["@userPhone"].Value = txtUtel2.Text;
            cmd.Parameters["@userMobilePhone"].Value = txtUtel3.Text;
            cmd.Parameters["@userCode"].Value = txtUzip.Text;
            cmd.Parameters["@userAddress"].Value = txtUaddr.Text;
            cmd.Parameters["@userEmail"].Value = txtUemail.Text;
            cmd.Parameters["@userQQ"].Value = txtUQQ.Text;
            try
            {
                conn.Open();
                string msg = op.sortadd(txtName.Text);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0 && msg=="")
                {
                    lblshow.Style["color"] = "red";
                  
                    //Response.Redirect("Login.aspx");
                    //Response.Write("注册成功，请等待2秒......");
                    lblshow.Text = "注册成功，请等待2秒......<script language=javascript>"
                    +"window.setTimeout(\"location.href='Login.aspx'\",2000);"
                    + "</script>";
                    
                    
                    
                    //Response.Write("<script language=javascript>window.setTimeout(\"location.href='Login.aspx'\",2000);</script>");

                }
                else
                {
                    Response.Write("<script language=javascript>alert('注册失败!')</script>");

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
    protected void Btnland_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Default.aspx");
    }
}
