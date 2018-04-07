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
	public class S_ShopOpenStep1 : BaseMemberWebControl
	{
		private string string_0 = "S_ShopOpenStep1.ascx";
		private Repeater repeater_0;
		public S_ShopOpenStep1()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.GetData();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelShopTemplateCount");
				string text = label.Text;
				string text2 = "0";
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split(new char[]
					{
						','
					});
					text2 = array.Length.ToString();
				}
				label.Text = text2;
			}
		}
		public void GetData()
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)LogicFactory.CreateShop_Rank_Action();
			DataTable dataTable = shop_Rank_Action.Search(0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
