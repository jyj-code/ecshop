using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ProductIntegralDetal : Page, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Image ImageProduct;
	protected Label LabelProductName;
	protected Label LabelProductCategoryName;
	protected Label LabelRepertoryNumber;
	protected Label LabelProductUnit;
	protected Label LabelMarketPrice;
	protected Label LabelScore;
	protected Label LabelRepertoryCount;
	protected Label LabelTitle;
	protected Label LabelKeywords;
	protected Label LabelDescribe;
	protected Label LabelIsNew;
	protected Label LabelIsHot;
	protected Label LabelIsSaled;
	protected Label LabelIsAudit;
	protected TextBox FCKeditorDetail;
	protected Button ButtonEdit;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldMemLoginID;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldType;
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
		if (!this.Page.IsPostBack)
		{
			this.hiddenFieldGuid.Value = this.Page.Request.QueryString["Guid"].Replace("'", "");
			this.hiddenFieldType.Value = this.Page.Request.QueryString["Type"].Replace("'", "");
		}
		this.GetData();
	}
	public void GetData()
	{
		ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
		try
		{
			DataTable infoByGuid = shopNum1_Shop_ScoreProduct_Action.GetInfoByGuid(this.hiddenFieldGuid.Value);
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				this.ImageProduct.ImageUrl = infoByGuid.Rows[0]["OriginalImge"].ToString();
				this.LabelProductName.Text = infoByGuid.Rows[0]["Name"].ToString();
				this.LabelProductCategoryName.Text = infoByGuid.Rows[0]["ProductCategoryName"].ToString();
				this.LabelRepertoryNumber.Text = infoByGuid.Rows[0]["RepertoryNumber"].ToString();
				this.LabelProductUnit.Text = infoByGuid.Rows[0]["UnitName"].ToString();
				this.LabelMarketPrice.Text = infoByGuid.Rows[0]["MarketPrice"].ToString();
				this.LabelScore.Text = infoByGuid.Rows[0]["Score"].ToString();
				this.LabelTitle.Text = infoByGuid.Rows[0]["Meto_Title"].ToString();
				this.LabelKeywords.Text = infoByGuid.Rows[0]["Meto_Keywords"].ToString();
				this.LabelDescribe.Text = infoByGuid.Rows[0]["Meto_Description"].ToString();
				this.LabelRepertoryCount.Text = infoByGuid.Rows[0]["RepertoryCount"].ToString();
				if (infoByGuid.Rows[0]["IsNew"].ToString() == "1")
				{
					this.LabelIsNew.Text = "是";
				}
				else
				{
					this.LabelIsNew.Text = "否";
				}
				if (infoByGuid.Rows[0]["IsHot"].ToString() == "1")
				{
					this.LabelIsHot.Text = "是";
				}
				else
				{
					this.LabelIsHot.Text = "否";
				}
				if (infoByGuid.Rows[0]["IsSaled"].ToString() == "1")
				{
					this.LabelIsSaled.Text = "是";
				}
				else
				{
					this.LabelIsSaled.Text = "否";
				}
				if (infoByGuid.Rows[0]["IsAudit"].ToString() == "0")
				{
					this.LabelIsAudit.Text = "未审核";
				}
				else if (infoByGuid.Rows[0]["IsAudit"].ToString() == "1")
				{
					this.LabelIsAudit.Text = "审核通过";
				}
				else if (infoByGuid.Rows[0]["IsAudit"].ToString() == "2")
				{
					this.LabelIsAudit.Text = "审核未通过";
				}
				this.FCKeditorDetail.Text = infoByGuid.Rows[0]["Detail"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldType.Value == "0")
		{
			base.Response.Redirect("ProductIntegralChecked_List.aspx");
		}
		else if (this.hiddenFieldType.Value == "1")
		{
			base.Response.Redirect("ProductIntegral_List.aspx");
		}
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
		try
		{
			int num = shopNum1_Shop_ScoreProduct_Action.IsAudit("'" + this.hiddenFieldGuid.Value + "'", 1);
			if (num > 0)
			{
				MessageBox.Show("审核成功");
			}
			else
			{
				MessageBox.Show("审核失败!");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("审核失败，原因：" + ex.Message);
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
		try
		{
			int num = shopNum1_Shop_ScoreProduct_Action.IsAudit("'" + this.hiddenFieldGuid.Value + "'", 2);
			if (num > 0)
			{
				MessageBox.Show("操作成功。");
			}
			else
			{
				MessageBox.Show("审核失败!");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("审核失败，原因：" + ex.Message);
		}
	}
}
