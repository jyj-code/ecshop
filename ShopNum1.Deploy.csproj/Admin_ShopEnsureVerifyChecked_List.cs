using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ShopEnsureVerifyChecked_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSourceData;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	private string string_12 = string.Empty;
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
			this.BandDropdownIsAudit();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.DelShopEnsureList("'" + this.CheckGuid.Value.Replace("'", "") + "'");
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		int num = shop_Ensure_Action.DelShopEnsureList(guid);
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
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.UpdataIsAuditByGuid(this.CheckGuid.Value, 1);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.UpdataIsAuditByGuid(this.CheckGuid.Value, 2);
		if (num > 0)
		{
			int num2 = this.BackMoney(this.CheckGuid.Value);
			if (num2 == 1)
			{
				this.BindGrid();
				this.MessageShow.Visible = true;
				this.MessageShow.ShowMessage("UpdateYes");
				shop_Ensure_Action.DelShopEnsureList(this.CheckGuid.Value);
			}
			else
			{
				this.MessageShow.Visible = true;
				this.MessageShow.ShowMessage("店铺会员未支付");
			}
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("审核失败");
		}
	}
	public void BandDropdownIsAudit()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	protected string IsAudit(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public int BackMoney(string checkGuid)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		DataTable ensureMoney = shop_Ensure_Action.GetEnsureMoney(new Guid(checkGuid.Replace("'", "")));
		string text = ensureMoney.Rows[0]["EnsureMoney"].ToString();
		string text2 = ensureMoney.Rows[0]["MemberLoginID"].ToString();
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
		DataTable advancePayment = shopNum1_Member_Action.GetAdvancePayment(text2);
		decimal num = Convert.ToDecimal(advancePayment.Rows[0]["AdvancePayment"].ToString());
		string text3 = advancePayment.Rows[0]["Email"].ToString();
		int num2 = shop_Ensure_Action.CheckIsPayMentByID(checkGuid.Replace("'", ""));
		int result;
		if (num2 > 0)
		{
			shopNum1_Member_Action.UpdtateMemberAdvancePayment(text2, text);
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = new ShopNum1_AdvancePaymentModifyLog_Action();
			ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
			shopNum1_AdvancePaymentModifyLog.MemLoginID = text2;
			shopNum1_AdvancePaymentModifyLog.OperateType = 5;
			shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(text);
			shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num;
			shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
			shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
			shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
			shopNum1_AdvancePaymentModifyLog.Memo = "系统退还保障金";
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num + text);
			shopNum1_AdvancePaymentModifyLog.UserMemo = "";
			shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
			if (text3 != null || text3 != "")
			{
				try
				{
					this.SendEmail(text3, text2, shopNum1_AdvancePaymentModifyLog.OperateMoney, shopNum1_AdvancePaymentModifyLog.LastOperateMoney);
				}
				catch
				{
				}
			}
			result = 1;
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("店铺会员未支付服务保障金");
			result = 0;
		}
		return result;
	}
	protected void GetEmailSetting()
	{
		this.string_5 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailServer"));
		this.string_6 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("SMTP"));
		this.string_8 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("ServerPort"));
		this.string_7 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailAccount"));
		this.string_9 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailPassword"));
		this.string_10 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("RestoreEmail"));
		this.string_11 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailCode"));
	}
	public int SendEmail(string email, string memloginid, decimal backMoney, decimal AddPayMentMoney)
	{
		int result = 0;
		ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
		this.GetEmailSetting();
		NetMail netMail = new NetMail();
		ShopNum1_Email_Action shopNum1_Email_Action = new ShopNum1_Email_Action();
		netMail.RecipientEmail = email;
		string s = string.Empty;
		if (backMoney > 0m)
		{
			s = string.Concat(new object[]
			{
				"尊敬的",
				memloginid,
				"用户，由于系统原因，你的保障金审核不通过,现退还你的保障金",
				backMoney,
				"现你的预存款金额为",
				AddPayMentMoney
			});
		}
		else
		{
			s = string.Concat(new object[]
			{
				"尊敬的",
				memloginid,
				"用户，由于系统原因，你的保障金审核不通过现你的预存款金额为",
				AddPayMentMoney
			});
		}
		netMail.Subject = "系统通知";
		netMail.Body = HttpContext.Current.Server.HtmlDecode(s);
		if (!netMail.Send())
		{
			ShopNum1_EmailGroupSend emailGroupSend = this.Add(memloginid, email, 0, netMail.Body);
			shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
		}
		else
		{
			ShopNum1_EmailGroupSend emailGroupSend = this.Add(memloginid, email, 2, netMail.Body);
			shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
			result = 1;
		}
		return result;
	}
	protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
	{
		return new ShopNum1_EmailGroupSend
		{
			Guid = Guid.NewGuid(),
			EmailTitle = this.string_12,
			CreateTime = DateTime.Now,
			EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b"),
			SendObjectEmail = sconts,
			SendObject = memLoginID + "-" + email,
			State = state
		};
	}
}
