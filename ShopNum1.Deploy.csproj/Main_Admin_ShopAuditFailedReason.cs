using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopAuditFailedReason : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	protected HtmlLink sizestylesheet;
	protected Label LabelShopAuditFailedReason;
	protected TextBox TextBoxShopAuditFailedReason;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorRealName;
	protected RegularExpressionValidator RegularExpressionValidatorRealName;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected Panel PanelShow;
	protected Panel PanelShowMsg;
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
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.UpdateShopState(this.Page.Request.QueryString["guid"].ToString().Replace("'", ""), this.TextBoxShopAuditFailedReason.Text.Trim(), base.ShopNum1LoginID, DateTime.Now.ToString(), 2) > 0)
		{
			if (ShopSettings.GetValue("AuditOpenShopIsEmail") == "1")
			{
				this.IsEmail(this.Page.Request.QueryString["guid"].ToString());
			}
			if (ShopSettings.GetValue("AuditOpenShopIsMMS") == "1")
			{
				this.IsMMS();
			}
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员审核店铺不通过",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ShopAuditFailedReason.aspx",
				Date = DateTime.Now
			});
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
			this.ReturnMoney();
			this.PanelShow.Visible = false;
			this.PanelShowMsg.Visible = true;
			this.Page.RegisterStartupScript("name", "<script>window.parent.location='ShopInfoList_Audit.aspx';</script>");
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	public void ReturnMoney()
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
		string text = string.Empty;
		decimal num = 0m;
		string text2 = string.Empty;
		if (allShopInfoByGuid != null && allShopInfoByGuid.Rows.Count > 0)
		{
			text = allShopInfoByGuid.Rows[0]["ShopRank"].ToString();
			text2 = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
		}
		decimal num2 = 0m;
		try
		{
			num2 = Convert.ToDecimal(shopNum1_Member_Action.GetAdvancePayment(text2).Rows[0][0].ToString());
		}
		catch (Exception)
		{
		}
		if (text != "")
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			DataTable shopRankPrice = shop_Rank_Action.GetShopRankPrice(text);
			if (shopRankPrice != null && shopRankPrice.Rows.Count > 0)
			{
				num = Convert.ToDecimal(shopRankPrice.Rows[0][0].ToString());
			}
		}
		if (num > 0m)
		{
			int num3 = shopNum1_Member_Action.UpdateAdvancePayment(0, text2, num);
			if (num3 > 0)
			{
				ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
				shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
				shopNum1_AdvancePaymentModifyLog.OperateType = 5;
				shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num2;
				shopNum1_AdvancePaymentModifyLog.OperateMoney = num;
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num2) + num;
				shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
				shopNum1_AdvancePaymentModifyLog.Memo = "开店铺审核失败，返回预存款";
				shopNum1_AdvancePaymentModifyLog.MemLoginID = text2;
				shopNum1_AdvancePaymentModifyLog.CreateUser = text2;
				shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
				ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
				shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
			}
		}
	}
	protected void GetEmailSetting()
	{
		ShopSettings shopSettings = new ShopSettings();
		this.string_5 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailServer"));
		this.string_6 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
		this.string_8 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ServerPort"));
		this.string_7 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailAccount"));
		this.string_9 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailPassword"));
		this.string_10 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "RestoreEmail"));
		this.string_11 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailCode"));
	}
	protected void IsMMS()
	{
		try
		{
			string value = ShopSettings.GetValue("Name");
			string mMsTitle = string.Empty;
			string text = string.Empty;
			string mobile = string.Empty;
			string text2 = "60c1bef2-33e4-4510-944c-afca43d09f0c";
			string text3 = string.Empty;
			IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
			DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text2 + "'", 0);
			Guid.NewGuid().ToString();
			if (editInfo.Rows.Count > 0)
			{
				text3 = editInfo.Rows[0]["Remark"].ToString();
				mMsTitle = editInfo.Rows[0]["Title"].ToString();
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberInfoByGuID = shopNum1_Member_Action.GetMemberInfoByGuID(this.Page.Request.QueryString["guid"].ToString().Replace("'", ""));
			if (memberInfoByGuID.Rows.Count > 0)
			{
				text = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
				if (memberInfoByGuID.Rows[0]["Phone"].ToString() != "")
				{
					mobile = memberInfoByGuID.Rows[0]["Phone"].ToString();
				}
				else
				{
					mobile = memberInfoByGuID.Rows[0]["tel"].ToString();
				}
			}
			text3 = text3.Replace("恭喜", "抱歉");
			text3 = text3.Replace("已经通过审核", "未通过审核");
			text3 = text3.Replace("{$Name}", text);
			text3 = text3.Replace("{$ShopName}", value);
			text3 = text3.Replace("{$SysSendTime} ", DateTime.Now.ToString("yyyy-MM-dd"));
			SMS sMS = new SMS();
			string text4 = "";
			sMS.Send(mobile, text3, out text4);
			if (text4.IndexOf("发送成功") != -1)
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(text, mobile, mMsTitle, 2, text2, text3);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
			else
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(text, mobile, mMsTitle, 0, text2, text3);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
		}
		catch (Exception)
		{
		}
	}
	protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid, string MMsBody)
	{
		return new ShopNum1_MMSGroupSend
		{
			Guid = Guid.NewGuid(),
			MMSTitle = MMsTitle,
			CreateTime = DateTime.Now,
			MMSGuid = new Guid(mmsGuid),
			SendObjectMMS = MMsBody,
			SendObject = memLoginID + "-" + mobile,
			State = state
		};
	}
	protected void IsEmail(string strId)
	{
		try
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberInfoByGuID = shopNum1_Member_Action.GetMemberInfoByGuID(strId.Replace("'", ""));
			if (!(memberInfoByGuID.Rows[0]["Email"].ToString() == ""))
			{
				string value = ShopSettings.GetValue("Name");
				OpenShop openShop = new OpenShop();
				this.GetEmailSetting();
				NetMail netMail = new NetMail();
				netMail.RecipientEmail = memberInfoByGuID.Rows[0]["Email"].ToString();
				openShop.Name = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
				openShop.ShopID = ShopSettings.GetValue("PersonShopUrl") + memberInfoByGuID.Rows[0]["ShopID"].ToString();
				openShop.ShopStatus = "审核不通过";
				openShop.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				openShop.ShopName = value;
				string text = string.Empty;
				string text2 = string.Empty;
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'5387cec4-05ed-41d1-bc1f-c900c4959585'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					text2 = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", memberInfoByGuID.Rows[0]["MemLoginID"].ToString());
				text = text.Replace("{$ShopName}", openShop.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				netMail.Subject = text2;
				netMail.Body = openShop.ChangeOpenShop(this.Page.Server.HtmlDecode(text));
				if (!netMail.Send())
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), text2, memberInfoByGuID.Rows[0]["Email"].ToString(), 0, netMail.Body);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
				}
				else
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), text2, memberInfoByGuID.Rows[0]["Email"].ToString(), 2, netMail.Body);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
				}
			}
		}
		catch (Exception)
		{
		}
	}
	protected ShopNum1_EmailGroupSend Add(string memLoginID, string strTitle, string email, int state, string scont)
	{
		return new ShopNum1_EmailGroupSend
		{
			Guid = Guid.NewGuid(),
			EmailTitle = strTitle,
			CreateTime = DateTime.Now,
			EmailGuid = new Guid("60c1bef2-33e4-4510-944c-afca43d09f0c"),
			SendObjectEmail = scont,
			SendObject = memLoginID + "-" + email,
			State = state
		};
	}
}
