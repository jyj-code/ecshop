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
public class Main_Admin_OrdeComplaintsOperate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label Label1;
	protected Label LabelTitle;
	protected Label LabelName;
	protected HyperLink HyperLinkOrderDetail;
	protected Label LabelArticleGuid;
	protected Label LabelMemLoginID;
	protected Label LabelRank;
	protected Label Labelguid;
	protected Label LabelIPAddress;
	protected Label LabelEvidence;
	protected Label Label3;
	protected Image ImageEvidence;
	protected Label LabelTime;
	protected Label LabelComplaintTime;
	protected Label Label4;
	protected Label LabelShopID;
	protected Label LabelReplyUser;
	protected Label LabelComplaintContent;
	protected Label Label6;
	protected Image ComplaintImage;
	protected Label Labelstate;
	protected Label LabelProcessingState;
	protected Label Label5;
	protected Label LabelProcessingTime;
	protected Label Label7;
	protected TextBox TextBoxProcessingResult;
	protected Label Label8;
	protected RequiredFieldValidator RequiredFieldValidatorResult;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Button ButtonSure;
	protected Button ButtonBack;
	protected MessageShow MessageShow1;
	protected HiddenField hiddenGuid;
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
		this.hiddenGuid.Value = ((base.Request.QueryString["guid"] == null) ? "" : base.Request.QueryString["guid"].ToString());
		if (!base.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		ShopNum1_OrdeComplaints_Action shopNum1_OrdeComplaints_Action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
		DataTable orderComplaintsDetails = shopNum1_OrdeComplaints_Action.GetOrderComplaintsDetails(this.hiddenGuid.Value.Replace("'", ""));
		if (orderComplaintsDetails.Rows.Count > 0)
		{
			this.LabelName.Text = orderComplaintsDetails.Rows[0]["OrderID"].ToString();
			this.LabelMemLoginID.Text = orderComplaintsDetails.Rows[0]["MemLoginID"].ToString();
			this.LabelShopID.Text = orderComplaintsDetails.Rows[0]["ComplaintShop"].ToString();
			this.Labelguid.Text = orderComplaintsDetails.Rows[0]["ID"].ToString();
			this.LabelComplaintTime.Text = orderComplaintsDetails.Rows[0]["ComplaintTime"].ToString();
			this.LabelProcessingTime.Text = orderComplaintsDetails.Rows[0]["ProcessingTime"].ToString();
			string a = orderComplaintsDetails.Rows[0]["ProcessingStatus"].ToString();
			if (a == "0")
			{
				this.LabelProcessingState.Text = "未处理";
			}
			if (a == "1")
			{
				this.LabelProcessingState.Text = "处理中";
			}
			if (a == "2")
			{
				this.LabelProcessingState.Text = "已处理";
				this.TextBoxProcessingResult.ReadOnly = true;
				this.ButtonSure.Enabled = false;
			}
			this.LabelEvidence.Text = orderComplaintsDetails.Rows[0]["Evidence"].ToString();
			this.ImageEvidence.ImageUrl = orderComplaintsDetails.Rows[0]["EvidenceImage"].ToString();
			this.LabelComplaintContent.Text = orderComplaintsDetails.Rows[0]["AppealContent"].ToString();
			this.TextBoxProcessingResult.Text = orderComplaintsDetails.Rows[0]["ProcessingResults"].ToString();
			this.ComplaintImage.ImageUrl = orderComplaintsDetails.Rows[0]["AppealImage"].ToString();
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderGuidAndTypeByOrderNum = shopNum1_OrderInfo_Action.GetOrderGuidAndTypeByOrderNum(this.LabelName.Text.Trim());
			if (orderGuidAndTypeByOrderNum != null && orderGuidAndTypeByOrderNum.Rows.Count > 0)
			{
				string str = orderGuidAndTypeByOrderNum.Rows[0]["Guid"].ToString();
				if (orderGuidAndTypeByOrderNum.Rows[0]["OrderType"].ToString() == "0")
				{
					this.HyperLinkOrderDetail.NavigateUrl = "Order_Operate.aspx?Guid=" + str;
				}
				else if (orderGuidAndTypeByOrderNum.Rows[0]["OrderType"].ToString() == "1")
				{
					this.HyperLinkOrderDetail.NavigateUrl = "OrderSpell_Operate.aspx?Guid" + str;
				}
				else if (orderGuidAndTypeByOrderNum.Rows[0]["OrderType"].ToString() == "2")
				{
					this.HyperLinkOrderDetail.NavigateUrl = "OrderPanic_List.aspx?Guid=" + str;
				}
				else
				{
					this.HyperLinkOrderDetail.NavigateUrl = "";
				}
			}
		}
	}
	protected void ButtonSure_Click(object sender, EventArgs e)
	{
		ShopNum1_OrdeComplaints_Action shopNum1_OrdeComplaints_Action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
		int num = shopNum1_OrdeComplaints_Action.addReply(new ShopNum1_OrderComplaint
		{
			ProcessingTime = new DateTime?(DateTime.Now),
			ProcessingResults = this.TextBoxProcessingResult.Text,
			ProcessingStatus = new int?(2),
			ID = int.Parse(this.hiddenGuid.Value.Replace("'", "")),
			OperateUser = this.Session["AdminLoginCookie"].ToString()
		});
		if (num > 0)
		{
			MessageBox.Show("处理完成");
		}
		else
		{
			MessageBox.Show("处理失败");
		}
		this.method_5();
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrdeComplaints_List.aspx");
	}
}
