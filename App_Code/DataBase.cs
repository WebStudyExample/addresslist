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
/// DataBase 的摘要说明
/// </summary>
public class DataBase
{
   
   
	public DataBase()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    protected SqlConnection Connection;

    public DataTable DataSelect(string Sqltext)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
       
        SqlDataAdapter datap = new SqlDataAdapter(Sqltext, con);
        DataTable dt = new DataTable();
        datap.Fill(dt);
       
        return dt;
    
    
    
    }
    public DataSet DataAll(string sqltxt)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        SqlDataAdapter datap = new SqlDataAdapter(sqltxt, con);
        DataSet ds = new DataSet();
        datap.Fill(ds);
        return ds;
    
    
    }
    private SqlConnection CreateConnection()
    {
        SqlConnection conn = new SqlConnection();
       
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        return conn;


    }
    private SqlParameter CreateReturnValuePar()
    { 
    SqlParameter par=CreateParameter("RetrunValue",SqlDbType.Int,4,null);
        par.Direction=ParameterDirection.ReturnValue;
        return par;
    
    }
    private SqlCommand CreateCommand(string procName, params SqlParameter[] pars)
    {
        SqlCommand cmd = new SqlCommand(procName, CreateConnection());
        cmd.CommandType = CommandType.StoredProcedure;
        if (pars != null)
        {
            foreach (SqlParameter par in pars)
            {
                cmd.Parameters.Add(par);
            
            }
        
        
        
        }
        cmd.Parameters.Add(CreateReturnValuePar());
        return cmd;
    
    }
    public int ExecuteNonQuery(string ProcName, params SqlParameter[] Pars)
    {
        SqlCommand cmd = CreateCommand(ProcName, Pars);
        cmd.Connection.Open();
       
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        
        return int.Parse(cmd.Parameters["RetrunValue"].Value.ToString());
    
    
    
    }
    public SqlDataReader ExecuteDataReader(string ProcName, params SqlParameter[] Pars)
    {
        SqlCommand cmd = CreateCommand(ProcName, Pars);
        cmd.Connection.Open();
        return cmd.ExecuteReader(CommandBehavior.CloseConnection);
    
    
    
    }

    public SqlParameter CreateParameter(string ParName, SqlDbType DbType, int Size, object ParValue)
    {
        SqlParameter par = new SqlParameter();
        par.Value = ParValue;
        par.ParameterName = ParName;
        par.SqlDbType = DbType;
        par.Size = Size;
        return par;
    
    }
    public static string Getfield(string sql, string field)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                string str = sdr[field].ToString();
                sdr.Close();
                return str;
            }
            catch
            {
                return "获取信息失败！";
            }
            finally
            {
                con.Close();
            }
        
        
        
        
    
    
    }
    public static bool DataTypes(int val, string sval, string procname)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
            SqlCommand cmd = new SqlCommand(procname, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter s = new SqlParameter(sval, SqlDbType.Int, 4);
            s.Value = val;
            cmd.Parameters.Add(s);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            
            }
            finally
            {
                con.Close();            
            
            }
        
        
        }
    public DataRow GetDataRow(String SqlString)
    {
        DataSet dataset = DataAll(SqlString);
        dataset.CaseSensitive = false;
        if (dataset.Tables[0].Rows.Count > 0)
        {
            return dataset.Tables[0].Rows[0];


        }
        else
        {
            return null;
        
        
        }
    
    }
    public bool Execute(string sql)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        SqlCommand cmd = new SqlCommand(sql, con);
        
        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;

        }
        finally
        {
            con.Close();

        }
    
    }
    public DataSet GetDataSet(String Sqlstring)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(Sqlstring,con);
        DataSet dataset = new DataSet();
        adapter.Fill(dataset);
        con.Close();
        return dataset;
    }
    public DataTable GetDataTable(String SqlString)
    {
        DataSet dataset = GetDataSet(SqlString);
        dataset.CaseSensitive = false;
        return dataset.Tables[0];

    }
 
    
    
    }
  
