using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlDataAdapter da = null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            if (Session["userID"] == null || Session["userID"].ToString() == "")
            {

                Page.Response.Redirect("index.aspx");
            }
            else
            {

                ltrUser.Text = Session["userID"].ToString();
            }
        }
    }
}
