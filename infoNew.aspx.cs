using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class infoNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userID"] == null || Session["userID"].ToString() == "")
            {

                Page.Response.Redirect("index.aspx");
            }
            else
            {
                //dataBind();
                DDLData();
                lblID.Text = Session["userID"].ToString();

                //detailsAllBind();
            }
        }
    }

    protected void BtnAdddata_Click(object sender, EventArgs e)
    {
        string fileName = Uploadpri.PostedFile.FileName;
        string fileName2 = Uploadpri.PostedFile.FileName.Substring(fileName.LastIndexOf("\\") + 1);
        string type1 = fileName2.Substring(fileName2.LastIndexOf(".") + 1);
        string typeToLower = type1.ToLower();
        if (typeToLower == "bmp" || typeToLower == "gif" || typeToLower == "jpg" || typeToLower == "")
        {

            operation op1 = new operation();
            DateTime time = new DateTime();
            string uploadName = Uploadpri.Value.Trim();
            string pictureName = "";



            if (uploadName != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);
                pictureName = System.DateTime.Now.Ticks.ToString() + suffix;

            }
            string msg = op1.Add(lblID.Text, textName.Text, textPhone.Text, textMobile.Text, textAddress.Text, TextQQ.Text, textEmail.Text, pictureName, time.ToString(), txtgeneral.Text, DDLsrot.SelectedValue.ToString());
            if (msg == "")
            {
                //lblmsg.Text = "好友资料添加成功!";
                //lblmsg.Style["color"] = "red";
                Response.Write("<script language=javascript>alert('好友资料添加成功!')</script>");


            }
            else
            {
                //lblmsg.Text = "好友添加失败!";
                //lblmsg.Style["color"] = "red";
                Response.Write("<script language=javascript>alert('好友添加失败或好友名重复!')</script>");
            }

            if (uploadName != "")
            {
                string path = Server.MapPath(".\\Pictures\\");
                Uploadpri.PostedFile.SaveAs(path + pictureName);
            }

        }
        else
        {
            Response.Write("<script language=javascirpt type='text/javascript'>");
            Response.Write("window.alert('请上传正确文件格式!')");
            Response.Write("</script>");

        }

        //Response.Redirect("GridViewUsage.aspx");
        textAddress.Text = "";
        textEmail.Text = "";
        textMobile.Text = "";
        textName.Text = "";
        textPhone.Text = "";
        TextQQ.Text = "";
        txtgeneral.Text = "";
        this.textName.Focus();
        //dataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        textAddress.Text = "";
        textEmail.Text = "";
        textMobile.Text = "";
        textName.Text = "";
        textPhone.Text = "";
        TextQQ.Text = "";
        this.textName.Focus();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("GridViewUsage.aspx");
    }

    private void DDLData()
    {
        string id = Session["userID"].ToString();
        string sql = "select * from sorttable where clientID='" + id + "'";
        DataBase db = new DataBase();
        DataSet ds = db.GetDataSet(sql);

        DDLsrot.DataSource = ds;
        DDLsrot.DataValueField = "sortnumber";
        DDLsrot.DataTextField = "sortname";
        DDLsrot.DataBind();
    }
}
