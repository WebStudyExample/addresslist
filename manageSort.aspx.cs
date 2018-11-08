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

public partial class manageSort : System.Web.UI.Page
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
        string id = Session["userID"].ToString();
        string sql = "select * from sorttable where clientID='" + id + "' order by wid asc";
        DataBase db = new DataBase();
        DataSet ds = db.DataAll(sql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "wid" };
        GridView1.DataBind();
        return;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        dataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        dataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        dataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Insert")
        {
            string newname = ((TextBox)GridView1.FooterRow.Cells[0].FindControl("txtnewname")).Text.Trim();
            string newnumber = ((TextBox)GridView1.FooterRow.Cells[1].FindControl("txtnewno")).Text.Trim();
            int i = sortnumberValidate(newnumber);
            if (i == 0)
            {




                if (newname == "" || newnumber == "")
                {
                    ltrMsg.Text = "注意不能为空！";
                    
                    return;
                }
                else
                {

                    string newid = Session["useriD"].ToString();
                    string sql = "insert into sorttable(sortname,sortnumber,clientID) values ('" + newname + "','" + newnumber + "','" + newid + "')";
                    DataBase db = new DataBase();
                    if (db.Execute(sql))
                    {
                        ltrMsg.Text = "数据添加成功!";
                        
                        GridView1.EditIndex = -1;
                        dataBind();
                    }
                    else
                    {
                        ltrMsg.Text = "数据添加失败!";
                        

                    }
                }

            }

        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
        int nid = (int)GridView1.DataKeys[e.RowIndex].Value;
        string sql = "delete from sorttable where wid='" + nid + "'";
        DataBase db = new DataBase();
        if (db.Execute(sql))
        {
            ltrMsg.Text = "数据删除成功!";
           
            GridView1.EditIndex = -1;
            dataBind();
        }
        else
        {
            ltrMsg.Text = "数据删除失败!";
            

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int nid = (int)GridView1.DataKeys[e.RowIndex].Value;

        string newname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtname")).Text.Trim();
        //string newnumber = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtnumber")).Text.Trim();
        string sql = "update sorttable set sortname='" + newname + "' where wid='" + nid + "'";
        
        DataBase db = new DataBase();
        if (db.Execute(sql))
        {
            ltrMsg.Text = "数据修改成功！";
           
            GridView1.EditIndex = -1;
            dataBind();

        }
        else
        {
            ltrMsg.Text = "数据修改失败！";
            
        }
    }
    private int sortnumberValidate(string sid)
    {
        string nid = Session["userid"].ToString();
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["VoteConnectionString"]);
        SqlCommand cmd = new SqlCommand("select * from sorttable where sortnumber='"+sid+"' and clientID='" + nid + "'", conn);
        int i = 0;
        try
        {
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                i = 1;
                Response.Write("<script language=javascript>alert(' 不能添加重复编号!')</script>");
            }
            else
            {
                ltrMsg.Text = "可以添加信息！";
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType==DataControlRowType.DataRow&&e.Row.RowIndex==0)
        //{
            
        //        //注意：第一行为默认项，只可修改编号称不可删除！";
              
        //    Button bt = (Button)e.Row.Cells[3].FindControl("Btndelete");
        //    bt.Visible = false;              
            
        //}
    }
}
