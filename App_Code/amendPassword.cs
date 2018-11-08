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
/// amendPassword 的摘要说明
/// </summary>
public class amendPassword
{
    public string EncryptPassword(string PasswordString,string PasswordFormat)
    {
        string EncryptPassword = "";
        if (PasswordFormat == "MD5")
        {
            EncryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
        }
        else
        {
            EncryptPassword = "";
        
        }
        return EncryptPassword;
    
    }
    public static string Show_MessageBox(string Msg_Text)
    {
        return "<script language='javascript'>alert('" + Msg_Text + "');</script>";
    
    }
}