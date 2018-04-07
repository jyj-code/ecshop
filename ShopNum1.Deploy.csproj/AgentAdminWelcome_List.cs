using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdminWelcome_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelLoginID;
	protected Label LabelCity;
	protected Label LabelAdvancePayment;
	protected Label LabelLastLoginTime;
	protected Label LabelVersion;
	protected Label LabelForCount;
	protected Label LabelForPayCount;
	protected Label LabelForDispatchCount;
	protected Label LabelForConfirmCount;
	protected Label LabelFinishedCount;
	protected Label LabelAuditProductCount;
	protected Label LabelProductCount;
	protected Label LabelSpellBuyProductCount;
	protected Label LabelPanicBuyProductCount;
	protected Label LabelBestCount;
	protected Label LabelRecommendCount;
	protected Label LabelNewCount;
	protected Label LabelHotCount;
	protected Label LabelAuditShopCount;
	protected Label LabelMemApply;
	protected Label LabelPaymentApply;
	protected Label LabelMessageBoard;
	protected Label LabelDemandCheck;
	protected Label LabelCategoryChecked;
	protected Label LabelProuductChecked;
	protected Label LabelProductCommentAudit;
	protected Label LabelProductPriceCount;
	protected Label LabelOrderNow;
	protected Label LabelMemberCount;
	protected Label LabelShopNowCount;
	protected Label LabelMemberAllCount;
	protected Label LabelShopAllCount;
	protected Label LabelBuyNumberCount;
	protected Label LabelMessageBoardCount;
	protected Label Label1MessageCount;
	protected Label LabelArticleComment;
	protected Label LabelProductComment;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (base.SubstationID == "all")
		{
			this.Page.Request.Cookies["AdminLoginCookie"].Expires = DateTime.Now.AddDays(-5.0);
			this.Page.Response.Cookies.Add(this.Page.Request.Cookies["AdminLoginCookie"]);
			base.Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
		}
		this.GetAdminWelcomeInfo();
	}
	protected void GetAdminWelcomeInfo()
	{
		string text = DateTime.Now.ToString("yyyy-MM-dd");
		ShopNum1_AdminWelcome_Action shopNum1_AdminWelcome_Action = new ShopNum1_AdminWelcome_Action();
		this.LabelLoginID.Text = base.ShopNum1LoginID;
		try
		{
			string text2 = string.Empty;
			string text3 = string.Empty;
			text2 = Common.GetNameById("Name", "ShopNum1_SubstationManage", "   AND  SubstationID='" + base.SubstationID + "'   ");
			text3 = Common.GetNameById("AdvancePayment", "ShopNum1_SubstationManage", "   AND  SubstationID='" + base.SubstationID + "'   ");
			if (!string.IsNullOrEmpty(text2))
			{
				this.LabelCity.Text = text2;
			}
			if (!string.IsNullOrEmpty(text3))
			{
				this.LabelAdvancePayment.Text = text3;
			}
			else
			{
				this.LabelAdvancePayment.Text = "0";
			}
		}
		catch (Exception)
		{
		}
		string text4 = string.Empty;
		if (this.Page.Request.Cookies["AdminLoginDateCookie"] != null)
		{
			HttpCookie cookie = this.Page.Request.Cookies["AdminLoginDateCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			text4 = httpCookie.Values["LastLoginTime"].ToString();
		}
		else
		{
			text4 = DateTime.Now.ToString();
		}
		this.LabelLastLoginTime.Text = text4;
		string value = ShopSettings.GetValue("ShopNum1Version");
		this.LabelVersion.Text = value;
		this.LabelForCount.Text = shopNum1_AdminWelcome_Action.SearchOrderForDispatch("", "", "", 2, base.SubstationID);
		this.LabelForDispatchCount.Text = shopNum1_AdminWelcome_Action.SearchOrderForDispatch("1", "0", "1", 10, base.SubstationID);
		this.LabelForConfirmCount.Text = shopNum1_AdminWelcome_Action.SearchOrderForDispatch("2", "", "", 10, base.SubstationID);
		this.LabelForPayCount.Text = shopNum1_AdminWelcome_Action.SearchOrderForDispatch("0", "", "0", 10, base.SubstationID);
		this.LabelFinishedCount.Text = shopNum1_AdminWelcome_Action.SearchOrderForDispatch("3", string.Empty, string.Empty, 10, base.SubstationID);
		this.LabelProductCount.Text = shopNum1_AdminWelcome_Action.SearchProductCount(0, base.SubstationID);
		this.LabelAuditProductCount.Text = shopNum1_AdminWelcome_Action.SearchAuditProductCount(0, 0, base.SubstationID);
		this.LabelPanicBuyProductCount.Text = shopNum1_AdminWelcome_Action.SearchActivityProductCount("1", "1", 2, base.SubstationID);
		this.LabelSpellBuyProductCount.Text = shopNum1_AdminWelcome_Action.SearchGroupProduct();
		this.LabelNewCount.Text = shopNum1_AdminWelcome_Action.SearchRecommendCount(string.Empty, string.Empty, string.Empty, "1", 0, base.SubstationID);
		this.LabelBestCount.Text = shopNum1_AdminWelcome_Action.SearchRecommendCount("1", string.Empty, string.Empty, string.Empty, 0, base.SubstationID);
		this.LabelHotCount.Text = shopNum1_AdminWelcome_Action.SearchRecommendCount(string.Empty, "1", string.Empty, string.Empty, 0, base.SubstationID);
		this.LabelRecommendCount.Text = shopNum1_AdminWelcome_Action.SearchRecommendCount(string.Empty, string.Empty, "1", string.Empty, 0, base.SubstationID);
		this.LabelMessageBoardCount.Text = shopNum1_AdminWelcome_Action.SearchMessageBoardCount(0, 0);
		this.Label1MessageCount.Text = shopNum1_AdminWelcome_Action.SearchMessageCount(0, 0);
		this.LabelArticleComment.Text = shopNum1_AdminWelcome_Action.SearchArticleCommentCount(0, 0);
		this.LabelProductComment.Text = shopNum1_AdminWelcome_Action.SearchProductCommentCount(0, 0);
		this.LabelAuditShopCount.Text = shopNum1_AdminWelcome_Action.SearchRegisterShopCount(0, text, 0, base.SubstationID);
		ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
		this.LabelMemApply.Text = shopNum1_AdvancePaymentApplyLog_Action.Search("", "", "", 1, 0, 0).Rows.Count.ToString();
		ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action2 = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
		this.LabelPaymentApply.Text = shopNum1_AdvancePaymentApplyLog_Action2.Search("", "", "", 0, 0, 0).Rows.Count.ToString();
		this.LabelMessageBoard.Text = shopNum1_AdminWelcome_Action.SearchMessageBoardCount();
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		this.LabelDemandCheck.Text = shopNum1_SupplyDemandCheck_Action.SearchNew("", "", "0", base.SubstationID).Rows.Count.ToString();
		this.LabelProuductChecked.Text = shopNum1_AdminWelcome_Action.SearchAuditProductCount(0, 0, base.SubstationID);
		this.LabelProductCommentAudit.Text = shopNum1_AdminWelcome_Action.SearchMessageBoardCount();
		this.LabelOrderNow.Text = shopNum1_AdminWelcome_Action.SearchOrderNowCount(base.SubstationID);
		this.LabelMemberAllCount.Text = shopNum1_AdminWelcome_Action.SearchAllMemberCount(0);
		this.LabelShopAllCount.Text = shopNum1_AdminWelcome_Action.SearchAllShopCount(0, base.SubstationID);
		if (shopNum1_AdminWelcome_Action.SearchSaleInfo(text, 0, base.SubstationID) == string.Empty)
		{
			this.LabelProductPriceCount.Text = "0.00";
		}
		else
		{
			this.LabelProductPriceCount.Text = shopNum1_AdminWelcome_Action.SearchSaleInfo(text, 0, base.SubstationID);
		}
		this.LabelBuyNumberCount.Text = shopNum1_AdminWelcome_Action.SearchSaleProductCount(text, 0);
		this.LabelMemberCount.Text = shopNum1_AdminWelcome_Action.SearchRegisterMemberCount(text, 0);
		this.LabelShopNowCount.Text = shopNum1_AdminWelcome_Action.SearchShopNowCount(base.SubstationID);
	}
}
