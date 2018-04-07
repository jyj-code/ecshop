using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class OnLineService : BaseWebControl
	{
		private string string_0 = "OnLineService.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private Repeater repeater_3;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlTableRow htmlTableRow_0;
		private HtmlTableRow htmlTableRow_1;
		private HtmlTableRow htmlTableRow_2;
		private HtmlTableRow htmlTableRow_3;
		private HtmlTableRow htmlTableRow_4;
		private HtmlTableRow htmlTableRow_5;
		private HtmlTableRow htmlTableRow_6;
		private HtmlTableRow htmlTableRow_7;
		private ShopNum1_OnLineService_Action shopNum1_OnLineService_Action_0 = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
		public OnLineService()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterQQ");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterMSN");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterWW");
			this.repeater_3 = (Repeater)skin.FindControl("RepeaterHi");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("SpanQQ");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("SpanMSN");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("TRwwTitle");
			this.htmlTableRow_1 = (HtmlTableRow)skin.FindControl("TRwwContent");
			this.htmlTableRow_2 = (HtmlTableRow)skin.FindControl("TRqqTitle");
			this.htmlTableRow_3 = (HtmlTableRow)skin.FindControl("TRqqContent");
			this.htmlTableRow_4 = (HtmlTableRow)skin.FindControl("TRmsnTitle");
			this.htmlTableRow_5 = (HtmlTableRow)skin.FindControl("TRmsnContent");
			this.htmlTableRow_6 = (HtmlTableRow)skin.FindControl("TRbaiduTitle");
			this.htmlTableRow_7 = (HtmlTableRow)skin.FindControl("TRbaiduContent");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
			this.method_1();
			if (this.repeater_2 != null)
			{
				this.method_2();
				this.method_3();
			}
		}
		private void method_0()
		{
			string a = string.Empty;
			if (this.htmlTableRow_2 != null)
			{
				a = this.shopNum1_OnLineService_Action_0.GetIsShowByID("1");
				if (a == "1")
				{
					this.htmlTableRow_2.Visible = true;
					this.htmlTableRow_3.Visible = true;
					if (this.repeater_0 != null)
					{
						DataTable dataTable = this.shopNum1_OnLineService_Action_0.SearchTypeInfo("QQ", 1);
						this.repeater_0.DataSource = dataTable.DefaultView;
						this.repeater_0.DataBind();
					}
				}
				else
				{
					this.htmlTableRow_2.Visible = false;
					this.htmlTableRow_3.Visible = false;
				}
			}
			else if (this.htmlGenericControl_0 != null)
			{
				a = this.shopNum1_OnLineService_Action_0.GetIsShowByID("5");
				if (a == "1")
				{
					this.htmlGenericControl_0.Visible = true;
					if (this.repeater_0 != null)
					{
						DataTable dataTable = this.shopNum1_OnLineService_Action_0.SearchTypeInfo("QQ", 1);
						this.repeater_0.DataSource = dataTable.DefaultView;
						this.repeater_0.DataBind();
					}
				}
				else
				{
					this.htmlGenericControl_0.Visible = false;
				}
			}
		}
		private void method_1()
		{
			string a = string.Empty;
			if (this.htmlTableRow_4 != null)
			{
				a = this.shopNum1_OnLineService_Action_0.GetIsShowByID("3");
				if (a == "1")
				{
					this.htmlTableRow_4.Visible = true;
					this.htmlTableRow_5.Visible = true;
					if (this.repeater_1 != null)
					{
						DataTable dataTable = this.shopNum1_OnLineService_Action_0.SearchTypeInfo("MSN", 1);
						this.repeater_1.DataSource = dataTable.DefaultView;
						this.repeater_1.DataBind();
					}
				}
				else
				{
					this.htmlTableRow_4.Visible = false;
					this.htmlTableRow_5.Visible = false;
				}
			}
			else if (this.htmlGenericControl_1 != null)
			{
				a = this.shopNum1_OnLineService_Action_0.GetIsShowByID("6");
				if (a == "1")
				{
					this.htmlGenericControl_1.Visible = true;
					if (this.repeater_1 != null)
					{
						DataTable dataTable = this.shopNum1_OnLineService_Action_0.SearchTypeInfo("MSN", 1);
						this.repeater_1.DataSource = dataTable.DefaultView;
						this.repeater_1.DataBind();
					}
				}
				else
				{
					this.htmlGenericControl_1.Visible = false;
				}
			}
		}
		private void method_2()
		{
			string isShowByID = this.shopNum1_OnLineService_Action_0.GetIsShowByID("2");
			if (isShowByID == "1")
			{
				this.htmlTableRow_0.Visible = true;
				this.htmlTableRow_1.Visible = true;
				if (this.repeater_2 != null)
				{
					DataTable dataTable = this.shopNum1_OnLineService_Action_0.SearchTypeInfo("WW", 1);
					this.repeater_2.DataSource = dataTable.DefaultView;
					this.repeater_2.DataBind();
				}
			}
			else
			{
				this.htmlTableRow_0.Visible = false;
				this.htmlTableRow_1.Visible = false;
			}
		}
		private void method_3()
		{
			string isShowByID = this.shopNum1_OnLineService_Action_0.GetIsShowByID("4");
			if (isShowByID == "1")
			{
				this.htmlTableRow_6.Visible = true;
				this.htmlTableRow_7.Visible = true;
				if (this.repeater_3 != null)
				{
					DataTable dataTable = this.shopNum1_OnLineService_Action_0.SearchTypeInfo("HI", 1);
					this.repeater_3.DataSource = dataTable.DefaultView;
					this.repeater_3.DataBind();
				}
			}
			else
			{
				this.htmlTableRow_6.Visible = false;
				this.htmlTableRow_7.Visible = false;
			}
		}
	}
}
