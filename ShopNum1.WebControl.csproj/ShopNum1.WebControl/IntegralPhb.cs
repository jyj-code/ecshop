using ShopNum1.BusinessLogic;
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
	public class IntegralPhb : BaseWebControl
	{
		private string string_0 = "IntegralPhb.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public IntegralPhb()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			if (!this.Page.IsPostBack)
			{
				this.GetData();
			}
		}
		public void GetData()
		{
			if (string.IsNullOrEmpty(this.ShowCount))
			{
				this.ShowCount = "4";
			}
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			DataTable dataTopWeb;
			if (this.string_1 == "all")
			{
				dataTopWeb = shopNum1_Shop_ScoreProduct_Action.GetDataTopWeb(1, 0, 1, Convert.ToInt32(this.ShowCount));
			}
			else
			{
				dataTopWeb = shopNum1_Shop_ScoreProduct_Action.GetDataTopWeb(1, 0, 1, Convert.ToInt32(this.ShowCount), this.string_1);
			}
			if (dataTopWeb != null && dataTopWeb.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTopWeb.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
