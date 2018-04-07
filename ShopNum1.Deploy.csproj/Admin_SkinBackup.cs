using ShopNum1.Common;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SkinBackup : PageBase, IRequiresSessionState
{
	protected Image ImageCurrentSkin;
	protected Label LabelFolderNameValue;
	protected Label LabelNameValue;
	protected Label LabelDescriptionValue;
	protected Button ButtonBackUp;
	protected Label LabelSkins;
	protected DataList DataListShow;
	protected HtmlForm form1;
	private DataTable dt;
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.method_6();
		}
	}
	protected DataTable CreateSkinTable()
	{
		this.dt = new DataTable();
		this.dt.Rows.Clear();
		DataColumn dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.Guid");
		dataColumn.ColumnName = "Guid";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "Name";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "createTime";
		this.dt.Columns.Add(dataColumn);
		return this.dt;
	}
	private void method_5()
	{
		try
		{
			string[] files = Directory.GetFiles(base.Server.MapPath("~/BackUp/"), "*.Zip");
			DataTable dataTable = this.CreateSkinTable();
			for (int i = 0; i < files.Length; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Guid"] = Guid.NewGuid();
				FileInfo fileInfo = new FileInfo(files[i]);
				dataRow["createTime"] = fileInfo.CreationTime.ToString("yyyy-MM-dd hh-mm-ss");
				dataRow["Name"] = fileInfo.Name.Split(new char[]
				{
					'.'
				})[0].Split(new char[]
				{
					'('
				})[0];
				dataTable.Rows.Add(dataRow);
			}
			this.DataListShow.DataSource = dataTable;
			this.DataListShow.DataBind();
		}
		catch
		{
		}
	}
	protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
	{
		if (e.CommandName == "select")
		{
			Label label = (Label)e.Item.FindControl("LabelNameValue");
			Label label2 = (Label)e.Item.FindControl("LabelCreateTime");
			int num = 1;
			try
			{
				try
				{
					Themes.DeleteFolder(base.Server.MapPath("~/Main/Themes/Skin_Default"));
					Directory.CreateDirectory(base.Server.MapPath("~/Main/Themes/Skin_Default"));
					if (Directory.Exists(base.Server.MapPath("~/Main/Themes/Skin_Default")))
					{
						string path = string.Concat(new string[]
						{
							"~/BackUp/",
							label.Text,
							"(",
							label2.Text.ToString(),
							").zip"
						});
						string zipedFolder = this.Page.Server.MapPath("~/Main/Themes/");
						string text = string.Concat(new string[]
						{
							this.Page.Server.MapPath("~/Main/Themes/Skin_Default/"),
							label.Text,
							"(",
							label2.Text.ToString(),
							").zip"
						});
						if (!File.Exists(text))
						{
							File.Copy(this.Page.Server.MapPath(path), text);
							Thread.Sleep(200);
						}
						ShopNum1UnZipClass.UnZip(text, zipedFolder, null);
						File.Delete(text);
					}
				}
				catch (Exception ex)
				{
					num = -1;
					MessageBox.Show(ex.Message.ToString());
					this.method_5();
				}
				return;
			}
			finally
			{
				if (num == 1)
				{
					MessageBox.Show("恢复模板成功!");
					this.method_5();
				}
			}
		}
		if (e.CommandName == "delete")
		{
			Label label = (Label)e.Item.FindControl("LabelNameValue");
			Label label2 = (Label)e.Item.FindControl("LabelCreateTime");
			int num = 1;
			string path = string.Concat(new string[]
			{
				"~/BackUp/",
				label.Text,
				"(",
				label2.Text,
				").zip"
			});
			try
			{
				File.Delete(this.Page.Server.MapPath(path));
				MessageBox.Show("删除成功!");
				this.method_5();
			}
			catch
			{
				MessageBox.Show("删除失败!");
				this.method_5();
			}
		}
	}
	protected void ButtonBackUp_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "~/Main/Themes/" + Globals.SkinName;
			string path = text + "/Skin.xml";
			string xmlPath = base.Server.MapPath(path);
			DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "Skin");
			string text2 = xmlData.Tables[0].Rows[0]["name"].ToString();
			string path2 = string.Concat(new string[]
			{
				"~/BackUp/",
				text2,
				"(",
				DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss"),
				").zip"
			});
			Thread.Sleep(200);
			ShopNum1Zip.ZipFileDictory(base.Server.MapPath(text), base.Server.MapPath(path2), null);
			MessageBox.Show("模板备份成功!");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + "请创建主目录BackUp");
		}
		finally
		{
			this.method_5();
		}
	}
	private void method_6()
	{
		string text = string.Empty;
		text = Globals.SkinName;
		this.LabelFolderNameValue.Text = text;
		string str = "Themes/" + text + "/Skin.xml";
		string xmlPath = base.Server.MapPath("../" + str);
		DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "Skin");
		foreach (DataRow dataRow in xmlData.Tables[0].Rows)
		{
			this.LabelNameValue.Text = dataRow["name"].ToString().Trim();
			this.LabelDescriptionValue.Text = dataRow["description"].ToString().Trim();
		}
		this.ImageCurrentSkin.ImageUrl = Globals.SkinPath + "/Skin.jpg";
	}
}
