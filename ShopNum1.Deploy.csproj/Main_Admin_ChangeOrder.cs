using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ChangeOrder : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label Label2;
	protected TextBox TextBoxOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	[CompilerGenerated]
	private string string_6;
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
	protected string guid
	{
		get;
		set;
	}
	protected string back
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		this.guid = ((this.Page.Request.QueryString["guid"] == null) ? Guid.NewGuid().ToString() : this.Page.Request.QueryString["guid"]);
		this.back = ((this.Page.Request.QueryString["back"] == null) ? "-1" : this.Page.Request.QueryString["back"]);
		if (!this.Page.IsPostBack)
		{
			this.DataBind();
		}
	}
	protected new void DataBind()
	{
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		DataTable systemOrderID = shopNum1_ProuductChecked_Action.GetSystemOrderID(this.guid);
		if (systemOrderID.Rows.Count > 0)
		{
			this.TextBoxOrderID.Text = systemOrderID.Rows[0][0].ToString();
		}
		else
		{
			this.TextBoxOrderID.Text = "";
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (this.back == "prouduct")
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			num = shopNum1_ProuductChecked_Action.UpdateProduct(this.guid, "SystemOrderID", this.TextBoxOrderID.Text.Trim());
		}
		else if (this.back == ShopSettings.GetValue("PersonShopUrl"))
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			num = shopNum1_ShopInfoList_Action.Update(this.guid, this.TextBoxOrderID.Text.Trim(), "SystemOrderID");
		}
		if (num > 0)
		{
			if (this.back == "prouduct")
			{
				base.Response.Redirect("Prouduct_List.aspx");
			}
			else if (this.back == "shop")
			{
				base.Response.Redirect("ShopInfoList_Manage.aspx");
			}
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.back == "prouduct")
		{
			base.Response.Redirect("Prouduct_List.aspx");
		}
		else if (this.back == "shop")
		{
			base.Response.Redirect("ShopInfoList_Manage.aspx");
		}
	}
}
