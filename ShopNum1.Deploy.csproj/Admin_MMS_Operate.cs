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
public class Admin_MMS_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelType;
	protected DropDownList DropDownListType;
	protected Label LabelTitle;
	protected TextBox TextBoxTitle;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected Label Label1;
	protected Label LabelNameRemark;
	protected TextBox FCKeditorRemark;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorRemark;
	protected Button butConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
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
		if (!this.Page.IsPostBack)
		{
			this.BindMenu();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑短信模板";
				this.GetEditInfo();
			}
		}
	}
	protected void butConfirm_Click(object sender, EventArgs e)
	{
		if (this.FCKeditorRemark.Text == string.Empty)
		{
			MessageBox.Show("短信内容不能为空!");
		}
		else if (this.FCKeditorRemark.Text.Length > 300)
		{
			this.Page.RegisterStartupScript("pop", "<script>alert('你输入的短信内容长度已经大于300，<br/>请删减文字！');</script>");
		}
		else if (this.butConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.butConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(this.hiddenFieldGuid.Value, 0);
		this.DropDownListType.Text = editInfo.Rows[0]["TypeName"].ToString();
		this.FCKeditorRemark.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
		this.TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
		this.butConfirm.Text = "更新";
		this.butConfirm.ToolTip = "Update";
	}
	protected void Add()
	{
		ShopNum1_MMS shopNum1_MMS = new ShopNum1_MMS();
		shopNum1_MMS.Guid = Guid.NewGuid();
		shopNum1_MMS.TypeName = this.DropDownListType.SelectedValue.ToString();
		shopNum1_MMS.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_MMS.Remark = base.Server.HtmlEncode(Operator.FilterString(this.FCKeditorRemark.Text.Replace("'", "''")));
		shopNum1_MMS.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_MMS.CreateUser = base.ShopNum1LoginID;
		shopNum1_MMS.CreateTime = DateTime.Now;
		shopNum1_MMS.ModifyUser = base.ShopNum1LoginID;
		shopNum1_MMS.ModifyTime = DateTime.Now;
		shopNum1_MMS.IsDeleted = 0;
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		int num = shopNum1_MMS_Action.Add(shopNum1_MMS);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增" + this.TextBoxTitle.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "MMS_Operate.aspx",
				Date = DateTime.Now
			});
			this.ClearControl();
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
		ShopNum1_MMS shopNum1_MMS = new ShopNum1_MMS();
		shopNum1_MMS.TypeName = this.DropDownListType.SelectedValue.ToString();
		shopNum1_MMS.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_MMS.Remark = base.Server.HtmlEncode(Operator.FilterString(this.FCKeditorRemark.Text.Replace("'", "''")));
		shopNum1_MMS.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_MMS.ModifyUser = base.ShopNum1LoginID;
		shopNum1_MMS.ModifyTime = DateTime.Now;
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		int num = shopNum1_MMS_Action.Update(this.hiddenFieldGuid.Value, shopNum1_MMS);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "编辑" + this.TextBoxTitle.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "MMS_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("MMS_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxTitle.Text = string.Empty;
		this.FCKeditorRemark.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.DropDownListType.SelectedValue = "-1";
	}
	protected void BindMenu()
	{
	}
}
