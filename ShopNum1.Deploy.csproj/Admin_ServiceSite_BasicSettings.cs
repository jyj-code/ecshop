using ShopNum1.Common;
using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_ServiceSite_BasicSettings : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label tab01;
	protected Label tab02;
	protected Label tab03;
	protected Label tab04;
	protected Label tab05;
	protected Label LabelAddCouponIsAudit;
	protected DropDownList DropDownListAddCouponIsAudit;
	protected Label LabelAddProductIsAudit;
	protected DropDownList DropDownListAddProductIsAudit;
	protected Label LabelAddPanicBuyProductIsAudit;
	protected DropDownList DropDownListAddPanicBuyProductIsAudit;
	protected Label LabelAddSpellBuyProductIsAudit;
	protected DropDownList DropDownListAddSpellBuyProductIsAudit;
	protected Label LabelProductCommentISAudit;
	protected DropDownList DropDownListProductCommentISAudit;
	protected Label LabelSupplyDemandCommentISAudit;
	protected DropDownList DropDownListSupplyDemandCommentISAudit;
	protected Label LabelArticleCommentISAudit;
	protected DropDownList DropDownListArticleCommentISAudit;
	protected Label LabelShopArticleCommentISAudit;
	protected DropDownList DropDownListShopArticleCommentISAudit;
	protected Label LabelMessageCommentISAudit;
	protected DropDownList DropDownListMessageCommentISAudit;
	protected Label LabelShopMessageCommentISAudit;
	protected DropDownList DropDownListShopMessageCommentISAudit;
	protected Label LabelVideoCommentISAudit;
	protected DropDownList DropDownListVideoCommentISAudit;
	protected Label LabelSupplyDemandIsAudit;
	protected DropDownList DropDownListSupplyDemandIsAudit;
	protected HtmlGenericControl content1;
	protected Label Label7;
	protected DropDownList DropDownListMobileCheck;
	protected Label LabelProductCommentVerifyCode;
	protected DropDownList DropDownListProductCommentVerifyCode;
	protected Label Label8;
	protected DropDownList DropDownListKewWordCheck;
	protected Label LabelSupplyDemandCommentVerifyCode;
	protected DropDownList DropDownListSupplyDemandCommentVerifyCode;
	protected Label LabelProductBuyVerifyCode;
	protected DropDownList DropDownListProductBuyVerifyCode;
	protected Label LabelAriticleCommentVerifyCode;
	protected DropDownList DropDownListAriticleCommentVerifyCode;
	protected Label LabelShopAriticleCommentVerifyCode;
	protected DropDownList DropDownListShopAriticleCommentVerifyCode;
	protected Label LabelVideoCommentVerifyCode;
	protected DropDownList DropDownListVideoCommentVerifyCode;
	protected Label LabelMessageVerifyCode;
	protected DropDownList DropDownListMessageVerifyCode;
	protected Label LabelShopMessageVerifyCode;
	protected DropDownList DropDownListShopMessageVerifyCode;
	protected Label LabelRegVerifyCode;
	protected DropDownList DropDownListRegVerifyCode;
	protected Label LabelMemLoginVerifyCode;
	protected DropDownList DropDownListMemLoginVerifyCode;
	protected Label LabelArticleCommentCondition;
	protected DropDownList DropDownListArticleCommentCondition;
	protected Label LabelShopArticleCommentCondition;
	protected DropDownList DropDownListShopArticleCommentCondition;
	protected Label LabelMessageCondition;
	protected DropDownList DropDownListMessageCondition;
	protected Label LabelShopMessageCondition;
	protected DropDownList DropDownListShopMessageCondition;
	protected Label LabelSupplyDemandCommentCondition;
	protected DropDownList DropDownListSupplyDemandCommentCondition;
	protected Label Label1;
	protected DropDownList DropDownListVideoCommentCondition;
	protected HtmlGenericControl content2;
	protected Label Label2;
	protected DropDownList DropDownListSignOrSendScore;
	protected Label Label5;
	protected TextBox TextBoxSignScore;
	protected Label Label6;
	protected TextBox TextBoxSignRankScore;
	protected Label LabelDecreaseRepertory;
	protected DropDownList DropDownListDecreaseRepertory;
	protected Label LabelPayIsEmail;
	protected DropDownList DropDownListPayIsEmail;
	protected Label LabelShipmentIsEmail;
	protected DropDownList DropDownListShipmentIsEmail;
	protected Label LabelShipmentOKIsEmail;
	protected DropDownList DropDownListShipmentOKIsEmail;
	protected Label LabelCancelOrderIsEmail;
	protected DropDownList DropDownListCancelOrderIsEmail;
	protected Label LabelOrderIsEmail;
	protected DropDownList DropDownListOrderIsEmail;
	protected Label LabelMemberRegister;
	protected DropDownList DropDownListMemberRegister;
	protected Label Label28;
	protected DropDownList DropDownListRegIsActivationEmail;
	protected Label LabelApplyOpenShopIsEmail;
	protected DropDownList DropDownListApplyOpenShopIsEmail;
	protected Label LabelAuditOpenShopIsEmail;
	protected DropDownList DropDownListAuditOpenShopIsEmail;
	protected Label LabelRegPresentScore;
	protected TextBox TextBoxRegPresentScore;
	protected RegularExpressionValidator RegularExpressionValidatorRegPresentScore;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxRegPresentScore;
	protected Label LabelRegPresentRankScore;
	protected TextBox TextBoxRegPresentRankScore;
	protected RegularExpressionValidator RegularExpressionValidatorRegPresentRankScore;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxRegPresentRankScore;
	protected Label LabelMyMessageRankSorce;
	protected TextBox TextBoxMyMessageRankSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMyMessageRankSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxMyMessageRankSorce;
	protected Label LabelMyMessageSorce;
	protected TextBox TextBoxMyMessageSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMyMessageSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxMyMessageSorce;
	protected Label LabelMyShopMessageRankSorce;
	protected TextBox TextBoxMyShopMessageRankSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMyShopMessageRankSorce;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxMyShopMessageRankSorce;
	protected Label LabelMyShopMessageSorce;
	protected TextBox TextBoxMyShopMessageSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMyShopMessageSorce;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxMyShopMessageSorce;
	protected Label LabelBuyProductRankScore;
	protected TextBox TextBoxBuyProductRankScore;
	protected RequiredFieldValidator RequiredFieldValidatorBuyProductRankScore;
	protected RegularExpressionValidator RegularExpressionValidatorBuyProductRankScore;
	protected Label LabelBuyProductScore;
	protected TextBox TextBoxBuyProductScore;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxBuyProductScore;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxBuyProductScore;
	protected Label LabelMyCommentRankSorce;
	protected TextBox TextBoxMyCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMyCommentRankSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxMyCommentRankSorce;
	protected Label LabelMyCommentSorce;
	protected TextBox TextBoxMyCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMyCommentSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxMyCommentSorce;
	protected Label LabelSellerCommentRankSorce;
	protected TextBox TextBoxSellerCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxSellerCommentRankSorce;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label LabelSellerCommentSorce;
	protected TextBox TextBoxSellerCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxSellerCommentSorce;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected Label LabelArticleCommentRankSorce;
	protected TextBox TextBoxArticleCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxArticleCommentRankSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxArticleCommentRankSorce;
	protected Label LabelArticleCommentSorce;
	protected TextBox TextBoxArticleCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxArticleCommentSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxArticleCommentSorce;
	protected Label LabelShopArticleCommentRankSorce;
	protected TextBox TextBoxShopArticleCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidator5;
	protected RegularExpressionValidator RegularExpressionValidator4;
	protected Label LabelShopArticleCommentSorce;
	protected TextBox TextBoxShopArticleCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidator6;
	protected RegularExpressionValidator RegularExpressionValidator5;
	protected Label LabelMySupplyDemandCommentRankSorce;
	protected TextBox TextBoxMySupplyDemandCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidator7;
	protected RegularExpressionValidator RegularExpressionValidator6;
	protected Label LabelMySupplyDemandCommentSorce;
	protected TextBox TextBoxMySupplyDemandCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidator8;
	protected RegularExpressionValidator RegularExpressionValidator7;
	protected Label LabelMyCategoryInfoCommentRankSorce;
	protected TextBox TextBoxMyCategoryInfoCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidator9;
	protected RegularExpressionValidator RegularExpressionValidator8;
	protected Label LabelMyCategoryInfoCommentSorce;
	protected TextBox TextBoxMyCategoryInfoCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidator10;
	protected RegularExpressionValidator RegularExpressionValidator9;
	protected Label LabelVideoCommentRankSorce;
	protected TextBox TextBoxVideoCommentRankSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxVideoCommentRankSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxVideoCommentRankSorce;
	protected Label LabelVideoCommentSorce;
	protected TextBox TextBoxVideoCommentSorce;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxVideoCommentSorce;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxVideoCommentSorce;
	protected Label LabelGoodAppraiseReputation;
	protected TextBox TextBoxGoodAppraiseReputation;
	protected RequiredFieldValidator RequiredFieldValidatorGoodAppraiseReputation;
	protected RegularExpressionValidator RegularExpressionValidatorGoodAppraiseReputation;
	protected Label LabelStandardAppraiseReputation;
	protected TextBox TextBoxStandardAppraiseReputation;
	protected RequiredFieldValidator RequiredFieldValidatorStandardAppraiseReputation;
	protected RegularExpressionValidator RegularExpressionValidatorStandardAppraiseReputation;
	protected Label LabelBadAppraiseReputation;
	protected TextBox TextBoxBadAppraiseReputation;
	protected RequiredFieldValidator RequiredFieldValidatorBadAppraiseReputation;
	protected RegularExpressionValidator RegularExpressionValidatorBadAppraiseReputation;
	protected HtmlGenericControl content3;
	protected DropDownList DropDownListAdminProductFcRate;
	protected TextBox TextBoxAdminProductFcRate;
	protected RequiredFieldValidator RequiredFieldValidatorAdminProductFcRate;
	protected RegularExpressionValidator RegularExpressionValidatorAdminProductFcRate;
	protected DropDownList DropDownListIsAdminProductFcCount;
	protected TextBox TextBoxAdminProductFcCount;
	protected RequiredFieldValidator RequiredFieldValidator13;
	protected RegularExpressionValidator RegularExpressionValidator17;
	protected DropDownList DropDownListIsOrderCommission;
	protected TextBox TextBoxOrderCommission;
	protected RequiredFieldValidator RequiredFieldValidator12;
	protected RegularExpressionValidator RegularExpressionValidator16;
	protected DropDownList DropDownListIsAgentOrderCommission;
	protected TextBox TextBoxAgentOrderCommission;
	protected RequiredFieldValidator RequiredFieldValidator15;
	protected RegularExpressionValidator RegularExpressionValidator15;
	protected DropDownList DropDownListIsRecommendCommision;
	protected TextBox TextBoxRecommendCommision;
	protected RequiredFieldValidator RequiredFieldValidator14;
	protected RegularExpressionValidator RegularExpressionValidator14;
	protected HtmlGenericControl content4;
	protected Label Label1SiteHtml;
	protected DropDownList DropDownListSiteHtml;
	protected Label Label10;
	protected TextBox TextBoxShopID;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxShopID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxShopID;
	protected Label Label26;
	protected TextBox TextBoxDefaultReceivedDays;
	protected RegularExpressionValidator RegularExpressionValidator10;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected Label Label27;
	protected TextBox TextBoxDefaultCancelOrderDays;
	protected RegularExpressionValidator RegularExpressionValidator11;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected Label Label24;
	protected TextBox TextBoxRefundIsAdmin;
	protected RegularExpressionValidator RegularExpressionValidator12;
	protected RequiredFieldValidator RequiredFieldValidator11;
	protected Label Label3;
	protected TextBox TextBoxMaxScroeProductCount;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected Label Label4;
	protected TextBox TextBoxZtcGoodsMoney;
	protected RegularExpressionValidator RegularExpressionValidator13;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected Label Label9;
	protected HtmlInputText txtWxPay;
	protected Label Label12;
	protected RadioButtonList RadioButtonListPayType;
	protected Localize Localize2;
	protected TextBox TextBoxICPNum;
	protected Localize Localize3;
	protected FileUpload FileUploadICP;
	protected HtmlGenericControl content5;
	protected Button ButtonEdit;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldXmlPath;
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
		if (!this.Page.IsPostBack)
		{
			this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
			this.BindSetting();
		}
	}
	protected void BindSetting()
	{
		XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
		foreach (XmlNode xmlNode in xmlNodeList)
		{
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				string name = xmlNode2.Name;
				switch (name)
				{
				case "OverrideUrl":
					this.DropDownListSiteHtml.SelectedValue = xmlNode2.InnerText;
					break;
				case "InitialShopID":
					this.TextBoxShopID.Text = xmlNode2.InnerText;
					break;
				case "DefaultReceivedDays":
					this.TextBoxDefaultReceivedDays.Text = xmlNode2.InnerText;
					break;
				case "DefaultCancelOrderDays":
					this.TextBoxDefaultCancelOrderDays.Text = xmlNode2.InnerText;
					break;
				case "RefundIsAdmin":
					this.TextBoxRefundIsAdmin.Text = xmlNode2.InnerText;
					break;
				case "MaxScroeProductCount":
					this.TextBoxMaxScroeProductCount.Text = xmlNode2.InnerText;
					break;
				case "ZtcMoney":
					this.TextBoxZtcGoodsMoney.Text = xmlNode2.InnerText;
					break;
				case "PayMentType":
					this.RadioButtonListPayType.SelectedValue = xmlNode2.InnerText;
					break;
				case "ICPNum":
					this.TextBoxICPNum.Text = xmlNode2.InnerText;
					break;
				case "IsMobileCheckPay":
					this.DropDownListMobileCheck.SelectedValue = xmlNode2.InnerText;
					break;
				case "AddCouponIsAudit":
					this.DropDownListAddCouponIsAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "AddProductIsAudit":
					this.DropDownListAddProductIsAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "AddSpellBuyProductIsAudit":
					this.DropDownListAddSpellBuyProductIsAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "AddPanicBuyProductIsAudit":
					this.DropDownListAddPanicBuyProductIsAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "SupplyDemandCommentISAudit":
					this.DropDownListSupplyDemandCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "ProductCommentISAudit":
					this.DropDownListProductCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "ArticleCommentISAudit":
					this.DropDownListArticleCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShopArticleCommentISAudit":
					this.DropDownListShopArticleCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "MessageCommentISAudit":
					this.DropDownListMessageCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShopMessageCommentISAudit":
					this.DropDownListShopMessageCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "VideoCommentISAudit":
					this.DropDownListVideoCommentISAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "SupplyDemandIsAudit":
					this.DropDownListSupplyDemandIsAudit.SelectedValue = xmlNode2.InnerText;
					break;
				case "RegPresentScore":
					this.TextBoxRegPresentScore.Text = xmlNode2.InnerText;
					break;
				case "RegPresentRankScore":
					this.TextBoxRegPresentRankScore.Text = xmlNode2.InnerText;
					break;
				case "ProductCommentVerifyCode":
					this.DropDownListProductCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "SupplyDemandCommentVerifyCode":
					this.DropDownListSupplyDemandCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "ProductBuyVerifyCode":
					this.DropDownListProductBuyVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "AriticleCommentVerifyCode":
					this.DropDownListAriticleCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShopAriticleCommentVerifyCode":
					this.DropDownListShopAriticleCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "VideoCommentVerifyCode":
					this.DropDownListVideoCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "MessageVerifyCode":
					this.DropDownListMessageVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "RegVerifyCode":
					this.DropDownListRegVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "MemLoginVerifyCode":
					this.DropDownListMemLoginVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "ArticleCommentCondition":
					this.DropDownListArticleCommentCondition.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShopArticleCommentCondition":
					this.DropDownListShopArticleCommentCondition.SelectedValue = xmlNode2.InnerText;
					break;
				case "MessageCondition":
					this.DropDownListMessageCondition.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShopMessageCondition":
					this.DropDownListShopMessageCondition.SelectedValue = xmlNode2.InnerText;
					break;
				case "SupplyDemandCommentCondition":
					this.DropDownListSupplyDemandCommentCondition.SelectedValue = xmlNode2.InnerText;
					break;
				case "DecreaseRepertory":
					this.DropDownListDecreaseRepertory.SelectedValue = xmlNode2.InnerText;
					break;
				case "MyMessageRankSorce":
					this.TextBoxMyMessageRankSorce.Text = xmlNode2.InnerText;
					break;
				case "MyMessageSorce":
					this.TextBoxMyMessageSorce.Text = xmlNode2.InnerText;
					break;
				case "MyShopMessageRankSorce":
					this.TextBoxMyShopMessageRankSorce.Text = xmlNode2.InnerText;
					break;
				case "MyShopMessageSorce":
					this.TextBoxMyShopMessageSorce.Text = xmlNode2.InnerText;
					break;
				case "BuyProductRankScore":
					this.TextBoxBuyProductRankScore.Text = xmlNode2.InnerText;
					break;
				case "BuyProductScore":
					this.TextBoxBuyProductScore.Text = xmlNode2.InnerText;
					break;
				case "MyProductCommentRankSorce":
					this.TextBoxMyCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "MyProductCommentSorce":
					this.TextBoxMyCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "SellerCommentRankSorce":
					this.TextBoxSellerCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "SellerCommentSorce":
					this.TextBoxSellerCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "MySupplyDemandCommentRankSorce":
					this.TextBoxMySupplyDemandCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "MySupplyDemandCommentSorce":
					this.TextBoxMySupplyDemandCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "MyCategoryInfoCommentRankSorce":
					this.TextBoxMyCategoryInfoCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "MyCategoryInfoCommentSorce":
					this.TextBoxMyCategoryInfoCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "ArticleCommentRankSorce":
					this.TextBoxArticleCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "ArticleCommentSorce":
					this.TextBoxArticleCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "ShopArticleCommentRankSorce":
					this.TextBoxShopArticleCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "ShopArticleCommentSorce":
					this.TextBoxShopArticleCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "VideoCommentRankSorce":
					this.TextBoxVideoCommentRankSorce.Text = xmlNode2.InnerText;
					break;
				case "VideoCommentSorce":
					this.TextBoxVideoCommentSorce.Text = xmlNode2.InnerText;
					break;
				case "GoodAppraiseReputation":
					this.TextBoxGoodAppraiseReputation.Text = xmlNode2.InnerText;
					break;
				case "StandardAppraiseReputation":
					this.TextBoxStandardAppraiseReputation.Text = xmlNode2.InnerText;
					break;
				case "BadAppraiseReputation":
					this.TextBoxBadAppraiseReputation.Text = xmlNode2.InnerText;
					break;
				case "SignOrSendScore":
					this.DropDownListSignOrSendScore.SelectedValue = xmlNode2.InnerText;
					break;
				case "SignScore":
					this.TextBoxSignScore.Text = xmlNode2.InnerText;
					break;
				case "SignRankScore":
					this.TextBoxSignRankScore.Text = xmlNode2.InnerText;
					break;
				case "ShopMessageVerifyCode":
					this.DropDownListShopMessageVerifyCode.SelectedValue = xmlNode2.InnerText;
					break;
				case "IsShopProductFcRate":
					this.DropDownListAdminProductFcRate.Text = xmlNode2.InnerText;
					break;
				case "AdminProductFcRate":
					this.TextBoxAdminProductFcRate.Text = xmlNode2.InnerText;
					break;
				case "IsAdminProductFcCount":
					this.DropDownListIsAdminProductFcCount.Text = xmlNode2.InnerText;
					break;
				case "AdminProductFcCount":
					this.TextBoxAdminProductFcCount.Text = xmlNode2.InnerText;
					break;
				case "IsOrderCommission":
					this.DropDownListIsOrderCommission.Text = xmlNode2.InnerText;
					break;
				case "OrderCommission":
					this.TextBoxOrderCommission.Text = xmlNode2.InnerText;
					break;
				case "IsAgentOrderCommission":
					this.DropDownListIsAgentOrderCommission.SelectedValue = xmlNode2.InnerText;
					break;
				case "AgentOrderCommission":
					this.TextBoxAgentOrderCommission.Text = xmlNode2.InnerText;
					break;
				case "VideoCommentCondition":
					this.DropDownListVideoCommentCondition.Text = xmlNode2.InnerText;
					break;
				case "IsRecommendCommisionOpen":
					this.DropDownListIsRecommendCommision.SelectedValue = xmlNode2.InnerText;
					break;
				case "RecommendCommision":
					this.TextBoxRecommendCommision.Text = xmlNode2.InnerText;
					break;
				case "KeyWordCheck":
					this.DropDownListKewWordCheck.Text = xmlNode2.InnerText;
					break;
				case "WxPayMoney":
					this.txtWxPay.Value = xmlNode2.InnerText;
					break;
				}
			}
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		int num = 1;
		try
		{
			this.Updata();
		}
		catch (Exception)
		{
			num = 0;
		}
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			ShopSettings.ResetShopSetting();
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Updata()
	{
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OverrideUrl", this.DropDownListSiteHtml.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/KeyWordCheck", this.DropDownListKewWordCheck.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/InitialShopID", this.TextBoxShopID.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/DefaultReceivedDays", this.TextBoxDefaultReceivedDays.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/DefaultCancelOrderDays", this.TextBoxDefaultCancelOrderDays.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RefundIsAdmin", this.TextBoxRefundIsAdmin.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MaxScroeProductCount", this.TextBoxMaxScroeProductCount.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ZtcMoney", this.TextBoxZtcGoodsMoney.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PayMentType", this.RadioButtonListPayType.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ICPNum", this.TextBoxICPNum.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddCouponIsAudit", this.DropDownListAddCouponIsAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddProductIsAudit", this.DropDownListAddProductIsAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddSpellBuyProductIsAudit", this.DropDownListAddSpellBuyProductIsAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddPanicBuyProductIsAudit", this.DropDownListAddPanicBuyProductIsAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ProductCommentISAudit", this.DropDownListProductCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandCommentISAudit", this.DropDownListSupplyDemandCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentISAudit", this.DropDownListArticleCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentISAudit", this.DropDownListShopArticleCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MessageCommentISAudit", this.DropDownListMessageCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopMessageCommentISAudit", this.DropDownListShopMessageCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentISAudit", this.DropDownListVideoCommentISAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentCondition", this.DropDownListVideoCommentCondition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandIsAudit", this.DropDownListSupplyDemandIsAudit.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegPresentScore", this.TextBoxRegPresentScore.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegPresentRankScore", this.TextBoxRegPresentRankScore.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ProductCommentVerifyCode", this.DropDownListProductCommentVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandCommentVerifyCode", this.DropDownListSupplyDemandCommentVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ProductBuyVerifyCode", this.DropDownListProductBuyVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AriticleCommentVerifyCode", this.DropDownListAriticleCommentVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopAriticleCommentVerifyCode", this.DropDownListShopAriticleCommentVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentVerifyCode", this.DropDownListVideoCommentVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MessageVerifyCode", this.DropDownListMessageVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopMessageVerifyCode", this.DropDownListShopMessageVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegVerifyCode", this.DropDownListRegVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MemLoginVerifyCode", this.DropDownListMemLoginVerifyCode.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentCondition", this.DropDownListArticleCommentCondition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentCondition", this.DropDownListShopArticleCommentCondition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MessageCondition", this.DropDownListMessageCondition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopMessageCondition", this.DropDownListShopMessageCondition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandCommentCondition", this.DropDownListSupplyDemandCommentCondition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/DecreaseRepertory", this.DropDownListDecreaseRepertory.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyMessageRankSorce", this.TextBoxMyMessageRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyMessageSorce", this.TextBoxMyMessageSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyShopMessageRankSorce", this.TextBoxMyShopMessageRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyShopMessageSorce", this.TextBoxMyShopMessageSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/BuyProductRankScore", this.TextBoxBuyProductRankScore.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/BuyProductScore", this.TextBoxBuyProductScore.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyProductCommentRankSorce", this.TextBoxMyCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyProductCommentSorce", this.TextBoxMyCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SellerCommentRankSorce", this.TextBoxSellerCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SellerCommentSorce", this.TextBoxSellerCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentRankSorce", this.TextBoxArticleCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentSorce", this.TextBoxArticleCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentRankSorce", this.TextBoxShopArticleCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentSorce", this.TextBoxShopArticleCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MySupplyDemandCommentRankSorce", this.TextBoxMySupplyDemandCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MySupplyDemandCommentSorce", this.TextBoxMySupplyDemandCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyCategoryInfoCommentRankSorce", this.TextBoxMyCategoryInfoCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyCategoryInfoCommentSorce", this.TextBoxMyCategoryInfoCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentRankSorce", this.TextBoxVideoCommentRankSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentSorce", this.TextBoxVideoCommentSorce.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/GoodAppraiseReputation", this.TextBoxGoodAppraiseReputation.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/StandardAppraiseReputation", this.TextBoxStandardAppraiseReputation.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/BadAppraiseReputation", this.TextBoxBadAppraiseReputation.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SignOrSendScore", this.DropDownListSignOrSendScore.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SignScore", this.TextBoxSignScore.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SignRankScore", this.TextBoxSignRankScore.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsRecommendCommisionOpen", this.DropDownListIsRecommendCommision.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RecommendCommision", this.TextBoxRecommendCommision.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsShopProductFcRate", this.DropDownListAdminProductFcRate.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AdminProductFcRate", this.TextBoxAdminProductFcRate.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsAdminProductFcCount", this.DropDownListIsAdminProductFcCount.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AdminProductFcCount", this.TextBoxAdminProductFcCount.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsOrderCommission", this.DropDownListIsOrderCommission.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderCommission", this.TextBoxOrderCommission.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsAgentOrderCommission", this.DropDownListIsAgentOrderCommission.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AgentOrderCommission", this.TextBoxAgentOrderCommission.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WxPayMoney", this.txtWxPay.Value.Trim());
		ShopSettings.ResetShopSetting();
	}
	protected bool FileUpload(FileUpload fileUpload, string filepath, out string strext)
	{
		new Random();
		string fileName = fileUpload.PostedFile.FileName;
		FileInfo fileInfo = new FileInfo(fileName);
		string text = "~/Upload/";
		fileName.Substring(fileName.LastIndexOf(".") + 1);
		string arg_3E_0 = fileUpload.PostedFile.ContentType;
		int contentLength = fileUpload.PostedFile.ContentLength;
		bool result;
		if (fileName != "")
		{
			if (contentLength < 1024000)
			{
				if (!Directory.Exists(base.Server.MapPath(text)))
				{
					Directory.CreateDirectory(base.Server.MapPath(text));
				}
				fileUpload.PostedFile.SaveAs(base.Server.MapPath(text + fileInfo.Name));
				strext = fileName;
				result = true;
			}
			else
			{
				strext = "文件不能大于1M！";
				result = false;
			}
		}
		else
		{
			strext = "upload 为空！";
			result = false;
		}
		return result;
	}
}
