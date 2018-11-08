using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class infoEdit : System.Web.UI.Page
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
                dataBind();
            }
        }
    }
   private void dataBind()
    {
        string ID = Session["userId"].ToString();

        string sql2 = "select * from addresslist where userId='" + ID + "' order by id desc";
        DataBase DB2 = new DataBase();
        DataSet ds2 = DB2.DataAll(sql2);
        GridView1.DataKeyNames = new string[] { "id" };
        GridView1.DataSource = ds2;
        GridView1.DataBind();
        return;
    }
   protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
       GridView1.PageIndex = e.NewPageIndex;
       dataBind();
   }
}
