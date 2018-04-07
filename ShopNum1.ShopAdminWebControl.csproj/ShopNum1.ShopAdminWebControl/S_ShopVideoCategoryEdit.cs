using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopVideoCategoryEdit : BaseMemberWebControl
	{
		private string string_0 = "S_ShopVideoCategoryEdit.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private CheckBox checkBox_0;
		private Button button_0;
		private Button button_1;
		private HiddenField hiddenField_0;
		private Shop_Common_Action shop_Common_Action_0 = (Shop_Common_Action)LogicFactory.CreateShop_Common_Action();
		public S_ShopVideoCategoryEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.button_1 = (Button)skin.FindControl("ButtonBack");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxKeyWrods");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxDescription");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxOrderID");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIsShow");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hiddenFieldGuid");
			this.button_0 = (Button)skin.FindControl("ButtonConfrim");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("hiddenFieldGuid");
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString());
			if (this.hiddenField_0.Value != "0")
			{
				this.method_2();
			}
			else
			{
				this.textBox_3.Text = Convert.ToString(this.method_0() + 1);
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopVideoCategory.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.hiddenField_0.Value != "0")
			{
				this.method_1();
			}
			else
			{
				this.method_3();
			}
		}
		private int method_0()
		{
			return this.shop_Common_Action_0.ReturnMaxID("OrderID", "MemLoginID", this.MemLoginID, "ShopNum1_Shop_VideoCategory");
		}
		private void method_1()
		{
			ShopNum1_Shop_VideoCategory shopNum1_Shop_VideoCategory = new ShopNum1_Shop_VideoCategory();
			shopNum1_Shop_VideoCategory.Guid = new Guid(this.hiddenField_0.Value);
			shopNum1_Shop_VideoCategory.Description = this.textBox_2.Text;
			shopNum1_Shop_VideoCategory.Keywords = this.textBox_1.Text;
			shopNum1_Shop_VideoCategory.Name = this.textBox_0.Text;
			shopNum1_Shop_VideoCategory.OrderID = Convert.ToInt32(this.textBox_3.Text);
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_VideoCategory.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_VideoCategory.IsShow = 0;
			}
			Shop_VideoCategory_Action shop_VideoCategory_Action = (Shop_VideoCategory_Action)LogicFactory.CreateShop_VideoCategory_Action();
			int num = shop_VideoCategory_Action.UpdateVideoCategory(shopNum1_Shop_VideoCategory);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShopVideoCategory.aspx");
			}
		}
		private void method_2()
		{
			Shop_VideoCategory_Action shop_VideoCategory_Action = (Shop_VideoCategory_Action)LogicFactory.CreateShop_VideoCategory_Action();
			DataTable videoCategory = shop_VideoCategory_Action.GetVideoCategory(this.hiddenField_0.Value);
			this.textBox_0.Text = videoCategory.Rows[0]["Name"].ToString();
			this.textBox_1.Text = videoCategory.Rows[0]["Keywords"].ToString();
			this.textBox_2.Text = videoCategory.Rows[0]["Description"].ToString();
			this.textBox_3.Text = videoCategory.Rows[0]["OrderID"].ToString();
			if (videoCategory.Rows[0]["IsShow"].ToString() == "1")
			{
				this.checkBox_0.Checked = true;
			}
			else
			{
				this.checkBox_0.Checked = false;
			}
		}
		private void method_3()
		{
			ShopNum1_Shop_VideoCategory shopNum1_Shop_VideoCategory = new ShopNum1_Shop_VideoCategory();
			shopNum1_Shop_VideoCategory.Guid = Guid.NewGuid();
			shopNum1_Shop_VideoCategory.Description = this.textBox_2.Text;
			shopNum1_Shop_VideoCategory.Keywords = this.textBox_1.Text;
			shopNum1_Shop_VideoCategory.Name = this.textBox_0.Text;
			shopNum1_Shop_VideoCategory.OrderID = Convert.ToInt32(this.textBox_3.Text);
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_VideoCategory.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_VideoCategory.IsShow = 0;
			}
			shopNum1_Shop_VideoCategory.MemLoginID = this.MemLoginID;
			Shop_VideoCategory_Action shop_VideoCategory_Action = (Shop_VideoCategory_Action)LogicFactory.CreateShop_VideoCategory_Action();
			int num = shop_VideoCategory_Action.AddVideoCategory(shopNum1_Shop_VideoCategory);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShopVideoCategory.aspx");
			}
		}
	}
}
