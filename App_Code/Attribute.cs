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
/// Attribute 的摘要说明
/// </summary>
public class Attribute
{
	public Attribute()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    private int _ID;
    private string _userID;
    private string _frdName;
    private string _frdPhone;
    private string _frdMobilePhone;
    private string _frdAddress;
    private string _frdQQ;
    private string _frdEmail;
    private string _frdImageUrl;
    private DateTime CreateDate;
    private string _general;

    private bool _exist;

    public int ID
    {
        set { this._ID = value; }
        get { return this._ID; }
    
    }
    public string UserID
    {
        set { this._userID=value; }
        get { return this._userID; }
    
    }
    public string FrdName
    {
        set { this._frdName = value; }
        get { return this._frdName; }
    
    }
    public string FrdPhone
    {
        set { this._frdPhone = value; }
        get { return this._frdPhone; }
    
    }
    public string FrdMobilePhone
    {
        set { this._frdMobilePhone = value; }
        get { return this._frdMobilePhone; }
    
    }
    public string FrdAddress
    {
        set { this._frdAddress = value; }
        get { return this._frdAddress; }
    }
    public string FrdQQ
    {
        set { this._frdQQ = value; }
        get { return this._frdQQ; }
    
    }
    public string FrdEmail
    {
        set { this._frdEmail = value; }
        get { return this._frdEmail; }
    
    }
    public string FrdImageUrl
    {
        set { this._frdImageUrl = value;}
        get { return this._frdImageUrl; }
    }
    public DateTime createdate
    {
        set { this.CreateDate = value; }
        get { return this.CreateDate; }
    }
    public bool Exist
    {
        get { return this._exist; }
    
    }
    public string General
    {
        set { this._general = value; }
        get { return this._general; }
    
    }
    #region 方法
    public void LoadData(int Aid)
    {
        DataBase db = new DataBase();
        string sql = "";
        sql = "Select * from AddressList where id= " + Aid;
        DataRow dr = db.GetDataRow(sql);
        if (dr != null)
        {
            this._ID = GetValue.ValidataDataRow_I(dr, "id");
            this._userID = GetValue.ValidateDataRow_S(dr, "userId");
            this._frdQQ = GetValue.ValidateDataRow_S(dr, "frdQQ");
            this._frdPhone = GetValue.ValidateDataRow_S(dr, "frdPhone");
            this._frdName = GetValue.ValidateDataRow_S(dr, "frdName");
            this._frdMobilePhone = GetValue.ValidateDataRow_S(dr, "frdMobilePhone");
            this._frdImageUrl = GetValue.ValidateDataRow_S(dr, "frdImageUrl");
            this._frdEmail = GetValue.ValidateDataRow_S(dr, "frdEmail");
            this._frdAddress = GetValue.ValidateDataRow_S(dr, "frdAddress");
            this.CreateDate = GetValue.ValidateDataRow_T(dr, "CreateDate");
            this._general = GetValue.ValidateDataRow_S(dr, "General");

            this._exist = true;
        }
        else
        { this._exist = false; }
    
    }

    #endregion 方法 
}
