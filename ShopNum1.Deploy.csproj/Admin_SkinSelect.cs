using ShopNum1.Common;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SkinSelect : PageBase, IRequiresSessionState
{
	protected Image ImageCurrentSkin;
	protected Label LabelCurrentSkins;
	protected Label LabelFolderName;
	protected Label LabelFolderNameValue;
	protected Label LabelName;
	protected Label LabelNameValue;
	protected Label LabelDescription;
	protected Label LabelDescriptionValue;
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
		this.CreateSkinTable();
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.method_6();
		}
	}
	private void method_5()
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
	private void method_6()
	{
		string path = base.Server.MapPath("~/Template/Master");
		try
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
		catch
		{
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		DataTable dataTable = (DataTable)this.ViewState["dataTableSkin"];
		DirectoryInfo[] array = directories;
		for (int i = 0; i < array.Length; i++)
		{
			DirectoryInfo directoryInfo2 = array[i];
			try
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Guid"] = Guid.NewGuid();
				dataRow["FolderName"] = directoryInfo2.Name;
				string str = directoryInfo2.Name + "/Skin.xml";
				string xmlPath = base.Server.MapPath("~/Template/Master/" + str);
				DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "Skin");
				foreach (DataRow dataRow2 in xmlData.Tables[0].Rows)
				{
					dataRow["Name"] = dataRow2["name"].ToString().Trim();
					dataRow["Description"] = dataRow2["description"].ToString().Trim();
					dataRow["SkinImage"] = "~/Template/Master/" + directoryInfo2.Name + "/Skin.jpg";
				}
				dataTable.Rows.Add(dataRow);
			}
			catch
			{
			}
		}
		this.DataListShow.DataSource = dataTable.DefaultView;
		this.DataListShow.DataBind();
	}
	protected void CreateSkinTable()
	{
		this.dt = new DataTable();
		this.dt.Rows.Clear();
		DataColumn dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.Guid");
		dataColumn.ColumnName = "Guid";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "FolderName";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "Name";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "Description";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "SkinImage";
		this.dt.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "SkinName";
		this.dt.Columns.Add(dataColumn);
		this.ViewState["dataTableSkin"] = this.dt;
	}
	protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
	{
		if (e.CommandName == "select")
		{
			Label label = (Label)e.Item.FindControl("LabelNameValue");
			Label label2 = (Label)e.Item.FindControl("LabelFolderNameValue");
			Label arg_59_0 = (Label)e.Item.FindControl("LabelSkinNameValue");
			int num = 1;
			if (label.Text == this.LabelNameValue.Text)
			{
				MessageBox.Show("正在使用该模版！");
			}
			else
			{
				try
				{
					string path = this.Page.Server.MapPath("~/Skin/Master/" + label2.Text.Trim() + "/" + label.Text.Trim()) + ".zip";
					if (File.Exists(path))
					{
						if (this.CheckSkinBackup() == "1")
						{
							string fileToZip = this.Page.Server.MapPath("~/Main/Themes/Skin_Default/");
							string str = DateTime.Now.ToString("yyyyMMddHHmmss");
							string zipedFile = this.Page.Server.MapPath("~/BackUp/" + str + ".zip");
							ShopNum1Zip.Zip(fileToZip, zipedFile, null);
						}
						try
						{
							return;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
							return;
						}
					}
					MessageBox.Show("该模板文件不存在！");
					return;
				}
				catch (Exception ex)
				{
					num = -1;
					MessageBox.Show(ex.Message.ToString());
					MessageBox.Show("应用模板失败！");
				}
				finally
				{
					if (num == 1)
					{
						this.method_5();
						MessageBox.Show("应用模板成功");
					}
				}
			}
		}
		if (e.CommandName == "delete")
		{
			Label label = (Label)e.Item.FindControl("LabelNameValue");
			Label label2 = (Label)e.Item.FindControl("LabelFolderNameValue");
			Label arg_1FE_0 = (Label)e.Item.FindControl("LabelSkinNameValue");
			int num = 1;
			if (label.Text == this.LabelNameValue.Text)
			{
				MessageBox.Show("正在使用该模版！");
			}
			else
			{
				try
				{
					this.method_7(this.Page.Server.MapPath("~/Skin/Master/" + label2.Text.Trim() + "/"));
					this.method_6();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
					MessageBox.Show("应用模板失败！");
				}
			}
		}
	}
	private void method_7(string string_5)
	{
		if (Directory.Exists(string_5))
		{
			string[] fileSystemEntries = Directory.GetFileSystemEntries(string_5);
			for (int i = 0; i < fileSystemEntries.Length; i++)
			{
				string text = fileSystemEntries[i];
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				else
				{
					this.method_7(text);
				}
			}
			Directory.Delete(string_5, true);
		}
	}
	public string CheckSkinBackup()
	{
		return ShopSettings.GetValue("SkinBackup");
	}
}
