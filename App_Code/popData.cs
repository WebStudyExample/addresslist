/**********
 * 修改时间：2009年1月6日
 * 作者：周炜
 * ********/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// popData 的摘要说明
/// </summary>
public class popData
{
    ddlselect newddl = new ddlselect();
	public popData()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Getpopmostly(string nid)
    {
        return newddl.GetsortData(nid);
    }
    public DataTable GetalladdresslistnewData(string nid,string nuser)
    {
        return newddl.GetAddresstableData(nid,nuser);
    }
    public DataRow GetaddersslistData(string newid, string nuser)
    {
        return newddl.GetaddressDatarow(newid, nuser);
    }
}
