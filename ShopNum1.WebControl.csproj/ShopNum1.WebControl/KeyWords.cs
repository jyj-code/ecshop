using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class KeyWords : BaseWebControl
	{
		private string string_0 = "KeyWords.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		public KeyWords()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterKeyWords");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			string value = ShopSettings.GetValue("KeywordsCount");
			ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
			DataTable dataTable = shopNum1_KeyWords_Action.SearchName(Convert.ToInt32(value), 0, this.string_1);
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
