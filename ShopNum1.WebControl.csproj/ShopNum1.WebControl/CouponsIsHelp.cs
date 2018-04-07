using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CouponsIsHelp : BaseWebControl
	{
		private string string_0 = "CouponsIsHelp.ascx";
		private Repeater repeater_0;
		private HtmlAnchor htmlAnchor_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ArticleCategoryID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public CouponsIsHelp()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("AHelpMore");
			this.CouponsDataBind();
		}
		protected void CouponsDataBind()
		{
			try
			{
				int.Parse(this.ShowCount);
			}
			catch
			{
				this.ShowCount = "10";
			}
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable dataTable = shopNum1_Article_Action.SearchByArticleCategoryID(int.Parse(this.ArticleCategoryID), int.Parse(this.ShowCount));
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
			this.htmlAnchor_0.HRef = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/articlelist/",
				this.ArticleCategoryID,
				ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
			});
		}
	}
}
