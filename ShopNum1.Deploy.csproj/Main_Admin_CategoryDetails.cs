using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_CategoryDetails : PageBase, IRequiresSessionState
{
	protected Localize LocalizeAssociatedCategoryGuid;
	protected TextBox TextBoxCategoryInfo;
	protected Localize LocalizeType;
	protected TextBox TextBoxType;
	protected Localize LocalizeValidTime;
	protected TextBox TextBoxValidTime;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Localize Localize1;
	protected TextBox TextBoxMemLoginID;
	protected Localize LocalizeTel;
	protected TextBox TextBoxTel;
	protected Localize LocalizeEmail;
	protected TextBox TextBoxEmail;
	protected Localize LocalizeOtherContactWay;
	protected TextBox TextBoxOtherContactWay;
	protected Localize LocalizeContent;
	protected TextBox FCKeditorContent;
	protected Localize LocalizeKeywords;
	protected TextBox FCKeditorKeywords;
	protected HiddenField MemLoginID;
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
		string guid = base.Request.QueryString["guid"];
		Shop_CategoryInfo_Action shop_CategoryInfo_Action = (Shop_CategoryInfo_Action)LogicFactory.CreateShop_CategoryInfo_Action();
		DataRow dataRow = shop_CategoryInfo_Action.UpdateSearch(guid);
		this.TextBoxCategoryInfo.Text = dataRow["name"].ToString();
		if (dataRow["Type"].ToString() == "0")
		{
			this.TextBoxType.Text = "其它";
		}
		this.TextBoxMemLoginID.Text = dataRow["AssociatedMemberID"].ToString();
		if (dataRow["ValidTime"].ToString().IndexOf("/") != -1)
		{
			this.TextBoxValidTime.Text = dataRow["ValidTime"].ToString().Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.TextBoxValidTime.Text = dataRow["ValidTime"].ToString();
		}
		this.TextBoxTitle.Text = dataRow["Title"].ToString();
		this.FCKeditorContent.Text = this.Page.Server.HtmlDecode(dataRow["Content"].ToString());
		this.FCKeditorKeywords.Text = this.Page.Server.HtmlDecode(dataRow["Content"].ToString());
		this.TextBoxTel.Text = dataRow["Tel"].ToString();
		this.TextBoxEmail.Text = dataRow["Email"].ToString();
		this.TextBoxOtherContactWay.Text = dataRow["OtherContactWay"].ToString();
	}
}
