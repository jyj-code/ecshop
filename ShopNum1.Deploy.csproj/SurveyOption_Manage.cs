using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class SurveyOption_Manage : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected System.Web.UI.WebControls.TextBox textBoxNAME;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
	protected Num1GridView num1GridViewShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField HiddenFieldSurveyGuid;
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
		this.HiddenFieldSurveyGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	protected void ButtonOK_Click(object sender, EventArgs e)
	{
		ShopNum1_SurveyOption shopNum1_SurveyOption = new ShopNum1_SurveyOption();
		shopNum1_SurveyOption.Guid = Guid.NewGuid();
		shopNum1_SurveyOption.SurveyGuid = this.HiddenFieldSurveyGuid.Value;
		shopNum1_SurveyOption.Name = this.textBoxNAME.Text.Trim();
		ShopNum1_SurveyOption_Action shopNum1_SurveyOption_Action = (ShopNum1_SurveyOption_Action)LogicFactory.CreateShopNum1_SurveyOption_Action();
		int num = shopNum1_SurveyOption_Action.Add(shopNum1_SurveyOption);
		if (num > 0)
		{
			this.BindGrid();
			this.textBoxNAME.Text = string.Empty;
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_SurveyOption_Action shopNum1_SurveyOption_Action = (ShopNum1_SurveyOption_Action)LogicFactory.CreateShopNum1_SurveyOption_Action();
		int num = shopNum1_SurveyOption_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
}
