using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopRankDetailed : BaseMemberWebControl
	{
		private string string_0 = "S_ShopRankDetailed.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Button button_0;
		public S_ShopRankDetailed()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_1.ItemDataBound += new RepeaterItemEventHandler(this.repeater_1_ItemDataBound);
			this.button_0 = (Button)skin.FindControl("ButtonBackList");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.BindData(this.Page.Request.QueryString["guid"].ToString());
			}
		}
		private void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = e.Item.FindControl("HiddenFieldShopTemplate") as HiddenField;
				this.repeater_0 = (Repeater)e.Item.FindControl("RepeaterData");
				ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopTemplate_Action();
				DataTable templateByID = shopNum1_ShopTemplate_Action.GetTemplateByID(hiddenField.Value);
				this.repeater_0.DataSource = templateByID;
				this.repeater_0.DataBind();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["type"] != null && this.Page.Request.QueryString["type"].ToString() == "open")
			{
				this.Page.Response.Redirect("S_ShopOpenStep1.aspx");
			}
			else
			{
				this.Page.Response.Redirect("S_ShowShopRank.aspx");
			}
		}
		public void BindData(string guid)
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			DataTable dataTable = shop_Rank_Action.Search("'" + guid + "'", 0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_1.DataSource = dataTable.DefaultView;
				this.repeater_1.DataBind();
			}
		}
	}
}
