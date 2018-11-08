using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class infoDelete : System.Web.UI.Page
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
            if (GridView1.Rows.Count == 0)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "script", "alert('没有数据!');", true);
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int yid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        string imgname = DataBase.Getfield("select frdImageUrl from AddressList where id=" + yid, "frdImageUrl");
        if (imgname != "")
        {
            if (DataBase.DataTypes(yid, "@id", "Deletephoto"))
            {
                imgname = imgname.Substring(imgname.LastIndexOf("/") + 1);
                File.Delete(Server.MapPath("./Pictures") + "//" + imgname);
                Response.Write("<script language=javascirpt type='text/javascript'>");
                Response.Write("window.alert('图片及信息删除成功！')");
                Response.Write("</script>");

            }
            else
            {
                Response.Write("<script language=javascirpt type='text/javascript'>");
                Response.Write("window.alert('图片删除失败！')");
                Response.Write("</script>");

            }

        }
        else
        {
            imgname = "空的哦！";
            File.Delete(Server.MapPath("./Pictures") + "//" + imgname);
            Response.Write("<script language=javascirpt type='text/javascript'>");
            Response.Write("window.alert('图片及信息删除成功！')");
            Response.Write("</script>");

        }

        string sql = "delete from addresslist where id=" + yid;
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        dataBind();
        conn.Close();


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        dataBind();
    }
}
