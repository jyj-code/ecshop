using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ZtcGoods : BaseWebControl
	{
		private string string_0 = "ZtcGoods.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public string ShowCount
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public string startNum
		{
			get;
			set;
		}
		public string endNum
		{
			get;
			set;
		}
		public ZtcGoods()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralTitle");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.literal_0.Text = this.Title;
			this.method_0();
		}
		private void method_0()
		{
			decimal ztc_Money = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney"));
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			DataTable dataTable = shopNum1_ZtcGoods_Action.Search(this.startNum, this.endNum, 1, ztc_Money, this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
