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

public partial class Showfriend : System.Web.UI.Page
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
                InitData();
           
                if (Request.UrlReferrer != null)
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }
        }
    }
    private void InitData()
    {
        int Aid = Convert.ToInt32(Request.QueryString["UseId"]);
        Attribute ab = new Attribute();
        ab.LoadData(Aid);
        ltrUserID.Text = ab.ID.ToString();
        ltrFrdName.Text = ab.FrdName;
        ltrFrdPhone.Text = ab.FrdPhone;
        ltrFrdQQ.Text = ab.FrdQQ;
        ltrFrdMobilePhone.Text = ab.FrdMobilePhone;
        ltrFrdAddress.Text = ab.FrdAddress;
        ltrFrdEmail.Text = ab.FrdEmail;
        ltrFrdTime.Text = ab.createdate.ToLongDateString();
        ltrFrdGeneral.Text = ab.General;
        Image1.ImageUrl = "Pictures\\" + ab.FrdImageUrl;
    }
    //protected void BtnBack_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<Script Language=JavaScript>window.history.go(-2);</Script>");
    //}
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
}
