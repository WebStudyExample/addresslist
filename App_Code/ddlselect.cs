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
/// ddlselect 的摘要说明
/// </summary>
public class ddlselect
{
    DataBase db = new DataBase();
	public ddlselect()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet GetsortData(string newid)
    {
        string strSQL = "select * from SortTable where clientID='"+newid+"'";
        return db.GetDataSet(strSQL);
    }
    public DataTable GetAddresstableData(string newid,string Nuser)
    {
        string strSQl = "select distinct(a.id),a.userID,a.frdname,a.frdphone,a.frdMobilePhone,a.frdAddress,a.frdQQ,a.frdEmail,a.frdImageUrl,a.CreateDate,a.general,b.sortname from addressList as a inner join sortTable as b on a.sortnumber=b.sortnumber where a.Sortnumber='" + newid + "' and a.userId='" + Nuser + "' order by id desc";
        return db.GetDataTable(strSQl);
    
    }
    public DataRow GetaddressDatarow(string newid,string Nuser)
    { 
    string strSQL="select * from addressList where Sortnumber='"+newid+"' and userId='"+Nuser+"'";
    return db.GetDataRow(strSQL);
    }
}
