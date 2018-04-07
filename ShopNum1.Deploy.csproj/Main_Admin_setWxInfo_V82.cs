using ShopNum1.Common;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_setWxInfo_V82 : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected HtmlSelect selectpart;
	protected HtmlInputText txtWxPay;
	protected Button btnPaySub;
	protected Button btnPayReturn;
	protected MessageShow MessageShow;
	protected HtmlInputHidden hidDepart;
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		string text = Common.ReqStr("guid");
		this.CheckGuid.Value = text;
		DataTable tableById = Common.GetTableById("wDepartTime,wPayMoney", "shopnum1_shopinfo", " And Guid='" + text + "'");
		if (tableById.Rows.Count > 0)
		{
			this.txtWxPay.Value = tableById.Rows[0]["wPayMoney"].ToString();
			this.hidDepart.Value = tableById.Rows[0]["wDepartTime"].ToString();
		}
	}
	protected void btnPayReturn_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("ShopInfoList_Manage.aspx");
	}
	protected void btnPaySub_Click(object sender, EventArgs e)
	{
		Common.UpdateInfo(string.Concat(new string[]
		{
			"wDepartTime='",
			this.selectpart.Items[this.selectpart.SelectedIndex].Value,
			"',wPayMoney='",
			this.txtWxPay.Value,
			"'"
		}), "shopnum1_shopinfo", " And Guid='" + this.CheckGuid.Value + "'");
		base.OperateLog(new ShopNum1_OperateLog
		{
			Record = "微信店铺费用设置成功",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "SetWxInfo_V82.aspx",
			Date = DateTime.Now
		});
		MessageBox.Show("保存成功！");
		this.method_5();
	}
}
