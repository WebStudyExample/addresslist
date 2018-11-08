using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class infoEditSave : System.Web.UI.Page
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
                //ltrname.Text = Session["userID"].ToString();
                initData();
                dataBind();
                //if (Request.UrlReferrer != null)
                //    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }

        }
    }
    private void dataBind()
    {
        int Aid = Convert.ToInt32(Request.QueryString["UserId"]);
        Attribute ab = new Attribute();
        ab.LoadData(Aid);
        ltrID.Text = ab.ID.ToString();
        textName.Text = ab.FrdName;
        ltrname.Text = ab.FrdName;
        textPhone.Text = ab.FrdPhone;
        textQQ.Text = ab.FrdQQ;
        textMobile.Text = ab.FrdMobilePhone;
        textAddress.Text = ab.FrdAddress;
        textEmail.Text = ab.FrdEmail;
        textGeneral.Text = ab.General;
    }
    private void initData()
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
    protected void Button_Click(object sender, EventArgs e)
    {
        //Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    protected void BtnAdddata_Click(object sender, EventArgs e)
    {
        string sql = " UPDATE AddressList SET frdName ='" + textName.Text + "', "
            + "frdPhone ='" + textPhone.Text + "', "
            + "frdMobilePhone ='" + textMobile.Text + "', "
            + "frdAddress='" + textAddress.Text + "', "
            + "frdQQ='" + textQQ.Text + "', "
            + "frdEmail = '" + textEmail.Text + "', "
            + "CreateDate='" + DateTime.Now.ToString() + "', "
            + "General ='" + textGeneral.Text + "', "
            +"Sortnumber='"+DDLsrot.SelectedValue+"' "
            + " where id=" + ltrID.Text;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Write("<script language=javascript>alert('好友资料修改成功!')</script>");
    }
}
