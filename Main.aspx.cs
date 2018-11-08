using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    popData pd = new popData();
    DataBase db = new DataBase();
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
                LoadData();
                alldata();

            }
        }
    }
    public void LoadData()
    {
        string id = Session["userID"].ToString();
        this.DDLmostly.DataSource = pd.Getpopmostly(id);
        this.DDLmostly.DataTextField = "sortname";
        this.DDLmostly.DataValueField = "sortnumber";
        DDLmostly.AutoPostBack = true;
        this.DDLmostly.DataBind();
    }
    protected void DDLmostly_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = DDLmostly.SelectedValue.ToString();
        string nid = Session["userID"].ToString();
        DataTable dt = pd.GetalladdresslistnewData(id, nid);
        GVdata.DataSource = dt;
        GVdata.DataBind();

    }
    public void alldata()
    {
        string nid = Session["userID"].ToString();
        string sql = "select distinct(a.id),a.userID,a.frdname,a.frdphone,a.frdMobilePhone,a.frdAddress,a.frdQQ,a.frdEmail,a.frdImageUrl,a.CreateDate,a.general,b.sortname from addresslist as a right join sorttable as b on a.Sortnumber=b.sortnumber where a.userid='" + nid + "' order by a.id desc";

        DataSet ds = db.GetDataSet(sql);
        GVdata.DataSource = ds;
        GVdata.DataBind();

    }



    protected void GVdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GVdata.PageIndex = e.NewPageIndex;
        alldata();
    }

    protected void Btndata_Click(object sender, EventArgs e)
    {
        alldata();

    }
}
