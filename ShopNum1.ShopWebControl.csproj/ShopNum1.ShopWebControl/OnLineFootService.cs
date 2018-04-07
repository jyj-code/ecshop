using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class OnLineFootService : BaseWebControl
	{
		private string string_0 = "OnLineFootService.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private Repeater repeater_3;
		private Panel panel_0;
		private Panel panel_1;
		private Panel panel_2;
		private Panel panel_3;
		private Label label_0;
		private Shop_OnLineService_Action shop_OnLineService_Action_0 = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_3;
		public int ShowCount
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public OnLineFootService()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterQQ");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterWW");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterKFT");
			this.repeater_3 = (Repeater)skin.FindControl("RepeaterPH");
			this.panel_0 = (Panel)skin.FindControl("PanelQQ");
			this.panel_1 = (Panel)skin.FindControl("PanelWW");
			this.panel_2 = (Panel)skin.FindControl("PanelPhone");
			this.label_0 = (Label)skin.FindControl("Lab_Phone");
			this.panel_3 = (Panel)skin.FindControl("PanelShowServer");
			this.string_1 = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			string shopMemLoginIdByShopID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.string_1);
			string shopOpenTimeByShopID = shopNum1_ShopInfoList_Action.GetShopOpenTimeByShopID(this.string_1);
			if (shopMemLoginIdByShopID != "" && shopOpenTimeByShopID != "")
			{
				this.MemLoginID = shopMemLoginIdByShopID;
				string text = DateTime.Parse(shopOpenTimeByShopID).ToString("yyyy-MM-dd");
				this.shop_OnLineService_Action_0.StrPath = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text.Replace("-", "/"),
					"/",
					this.string_1,
					"/xml/OnLineServer.xml"
				});
				this.method_1();
				this.method_0(shopOpenTimeByShopID);
				if (this.repeater_1 != null)
				{
					this.method_2();
				}
			}
		}
		private void method_0(string string_4)
		{
			this.string_1 = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			if (this.string_1 != "0")
			{
				string text = DateTime.Parse(string_4).ToString("yyyy-MM-dd");
				string path = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text.Replace("-", "/"),
					"/",
					ShopSettings.GetValue("PersonShopUrl"),
					this.string_1,
					"/Site_Settings.xml"
				});
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(path));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				if (dataRow["ShowCustomer"].ToString() == "1")
				{
					this.panel_3.Visible = true;
				}
				else if (dataRow["ShowCustomer"].ToString() == "0")
				{
					this.panel_3.Visible = false;
				}
				try
				{
					if (dataRow["IsOpenServicePhone"].ToString() != "1")
					{
						this.panel_2.Visible = false;
					}
					else
					{
						this.panel_2.Visible = true;
						this.label_0.Text = dataRow["ServicePhone"].ToString();
					}
				}
				catch
				{
				}
			}
		}
		private void method_1()
		{
			DataTable onLineServiceList = this.shop_OnLineService_Action_0.GetOnLineServiceList1(this.MemLoginID, "QQ", this.ShowCount.ToString());
			if (onLineServiceList.Rows.Count > 0)
			{
				this.repeater_0.DataSource = onLineServiceList;
				this.repeater_0.DataBind();
			}
			else
			{
				this.panel_0.Visible = false;
				this.repeater_0.Visible = false;
			}
		}
		private void method_2()
		{
			DataTable onLineServiceList = this.shop_OnLineService_Action_0.GetOnLineServiceList1(this.MemLoginID, "WW", this.ShowCount.ToString());
			if (onLineServiceList != null && onLineServiceList.Rows.Count > 0)
			{
				this.repeater_1.DataSource = onLineServiceList;
				this.repeater_1.DataBind();
			}
			else
			{
				this.panel_1.Visible = false;
				this.repeater_1.Visible = false;
			}
		}
	}
}
