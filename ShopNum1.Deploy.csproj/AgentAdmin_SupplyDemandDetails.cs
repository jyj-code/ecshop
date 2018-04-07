using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_SupplyDemandDetails : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Localize LocalizeType;
	protected TextBox TextBoxType;
	protected Localize Localize2;
	protected TextBox TextBoxAddressValue;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Localize LocalizeTradeType;
	protected TextBox TextBoxTradeType;
	protected Localize Localize3;
	protected TextBox TextBoxTel;
	protected Localize Localize4;
	protected TextBox TextBoxEmail;
	protected Localize Localize5;
	protected TextBox TextBoxOtherContactWay;
	protected Localize Localize6;
	protected TextBox TextBoxContactName;
	protected Localize LocalizeKeywords;
	protected TextBox TextBoxKeywords;
	protected Localize LocalizeDescription;
	protected TextBox TextBoxDescription;
	protected Localize LocalizeValidTime;
	protected TextBox TextBoxValidTime;
	protected Localize Localize1;
	protected TextBox TextBoxIsAudit;
	protected Localize LocalizeOrderID;
	protected TextBox TextBoxMemLoginID;
	protected Localize LocalizeImage;
	protected Image ImageOriginalImge;
	protected Localize LocalizeContent;
	protected TextBox FCKeditorContent;
	protected Button ButtonAudit;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
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
		string guid = base.Request.QueryString["guid"];
		Shop_SupplyDemand_Action shop_SupplyDemand_Action = (Shop_SupplyDemand_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_SupplyDemand_Action();
		DataRow dataRow = shop_SupplyDemand_Action.UpdateSearch(guid);
		this.TextBoxTitle.Text = dataRow["Title"].ToString();
		this.TextBoxType.Text = dataRow["CategoryName"].ToString();
		this.TextBoxAddressValue.Text = dataRow["AddressValue"].ToString();
		if (dataRow["TradeType"].ToString() == "0")
		{
			this.TextBoxTradeType.Text = "供";
		}
		else
		{
			this.TextBoxTradeType.Text = "求";
		}
		this.TextBoxKeywords.Text = dataRow["Keywords"].ToString();
		this.TextBoxValidTime.Text = dataRow["ValidTime"].ToString();
		if (dataRow["IsAudit"].ToString() == "0")
		{
			this.TextBoxIsAudit.Text = "未审核";
		}
		else if (dataRow["IsAudit"].ToString() == "1")
		{
			this.TextBoxIsAudit.Text = "审核中";
		}
		else if (dataRow["IsAudit"].ToString() == "2")
		{
			this.TextBoxIsAudit.Text = "审核未通过";
		}
		else if (dataRow["IsAudit"].ToString() == "3")
		{
			this.TextBoxIsAudit.Text = "审核通过";
		}
		this.TextBoxMemLoginID.Text = dataRow["MemberID"].ToString();
		this.FCKeditorContent.Text = this.Page.Server.HtmlDecode(dataRow["Content"].ToString());
		this.TextBoxDescription.Text = this.Page.Server.HtmlDecode(dataRow["Description"].ToString());
		this.ImageOriginalImge.ImageUrl = dataRow["Image"].ToString();
		this.TextBoxTel.Text = dataRow["Tel"].ToString();
		this.TextBoxEmail.Text = dataRow["Email"].ToString();
		this.TextBoxOtherContactWay.Text = dataRow["OtherContactWay"].ToString();
		this.TextBoxContactName.Text = dataRow["ContactName"].ToString();
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (base.Request.QueryString["type"] != null && base.Request.QueryString["type"].ToString() == "audit")
		{
			this.Page.Response.Redirect("ShopNum1_SupplyDemandCheck_List.aspx");
		}
		else
		{
			this.Page.Response.Redirect("ShopNum1_SupplyDemand_List.aspx");
		}
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		if (shopNum1_SupplyDemandCheck_Action.Update(this.Page.Request.QueryString["guid"].ToString(), "3") > 0)
		{
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		if (shopNum1_SupplyDemandCheck_Action.Update(this.Page.Request.QueryString["guid"].ToString(), "2") > 0)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
}
