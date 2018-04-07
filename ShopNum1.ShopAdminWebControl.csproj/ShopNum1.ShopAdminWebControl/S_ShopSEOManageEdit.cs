using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopSEOManageEdit : BaseShopWebControl
	{
		private string string_0 = "S_ShopSEOManageEdit.aspx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		private Button button_1;
		[CompilerGenerated]
		private string string_1;
		public string SetPath
		{
			get;
			set;
		}
		public S_ShopSEOManageEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxPageName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxKeyWord");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxEsec");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			this.SetPath = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/shop",
				text,
				"/xml/SetMeto.xml"
			});
			if (this.Page.Request.QueryString["pid"] != null)
			{
				this.GetEditInfo();
				this.textBox_0.ReadOnly = true;
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopSEOManage.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["pid"] != null)
			{
				this.Edit();
			}
			else
			{
				this.Add();
			}
		}
		public void Add()
		{
			IShopNum1_ExtendSiteMota_Action shopNum1_ExtendSiteMota_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
			string name = this.textBox_0.Text.Trim();
			string title = this.textBox_1.Text.Trim();
			string keywords = this.textBox_2.Text.Trim();
			string text = this.textBox_3.Text.Trim();
			int num = shopNum1_ExtendSiteMota_Action.Add(name, title, keywords, text, this.SetPath);
			if (num > 0)
			{
				MessageBox.Show("添加成功！");
				this.textBox_0.Text = "";
				this.textBox_1.Text = "";
			}
			else if (num == 0)
			{
				MessageBox.Show("此页面名已经存在了!");
			}
			else
			{
				MessageBox.Show("添加失败!");
			}
		}
		public void Edit()
		{
			IShopNum1_ExtendSiteMota_Action shopNum1_ExtendSiteMota_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
			string name = this.textBox_0.Text.Trim();
			string title = this.textBox_1.Text.Trim();
			string keywords = this.textBox_2.Text.Trim();
			string text = this.textBox_3.Text.Trim();
			int num = shopNum1_ExtendSiteMota_Action.edit(name, title, keywords, text, this.SetPath);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShopSEOManage.aspx");
			}
			else
			{
				MessageBox.Show("修改失败");
			}
		}
		public void GetEditInfo()
		{
			IShopNum1_ExtendSiteMota_Action shopNum1_ExtendSiteMota_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
			DataRow dataRow = shopNum1_ExtendSiteMota_Action.SelectByName(this.Page.Request.QueryString["pid"].ToString().Replace("'", ""), this.SetPath).Rows[0];
			this.textBox_0.Text = dataRow["PageName"].ToString();
			this.textBox_1.Text = dataRow["Title"].ToString();
			this.textBox_2.Text = dataRow["KeyWords"].ToString();
			this.textBox_3.Text = dataRow["Description"].ToString();
		}
	}
}
