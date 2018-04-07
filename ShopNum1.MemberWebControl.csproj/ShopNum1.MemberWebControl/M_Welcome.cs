using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_Welcome : BaseMemberWebControl
	{
		private string string_0 = "M_Welcome.ascx";
		private Image image_0;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private HtmlAnchor htmlAnchor_0;
		private HtmlAnchor htmlAnchor_1;
		private Label label_3;
		private Label label_4;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Button button_0;
		private Label label_10;
		private HtmlAnchor htmlAnchor_2;
		private HtmlAnchor htmlAnchor_3;
		public M_Welcome()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlAnchor_2 = (HtmlAnchor)skin.FindControl("Sjwyz");
			this.htmlAnchor_3 = (HtmlAnchor)skin.FindControl("Yxwyz");
			this.label_10 = (Label)skin.FindControl("LabelShowShang");
			this.button_0 = (Button)skin.FindControl("ButtonSingin");
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
			DataTable dataTable = shopNum1_Member_Action.CheckSignin(this.MemLoginID, dayTime);
			if (dataTable != null && dataTable.Rows.Count != 0 && Convert.ToInt32(dataTable.Rows[0]["count"]) > 0)
			{
				this.button_0.Text = "已签到";
			}
			this.label_0 = (Label)skin.FindControl("LabelMemLoginID");
			this.label_1 = (Label)skin.FindControl("LabelLoginTime");
			this.label_2 = (Label)skin.FindControl("LabelLastLoginTime");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Sjyz");
			this.htmlAnchor_1 = (HtmlAnchor)skin.FindControl("Yxyz");
			this.label_3 = (Label)skin.FindControl("LabelAdvancePayment");
			this.label_4 = (Label)skin.FindControl("LabelScore");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterAnnouncement");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterShowCai");
			this.label_5 = (Label)skin.FindControl("LabelWwcOrder");
			this.label_6 = (Label)skin.FindControl("LabelWaitPayOrder");
			this.label_7 = (Label)skin.FindControl("LabelWaitMakeSure");
			this.label_8 = (Label)skin.FindControl("lblLifeWaitPayOrder");
			this.label_9 = (Label)skin.FindControl("lblLifeWaitMakeSure");
			this.image_0 = (Image)skin.FindControl("ImageRank");
			string nameById = ShopNum1.Common.Common.GetNameById("MemberRankGuid", "ShopNum1_Member", "  AND  MemLoginID='" + this.MemLoginID + "'");
			string str = Guid.NewGuid().ToString();
			if (!string.IsNullOrEmpty(nameById))
			{
				str = nameById;
			}
			ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
			DataTable dataTable2 = shopNum1_MemberRank_Action.Search("'" + str + "'", 0);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				string text = dataTable2.Rows[0]["Pic"].ToString();
				if (text.StartsWith("/"))
				{
					this.image_0.ImageUrl = text;
				}
				else
				{
					this.image_0.ImageUrl = "/" + text;
				}
				this.image_0.ToolTip = dataTable2.Rows[0]["Name"].ToString();
			}
			this.GetDataInfo();
			this.GetAnnouncement();
			this.GetRecommend();
		}
		public void GetDataInfo()
		{
			this.label_0.Text = this.MemLoginID;
			this.label_1.Text = ShopNum1.Common.Common.GetNameById("LoginTime", "ShopNum1_Member", " AND   MemLoginID ='" + this.MemLoginID + "'");
			this.label_2.Text = ShopNum1.Common.Common.GetNameById("LoginDate", "ShopNum1_Member", " AND   MemLoginID ='" + this.MemLoginID + "'");
			if (Convert.ToDateTime("1900-1-1").ToString() == this.label_2.Text)
			{
				this.label_10.Visible = false;
				this.label_2.Text = "";
			}
			if (ShopNum1.Common.Common.GetNameById("IsMobileActivation", "ShopNum1_Member", " AND   MemLoginID ='" + this.MemLoginID + "'") == "1")
			{
				this.htmlAnchor_0.Visible = true;
				this.htmlAnchor_2.Visible = false;
			}
			else
			{
				this.htmlAnchor_2.Visible = true;
				this.htmlAnchor_0.Visible = false;
			}
			if (ShopNum1.Common.Common.GetNameById("IsEmailActivation", "ShopNum1_Member", " AND   MemLoginID ='" + this.MemLoginID + "'") == "1")
			{
				this.htmlAnchor_1.Visible = true;
				this.htmlAnchor_3.Visible = false;
			}
			else
			{
				this.htmlAnchor_1.Visible = false;
				this.htmlAnchor_3.Visible = true;
			}
			this.label_3.Text = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", " AND   MemLoginID ='" + this.MemLoginID + "'");
			this.label_4.Text = ShopNum1.Common.Common.GetNameById("Score", "ShopNum1_Member", " AND   MemLoginID ='" + this.MemLoginID + "'");
			this.label_5.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   MemLoginID ='" + this.MemLoginID + "'  AND  OderStatus IN(0,2)  AND IsDeleted=0 ");
			this.label_6.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   MemLoginID ='" + this.MemLoginID + "'  AND  OderStatus=0    AND PaymentStatus=0  And FeeType!=2  AND IsDeleted=0");
			this.label_7.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   MemLoginID ='" + this.MemLoginID + "'  AND  OderStatus=2  And FeeType!=2   AND IsDeleted=0");
			try
			{
				this.label_8.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   MemLoginID ='" + this.MemLoginID + "'  AND  OderStatus=0 And FeeType=2  AND PaymentStatus=0   AND IsDeleted=0");
				this.label_9.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo", " AND   MemLoginID ='" + this.MemLoginID + "'  AND  OderStatus=2 And FeeType=2  AND IsDeleted=0");
			}
			catch
			{
			}
		}
		public void GetAnnouncement()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable announcementByTypeName = shopNum1_Article_Action.GetAnnouncementByTypeName("会员公告", 3);
			if (announcementByTypeName != null && announcementByTypeName.Rows.Count > 0)
			{
				this.repeater_0.DataSource = announcementByTypeName.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public void GetRecommend()
		{
			DataTable tableById = ShopNum1.Common.Common.GetTableById("  TOP 4  *", "ShopNum1_Shop_Product", "  AND   IsRecommend =1   ORDER  BY   OrderID  DESC   ");
			if (tableById != null && tableById.Rows.Count > 0)
			{
				this.repeater_1.DataSource = tableById.DefaultView;
				this.repeater_1.DataBind();
			}
		}
	}
}
