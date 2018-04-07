using ShopNum1.Common;
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
	public class S_ShopNewsCategoryEdit : BaseMemberWebControl
	{
		private string string_0 = "S_ShopNewsCategoryEdit.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private CheckBox checkBox_0;
		private Button button_0;
		private Button button_1;
		private HiddenField hiddenField_0;
		private Shop_Common_Action shop_Common_Action_0 = (Shop_Common_Action)LogicFactory.CreateShop_Common_Action();
		public S_ShopNewsCategoryEdit()
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
			this.Page.Response.Redirect("S_ShopNewsCategory.aspx");
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
			string nameById = ShopNum1.Common.Common.GetNameById("MAX(OrderID)", "ShopNum1_Shop_NewsCategory", "  AND   MemLoginID='" + this.MemLoginID + "'");
			int result;
			if (!string.IsNullOrEmpty(nameById))
			{
				result = Convert.ToInt32(nameById);
			}
			else
			{
				result = 0;
			}
			return result;
		}
		private void method_1()
		{
			ShopNum1_Shop_NewsCategory shopNum1_Shop_NewsCategory = new ShopNum1_Shop_NewsCategory();
			shopNum1_Shop_NewsCategory.Guid = new Guid(this.hiddenField_0.Value);
			shopNum1_Shop_NewsCategory.Description = this.textBox_2.Text;
			shopNum1_Shop_NewsCategory.Keywords = this.textBox_1.Text;
			shopNum1_Shop_NewsCategory.Name = this.textBox_0.Text;
			shopNum1_Shop_NewsCategory.OrderID = Convert.ToInt32(this.textBox_3.Text);
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_NewsCategory.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_NewsCategory.IsShow = 0;
			}
			Shop_NewsCategory_Action shop_NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();
			int num = shop_NewsCategory_Action.UpdateNewsCategory(shopNum1_Shop_NewsCategory);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShopNewsCategory.aspx");
			}
		}
		private void method_2()
		{
			Shop_NewsCategory_Action shop_NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();
			DataTable newsCategory = shop_NewsCategory_Action.GetNewsCategory(this.hiddenField_0.Value);
			this.textBox_0.Text = newsCategory.Rows[0]["Name"].ToString();
			this.textBox_1.Text = newsCategory.Rows[0]["Keywords"].ToString();
			this.textBox_2.Text = newsCategory.Rows[0]["Description"].ToString();
			this.textBox_3.Text = newsCategory.Rows[0]["OrderID"].ToString();
			if (newsCategory.Rows[0]["IsShow"].ToString() == "1")
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
			ShopNum1_Shop_NewsCategory shopNum1_Shop_NewsCategory = new ShopNum1_Shop_NewsCategory();
			shopNum1_Shop_NewsCategory.Guid = Guid.NewGuid();
			shopNum1_Shop_NewsCategory.Description = this.textBox_2.Text;
			shopNum1_Shop_NewsCategory.Keywords = this.textBox_1.Text;
			shopNum1_Shop_NewsCategory.Name = this.textBox_0.Text;
			shopNum1_Shop_NewsCategory.OrderID = Convert.ToInt32(this.textBox_3.Text);
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_NewsCategory.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_NewsCategory.IsShow = 0;
			}
			shopNum1_Shop_NewsCategory.MemLoginID = this.MemLoginID;
			Shop_NewsCategory_Action shop_NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();
			int num = shop_NewsCategory_Action.AddNewsCategory(shopNum1_Shop_NewsCategory);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShopNewsCategory.aspx");
			}
		}
	}
}
