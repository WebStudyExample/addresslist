using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class infoShow : System.Web.UI.Page
{
    SqlConnection conn;

    string sql1 = "select [id],selectname from listname";
    string sql2 = "select * from addresslist where ";
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
              //  ddldataBind();

                dataBind();
            }
        }
    }
    private void dataBind()
    {

        string Myid = Session["UserID"].ToString();
        string sql = "select * from addresslist where userID='" + Myid + "'order by id desc ";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds, "addressTable");
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "id" };
        GridView1.DataBind();
        conn.Close();



    }
    //private void ddldataBind()
    //{
    //    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //    SqlDataAdapter da = new SqlDataAdapter(sql1, conn);
    //    DataSet ds = new DataSet();
    //    conn.Open();
    //    da.Fill(ds, "DDLTable");
    //    DropDownList1.DataSource = ds;
    //    DropDownList1.DataTextField = "selectname";

    //    DropDownList1.DataBind();
    //    conn.Close();



    //}
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        string uid = Session["userID"].ToString();
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string selectID = DropDownList1.SelectedValue.ToString();
        string txtinfo = TextBox1.Text.Trim();
        if (selectID == "好友姓名")
        {
            sql2 += "frdName like '%" + txtinfo + "%' and userId='" + uid + "'";

        }
        else if (selectID == "地址")
        {

            sql2 += "frdAddress like '%" + txtinfo + "%' and userId='" + uid + "'";

        }
        else if (selectID == "好友QQ号")
        {
            sql2 += "frdQQ like '" + txtinfo + "' and userId='" + uid + "'";



        }
        else
        {

            sql2 += "frdMobilePhone like '" + txtinfo + "' and userId='" + uid + "'";

        }
        conn.Open();
        //SqlCommand cmd = new SqlCommand(sql2, conn);
        //SqlDataReader dr = cmd.ExecuteReader();
        SqlDataAdapter da = new SqlDataAdapter(sql2, conn);
        DataSet ds = new DataSet();
        da.Fill(ds, "selectData");

        GridView1.DataSource = ds;


        GridView1.DataBind();
        if (GridView1.Rows.Count == 0)
        {
            ltrMsg.Text = "未找到您所需要的信息！";
           

        }
        else
        {
            ltrMsg.Text = "搜索完毕！";
            

        }
        conn.Close();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        dataBind();
    }
}
