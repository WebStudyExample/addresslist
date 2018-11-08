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
using System.Data.SqlClient;

/// <summary>
/// operation 的摘要说明
/// </summary>
public class operation
{
	public operation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    
    public SqlDataReader GetAll()
    {
        DataBase db = new DataBase();
        return db.ExecuteDataReader("GetAlldata", null);

    }
    public string Add(string userId, string frdName, string frdPhone, string frdMobilePhone, string frdAddress, string frdQQ, string frdEmail, string frdimageurl, string createdate, string newgeneral,string sortnumber)
    {
        DataBase db = new DataBase();
        SqlParameter[] pars ={db.CreateParameter("@userId",SqlDbType.VarChar,15,userId),
                              db.CreateParameter("@frdName",SqlDbType.VarChar,10,frdName),
                              db.CreateParameter("@frdPhone",SqlDbType.VarChar,15,frdPhone),
                              db.CreateParameter("@frdMobilePhone",SqlDbType.VarChar,11,frdMobilePhone),
                              db.CreateParameter("@frdAddress",SqlDbType.VarChar,200,frdAddress),
                              db.CreateParameter("@frdQQ",SqlDbType.VarChar,20,frdQQ),
                              db.CreateParameter("@frdEmail",SqlDbType.VarChar,100,frdEmail),
                              db.CreateParameter("@frdImageUrl",SqlDbType.VarChar,200,frdimageurl),
                              db.CreateParameter("@CreateDate",SqlDbType.DateTime,(8),DateTime.Now),
                              db.CreateParameter("@Ngeneral",SqlDbType.VarChar,7000,newgeneral),
                              db.CreateParameter("@number",SqlDbType.VarChar,100,sortnumber)
                              
        };
        int rc = db.ExecuteNonQuery("AddDatalist", pars);
        switch (rc)
        {
            case -1:
                return "好友添加问题!";
            case 0:
                return "所有信息添加失败!";
            default:
                return "";
        }
}
    public string Delete(string id)
    {
        DataBase db = new DataBase();
        SqlParameter[] pars ={ db.CreateParameter("@userId", SqlDbType.Int,4,id) };
                              
        int rc = db.ExecuteNonQuery("deleteinfo", pars);
        switch (rc)
        {
            case -1:
                return "不存在此有用户!";
            case 0:
                return "删除失败!";
            default:
                return "";
        }
    
    
    }
    public string sortadd(string userID)
    {
        DataBase db = new DataBase();
        SqlParameter pars = db.CreateParameter("@userID", SqlDbType.VarChar, 15, userID);
          
        int rc = db.ExecuteNonQuery("addDatasort", pars);
        switch(rc)
        {
            case -1:
                return "用户名重复啦!";
            case 0:
                return "insert 失败!";
            default:
                return "";
        
        }
    }


}
