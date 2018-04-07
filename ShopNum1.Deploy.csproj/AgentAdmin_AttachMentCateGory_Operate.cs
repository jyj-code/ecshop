using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_AttachMentCateGory_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeCategoryName;
	protected TextBox TextBoxCategoryName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize LocalizeDescription;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected AgentAdmin_MessageShow MessageShow;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelTitle.Text = "编辑附件类别";
			this.GetEditInfo();
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		DataRow dataRow = shopNum1_AttachMentCategory_Action.EditShow(this.hiddenFieldGuid.Value);
		this.TextBoxCategoryName.Text = dataRow["CategoryName"].ToString();
		this.TextBoxDescription.Text = dataRow["Description"].ToString();
		this.ButtonConfirm.Text = "更新";
	}
	protected void Add()
	{
		ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory = new ShopNum1_AttachMentCateGory();
		shopNum1_AttachMentCateGory.Guid = Guid.NewGuid();
		shopNum1_AttachMentCateGory.CateGoryName = this.TextBoxCategoryName.Text;
		shopNum1_AttachMentCateGory.Description = this.TextBoxDescription.Text;
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		int num = shopNum1_AttachMentCategory_Action.Insert(shopNum1_AttachMentCateGory);
		if (num > 0)
		{
			this.method_5();
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增" + this.TextBoxCategoryName.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AttachMentCateGory_Operate.aspx",
				Date = DateTime.Now
			});
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Edit()
	{
		ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory = new ShopNum1_AttachMentCateGory();
		shopNum1_AttachMentCateGory.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_AttachMentCateGory.CateGoryName = this.TextBoxCategoryName.Text;
		shopNum1_AttachMentCateGory.Description = this.TextBoxDescription.Text;
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		int num = shopNum1_AttachMentCategory_Action.Update(shopNum1_AttachMentCateGory);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "编辑" + this.TextBoxCategoryName.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AttachMentCateGory_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("AttachMentCateGory_List.aspx");
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_5()
	{
		this.TextBoxCategoryName.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
}
