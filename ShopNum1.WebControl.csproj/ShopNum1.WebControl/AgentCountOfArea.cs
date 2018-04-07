using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AgentCountOfArea : BaseWebControl
	{
		protected string strSapce = "\u3000\u3000";
		protected char charSapce = '\u3000';
		private string string_0 = "all";
		private string string_1 = "AgentCountOfArea.ascx";
		private Repeater repeater_0;
		public AgentCountOfArea()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_0 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable;
			if (this.string_0 == "all")
			{
				dataTable = shopNum1_Member_Action.SearchAgentCountOfAreacode();
			}
			else
			{
				dataTable = shopNum1_Member_Action.SearchAgentCountOfAreacode(this.string_0);
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
