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
public class Admin_ComplaintsManagement_Operate : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label Label2;
	protected HyperLink HyperLinkProductLink;
	protected Label LabelArticleGuid;
	protected Label LabelMemLoginID;
	protected Label LabelRank;
	protected Label Labelguid;
	protected Label LabelIPAddress;
	protected Label LabelEvidence;
	protected Label LabelEvidenceImage;
	protected Image ImageEvidence;
	protected Label LabelTime;
	protected Label LabelReportTime;
	protected Label Label3;
	protected Label LabelShopID;
	protected Label LabelReplyUser;
	protected Label LabelComplaintContent;
	protected Label LabelReplyImage;
	protected HtmlImage ReplyImage;
	protected Label LabelReplyTime1;
	protected Label LabelReplyTime;
	protected Label Labelstate;
	protected Label LabelProcessingState;
	protected Label Label5;
	protected Label LabelProcessingResult;
	protected Label Label4;
	protected Label LabelProcessingTime;
	protected Label LabelResult;
	protected TextBox TextBoxResult;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidatorResult;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
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
			this.Processing();
			this.method_5();
		}
	}
	public void Processing()
	{
		if (this.LabelProcessingState.Text == "未处理")
		{
			ShopNum1_MemberReport_Action shopNum1_MemberReport_Action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
			try
			{
				shopNum1_MemberReport_Action.UpdateProcessingStatus(this.hiddenGuid.Value.Replace("'", ""), 1);
			}
			catch (Exception)
			{
				MessageBox.Show("系统错误！");
			}
		}
	}
	private void method_5()
	{
		ShopNum1_MemberReport_Action shopNum1_MemberReport_Action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
		DataTable complaintsManagement = shopNum1_MemberReport_Action.GetComplaintsManagement(this.hiddenGuid.Value);
		if (complaintsManagement.Rows.Count > 0)
		{
			this.HyperLinkProductLink.Text = complaintsManagement.Rows[0]["ProductUrl"].ToString();
			this.HyperLinkProductLink.NavigateUrl = "http://" + complaintsManagement.Rows[0]["ProductUrl"].ToString().Replace("http://", "");
			this.ReplyImage.Src = complaintsManagement.Rows[0]["ComplaintImage"].ToString();
			this.LabelReplyTime.Text = complaintsManagement.Rows[0]["ComplaintTime"].ToString();
			this.LabelMemLoginID.Text = complaintsManagement.Rows[0]["MemLoginID"].ToString();
			this.LabelShopID.Text = complaintsManagement.Rows[0]["ReportShop"].ToString();
			this.Labelguid.Text = complaintsManagement.Rows[0]["ID"].ToString();
			this.LabelReportTime.Text = complaintsManagement.Rows[0]["ReportTime"].ToString();
			this.LabelProcessingTime.Text = complaintsManagement.Rows[0]["ProcessingTime"].ToString();
			this.ImageEvidence.ImageUrl = complaintsManagement.Rows[0]["EvidenceImage"].ToString();
			string a = complaintsManagement.Rows[0]["ProcessingStatus"].ToString();
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
				this.TextBoxResult.ReadOnly = true;
				this.ButtonConfirm.Enabled = false;
			}
			this.LabelProcessingResult.Text = complaintsManagement.Rows[0]["ProcessingResults"].ToString();
			this.LabelEvidence.Text = complaintsManagement.Rows[0]["Evidence"].ToString();
			this.LabelComplaintContent.Text = complaintsManagement.Rows[0]["ComplaintContent"].ToString();
			this.TextBoxResult.Text = complaintsManagement.Rows[0]["ProcessingResults"].ToString();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_MemberReport_Action shopNum1_MemberReport_Action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
		int num = shopNum1_MemberReport_Action.addReply(new ShopNum1_MemberReport
		{
			ProcessingTime = new DateTime?(DateTime.Now),
			ProcessingResults = this.TextBoxResult.Text,
			ProcessingStatus = new int?(2),
			OperateUser = base.ShopNum1LoginID,
			ID = int.Parse(this.hiddenGuid.Value.Replace("'", ""))
		});
		if (num > 0)
		{
			MessageBox.Show("处理完成");
			this.TextBoxResult.Enabled = false;
			this.ButtonConfirm.Enabled = false;
		}
		else
		{
			MessageBox.Show("处理失败");
		}
		this.method_5();
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ComplaintsManagement_List.aspx");
	}
}
