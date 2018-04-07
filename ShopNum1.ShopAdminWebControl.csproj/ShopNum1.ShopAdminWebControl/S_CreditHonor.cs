using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_CreditHonor : BaseShopWebControl
	{
		private string string_0 = "S_CreditHonor.ascx";
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
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private DataTable dataTable_0 = null;
		public S_CreditHonor()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidSpeed");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidCharacter");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidAttitude");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divPage");
			this.repeater_0 = (Repeater)skin.FindControl("repBingComment");
			this.label_20 = (Label)skin.FindControl("lblGoodRate");
			this.label_0 = (Label)skin.FindControl("lblWeekGood");
			this.label_1 = (Label)skin.FindControl("lblWeekMiddle");
			this.label_2 = (Label)skin.FindControl("lblWeekBad");
			this.label_3 = (Label)skin.FindControl("lblWeekTotal");
			this.label_4 = (Label)skin.FindControl("lblMonthGood");
			this.label_5 = (Label)skin.FindControl("lblMonthMiddle");
			this.label_6 = (Label)skin.FindControl("lblMonthBad");
			this.label_7 = (Label)skin.FindControl("lblMonthTotal");
			this.label_8 = (Label)skin.FindControl("lblSixBMonthGood");
			this.label_9 = (Label)skin.FindControl("lblSixBMonthMiddle");
			this.label_10 = (Label)skin.FindControl("lblSixBMonthBad");
			this.label_11 = (Label)skin.FindControl("lblSixBMonthTotal");
			this.label_12 = (Label)skin.FindControl("lblSixRMonthGood");
			this.label_13 = (Label)skin.FindControl("lblSixRMonthMiddle");
			this.label_14 = (Label)skin.FindControl("lblSixRMonthBad");
			this.label_15 = (Label)skin.FindControl("lblSixRMonthTotal");
			this.label_16 = (Label)skin.FindControl("lblGoodTotal");
			this.label_17 = (Label)skin.FindControl("lblMiddleTotal");
			this.label_18 = (Label)skin.FindControl("lblBadTotal");
			this.label_19 = (Label)skin.FindControl("lblAllTotal");
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				string goodRate = shop_ProductComment_Action.GetGoodRate(this.MemLoginID, "4");
				DataTable shopCommentCount = shop_ProductComment_Action.GetShopCommentCount(this.MemLoginID, "1");
				if (goodRate != "")
				{
					this.label_20.Text = goodRate.Split(new char[]
					{
						'|'
					})[0];
					this.htmlInputHidden_0.Value = goodRate.Split(new char[]
					{
						'|'
					})[1];
					this.htmlInputHidden_1.Value = goodRate.Split(new char[]
					{
						'|'
					})[2];
					this.htmlInputHidden_2.Value = goodRate.Split(new char[]
					{
						'|'
					})[3];
				}
				if (shopCommentCount.Rows.Count > 0)
				{
					this.label_0.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "' and CommentType='5'").Count<DataRow>().ToString();
					this.label_1.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "' and CommentType='3'").Count<DataRow>().ToString();
					this.label_2.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "' and CommentType='1'").Count<DataRow>().ToString();
					this.label_3.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddDays(-7.0) + "'").Count<DataRow>().ToString();
					this.label_4.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "' and CommentType='5'").Count<DataRow>().ToString();
					this.label_5.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "' and CommentType='3'").Count<DataRow>().ToString();
					this.label_6.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "' and CommentType='1'").Count<DataRow>().ToString();
					this.label_7.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-1) + "'").Count<DataRow>().ToString();
					this.label_8.Text = shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "' and CommentType='5'").Count<DataRow>().ToString();
					this.label_9.Text = shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "' and CommentType='3'").Count<DataRow>().ToString();
					this.label_10.Text = shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "' and CommentType='1'").Count<DataRow>().ToString();
					this.label_11.Text = shopCommentCount.Select("CommentTime<='" + DateTime.Now.AddMonths(-6) + "'").Count<DataRow>().ToString();
					this.label_12.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "' and CommentType='5'").Count<DataRow>().ToString();
					this.label_13.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "' and CommentType='3'").Count<DataRow>().ToString();
					this.label_14.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "' and CommentType='1'").Count<DataRow>().ToString();
					this.label_15.Text = shopCommentCount.Select("CommentTime>='" + DateTime.Now.AddMonths(-6) + "'").Count<DataRow>().ToString();
					this.label_16.Text = shopCommentCount.Select("CommentType='5'").Count<DataRow>().ToString();
					this.label_17.Text = shopCommentCount.Select("CommentType='3'").Count<DataRow>().ToString();
					this.label_18.Text = shopCommentCount.Select("CommentType='1'").Count<DataRow>().ToString();
					this.label_19.Text = shopCommentCount.Rows.Count.ToString();
				}
			}
		}
		private void method_0()
		{
			string text = string.Empty;
			text = " and shoploginid='" + this.MemLoginID + "' and isaudit=1 ";
			if (ShopNum1.Common.Common.ReqStr("type") == "2")
			{
				text += " And buyerattitude is not null";
			}
			int pageSize = 10;
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shop_ProductComment_Action.SelectShopComment(pageSize.ToString(), pageID.ToString(), text, "0");
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/shopadmin/S_CreditHonor.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = pageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			this.dataTable_0 = shop_ProductComment_Action.SelectShopComment(pageSize.ToString(), pageID.ToString(), text, "1");
			this.repeater_0.DataSource = this.dataTable_0.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
