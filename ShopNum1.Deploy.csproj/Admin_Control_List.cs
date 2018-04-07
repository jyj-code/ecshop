using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Control_List : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageType;
	protected Label LabelPageTypeShow;
	protected Label LabelPageName;
	protected Label LabelPageNameShow;
	protected Label LabelPagePath;
	protected Label LabelPagePathShow;
	protected System.Web.UI.WebControls.Button ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected Num1GridView Num1GridViewShow;
	protected Label LabelPageTitle;
	protected Label LabelControlType;
	protected System.Web.UI.WebControls.DropDownList DropDownListControlType;
	protected Label LabelControlName;
	protected System.Web.UI.WebControls.TextBox TextBoxControlName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected Label LabelControlID;
	protected System.Web.UI.WebControls.TextBox TextBoxControlID;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorControlID;
	protected Label LabelDescription;
	protected System.Web.UI.WebControls.TextBox TextBoxDescription;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HtmlGenericControl divPage;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenGuid;
	protected HiddenField hiddenControlGuid;
	protected ObjectDataSource ObjectDataSourceData;
	protected HtmlForm form2;
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
			this.hiddenGuid.Value = base.Request.QueryString["Guid"];
			this.BindPage();
			this.BindGrid();
		}
	}
	protected void DropDownListSPageType_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
	protected void DropDownListSOne_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
	protected void DropDownListSTwo_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
	protected void DropDownListPageType_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
	protected void DropDownListControlType_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		this.ClearControl();
		this.LabelPageTitle.Text = "编辑控件";
		this.ButtonConfirm.ToolTip = "Update";
		this.ButtonConfirm.Text = "更新";
		DataTable control = this.GetControl();
		this.hiddenControlGuid.Value = control.Rows[0]["Guid"].ToString();
		this.TextBoxControlID.Text = control.Rows[0]["ControlID"].ToString();
		this.TextBoxControlName.Text = control.Rows[0]["Name"].ToString();
		this.TextBoxDescription.Text = control.Rows[0]["Description"].ToString();
		this.DropDownListControlType.SelectedValue = control.Rows[0]["ControlType"].ToString();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_PageWebControl_Action shopNum1_PageWebControl_Action = (ShopNum1_PageWebControl_Action)LogicFactory.CreateShopNum1_PageWebControl_Action();
		int num = shopNum1_PageWebControl_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "Control_List.aspx",
				Date = DateTime.Now
			});
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.BindGrid();
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			try
			{
				ShopNum1_PageWebControl_Action shopNum1_PageWebControl_Action = (ShopNum1_PageWebControl_Action)LogicFactory.CreateShopNum1_PageWebControl_Action();
				ShopNum1_PageWebControl shopNum1_PageWebControl = new ShopNum1_PageWebControl();
				string g = this.hiddenGuid.Value.Replace("'", "");
				shopNum1_PageWebControl.Guid = Guid.NewGuid();
				shopNum1_PageWebControl.Name = this.TextBoxControlName.Text.Trim();
				shopNum1_PageWebControl.PageGuid = new Guid(g);
				shopNum1_PageWebControl.ControlID = this.TextBoxControlID.Text.Trim();
				shopNum1_PageWebControl.ControlType = this.DropDownListControlType.SelectedValue;
				shopNum1_PageWebControl.Description = this.TextBoxDescription.Text.Trim();
				shopNum1_PageWebControl.CreateUser = base.ShopNum1LoginID;
				shopNum1_PageWebControl.CreateTime = DateTime.Now;
				shopNum1_PageWebControl.ModifyUser = base.ShopNum1LoginID;
				shopNum1_PageWebControl.ModifyTime = DateTime.Now;
				shopNum1_PageWebControl.IsDeleted = 0;
				int num = shopNum1_PageWebControl_Action.Add(shopNum1_PageWebControl);
				if (num > 0)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "新增" + this.TextBoxControlID.Text.Trim() + "成功",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "Control_List.aspx",
						Date = DateTime.Now
					});
					this.MessageShow.ShowMessage("AddYes");
					this.MessageShow.Visible = true;
					this.BindGrid();
					this.ClearControl();
				}
				else
				{
					this.MessageShow.ShowMessage("AddNo");
					this.MessageShow.Visible = true;
				}
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}
		if (this.ButtonConfirm.ToolTip == "Update")
		{
			ShopNum1_PageWebControl_Action shopNum1_PageWebControl_Action = (ShopNum1_PageWebControl_Action)LogicFactory.CreateShopNum1_PageWebControl_Action();
			int num = shopNum1_PageWebControl_Action.Update(new ShopNum1_PageWebControl
			{
				Guid = new Guid(this.hiddenControlGuid.Value),
				Name = this.TextBoxControlName.Text.Trim(),
				ControlID = this.TextBoxControlID.Text.Trim(),
				ControlType = this.DropDownListControlType.SelectedValue,
				Description = this.TextBoxDescription.Text.Trim(),
				ModifyUser = base.ShopNum1LoginID,
				ModifyTime = DateTime.Now,
				IsDeleted = 0
			});
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "编辑" + this.TextBoxControlID.Text.Trim() + "成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Control_List.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("EditYes");
				this.MessageShow.Visible = true;
				this.BindGrid();
				this.ClearControl();
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void BindPage()
	{
		ShopNum1_Page_Action shopNum1_Page_Action = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
		DataTable dataTable = shopNum1_Page_Action.Search(this.hiddenGuid.Value, 0);
		this.LabelPageNameShow.Text = dataTable.Rows[0]["Name"].ToString();
		if (dataTable.Rows[0]["PageType"].ToString() == "0")
		{
			this.LabelPageTypeShow.Text = LocalizationUtil.GetChangeMessage("Page_List", "PageType", "0");
		}
		else if (dataTable.Rows[0]["PageType"].ToString() == "1")
		{
			this.LabelPageTypeShow.Text = LocalizationUtil.GetChangeMessage("Page_List", "PageType", "1");
		}
		else if (dataTable.Rows[0]["PageType"].ToString() == "3")
		{
			this.LabelPageTypeShow.Text = LocalizationUtil.GetChangeMessage("Page_List", "PageType", "3");
		}
		this.LabelPagePathShow.Text = dataTable.Rows[0]["PagePath"].ToString();
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected DataTable GetControl()
	{
		string guid = this.CheckGuid.Value.Replace("'", "");
		ShopNum1_PageWebControl_Action shopNum1_PageWebControl_Action = (ShopNum1_PageWebControl_Action)LogicFactory.CreateShopNum1_PageWebControl_Action();
		return shopNum1_PageWebControl_Action.Search(string.Empty, guid, 0);
	}
	protected void ClearControl()
	{
		this.TextBoxDescription.Text = string.Empty;
		this.TextBoxControlName.Text = string.Empty;
		this.TextBoxControlID.Text = string.Empty;
	}
}
