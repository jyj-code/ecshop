using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
public class Main_Admin_MemberInfo_SendMsg : PageBase, IRequiresSessionState
{
	protected string strCurrentMem = string.Empty;
	private ShopNum1_Member_Action shopNum1_Member_Action_0 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
	private ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action_0 = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
	private ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action_0 = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
	private JsonModel jsonModel_0 = new JsonModel();
	protected HtmlHead Head1;
	protected MessageShow MessageShow;
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
			string text = base.Request.QueryString["guid"];
			if (!string.IsNullOrEmpty(text))
			{
				this.strCurrentMem = this.shopNum1_Member_Action_0.GetMemLoginIDByGuid(text);
			}
		}
		string text2 = base.Request.Params["sendType"];
		string text3 = text2;
		if (text3 != null)
		{
			if (!(text3 == "1"))
			{
				if (!(text3 == "2"))
				{
					if (text3 == "3")
					{
						this.method_7();
					}
				}
				else
				{
					this.method_6();
				}
			}
			else
			{
				this.method_5();
			}
		}
	}
	private void method_5()
	{
		Thread.Sleep(2000);
		string string_ = base.Request.Form["msgTitle"].Trim();
		string string_2 = base.Request.Form["SendContent"].Trim();
		string[] array = base.Request.Form["sendMems"].Split(new char[]
		{
			','
		});
		List<string> list = new List<string>();
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrEmpty(array[i].Trim()))
			{
				list.Add(array[i].Trim());
			}
		}
		if (this.method_8(string_2, string_, list))
		{
			this.jsonModel_0.Status = "ok";
			this.jsonModel_0.Msg = "发送成功";
		}
		else
		{
			this.jsonModel_0.Status = "err";
			this.jsonModel_0.Msg = "发送失败";
		}
		base.Response.Write(JsonHelper.ObjToJson(this.jsonModel_0));
		base.Response.End();
	}
	private void method_6()
	{
		Thread.Sleep(2000);
		string string_ = base.Request.Form["msgTitle"].Trim();
		string string_2 = base.Request.Form["SendContent"].Trim();
		DataTable dataTable = this.shopNum1_Member_Action_0.SearchMember(0);
		List<string> list = new List<string>();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			if (!string.Equals(dataRow["MemLoginID"].ToString().Trim(), base.ShopNum1LoginID))
			{
				list.Add(dataRow["MemLoginID"].ToString().Trim());
			}
		}
		if (this.method_8(string_2, string_, list))
		{
			this.jsonModel_0.Status = "ok";
			this.jsonModel_0.Msg = "发送成功";
		}
		else
		{
			this.jsonModel_0.Status = "err";
			this.jsonModel_0.Msg = "发送失败";
		}
		base.Response.Write(JsonHelper.ObjToJson(this.jsonModel_0));
		base.Response.End();
	}
	private void method_7()
	{
		Thread.Sleep(2000);
		string string_ = base.Request.Form["msgTitle"].Trim();
		string string_2 = base.Request.Form["SendContent"].Trim();
		List<string> list = new List<string>();
		DataTable dataTable = this.shopNum1_ShopInfoList_Action_0.SearchAllMemID(0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			if (!string.Equals(dataRow["MemLoginID"].ToString().Trim(), base.ShopNum1LoginID))
			{
				list.Add(dataRow["MemLoginID"].ToString().Trim());
			}
		}
		if (this.method_8(string_2, string_, list))
		{
			this.jsonModel_0.Status = "ok";
			this.jsonModel_0.Msg = "发送成功";
		}
		else
		{
			this.jsonModel_0.Status = "err";
			this.jsonModel_0.Msg = "发送失败";
		}
		base.Response.Write(JsonHelper.ObjToJson(this.jsonModel_0));
		base.Response.End();
	}
	private bool method_8(string string_5, string string_6, List<string> list_0)
	{
		ShopNum1_MessageInfo shopNum1_MessageInfo = new ShopNum1_MessageInfo();
		shopNum1_MessageInfo.Content = string_5;
		shopNum1_MessageInfo.Guid = Guid.NewGuid();
		shopNum1_MessageInfo.Title = string_6;
		shopNum1_MessageInfo.Type = "1";
		shopNum1_MessageInfo.MemLoginID = "";
		shopNum1_MessageInfo.MemLoginID = base.ShopNum1LoginID;
		shopNum1_MessageInfo.SendTime = DateTime.Now;
		shopNum1_MessageInfo.IsDeleted = 0;
		bool result;
		if (this.shopNum1_MessageInfo_Action_0.Add(shopNum1_MessageInfo, list_0) > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "发送消息成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "MemberInfo_SendMsg.aspx",
				Date = DateTime.Now
			});
			result = true;
		}
		else
		{
			result = false;
		}
		return result;
	}
}
