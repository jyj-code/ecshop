using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopCommentFavorableRate : BaseWebControl
	{
		private string string_0 = "ShopCommentFavorableRate.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Label label_10;
		private Label label_11;
		private Label label_12;
		private Label label_13;
		private Label label_14;
		private Label label_15;
		private Label label_16;
		private Label label_17;
		private Label label_18;
		private Label label_19;
		private Label label_20;
		public ShopCommentFavorableRate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelFavorableRate");
			this.label_1 = (Label)skin.FindControl("LabelGoodWeek");
			this.label_2 = (Label)skin.FindControl("LabelGoodOneMonth");
			this.label_3 = (Label)skin.FindControl("LabelGoodSixMonth");
			this.label_4 = (Label)skin.FindControl("LabelGoodPrevious");
			this.label_5 = (Label)skin.FindControl("LabelGoodAll");
			this.label_6 = (Label)skin.FindControl("LabelGeneralWeek");
			this.label_7 = (Label)skin.FindControl("LabelGeneralOneMonth");
			this.label_8 = (Label)skin.FindControl("LabelGeneralSixMonth");
			this.label_9 = (Label)skin.FindControl("LabelGeneralPrevious");
			this.label_10 = (Label)skin.FindControl("LabelGeneralAll");
			this.label_11 = (Label)skin.FindControl("LabelBadWeek");
			this.label_12 = (Label)skin.FindControl("LabelBadOneMonth");
			this.label_13 = (Label)skin.FindControl("LabelBadSixMonth");
			this.label_14 = (Label)skin.FindControl("LabelBadPrevious");
			this.label_15 = (Label)skin.FindControl("LabelBadAll");
			this.label_16 = (Label)skin.FindControl("LabelAllWeek");
			this.label_17 = (Label)skin.FindControl("LabelAllOneMonth");
			this.label_18 = (Label)skin.FindControl("LabelAllSixMonth");
			this.label_19 = (Label)skin.FindControl("LabelAllPrevious");
			this.label_20 = (Label)skin.FindControl("LabelAll");
			this.method_0();
		}
		private void method_0()
		{
			string shopid = (this.Page.Request.QueryString["ShopID"].ToString() == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			this.label_1.Text = shop_ProductComment_Action.ShopComment("5", "1", shopid).Rows[0][0].ToString();
			this.label_2.Text = shop_ProductComment_Action.ShopComment("5", "2", shopid).Rows[0][0].ToString();
			this.label_3.Text = shop_ProductComment_Action.ShopComment("5", "3", shopid).Rows[0][0].ToString();
			this.label_4.Text = shop_ProductComment_Action.ShopComment("5", "4", shopid).Rows[0][0].ToString();
			this.label_5.Text = shop_ProductComment_Action.ShopComment("5", string.Empty, shopid).Rows[0][0].ToString();
			this.label_6.Text = shop_ProductComment_Action.ShopComment("3", "1", shopid).Rows[0][0].ToString();
			this.label_7.Text = shop_ProductComment_Action.ShopComment("3", "2", shopid).Rows[0][0].ToString();
			this.label_8.Text = shop_ProductComment_Action.ShopComment("3", "3", shopid).Rows[0][0].ToString();
			this.label_9.Text = shop_ProductComment_Action.ShopComment("3", "4", shopid).Rows[0][0].ToString();
			this.label_10.Text = shop_ProductComment_Action.ShopComment("3", string.Empty, shopid).Rows[0][0].ToString();
			this.label_11.Text = shop_ProductComment_Action.ShopComment("1", "1", shopid).Rows[0][0].ToString();
			this.label_12.Text = shop_ProductComment_Action.ShopComment("1", "2", shopid).Rows[0][0].ToString();
			this.label_13.Text = shop_ProductComment_Action.ShopComment("1", "3", shopid).Rows[0][0].ToString();
			this.label_14.Text = shop_ProductComment_Action.ShopComment("1", "4", shopid).Rows[0][0].ToString();
			this.label_15.Text = shop_ProductComment_Action.ShopComment("1", string.Empty, shopid).Rows[0][0].ToString();
			this.label_16.Text = shop_ProductComment_Action.ShopComment(string.Empty, "1", shopid).Rows[0][0].ToString();
			this.label_17.Text = shop_ProductComment_Action.ShopComment(string.Empty, "2", shopid).Rows[0][0].ToString();
			this.label_18.Text = shop_ProductComment_Action.ShopComment(string.Empty, "3", shopid).Rows[0][0].ToString();
			this.label_19.Text = shop_ProductComment_Action.ShopComment(string.Empty, "4", shopid).Rows[0][0].ToString();
			this.label_20.Text = shop_ProductComment_Action.ShopComment(string.Empty, string.Empty, shopid).Rows[0][0].ToString();
			if (this.label_20.Text != "0")
			{
				this.label_0.Text = Convert.ToString(int.Parse(this.label_5.Text) * 100 / int.Parse(this.label_20.Text));
			}
			else
			{
				this.label_0.Text = "0";
			}
		}
	}
}
