using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_OnLineServiceOperate : BaseShopWebControl
	{
		private string string_0 = "S_OnLineServiceOperate.ascx";
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputCheckBox htmlInputCheckBox_0;
		private Button button_0;
		private Button button_1;
		[CompilerGenerated]
		private string string_1;
		public string Guid
		{
			get;
			set;
		}
		public S_OnLineServiceOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_OnlineServiceName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_OnlineServiceID");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_OrderID");
			this.htmlInputCheckBox_0 = (HtmlInputCheckBox)skin.FindControl("check_IsShow");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_TypeName");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_TypeValue");
			this.button_0 = (Button)skin.FindControl("btn_Save");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("btn_Back");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.Guid = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("Guid"));
			if (this.Guid != "0")
			{
				this.method_1();
			}
			else
			{
				this.htmlInputText_2.Value = (this.method_3() + 1).ToString();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_OnLineServiceList.aspx?Type=1");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Guid != "0")
			{
				this.method_0();
			}
			else
			{
				this.method_2();
			}
		}
		private void method_0()
		{
			ShopNum1_Shop_OnlineService shopNum1_Shop_OnlineService = new ShopNum1_Shop_OnlineService();
			shopNum1_Shop_OnlineService.Guid = new Guid(this.Guid);
			shopNum1_Shop_OnlineService.Type = this.htmlInputHidden_1.Value;
			shopNum1_Shop_OnlineService.TypeName = this.htmlInputHidden_0.Value;
			shopNum1_Shop_OnlineService.Name = this.htmlInputText_0.Value;
			shopNum1_Shop_OnlineService.ServiceAccount = this.htmlInputText_1.Value;
			shopNum1_Shop_OnlineService.OrderID = Convert.ToInt32(this.htmlInputText_2.Value);
			if (this.htmlInputCheckBox_0.Checked)
			{
				shopNum1_Shop_OnlineService.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_OnlineService.IsShow = 0;
			}
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			int num = shop_OnLineService_Action.UpdateOnLineService(shopNum1_Shop_OnlineService);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_OnLineServiceList.aspx?Type=1");
			}
		}
		private void method_1()
		{
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			DataTable onLineService = shop_OnLineService_Action.GetOnLineService(this.Guid);
			this.htmlInputHidden_1.Value = onLineService.Rows[0]["Type"].ToString();
			this.htmlInputHidden_0.Value = onLineService.Rows[0]["TypeName"].ToString();
			this.htmlInputText_0.Value = onLineService.Rows[0]["Name"].ToString();
			this.htmlInputText_1.Value = onLineService.Rows[0]["ServiceAccount"].ToString();
			this.htmlInputText_2.Value = onLineService.Rows[0]["OrderID"].ToString();
			if (onLineService.Rows[0]["IsShow"].ToString() == "1")
			{
				this.htmlInputCheckBox_0.Checked = true;
			}
			else
			{
				this.htmlInputCheckBox_0.Checked = false;
			}
		}
		private void method_2()
		{
			ShopNum1_Shop_OnlineService shopNum1_Shop_OnlineService = new ShopNum1_Shop_OnlineService();
			shopNum1_Shop_OnlineService.Guid = System.Guid.NewGuid();
			shopNum1_Shop_OnlineService.Type = this.htmlInputHidden_1.Value;
			shopNum1_Shop_OnlineService.TypeName = this.htmlInputHidden_0.Value;
			shopNum1_Shop_OnlineService.Name = this.htmlInputText_0.Value;
			shopNum1_Shop_OnlineService.ServiceAccount = this.htmlInputText_1.Value;
			shopNum1_Shop_OnlineService.OrderID = Convert.ToInt32(this.htmlInputText_2.Value);
			if (this.htmlInputCheckBox_0.Checked)
			{
				shopNum1_Shop_OnlineService.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_OnlineService.IsShow = 0;
			}
			shopNum1_Shop_OnlineService.MemLoginID = this.MemLoginID;
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			int num = shop_OnLineService_Action.AddOnLineService(shopNum1_Shop_OnlineService);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_OnLineServiceList.aspx?type=1");
			}
		}
		private int method_3()
		{
			return ShopNum1.Common.Common.ReturnMaxID("OrderID", "MemLoginID", this.MemLoginID, "ShopNum1_Shop_OnlineService");
		}
	}
}
