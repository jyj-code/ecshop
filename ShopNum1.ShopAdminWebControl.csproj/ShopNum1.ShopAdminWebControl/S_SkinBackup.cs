using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_SkinBackup : BaseShopWebControl
	{
		private string string_0 = "S_SkinBackup.ascx";
		private DataTable dataTable_0;
		private LinkButton linkButton_0;
		private Repeater repeater_0;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Image image_0;
		public S_SkinBackup()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.label_1 = (Label)skin.FindControl("LabelNameValue");
			this.label_0 = (Label)skin.FindControl("LabelFolderNameValue");
			this.label_2 = (Label)skin.FindControl("LabelDescriptionValue");
			this.image_0 = (Image)skin.FindControl("ImageCurrentSkin");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButton_BackUp");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.method_0();
			this.method_1();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.repeater_0.Items.Count >= 5)
				{
					MessageBox.Show("您只能备份最近五次的模板,请删除以前的备份!");
				}
				else
				{
					string webFilePath = this.GetWebFilePath();
					string path = webFilePath + "Themes/Skin_Default/";
					string path2 = webFilePath + "Themes/Skin_Default/Skin.xml";
					string xmlPath = this.Page.Server.MapPath(path2);
					DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "Skin");
					string text = xmlData.Tables[0].Rows[0]["name"].ToString();
					string path3 = string.Concat(new string[]
					{
						webFilePath,
						"BackUp/",
						text,
						"(",
						DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss"),
						").zip"
					});
					Thread.Sleep(20);
					ShopNum1Zip.ZipFileDictory(this.Page.Server.MapPath(path), this.Page.Server.MapPath(path3), null);
					MessageBox.Show("模板备份成功!");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("模板备份失败！");
			}
			finally
			{
				this.method_0();
			}
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			string webFilePath = this.GetWebFilePath();
			string path = this.Page.Server.MapPath(webFilePath + "Themes/Skin_Default");
			if (e.CommandName == "select")
			{
				Label label = (Label)e.Item.FindControl("LabelNameValue");
				int num = 1;
				try
				{
					try
					{
						Themes.DeleteFolder(path);
						Directory.CreateDirectory(path);
						if (Directory.Exists(path))
						{
							string path2 = webFilePath + "BackUp/" + label.Text + ".zip";
							string text = webFilePath + "Themes/Skin_Default/";
							string path3 = text + label.Text + ".zip";
							if (!File.Exists(this.Page.Server.MapPath(path3)))
							{
								File.Copy(this.Page.Server.MapPath(path2), this.Page.Server.MapPath(path3));
								Thread.Sleep(20);
							}
							ShopNum1UnZipClass.UnZip(this.Page.Server.MapPath(path3), this.Page.Server.MapPath(text), null);
							File.Delete(this.Page.Server.MapPath(path3));
						}
					}
					catch (Exception)
					{
						num = -1;
						MessageBox.Show("恢复模板失败！");
						this.method_0();
					}
					return;
				}
				finally
				{
					if (num == 1)
					{
						MessageBox.Show("恢复模板成功!");
						this.method_0();
					}
				}
			}
			if (e.CommandName == "delete")
			{
				Label label = (Label)e.Item.FindControl("LabelNameValue");
				string path2 = webFilePath + "BackUp/" + label.Text + ".zip";
				try
				{
					File.Delete(this.Page.Server.MapPath(path2));
					MessageBox.Show("删除成功!");
					this.method_0();
				}
				catch
				{
					MessageBox.Show("删除失败!");
					this.method_0();
				}
			}
		}
		protected DataTable CreateSkinTable()
		{
			this.dataTable_0 = new DataTable();
			this.dataTable_0.Rows.Clear();
			DataColumn dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.Guid");
			dataColumn.ColumnName = "Guid";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "Name";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "createTime";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "SkinImage";
			this.dataTable_0.Columns.Add(dataColumn);
			return this.dataTable_0;
		}
		private void method_0()
		{
			if (!Directory.Exists(this.Page.Server.MapPath(this.GetWebFilePath() + "BackUp/")))
			{
				try
				{
					Directory.CreateDirectory(this.Page.Server.MapPath(this.GetWebFilePath() + "BackUp/"));
				}
				catch
				{
					this.repeater_0.DataSource = null;
					this.repeater_0.DataBind();
					return;
				}
			}
			string[] files = Directory.GetFiles(this.Page.Server.MapPath(this.GetWebFilePath() + "BackUp/"), "*.Zip");
			DataTable dataTable = this.CreateSkinTable();
			for (int i = 0; i < files.Length; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Guid"] = Guid.NewGuid();
				FileInfo fileInfo = new FileInfo(files[i]);
				dataRow["createTime"] = fileInfo.CreationTime.ToString();
				dataRow["Name"] = fileInfo.Name.Split(new char[]
				{
					'.'
				})[0];
				dataRow["SkinImage"] = this.GetWebFilePath() + "Themes/Skin_Default/skin.jpg";
				dataTable.Rows.Add(dataRow);
			}
			this.repeater_0.DataSource = dataTable;
			this.repeater_0.DataBind();
		}
		private void method_1()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string path = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				text,
				"/Themes/Skin_Default/Skin.xml"
			});
			string xmlPath = this.Page.Server.MapPath(path);
			try
			{
				DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "Skin");
				foreach (DataRow dataRow in xmlData.Tables[0].Rows)
				{
					this.label_1.Text = dataRow["name"].ToString().Trim();
					this.label_2.Text = dataRow["description"].ToString().Trim();
				}
				this.image_0.ImageUrl = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text2.Replace("-", "/"),
					"/",
					ShopSettings.GetValue("PersonShopUrl"),
					text,
					"/Themes/Skin_Default/Skin.jpg"
				});
			}
			catch
			{
			}
		}
		protected string GetWebFilePath()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopSimpleByMemID = shop_ShopInfo_Action.GetShopSimpleByMemID(this.MemLoginID);
			string text = shopSimpleByMemID.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(shopSimpleByMemID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string text3 = text2.Split(new char[]
			{
				'-'
			})[0];
			string text4 = text2.Split(new char[]
			{
				'-'
			})[1];
			string text5 = text2.Split(new char[]
			{
				'-'
			})[2];
			return string.Concat(new string[]
			{
				"/shop/shop/",
				text3,
				"/",
				text4,
				"/",
				text5,
				"/shop",
				text,
				"/"
			});
		}
	}
}
