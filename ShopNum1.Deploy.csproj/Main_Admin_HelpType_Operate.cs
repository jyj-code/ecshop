using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_HelpType_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label lbladd;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize LocalizeOrderID;
	protected TextBox TextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Localize LocalizeDescription;
	protected TextBox TextBoxDescription;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldAgentLoginID;
	protected HiddenField CheckGuid;
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
		this.CheckGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			if (this.CheckGuid.Value != "0")
			{
				this.HelpTypeBind();
				this.lbladd.Text = "编辑帮助分类";
			}
			else
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.method_5() + 1);
			}
		}
	}
	private int method_5()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_HelpType");
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value != "0")
		{
			this.Update();
		}
		else
		{
			this.Add();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("HelpType_List.aspx");
	}
	protected void HelpTypeBind()
	{
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		DataTable editInfo = shopNum1_HelpType_Action.GetEditInfo(this.CheckGuid.Value);
		this.TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
		this.TextBoxDescription.Text = editInfo.Rows[0]["Remark"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.ButtonConfirm.Text = "更新";
	}
	protected void Add()
	{
		ShopNum1_HelpType shopNum1_HelpType = new ShopNum1_HelpType();
		shopNum1_HelpType.Guid = Guid.NewGuid();
		shopNum1_HelpType.Name = this.TextBoxName.Text;
		shopNum1_HelpType.Remark = this.TextBoxDescription.Text;
		shopNum1_HelpType.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_HelpType.CreateUser = "admin";
		shopNum1_HelpType.ModifyUser = "admin";
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		int num = shopNum1_HelpType_Action.Add(shopNum1_HelpType);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Update()
	{
		ShopNum1_HelpType shopNum1_HelpType = new ShopNum1_HelpType();
		shopNum1_HelpType.Guid = new Guid(this.CheckGuid.Value.Replace("'", ""));
		shopNum1_HelpType.Name = this.TextBoxName.Text;
		shopNum1_HelpType.Remark = this.TextBoxDescription.Text;
		shopNum1_HelpType.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_HelpType.ModifyUser = "admin";
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		int num = shopNum1_HelpType_Action.update(shopNum1_HelpType);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			base.Response.Redirect("HelpType_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
}
