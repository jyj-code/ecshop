using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_UserDefinedColumnOperate : BaseShopWebControl
	{
		private string string_0 = "S_UserDefinedColumnOperate.ascx";
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputCheckBox htmlInputCheckBox_0;
		private Button button_0;
		private Button button_1;
		private string string_1 = string.Empty;
		public S_UserDefinedColumnOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_MenuName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_AdLink");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_OrderID");
			this.htmlInputCheckBox_0 = (HtmlInputCheckBox)skin.FindControl("check_IsShow");
			this.button_0 = (Button)skin.FindControl("btn_Save");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("btn_Back");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.string_1 = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("Guid"));
			if (this.string_1 != "0")
			{
				this.GetEditInfo();
			}
			else
			{
				this.htmlInputText_2.Value = (this.method_0() + 1).ToString();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_UserDefinedColumnList.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.string_1 != "0")
			{
				this.Edit();
			}
			else
			{
				this.Add();
			}
		}
		public void Edit()
		{
			if (this.htmlInputText_0.Value == "")
			{
				MessageBox.Show("自定义栏目不能为空");
			}
			else if (this.htmlInputText_1.Value == "")
			{
				MessageBox.Show("链接不能为空");
			}
			else
			{
				ShopNum1_Shop_UserDefinedColumn shopNum1_Shop_UserDefinedColumn = new ShopNum1_Shop_UserDefinedColumn();
				shopNum1_Shop_UserDefinedColumn.Guid = new Guid(this.string_1);
				if (this.htmlInputCheckBox_0.Checked)
				{
					shopNum1_Shop_UserDefinedColumn.IsShow = 1;
				}
				else
				{
					shopNum1_Shop_UserDefinedColumn.IsShow = 0;
				}
				shopNum1_Shop_UserDefinedColumn.IfOpen = 0;
				shopNum1_Shop_UserDefinedColumn.Name = this.htmlInputText_0.Value.Trim();
				shopNum1_Shop_UserDefinedColumn.LinkAddress = this.htmlInputText_1.Value.Trim();
				shopNum1_Shop_UserDefinedColumn.OrderID = Convert.ToInt32(this.htmlInputText_2.Value);
				Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
				int num = shop_UserDefinedColumn_Action.UpdateUserDefinedColumn(shopNum1_Shop_UserDefinedColumn);
				if (num > 0)
				{
					this.Page.Response.Redirect("S_UserDefinedColumnList.aspx");
				}
			}
		}
		public void Add()
		{
			if (this.htmlInputText_0.Value == "")
			{
				MessageBox.Show("自定义栏目不能为空");
			}
			else if (this.htmlInputText_1.Value == "")
			{
				MessageBox.Show("链接不能为空");
			}
			else
			{
				ShopNum1_Shop_UserDefinedColumn shopNum1_Shop_UserDefinedColumn = new ShopNum1_Shop_UserDefinedColumn();
				shopNum1_Shop_UserDefinedColumn.Guid = Guid.NewGuid();
				if (this.htmlInputCheckBox_0.Checked)
				{
					shopNum1_Shop_UserDefinedColumn.IsShow = 1;
				}
				else
				{
					shopNum1_Shop_UserDefinedColumn.IsShow = 0;
				}
				shopNum1_Shop_UserDefinedColumn.IfOpen = 0;
				shopNum1_Shop_UserDefinedColumn.Name = this.htmlInputText_0.Value.Trim();
				shopNum1_Shop_UserDefinedColumn.LinkAddress = this.htmlInputText_1.Value.Trim();
				shopNum1_Shop_UserDefinedColumn.OrderID = Convert.ToInt32(this.htmlInputText_2.Value);
				shopNum1_Shop_UserDefinedColumn.MemLoginID = this.MemLoginID;
				Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
				int num = shop_UserDefinedColumn_Action.AddUserDefinedColumn(shopNum1_Shop_UserDefinedColumn);
				if (num > 0)
				{
					this.Page.Response.Redirect("S_UserDefinedColumnList.aspx");
				}
			}
		}
		public void GetEditInfo()
		{
			Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
			DataTable userDefinedColumn = shop_UserDefinedColumn_Action.GetUserDefinedColumn(this.string_1);
			if (userDefinedColumn.Rows[0]["IsShow"].ToString() == "1")
			{
				this.htmlInputCheckBox_0.Checked = true;
			}
			else
			{
				this.htmlInputCheckBox_0.Checked = false;
			}
			this.htmlInputText_0.Value = userDefinedColumn.Rows[0]["Name"].ToString();
			this.htmlInputText_1.Value = userDefinedColumn.Rows[0]["LinkAddress"].ToString();
			this.htmlInputText_2.Value = userDefinedColumn.Rows[0]["OrderID"].ToString();
		}
		private int method_0()
		{
			return ShopNum1.Common.Common.ReturnMaxID("OrderID", "MemLoginID", this.MemLoginID, "ShopNum1_Shop_UserDefinedColumn");
		}
	}
}
