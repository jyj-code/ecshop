using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_SkinSelect : BaseShopWebControl
	{
		private string string_0 = "S_SkinSelect.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Image image_0;
		private Repeater repeater_0;
		private DataTable dataTable_0;
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		protected string shopid
		{
			get;
			set;
		}
		protected string openTime
		{
			get;
			set;
		}
		protected string ShopRank
		{
			get;
			set;
		}
		public S_SkinSelect()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelFolderNameValue");
			this.label_1 = (Label)skin.FindControl("LabelNameValue");
			this.label_2 = (Label)skin.FindControl("LabelDescriptionValue");
			this.image_0 = (Image)skin.FindControl("ImageCurrentSkin");
			this.repeater_0 = (Repeater)skin.FindControl("Rep_SkinSelect");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			try
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				DataTable shopSimpleByMemID = shop_ShopInfo_Action.GetShopSimpleByMemID(this.MemLoginID);
				this.shopid = shopSimpleByMemID.Rows[0]["ShopID"].ToString();
				this.openTime = DateTime.Parse(shopSimpleByMemID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
				this.ShopRank = shopSimpleByMemID.Rows[0]["ShopRank"].ToString();
				this.CreateSkinTable();
				this.method_0();
				this.GetAllSkins();
			}
			catch (Exception)
			{
			}
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			try
			{
				if (e.CommandName == "select")
				{
					Label label = (Label)e.Item.FindControl("LabelNameValue");
					Label label2 = (Label)e.Item.FindControl("LabelDescriptionValue");
					Label arg_5A_0 = (Label)e.Item.FindControl("LabelSkinNameValue");
					HtmlInputHidden htmlInputHidden = (HtmlInputHidden)e.Item.FindControl("hidPath");
					int num = 1;
					if (label.Text == this.label_1.Text)
					{
						MessageBox.Show("正在使用该模版！");
					}
					else
					{
						try
						{
							string path = this.Page.Server.MapPath("/Template/ShopTemplate/" + htmlInputHidden.Value) + "zz";
							if (!File.Exists(path))
							{
								num = -1;
								MessageBox.Show("当前模板不存在，请检查服务器文件！");
								return;
							}
							string webFilePath = this.GetWebFilePath();
							this.method_1(this.Page.Server.MapPath(webFilePath));
							if (!Directory.Exists(this.Page.Server.MapPath(webFilePath)))
							{
								Directory.CreateDirectory(this.Page.Server.MapPath(webFilePath));
							}
							string text = this.GetWebFilePath().Replace("Skin_Default", "backUp");
							if (!Directory.Exists(this.Page.Server.MapPath(text)))
							{
								Directory.CreateDirectory(this.Page.Server.MapPath(text));
							}
							text = text + htmlInputHidden.Value + "zz";
							if (File.Exists(this.Page.Server.MapPath(text)))
							{
								File.Delete(this.Page.Server.MapPath(text));
							}
							if (!File.Exists(this.Page.Server.MapPath(text)))
							{
								File.Copy(this.Page.Server.MapPath("/Template/ShopTemplate/" + htmlInputHidden.Value) + "zz", this.Page.Server.MapPath(text));
							}
							ShopNum1UnZipClass.UnZip(this.Page.Server.MapPath(text), this.Page.Server.MapPath(webFilePath), "");
							File.Delete(this.Page.Server.MapPath(text));
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
								this.method_0();
								MessageBox.Show("应用模板成功");
							}
						}
					}
				}
				if (e.CommandName == "delete")
				{
					Label label = (Label)e.Item.FindControl("LabelNameValue");
					Label label2 = (Label)e.Item.FindControl("LabelFolderNameValue");
					Label arg_2FB_0 = (Label)e.Item.FindControl("LabelSkinNameValue");
					int num = 1;
					if (label.Text == this.label_1.Text)
					{
						MessageBox.Show("正在使用该模版！");
					}
					else
					{
						try
						{
							this.method_1(this.Page.Server.MapPath("~/Main/Skin/Master/" + label2.Text.Trim() + "/"));
							this.GetAllSkins();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message.ToString());
							MessageBox.Show("应用模板失败！");
						}
					}
				}
			}
			catch
			{
			}
		}
		protected void CreateSkinTable()
		{
			this.dataTable_0 = new DataTable();
			this.dataTable_0.Rows.Clear();
			DataColumn dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.Guid");
			dataColumn.ColumnName = "Guid";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "FolderName";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "Name";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "Description";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "SkinImage";
			this.dataTable_0.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "SkinName";
			this.dataTable_0.Columns.Add(dataColumn);
			this.ViewState["dataTableSkin"] = this.dataTable_0;
		}
		private void method_0()
		{
			string text = this.Page.Server.MapPath(this.GetWebFilePath()) + "Skin.xml";
			DataSet xmlData = XmlOperator.GetXmlData(text, "Skin");
			if (File.Exists(text))
			{
				foreach (DataRow dataRow in xmlData.Tables[0].Rows)
				{
					this.label_1.Text = dataRow["name"].ToString().Trim();
					this.label_2.Text = dataRow["description"].ToString().Trim();
					this.label_0.Text = dataRow["description"].ToString().Trim();
				}
				this.image_0.ImageUrl = this.GetWebFilePath() + "Skin.jpg";
			}
		}
		public void GetAllSkins()
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)LogicFactory.CreateShop_Rank_Action();
			DataTable templateByRankGuid = shop_Rank_Action.GetTemplateByRankGuid(this.ShopRank);
			if (templateByRankGuid != null && templateByRankGuid.Rows.Count > 0)
			{
				this.repeater_0.DataSource = templateByRankGuid.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void method_1(string string_4)
		{
			if (Directory.Exists(string_4))
			{
				string[] fileSystemEntries = Directory.GetFileSystemEntries(string_4);
				for (int i = 0; i < fileSystemEntries.Length; i++)
				{
					string text = fileSystemEntries[i];
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					else
					{
						this.method_1(text);
					}
				}
				Directory.Delete(string_4, true);
			}
		}
		public string CheckSkinBackup()
		{
			return ShopSettings.GetValue("SkinBackup");
		}
		protected string GetWebFilePath()
		{
			string text = this.openTime.Split(new char[]
			{
				'-'
			})[0];
			string text2 = this.openTime.Split(new char[]
			{
				'-'
			})[1];
			string text3 = this.openTime.Split(new char[]
			{
				'-'
			})[2];
			return string.Concat(new string[]
			{
				"~/shop/shop/",
				text,
				"/",
				text2,
				"/",
				text3,
				"/shop",
				this.shopid,
				"/Themes/Skin_Default/"
			});
		}
	}
}
