using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ClearData : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected CheckBox CheckboxCheckAll;
	protected HtmlInputCheckBox checkboxAll;
	protected CheckBox CheckboxProduct;
	protected CheckBox CheckboxCategoryAndBrand;
	protected CheckBox CheckboxMem;
	protected CheckBox CheckboxShop;
	protected CheckBox CheckboxImage;
	protected CheckBox CheckboxArticle;
	protected CheckBox CheckboxVideo;
	protected CheckBox CheckboxAgentMessage;
	protected CheckBox CheckboxAttachMent;
	protected CheckBox CheckboxSurveyOption;
	protected CheckBox CheckboxLink;
	protected CheckBox CheckboxService;
	protected CheckBox CheckboxScore;
	protected CheckBox CheckboxAdvancePayment;
	protected CheckBox CheckboxLimtPackage;
	protected UpdatePanel UpdatePanel1;
	protected TextBox TextBoxLoginID;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected TextBox TextBoxPwd;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected Button ButtonClearExperienceData;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldCheckedClearData;
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
	}
	protected void ButtonClearExperienceData_Click(object sender, EventArgs e)
	{
		this.method_5();
		string string_ = this.TextBoxLoginID.Text.Trim();
		string sHA1SecondHash = Encryption.GetSHA1SecondHash(this.TextBoxPwd.Text.Trim());
		int num = this.method_6(string_, sHA1SecondHash);
		if (num > 0)
		{
			ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
			int num2 = shopNum1_Common_Action.DeleteAllFromTables(this.hiddenFieldCheckedClearData.Value);
			if (num2 > 0)
			{
				MessageBox.Show("清除体验数据成功");
			}
			else
			{
				MessageBox.Show("清除体验数据失败");
			}
		}
		else if (num == 0)
		{
			MessageBox.Show("用户名或密码错误");
		}
		else if (num == -1)
		{
			MessageBox.Show("用户被锁定");
		}
	}
	private void method_5()
	{
		this.hiddenFieldCheckedClearData.Value = "";
		if (this.CheckboxCheckAll.Checked)
		{
			this.hiddenFieldCheckedClearData.Value = "ShopNum1_Brand;";
			HiddenField expr_39 = this.hiddenFieldCheckedClearData;
			expr_39.Value += "ShopNum1_Shop_Product;ShopNum1_CategoryType;ShopNum1_ProductCategory;ShopNum1_Shop_ProductCategory;ShopNum1_ShopProductProp;ShopNum1_ShopProductPropValue;ShopNum1_ShopProduct_Browse;shopnum1_shop_productcomment;ShopNum1_TbItem;ShopNum1_TbSystem;ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog;";
			HiddenField expr_54 = this.hiddenFieldCheckedClearData;
			expr_54.Value += "ShopNum1_Member;ShopNum1_MessageBoard;ShopNum1_Address;ShopNum1_MemberGroup;ShopNum1_MemberAssignGroup;";
			HiddenField expr_6F = this.hiddenFieldCheckedClearData;
			expr_6F.Value += "ShopNum1_ShopInfo;ShopNum1_Shop_UserDefinedColumn;ShopNum1_ShopCategory;";
			HiddenField expr_8A = this.hiddenFieldCheckedClearData;
			expr_8A.Value += "ShopNum1_Image;ShopNum1_ImageCategory;ShopNum1_Shop_Image;ShopNum1_Shop_ImageCategory;ShopNum1_Shop_ImagePath;";
			HiddenField expr_A5 = this.hiddenFieldCheckedClearData;
			expr_A5.Value += "ShopNum1_Article;ShopNum1_ArticleComment;ShopNum1_RelatedArticle;ShopNum1_Shop_News;ShopNum1_Shop_NewsCategory;ShopNum1_Announcement;";
			HiddenField expr_C0 = this.hiddenFieldCheckedClearData;
			expr_C0.Value += "ShopNum1_Shop_Video;ShopNum1_Shop_VideoCategory;ShopNum1_Shop_VideoComment;";
			HiddenField expr_DB = this.hiddenFieldCheckedClearData;
			expr_DB.Value += "ShopNum1_UserMessage;shopNum1_MemberMessage;ShopNum1_MessageInfo;ShopNum1_AttachMent;ShopNum1_AttachMentCategory;ShopNum1_SurveyTheme;ShopNum1_SurveyOption;ShopNum1_Link;ShopNum1_OnlineService;";
			HiddenField expr_F6 = this.hiddenFieldCheckedClearData;
			expr_F6.Value += "ShopNum1_ZtcApply;ShopNum1_ZtcGoods;ShopNum1_ShopProduct_Browse;ShopNum1_ShopProduct_Browse;ShopNum1_Shop_ScoreProduct;ShopNum1_Shop_ScoreProductCategory;ShopNum1_ScoreOrderInfo;ShopNum1_ScoreOrderProduct;ShopNum1_ScoreProductCategory;ShopNum1_SignIn;";
			HiddenField expr_111 = this.hiddenFieldCheckedClearData;
			expr_111.Value += "ShopNum1_RankScoreModifyLog;ShopNum1_ScoreModifyLog;ShopNum1_SupplyDemand;ShopNum1_SupplyDemandCategory;ShopNum1_SupplyDemandComment;ShopNum1_PreTransfer;";
			HiddenField expr_12C = this.hiddenFieldCheckedClearData;
			expr_12C.Value += "ShopNum1_AdvancePaymentApplyLog;ShopNum1_AdvancePaymentFreezeLog;ShopNum1_AdvancePaymentModifyLog;ShopNum1_Limt_Package;ShopNum1_Limt_Product;ShopNum1_Product_Activity;ShopNum1_City_AdvancePaymentModifyLog;ShopNum1_SubstationManage;ShopNum1_AgentPaymentApplyLog;ShopNum1_VideoCategory;ShopNum1_Video;ShopNum1_VideoComment;ShopNum1_MMSGroupSend;ShopNum1_EmailGroupSend;ShopNum1_Shop_ApplyEnsure;ShopNum1_Shop_ApplyEnsure;ShopNum1_Shop_ApplyCateGory;ShopNum1_Shop_ApplyShopRank;ShopNum1_ShopURLManage;ShopNum1_MemberReport;ShopNum1_OrderComplaint";
		}
		else
		{
			if (this.CheckboxProduct.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_176 = this.hiddenFieldCheckedClearData;
					expr_176.Value += ";";
				}
				HiddenField expr_191 = this.hiddenFieldCheckedClearData;
				expr_191.Value += "ShopNum1_Shop_ProductCategory;ShopNum1_ShopProductProp;ShopNum1_ProductCategory;ShopNum1_TbItem;ShopNum1_TbSystem;ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog;ShopNum1_Shop_Product;ShopNum1_CategoryType;ShopNum1_ZtcApply;ShopNum1_ZtcGoods;ShopNum1_ShopProduct_Browse;ShopNum1_Spec;ShopNum1_SpecProudct;ShopNum1_SpecProudctDetails;ShopNum1_ProductCategory;ShopNum1_CategoryType;ShopNum1_Shop_Product;ShopNum1_ShopProductPropValue;ShopNum1_ShopProduct_Browse;shopnum1_shop_productcomment;ShopNum1_Shop_Cart";
			}
			if (this.CheckboxCategoryAndBrand.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_1D6 = this.hiddenFieldCheckedClearData;
					expr_1D6.Value += ";";
				}
				HiddenField expr_1F1 = this.hiddenFieldCheckedClearData;
				expr_1F1.Value += "ShopNum1_Brand";
			}
			if (this.CheckboxMem.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_236 = this.hiddenFieldCheckedClearData;
					expr_236.Value += ";";
				}
				HiddenField expr_251 = this.hiddenFieldCheckedClearData;
				expr_251.Value += "ShopNum1_Member;ShopNum1_MessageBoard;ShopNum1_Address;ShopNum1_MemberGroup;ShopNum1_MemberAssignGroup;ShopNum1_SignIn;ShopNum1_RankScoreModifyLog;ShopNum1_ScoreModifyLog;ShopNum1_SupplyDemand;ShopNum1_SupplyDemandCategory;ShopNum1_SupplyDemandComment;ShopNum1_OperateLog;ShopNum1_MMSGroupSend;ShopNum1_EmailGroupSend;ShopNum1_MemberReport;ShopNum1_OrderComplaint";
			}
			if (this.CheckboxShop.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_296 = this.hiddenFieldCheckedClearData;
					expr_296.Value += ";";
				}
				HiddenField expr_2B1 = this.hiddenFieldCheckedClearData;
				expr_2B1.Value += "ShopNum1_ShopInfo;ShopNum1_Shop_UserDefinedColumn;ShopNum1_ShopRank;ShopNum1_ShopCategory;ShopNum1_Shop_ApplyEnsure;ShopNum1_Shop_ApplyEnsure;ShopNum1_Shop_ApplyCateGory;ShopNum1_Shop_ApplyShopRank;ShopNum1_ShopURLManage";
			}
			if (this.CheckboxImage.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_2F6 = this.hiddenFieldCheckedClearData;
					expr_2F6.Value += ";";
				}
				HiddenField expr_311 = this.hiddenFieldCheckedClearData;
				expr_311.Value += "ShopNum1_Image;ShopNum1_ImageCategory;ShopNum1_Shop_Image;ShopNum1_Shop_ImageCategory;ShopNum1_Shop_ImagePath";
			}
			if (this.CheckboxArticle.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_356 = this.hiddenFieldCheckedClearData;
					expr_356.Value += ";";
				}
				HiddenField expr_371 = this.hiddenFieldCheckedClearData;
				expr_371.Value += "ShopNum1_Article;ShopNum1_ArticleComment;ShopNum1_RelatedArticle;ShopNum1_Shop_News;ShopNum1_Shop_NewsCategory;ShopNum1_ArticleCategory;ShopNum1_Announcement;ShopNum1_AnnouncementCategory";
			}
			if (this.CheckboxVideo.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_3B6 = this.hiddenFieldCheckedClearData;
					expr_3B6.Value += ";";
				}
				HiddenField expr_3D1 = this.hiddenFieldCheckedClearData;
				expr_3D1.Value += "ShopNum1_Shop_Video;ShopNum1_Shop_VideoCategory;ShopNum1_Shop_VideoComment;ShopNum1_Video;ShopNum1_VideoCategory;ShopNum1_VideoComment;ShopNum1_VideoCategory;ShopNum1_Video;ShopNum1_VideoComment";
			}
			if (this.CheckboxAgentMessage.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_416 = this.hiddenFieldCheckedClearData;
					expr_416.Value += ";";
				}
				HiddenField expr_431 = this.hiddenFieldCheckedClearData;
				expr_431.Value += "ShopNum1_UserMessage;shopNum1_MemberMessage;ShopNum1_MessageInfo";
			}
			if (this.CheckboxAttachMent.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_476 = this.hiddenFieldCheckedClearData;
					expr_476.Value += ";";
				}
				HiddenField expr_491 = this.hiddenFieldCheckedClearData;
				expr_491.Value += "ShopNum1_AttachMent;ShopNum1_AttachMentCategory";
			}
			if (this.CheckboxSurveyOption.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_4D6 = this.hiddenFieldCheckedClearData;
					expr_4D6.Value += ";";
				}
				HiddenField expr_4F1 = this.hiddenFieldCheckedClearData;
				expr_4F1.Value += "ShopNum1_SurveyTheme;ShopNum1_SurveyOption";
			}
			if (this.CheckboxLink.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_536 = this.hiddenFieldCheckedClearData;
					expr_536.Value += ";";
				}
				HiddenField expr_551 = this.hiddenFieldCheckedClearData;
				expr_551.Value += "ShopNum1_Link";
			}
			if (this.CheckboxService.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_596 = this.hiddenFieldCheckedClearData;
					expr_596.Value += ";";
				}
				HiddenField expr_5B1 = this.hiddenFieldCheckedClearData;
				expr_5B1.Value += "ShopNum1_OnlineService";
			}
			if (this.CheckboxScore.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_5F6 = this.hiddenFieldCheckedClearData;
					expr_5F6.Value += ";";
				}
				HiddenField expr_611 = this.hiddenFieldCheckedClearData;
				expr_611.Value += "ShopNum1_ShopProduct_Browse;ShopNum1_Shop_ScoreProduct;ShopNum1_Shop_ScoreProductCategory;ShopNum1_ScoreOrderInfo;ShopNum1_ScoreOrderProduct;ShopNum1_ScoreProductCategory";
			}
			if (this.CheckboxAdvancePayment.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_656 = this.hiddenFieldCheckedClearData;
					expr_656.Value += ";";
				}
				HiddenField expr_671 = this.hiddenFieldCheckedClearData;
				expr_671.Value += "ShopNum1_AdvancePaymentApplyLog;ShopNum1_AdvancePaymentFreezeLog;ShopNum1_AdvancePaymentModifyLog;ShopNum1_PreTransfer;ShopNum1_City_AdvancePaymentModifyLog;ShopNum1_SubstationManage;ShopNum1_AgentPaymentApplyLog;ShopNum1_ThreePaymentRecord";
			}
			if (this.CheckboxLimtPackage.Checked)
			{
				if (this.hiddenFieldCheckedClearData.Value != "")
				{
					HiddenField expr_6B6 = this.hiddenFieldCheckedClearData;
					expr_6B6.Value += ";";
				}
				HiddenField expr_6D1 = this.hiddenFieldCheckedClearData;
				expr_6D1.Value += "ShopNum1_Limt_Package;ShopNum1_Limt_Product;ShopNum1_Product_Activity;ShopNum1_ThemeActivity;ShopNum1_ThemeActivityProduct";
			}
		}
	}
	private int method_6(string string_5, string string_6)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		return shopNum1_User_Action.CheckLogin(string_5, string_6, 0);
	}
}
