using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_AdvertisementOperate : BaseShopWebControl
	{
		private string string_0 = "S_AdvertisementOperate.ascx";
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private HtmlInputText htmlInputText_5;
		private Image image_0;
		private HiddenField hiddenField_0;
		private HtmlInputText htmlInputText_6;
		private HtmlInputText htmlInputText_7;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private Button button_0;
		private Button button_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string Guid
		{
			get;
			set;
		}
		public string SetPath
		{
			get;
			set;
		}
		public string OpenTime
		{
			get;
			set;
		}
		public string ShopID
		{
			get;
			set;
		}
		public S_AdvertisementOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_pageName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_fieName");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_divID");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txt_Explain");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txt_AdType");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("txt_AdLink");
			this.image_0 = (Image)skin.FindControl("ImageContent");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldContent");
			this.htmlInputText_6 = (HtmlInputText)skin.FindControl("txt_AdHeight");
			this.htmlInputText_7 = (HtmlInputText)skin.FindControl("txt_Adwidth");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_AdType");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_PathType");
			this.button_0 = (Button)skin.FindControl("btn_Save");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("btn_Back");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			this.ShopID = memLoginInfo.Rows[0]["ShopID"].ToString();
			this.OpenTime = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			this.SetPath = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				this.OpenTime.Replace("-", "/"),
				"/shop",
				this.ShopID,
				"/Themes/Skin_Default/Advertisement.xml"
			});
			this.Guid = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("Guid"));
			if (!this.Page.IsPostBack && this.Guid != "0")
			{
				this.GetEditInfo();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_AdvertisementList.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Edit();
		}
		public void Edit()
		{
			Advertisement advertisement = new Advertisement();
			advertisement.Guid = this.Guid;
			advertisement.Explain = this.htmlInputText_3.Value;
			advertisement.PageName = this.htmlInputText_0.Value;
			advertisement.FileName = this.htmlInputText_1.Value;
			advertisement.DivID = this.htmlInputText_2.Value;
			advertisement.Type = this.htmlInputHidden_0.Value;
			advertisement.Href = this.htmlInputText_5.Value;
			advertisement.Content = this.hiddenField_0.Value;
			advertisement.Width = this.htmlInputText_7.Value;
			advertisement.Height = this.htmlInputText_6.Value;
			Shop_Advertisement_Action shop_Advertisement_Action = (Shop_Advertisement_Action)LogicFactory.CreateShop_Advertisement_Action();
			shop_Advertisement_Action.StrPath = this.SetPath;
			int num = shop_Advertisement_Action.Update(advertisement);
			if (num > 0)
			{
				MessageBox.Show("编辑成功！");
				this.Page.Response.Redirect("S_AdvertisementList.aspx");
			}
			else
			{
				MessageBox.Show("编辑失败");
			}
		}
		public long loadImageSzie()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			string text = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			new XmlDataSource();
			string path = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text.Replace("-", "/"),
				"/shop",
				this.ShopID,
				"/Site_Settings.xml"
			});
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.Page.Server.MapPath(path));
			DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
			return Convert.ToInt64(dataRow["UserImageSpace"]);
		}
		public void GetEditInfo()
		{
			try
			{
				Shop_Advertisement_Action shop_Advertisement_Action = (Shop_Advertisement_Action)LogicFactory.CreateShop_Advertisement_Action();
				shop_Advertisement_Action.StrPath = this.SetPath;
				DataRow dataRow = shop_Advertisement_Action.SelectByID(this.Guid).Rows[0];
				this.htmlInputText_0.Value = dataRow["pagename"].ToString();
				this.htmlInputText_1.Value = dataRow["filename"].ToString();
				this.htmlInputText_2.Value = dataRow["divid"].ToString();
				this.htmlInputText_3.Value = dataRow["explain"].ToString();
				this.htmlInputHidden_0.Value = dataRow["type"].ToString();
				this.htmlInputText_5.Value = dataRow["href"].ToString();
				if (this.htmlInputHidden_0.Value == "0")
				{
					string text = string.Concat(new string[]
					{
						"/Shop/Shop/",
						this.OpenTime.Replace("-", "/"),
						"/shop",
						this.ShopID,
						"/",
						dataRow["content"].ToString()
					});
					if (File.Exists(HttpContext.Current.Server.MapPath(dataRow["content"].ToString())))
					{
						text = dataRow["content"].ToString();
					}
					this.image_0.ImageUrl = text;
					this.hiddenField_0.Value = text;
				}
				else
				{
					string text = string.Concat(new string[]
					{
						"/Shop/Shop/",
						this.OpenTime.Replace("-", "/"),
						"/shop",
						this.ShopID,
						"/",
						dataRow["content"].ToString()
					});
					if (File.Exists(HttpContext.Current.Server.MapPath(dataRow["content"].ToString())))
					{
						text = dataRow["content"].ToString();
					}
					this.image_0.ImageUrl = text;
					this.hiddenField_0.Value = text;
					this.htmlInputText_6.Value = dataRow["height"].ToString();
					this.htmlInputText_7.Value = dataRow["width"].ToString();
				}
			}
			catch (Exception ex)
			{
				File.AppendAllText(HttpContext.Current.Server.MapPath("~/logpath.txt"), ex.Message);
				this.image_0.ImageUrl = "Themes/Skin_Default/Images/ban_img1.jpg";
				this.hiddenField_0.Value = "Themes/Skin_Default/Images/ban_img1.jpg";
			}
		}
		public void AddImageSizeToXML(string filepath)
		{
			if (File.Exists(filepath))
			{
				FileInfo fileInfo = new FileInfo(filepath);
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
				string text = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
				new XmlDataSource();
				string path = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text.Replace("-", "/"),
					"/shop",
					this.ShopID,
					"/Site_Settings.xml"
				});
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(path));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				dataRow["UserImageSpace"] = (Convert.ToInt64(dataRow["UserImageSpace"]) + fileInfo.Length).ToString();
				dataSet.AcceptChanges();
				dataSet.WriteXml(this.Page.Server.MapPath(path));
			}
		}
	}
}
