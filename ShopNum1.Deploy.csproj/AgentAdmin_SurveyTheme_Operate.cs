using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_SurveyTheme_Operate : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Label LabelTitle;
	protected TextBox textBoxTitle;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelStartTime;
	protected TextBox textBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected Label LabelEndTime;
	protected TextBox textEndTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label Label4;
	protected RadioButtonList radioButtonCheck;
	protected Button ButtonConfirm;
	protected Button Button1;
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
		if (!this.Page.IsPostBack)
		{
			this.radioButtonCheck.SelectedValue = "0";
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑商城调查";
				this.GetEditInfo();
			}
		}
	}
	protected void btnConfirm_Click(object sender, EventArgs e)
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
	protected void Edit()
	{
		if (this.textBoxStartTime.Text.Trim() == "")
		{
			MessageBox.Show("请填写开始时间");
		}
		else if (this.textEndTime.Text.Trim() == "")
		{
			MessageBox.Show("请填写截止时间");
		}
		else
		{
			ShopNum1_SurveyTheme shopNum1_SurveyTheme = new ShopNum1_SurveyTheme();
			shopNum1_SurveyTheme.Title = this.textBoxTitle.Text.Trim();
			shopNum1_SurveyTheme.StartTime = new DateTime?(Convert.ToDateTime(this.textBoxStartTime.Text.Trim()));
			shopNum1_SurveyTheme.EndTime = new DateTime?(Convert.ToDateTime(this.textEndTime.Text.Trim()));
			shopNum1_SurveyTheme.SimplyOrMultiCheck = Convert.ToInt32(this.radioButtonCheck.SelectedItem.Value);
			ShopNum1_SurveyTheme_Action shopNum1_SurveyTheme_Action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
			int num = shopNum1_SurveyTheme_Action.Update(this.hiddenFieldGuid.Value, shopNum1_SurveyTheme);
			if (num > 0)
			{
				base.Response.Redirect("SurveyTheme_Manage.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void Add()
	{
		if (this.textBoxStartTime.Text.Trim() == "")
		{
			MessageBox.Show("请填写开始时间");
		}
		else if (this.textEndTime.Text.Trim() == "")
		{
			MessageBox.Show("请填写截止时间");
		}
		else
		{
			if (Convert.ToDateTime(this.textBoxStartTime.Text.Trim()) >= Convert.ToDateTime(this.textEndTime.Text.Trim()))
			{
				MessageBox.Show("截止时间不能小于或等于开始时间");
			}
			ShopNum1_SurveyTheme shopNum1_SurveyTheme = new ShopNum1_SurveyTheme();
			shopNum1_SurveyTheme.Guid = Guid.NewGuid();
			shopNum1_SurveyTheme.Title = this.textBoxTitle.Text.Trim();
			shopNum1_SurveyTheme.StartTime = new DateTime?(Convert.ToDateTime(this.textBoxStartTime.Text.Trim()));
			shopNum1_SurveyTheme.EndTime = new DateTime?(Convert.ToDateTime(this.textEndTime.Text.Trim()));
			shopNum1_SurveyTheme.SimplyOrMultiCheck = Convert.ToInt32(this.radioButtonCheck.SelectedItem.Value);
			ShopNum1_SurveyTheme_Action shopNum1_SurveyTheme_Action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
			int num = shopNum1_SurveyTheme_Action.Add(shopNum1_SurveyTheme);
			if (num > 0)
			{
				foreach (Control control in this.Controls)
				{
					for (int i = 0; i < control.Controls.Count; i++)
					{
						if (control.Controls[i] is TextBox)
						{
							TextBox textBox = (TextBox)control.Controls[i];
							textBox.Text = "";
						}
					}
				}
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_SurveyTheme_Action shopNum1_SurveyTheme_Action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
		DataTable editInfo = shopNum1_SurveyTheme_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.textBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
		this.textBoxStartTime.Text = Convert.ToDateTime(editInfo.Rows[0]["StartTime"]).ToString("yyyy-MM-dd");
		this.textEndTime.Text = Convert.ToDateTime(editInfo.Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
		this.radioButtonCheck.SelectedValue = editInfo.Rows[0]["SimplyOrMultiCheck"].ToString();
		this.ButtonConfirm.Text = "更新";
	}
}
