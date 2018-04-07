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
	public class AgentListOfArea : BaseWebControl
	{
		protected string strSapce = "\u3000\u3000";
		protected char charSapce = '\u3000';
		private string string_0 = "AgentListOfArea.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShowCount
		{
			get;
			set;
		}
		public string AreaCode
		{
			get;
			set;
		}
		public AgentListOfArea()
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
			this.AreaCode = ((this.Page.Request.QueryString["AreaCode"] == null) ? "" : this.Page.Request.QueryString["AreaCode"]);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.label_0 = (Label)skin.FindControl("LabelLevel1AreaName");
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) && this.label_0.Text == "")
			{
				string a = DataBinder.Eval(e.Item.DataItem, "MemLoginID").ToString();
				if (a == "")
				{
					this.label_0.Text = DataBinder.Eval(e.Item.DataItem, "name").ToString();
				}
			}
		}
		private void method_0()
		{
			if (!string.IsNullOrEmpty(this.AreaCode) && !(this.AreaCode == "-1"))
			{
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				DataTable dataTable = null;
				try
				{
					if (this.string_1 == "all")
					{
						dataTable = shopNum1_Member_Action.SearchAgentByAreacodeProp(this.AreaCode, this.ShowCount);
					}
					else
					{
						dataTable = shopNum1_Member_Action.SearchAgentByAreacodeProp(this.AreaCode, this.ShowCount, this.string_1);
					}
				}
				catch
				{
					dataTable = shopNum1_Member_Action.SearchAgentByAreacode(this.AreaCode, this.ShowCount);
				}
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					this.repeater_0.DataSource = dataTable;
					this.repeater_0.DataBind();
				}
			}
		}
	}
}
