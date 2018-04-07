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
public class AgentAdmin_Theme_ActivityOperate : PageBase, IRequiresSessionState
{
	protected HtmlInputText txtName;
	protected HtmlInputText txtStartTime;
	protected HtmlInputText txtEndTime;
	protected HtmlInputHidden hidpicTheme;
	protected HtmlImage picTheme;
	protected HtmlTextArea txtThemeDescription;
	protected HtmlInputText txtOrderID;
	protected HtmlInputText txtFinalTime;
	protected Button btnSub;
	protected Label lblMsg;
	protected HtmlForm form1;
	private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
	private ShopNum1_ThemeActivity shopNum1_ThemeActivity_0 = new ShopNum1_ThemeActivity();
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
			this.method_5();
		}
	}
	private void method_5()
	{
		try
		{
			this.txtStartTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			this.txtEndTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
			this.txtFinalTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
			if (Common.ReqStr("update") != "")
			{
				string guid = Common.ReqStr("update");
				DataTable themeActivtyByGuid = this.shopNum1_Activity_Action_0.GetThemeActivtyByGuid(guid);
				if (themeActivtyByGuid != null && themeActivtyByGuid.Rows.Count > 0)
				{
					this.txtName.Value = themeActivtyByGuid.Rows[0]["ThemeTitle"].ToString();
					this.txtStartTime.Value = themeActivtyByGuid.Rows[0]["StartDate"].ToString().Replace("/", "-");
					this.txtEndTime.Value = themeActivtyByGuid.Rows[0]["EndDate"].ToString().Replace("/", "-");
					this.txtThemeDescription.Value = themeActivtyByGuid.Rows[0]["ThemeDescription"].ToString();
					this.txtOrderID.Value = themeActivtyByGuid.Rows[0]["OrderID"].ToString();
					this.hidpicTheme.Value = themeActivtyByGuid.Rows[0]["themeimage"].ToString();
					this.picTheme.Src = themeActivtyByGuid.Rows[0]["themeimage"].ToString();
				}
			}
		}
		catch
		{
		}
	}
	protected void btnSub_Click(object sender, EventArgs e)
	{
		if (this.hidpicTheme.Value == string.Empty)
		{
			MessageBox.Show("横幅图片必须选择！");
		}
		else if (this.txtThemeDescription.Value.Length > 200)
		{
			MessageBox.Show("活动说明输入字符不能大于200！");
		}
		else
		{
			this.shopNum1_ThemeActivity_0.Guid = Guid.NewGuid();
			this.shopNum1_ThemeActivity_0.ThemeImage = this.hidpicTheme.Value;
			this.shopNum1_ThemeActivity_0.ThemeTitle = Operator.FilterString(this.txtName.Value);
			this.shopNum1_ThemeActivity_0.StartDate = Convert.ToDateTime(this.txtStartTime.Value);
			this.shopNum1_ThemeActivity_0.EndDate = Convert.ToDateTime(this.txtEndTime.Value);
			this.shopNum1_ThemeActivity_0.ThemeDescription = Operator.FilterString(this.txtThemeDescription.Value);
			this.shopNum1_ThemeActivity_0.ThemeStatus = 0;
			this.shopNum1_ThemeActivity_0.OrderID = Convert.ToInt32(this.txtOrderID.Value);
			this.shopNum1_ThemeActivity_0.CreateTime = DateTime.Now;
			this.shopNum1_ThemeActivity_0.CreateUser = base.ShopNum1LoginID;
			ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
			if (Common.ReqStr("update") != "")
			{
				this.shopNum1_ThemeActivity_0.Guid = new Guid(Common.ReqStr("update"));
				shopNum1_Activity_Action.UpdateThemeActivty(this.shopNum1_ThemeActivity_0);
			}
			else
			{
				this.shopNum1_ThemeActivity_0.SubstationID = base.SubstationID;
				shopNum1_Activity_Action.AddThemeActivty(this.shopNum1_ThemeActivity_0);
			}
			this.lblMsg.Visible = true;
			this.lblMsg.Text = "操作成功！";
			this.method_5();
		}
	}
}
