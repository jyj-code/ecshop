using ShopNum1.Common;
using ShopNum1.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_backupDB : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected LinkButton ButtonBackup;
	protected HtmlForm form1;
	public List<string[]> bakinfo = new List<string[]>();
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (this.Page.IsPostBack)
		{
		}
		if (this.Page.Request["action"] != null && this.Page.Request["action"] == "download")
		{
			string text = this.Page.Request["file"];
			base.Response.ContentType = "application/octet-stream";
			base.Response.Clear();
			base.Response.AddHeader("content-disposition", "attachment; filename=" + text);
			base.Response.ContentType = "application/octet-stream";
			base.Response.WriteFile(base.Server.MapPath("/App_Data/") + text);
			base.Response.End();
		}
		else
		{
			if (this.Page.Request["action"] != null && this.Page.Request["action"] == "del")
			{
				string text = this.Page.Request["file"];
				File.Delete(base.Server.MapPath("/App_Data/") + text);
			}
			if (this.Page.Request["action"] != null && this.Page.Request["action"] == "reduction")
			{
				string text = this.Page.Request["file"];
				string text2 = text.Substring(0, text.LastIndexOf('_'));
				string text3 = "select spid from master..sysprocesses where dbid=db_id( '" + text2 + "') ";
				DataTable dataTable = DatabaseExcetue.ReturnDataTable(text3.ToString());
				string connectionString = " Data Source=localhost;Initial Catalog=master;User Id=sa;Password=sa;Connect TimeOut=6000;Persist Security Info=True;";
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
				{
					string cmdText = " use master kill " + dataTable.Rows[i][0].ToString();
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
				string cmdText2 = string.Concat(new string[]
				{
					"backup log ",
					text2,
					" to disk='",
					base.Server.MapPath("/App_Data/"),
					text,
					"'  restore database ",
					text2,
					"  from disk='",
					base.Server.MapPath("/App_Data/"),
					text,
					"'"
				});
				try
				{
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					MessageBox.Show("还原数据库成功。");
					SqlConnection.ClearAllPools();
					sqlConnection.Close();
				}
				catch (Exception)
				{
					MessageBox.Show("还原数据库失败");
				}
			}
			this.bakinfo = this.GetDBfile();
		}
	}
	public List<string[]> GetDBfile()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(this.Page.Server.MapPath("/App_Data"));
		FileInfo[] files = directoryInfo.GetFiles();
		List<string[]> list = new List<string[]>();
		FileInfo[] array = files;
		for (int i = 0; i < array.Length; i++)
		{
			FileInfo fileInfo = array[i];
			Regex regex = new Regex(".bak");
			if (regex.IsMatch(fileInfo.Name.ToLower()))
			{
				list.Add(new string[]
				{
					fileInfo.Name,
					fileInfo.CreationTime.ToString()
				});
			}
		}
		return list;
	}
	protected void ButtonBackup_Click(object sender, EventArgs e)
	{
		string text = DatabaseExcetue.GetConnstring().Split(new char[]
		{
			';'
		})[1].Split(new char[]
		{
			'='
		})[1];
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Concat(new string[]
		{
			" backup database [",
			text,
			"] to disk='",
			this.Page.Server.MapPath("/App_Data/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak"),
			"';"
		}));
		try
		{
			DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
			this.bakinfo = this.GetDBfile();
			MessageBox.Show("备份数据库成功");
		}
		catch (Exception)
		{
			MessageBox.Show("备份数据库失败");
		}
	}
}
