using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopInfoList_Audit : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberName;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonSearchShop;
	protected LinkButton ButtonOperate;
	protected LinkButton ButtonOperate1;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSource;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldIsAudit;
	protected HiddenField HiddenFieldSubstationID;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.GetDropDownListSubstationID();
			this.method_5();
		}
	}
	public void GetDropDownListSubstationID()
	{
	}
	public string GetSubstationIDNameBySubstationID(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
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
			IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
			DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text2 + "'", 0);
			Guid.NewGuid().ToString();
			if (editInfo.Rows.Count > 0)
			{
				text3 = editInfo.Rows[0]["Remark"].ToString();
				mMsTitle = editInfo.Rows[0]["Title"].ToString();
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
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
				openShop.SysSendTime = DateTime.Now.ToString();
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
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable shopInfoByGuid = shopNum1_ShopInfoList_Action.GetShopInfoByGuid(this.CheckGuid.Value);
		string value = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
		string text = shopInfoByGuid.Rows[0]["ShopID"].ToString();
		string path = string.Concat(new string[]
		{
			"~/Shop/Shop/",
			Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			text
		});
		string path2 = string.Concat(new string[]
		{
			"~/ImgUpload/",
			Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			text
		});
		this.method_6(base.Server.MapPath(path2));
		this.method_6(base.Server.MapPath(path));
		if (shopNum1_ShopInfoList_Action.Delete(this.CheckGuid.Value) > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable shopInfoByGuid = shopNum1_ShopInfoList_Action.GetShopInfoByGuid(guid);
		string value = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
		string text = shopInfoByGuid.Rows[0]["ShopID"].ToString();
		string path = string.Concat(new string[]
		{
			"~/Shop/Shop/",
			Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			text
		});
		string path2 = string.Concat(new string[]
		{
			"~/ImgUpload/",
			Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			text
		});
		this.method_6(base.Server.MapPath(path2));
		this.method_6(base.Server.MapPath(path));
		if (shopNum1_ShopInfoList_Action.Delete(guid) > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_6(string string_12)
	{
		if (Directory.Exists(string_12))
		{
			string[] fileSystemEntries = Directory.GetFileSystemEntries(string_12);
			for (int i = 0; i < fileSystemEntries.Length; i++)
			{
				string text = fileSystemEntries[i];
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				else
				{
					this.method_6(text);
				}
			}
			Directory.Delete(string_12, true);
		}
	}
	public string YesOrNo(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "是";
		}
		else
		{
			result = "否";
		}
		return result;
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已通过";
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
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopInfo_AuditOperate.aspx?guid=" + this.CheckGuid.Value);
	}
}
