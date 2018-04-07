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
public class Main_Admin_Group_ActivityOperate : PageBase, IRequiresSessionState
{
	protected HtmlInputText txtName;
	protected HtmlInputText txtStartTime;
	protected HtmlInputText txtEndTime;
	protected HtmlInputText txtFinalTime;
	protected Button btnSub;
	protected MessageShow MessageShow;
	protected Label lblMsg;
	protected HtmlForm form1;
	private ShopNum1_Product_Activity shopNum1_Product_Activity_0 = new ShopNum1_Product_Activity();
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
			this.txtStartTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			this.txtEndTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
			this.txtFinalTime.Value = DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss");
			if (Common.ReqStr("id") != "")
			{
				string string_ = Common.ReqStr("id");
				ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
				DataTable groupActivityById = shopNum1_Activity_Action.GetGroupActivityById(string_);
				if (groupActivityById != null && groupActivityById.Rows.Count > 0)
				{
					this.txtName.Value = groupActivityById.Rows[0]["name"].ToString();
					this.txtStartTime.Value = groupActivityById.Rows[0]["starttime"].ToString().Replace("/", "-");
					this.txtEndTime.Value = groupActivityById.Rows[0]["endtime"].ToString().Replace("/", "-");
				}
			}
		}
	}
	protected void btnSub_Click(object sender, EventArgs e)
	{
		int num = DateTime.Compare(Convert.ToDateTime(this.txtStartTime.Value), Convert.ToDateTime(this.txtEndTime.Value));
		if (num != -1)
		{
			MessageBox.Show("结束时间必须大于开始时间!");
		}
		else
		{
			this.shopNum1_Product_Activity_0.Name = Operator.FilterString(this.txtName.Value);
			this.shopNum1_Product_Activity_0.StartTime = new DateTime?(Convert.ToDateTime(this.txtStartTime.Value));
			this.shopNum1_Product_Activity_0.EndTime = new DateTime?(Convert.ToDateTime(this.txtEndTime.Value));
			this.shopNum1_Product_Activity_0.FinalTime = new DateTime?(Convert.ToDateTime(this.txtFinalTime.Value));
			this.shopNum1_Product_Activity_0.Type = new int?(1);
			this.shopNum1_Product_Activity_0.Pic = "";
			this.shopNum1_Product_Activity_0.Discount = new decimal?(Convert.ToDecimal("0.00"));
			this.shopNum1_Product_Activity_0.SubstationID = base.SubstationID;
			ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
			if (Common.ReqStr("id") != "")
			{
				this.shopNum1_Product_Activity_0.Id = Convert.ToInt32(Common.ReqStr("id"));
				shopNum1_Activity_Action.UpdateActivity(this.shopNum1_Product_Activity_0);
			}
			else
			{
				shopNum1_Activity_Action.AddActivity(this.shopNum1_Product_Activity_0);
			}
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "添加或更改团购活动信息",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "Group_ProductList.aspx",
				Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
			});
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("操作成功！");
			this.Page.Response.Redirect("Group_ActivityList.aspx");
		}
	}
}
