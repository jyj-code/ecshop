using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopInfo_AuditOperate : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected TextBox TextBoxName;
	protected TextBox TextBoxShopName;
	protected TextBox TextBoxShopType;
	protected TextBox TextBoxShopCategory;
	protected TextBox TextBoxMainGoods;
	protected TextBox TextBoxSalesRange;
	protected TextBox TextBoxTel;
	protected TextBox TextBoxPhone;
	protected TextBox TextBoxPostalCode;
	protected TextBox TextBoxIdentityCard;
	protected TextBox TextBoxAddress;
	protected TextBox TextBoxAddressValue;
	protected TextBox TextBoxAddressDeteil;
	protected Image ImageCardImage1;
	protected HtmlAnchor aCardImage1;
	protected Image ImageBusinessLicense;
	protected HtmlAnchor aBusinessLicense;
	protected Panel PanelShowBusinessLicense;
	protected Button ButtonOperate;
	protected Button ButtonOperate1;
	protected Button ButtonBank;
	protected Label lbTest;
	protected AgentAdmin_MessageShow MessageShow;
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
		base.CheckLogin();
		if (!base.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		this.CheckGuid.Value = base.Request.QueryString["guid"];
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.CheckGuid.Value);
		this.TextBoxName.Text = allShopInfoByGuid.Rows[0]["Name"].ToString();
		this.TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();
		this.TextBoxSalesRange.Text = allShopInfoByGuid.Rows[0]["SalesRange"].ToString();
		this.TextBoxTel.Text = allShopInfoByGuid.Rows[0]["Tel"].ToString();
		this.TextBoxPhone.Text = allShopInfoByGuid.Rows[0]["Phone"].ToString();
		this.TextBoxPostalCode.Text = allShopInfoByGuid.Rows[0]["PostalCode"].ToString();
		this.TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
		this.TextBoxAddressValue.Text = allShopInfoByGuid.Rows[0]["AddressValue"].ToString().Replace(",", "");
		this.TextBoxIdentityCard.Text = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();
		this.ImageCardImage1.ImageUrl = allShopInfoByGuid.Rows[0]["CardImage"].ToString();
		this.aCardImage1.HRef = allShopInfoByGuid.Rows[0]["CardImage"].ToString();
		this.aBusinessLicense.HRef = allShopInfoByGuid.Rows[0]["BusinessLicense"].ToString();
		this.ImageBusinessLicense.ImageUrl = allShopInfoByGuid.Rows[0]["BusinessLicense"].ToString();
		if (allShopInfoByGuid.Rows[0]["ShopType"].ToString() == "0")
		{
			this.TextBoxShopType.Text = "个人";
		}
		else if (allShopInfoByGuid.Rows[0]["ShopType"].ToString() == "1")
		{
			this.PanelShowBusinessLicense.Visible = true;
			this.TextBoxShopType.Text = "企业";
		}
		this.TextBoxShopCategory.Text = this.GetShopCategory(allShopInfoByGuid.Rows[0]["ShopCategoryID"].ToString());
		this.TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MainGoods"].ToString();
		this.TextBoxAddressDeteil.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
	}
	public string GetShopCategory(string code)
	{
		string result;
		if (!string.IsNullOrEmpty(code) && code.Length > 0)
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			string text = string.Empty;
			int num = code.Length / 3;
			for (int i = 1; i <= num; i++)
			{
				string code2 = code.Substring(0, i * 3);
				DataTable shopCategoryMeto = shopNum1_ShopCategory_Action.GetShopCategoryMeto(code2);
				if (shopCategoryMeto != null && shopCategoryMeto.Rows.Count > 0)
				{
					if (text == string.Empty)
					{
						text = shopCategoryMeto.Rows[0]["Name"].ToString();
					}
					else
					{
						text = text + "/" + shopCategoryMeto.Rows[0]["Name"].ToString();
					}
				}
			}
			result = text;
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonBank_Click(object sender, EventArgs e)
	{
		if (base.Request.QueryString["GoBack"] != null && base.Request.QueryString["GoBack"].ToString() == "nosh")
		{
			base.Response.Redirect("ShopInfoList_AuditNo.aspx");
		}
		else
		{
			base.Response.Redirect("ShopInfoList_Audit.aspx");
		}
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("UpdateShopURL.aspx?guid=" + this.CheckGuid.Value + "&type=Audit");
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
			IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
			DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text2 + "'", 0);
			Guid.NewGuid().ToString();
			if (editInfo.Rows.Count > 0)
			{
				text3 = editInfo.Rows[0]["Remark"].ToString();
				mMsTitle = editInfo.Rows[0]["Title"].ToString();
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberInfoByGuID = shopNum1_Member_Action.GetMemberInfoByGuID(this.CheckGuid.Value.Replace("'", ""));
			if (memberInfoByGuID.Rows.Count > 0)
			{
				text = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
				if (memberInfoByGuID.Rows[0]["tel"].ToString() != "")
				{
					mobile = memberInfoByGuID.Rows[0]["tel"].ToString();
				}
				else
				{
					mobile = memberInfoByGuID.Rows[0]["mobile"].ToString();
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
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(text, mobile, mMsTitle, 2, text2);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
			else
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(text, mobile, mMsTitle, 0, text2);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
		}
		catch (Exception)
		{
		}
	}
	protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid)
	{
		return new ShopNum1_MMSGroupSend
		{
			Guid = Guid.NewGuid(),
			MMSTitle = MMsTitle,
			CreateTime = DateTime.Now,
			MMSGuid = new Guid(mmsGuid),
			SendObjectMMS = mobile,
			SendObject = memLoginID + "-" + mobile,
			State = state
		};
	}
	protected void IsEmail(string strId)
	{
		try
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
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
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
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
	protected void ButtonOperate1_Click(object sender, EventArgs e)
	{
	}
}
