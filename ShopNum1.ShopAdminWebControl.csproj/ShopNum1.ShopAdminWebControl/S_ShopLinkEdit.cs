using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopLinkEdit : BaseShopWebControl
	{
		private string string_0 = "S_ShopLinkEdit.ascx";
		private Label label_0;
		private TextBox textBox_0;
		private CheckBox checkBox_0;
		private TextBox textBox_1;
		private Button button_0;
		private Button button_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShopID
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public string ShopUrl
		{
			get;
			set;
		}
		public S_ShopLinkEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxShopMemLoginID");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIsShow");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxNote");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetDataInfo();
				this.label_0.Text = "编辑友情链接";
				this.button_0.Text = "编辑";
			}
			else
			{
				this.label_0.Text = "添加友情链接";
				this.button_0.Text = "添加";
			}
		}
		public void GetDataInfo()
		{
			Shop_ShopLink_Action shop_ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();
			DataTable dataTable = shop_ShopLink_Action.Edit(this.Page.Request.QueryString["guid"].ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.textBox_0.Text = dataTable.Rows[0]["ShopMemLoginID"].ToString();
				if (dataTable.Rows[0]["IsShow"].ToString() == "1")
				{
					this.checkBox_0.Checked = true;
				}
				else
				{
					this.checkBox_0.Checked = false;
				}
			}
			this.textBox_1.Text = dataTable.Rows[0]["Note"].ToString();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopLink.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.method_1();
				this.textBox_0.ReadOnly = true;
			}
			else
			{
				this.method_0();
			}
		}
		public bool CheckMemLoginID(string memloginID)
		{
			Shop_ShopLink_Action shop_ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();
			DataTable dataTable = shop_ShopLink_Action.CheckMemLoginID(memloginID);
			bool result;
			if (dataTable.Rows.Count > 0 && dataTable.Rows.Count < 2)
			{
				this.ShopID = dataTable.Rows[0]["ShopID"].ToString();
				this.ShopName = dataTable.Rows[0]["ShopName"].ToString();
				this.ShopUrl = dataTable.Rows[0]["ShopUrl"].ToString();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public string GetDomainName(string ShopMemLoginID)
		{
			string result;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "  AND  MemLoginID='" + ShopMemLoginID + "'");
				string nameById2 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   and  SubstationID='" + nameById + "'  ");
				result = nameById2;
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		private void method_0()
		{
			this.CheckMemLoginID(this.textBox_0.Text);
			Shop_ShopLink_Action shop_ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();
			ShopNum1_Shop_Link shopNum1_Shop_Link = new ShopNum1_Shop_Link();
			shopNum1_Shop_Link.CreateTime = DateTime.Now;
			shopNum1_Shop_Link.Guid = Guid.NewGuid();
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_Link.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_Link.IsShow = 0;
			}
			shopNum1_Shop_Link.MemLoginID = this.MemLoginID;
			shopNum1_Shop_Link.ModifyTime = DateTime.Now;
			shopNum1_Shop_Link.Note = this.textBox_1.Text.Trim();
			shopNum1_Shop_Link.ShopMemLoginID = this.textBox_0.Text;
			shopNum1_Shop_Link.ShopName = this.ShopName;
			shopNum1_Shop_Link.ShopUrl = "http://" + this.ShopUrl;
			try
			{
				int num = shop_ShopLink_Action.Add(shopNum1_Shop_Link);
				if (num > 0)
				{
					MessageBox.Show("添加成功！");
					this.textBox_1.Text = "";
					this.textBox_0.Text = "";
				}
				else
				{
					MessageBox.Show("添加失败！");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("添加失败！");
			}
		}
		private void method_1()
		{
			Shop_ShopLink_Action shop_ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();
			ShopNum1_Shop_Link shopNum1_Shop_Link = new ShopNum1_Shop_Link();
			shopNum1_Shop_Link.Guid = new Guid(this.Page.Request.QueryString["guid"].ToString());
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_Link.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_Link.IsShow = 0;
			}
			shopNum1_Shop_Link.ModifyTime = DateTime.Now;
			shopNum1_Shop_Link.Note = this.textBox_1.Text.Trim();
			shopNum1_Shop_Link.MemLoginID = this.MemLoginID;
			shopNum1_Shop_Link.ShopMemLoginID = this.textBox_0.Text;
			shopNum1_Shop_Link.ShopName = this.ShopName;
			shopNum1_Shop_Link.ShopUrl = "http://" + ShopSettings.GetValue("PersonShopUrl") + this.ShopID + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
			try
			{
				int num = shop_ShopLink_Action.Updata(shopNum1_Shop_Link);
				if (num > 0)
				{
					MessageBox.Show("编辑成功！");
				}
				else
				{
					MessageBox.Show("编辑失败！");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("编辑失败！");
			}
		}
	}
}
