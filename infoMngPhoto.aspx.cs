using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class infoMngPhoto : System.Web.UI.Page
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
                pnlUpdata.Visible = false;
            }
        }
    }
    private void dataBind()
    {
        string ID = Session["userId"].ToString();
        string sql = "select * from addresslist where userId='" + ID + "' order by id desc";
        DataBase DB = new DataBase();
        DataSet ds = DB.DataAll(sql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "id" };
        GridView1.DataBind();
        return;


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlUpdata.Visible = true;
        int uid = Convert.ToInt32(GridView1.SelectedValue.ToString());
        string frdname = DataBase.Getfield("select frdname from addresslist where id=" + uid, "frdname");
        ltrfrdinf.Text = frdname.ToString();

    }
    protected void BtnPhoto_Click(object sender, EventArgs e)
    {


        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int uid = Convert.ToInt32(GridView1.SelectedValue.ToString());

        string imgname = DataBase.Getfield("select frdImageUrl from AddressList where id=" + uid, "frdImageUrl");
        if (imgname != "")
        {
            imgname = imgname.Substring(imgname.LastIndexOf("/") + 1);
            File.Delete(Server.MapPath("./Pictures") + "//" + imgname);
        }
        string fileName = Uploadpri.PostedFile.FileName;
        string fileName2 = Uploadpri.PostedFile.FileName.Substring(fileName.LastIndexOf("\\") + 1);
        string type1 = fileName2.Substring(fileName2.LastIndexOf(".") + 1);
        string typeToLower = type1.ToLower();
        if (typeToLower == "bmp" || typeToLower == "gif" || typeToLower == "jpg" || typeToLower == "")
        {

            //DateTime time = new DateTime();
            string newtime = System.DateTime.Now.ToString();
            string uploadName = Uploadpri.Value.Trim();
            string pictureName = "";
            if (uploadName != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);
                pictureName = System.DateTime.Now.Ticks.ToString() + suffix;
            }
            string sql2 = "update addresslist set frdImageUrl='" + pictureName + "',CreateDate='" + newtime + "' where id=" + uid;
            SqlCommand cmd = new SqlCommand(sql2, conn1);
            conn1.Open();
            try
            {
                cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                ltrMsg.Text = "更新成功!";
                

            }
            catch (SqlException)
            {
                ltrMsg.Text = "更新失败!";
                

            }
            conn1.Close();
            dataBind();
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
    }
    protected void Btninf_Click(object sender, EventArgs e)
    {
        Response.Redirect("Showfriend.aspx");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        dataBind();
    }
}
