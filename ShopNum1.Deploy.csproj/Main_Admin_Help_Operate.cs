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
public class Main_Admin_Help_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected Localize LocalizeHelpTypeGuid;
	protected DropDownList DropDownListHelpTypeGuid;
	protected Label Label2;
	protected CompareValidator CompareFatherHelpTypeGuid;
	protected Localize LocalizeOrderID;
	protected TextBox TextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Localize LocalizeContent;
	protected TextBox FCKeditorContent;
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
			this.HelpTypeBind();
			if (this.CheckGuid.Value != "0")
			{
				this.HelpBind();
				this.LabelTitle.Text = "编辑帮助";
			}
			else
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.method_5() + 1);
			}
		}
	}
	private int method_5()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Help");
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopNum1Help_List.aspx");
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value != "0")
		{
			this.Update();
		}
		else
		{
			this.Insert();
		}
	}
	protected void HelpBind()
	{
		ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
		DataTable editInfo = shopNum1_Help_Action.GetEditInfo(this.CheckGuid.Value);
		this.TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.FCKeditorContent.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
		this.DropDownListHelpTypeGuid.SelectedValue = editInfo.Rows[0]["HelpTypeGuid"].ToString();
		this.ButtonConfirm.Text = "更新";
	}
	protected void HelpTypeBind()
	{
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		DataTable list = shopNum1_HelpType_Action.GetList();
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListHelpTypeGuid.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Guid"].ToString()));
		}
	}
	protected void Insert()
	{
		ShopNum1_Help shopNum1_Help = new ShopNum1_Help();
		shopNum1_Help.Guid = Guid.NewGuid();
		shopNum1_Help.Title = this.TextBoxTitle.Text;
		shopNum1_Help.Remark = base.Server.HtmlEncode(this.FCKeditorContent.Text.Replace("'", "''"));
		shopNum1_Help.HelpTypeGuid = new Guid(this.DropDownListHelpTypeGuid.SelectedValue);
		shopNum1_Help.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_Help.CreateUser = "admin";
		shopNum1_Help.ModifyUser = "admin";
		ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
		int num = shopNum1_Help_Action.Add(shopNum1_Help);
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
		ShopNum1_Help shopNum1_Help = new ShopNum1_Help();
		shopNum1_Help.Guid = new Guid(this.CheckGuid.Value.Replace("'", ""));
		shopNum1_Help.Title = this.TextBoxTitle.Text;
		shopNum1_Help.Remark = base.Server.HtmlEncode(this.FCKeditorContent.Text.Replace("'", "''"));
		shopNum1_Help.HelpTypeGuid = new Guid(this.DropDownListHelpTypeGuid.SelectedValue);
		shopNum1_Help.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_Help.ModifyUser = "admin";
		ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
		int num = shopNum1_Help_Action.Update(shopNum1_Help);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			base.Response.Redirect("Help_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
}
