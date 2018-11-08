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
/// GetValue 的摘要说明
/// </summary>
public class GetValue
{
	public GetValue()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string ValidateDataRow_S(DataRow row, string colname)
    {
        if (row[colname] != DBNull.Value)
            return row[colname].ToString();
        else
            return System.String.Empty;

    }
    public static int ValidataDataRow_I(DataRow row, string colname)
    {
        if (row[colname] != DBNull.Value)
            return Convert.ToInt32(row[colname]);
        else
            return System.Int32.MinValue;


    }
    public static DateTime ValidateDataRow_T(DataRow row, string colname)
    {
        if (row[colname] != DBNull.Value)
            return Convert.ToDateTime(row[colname]);
        else
            return System.DateTime.MinValue;
    
    }
}
