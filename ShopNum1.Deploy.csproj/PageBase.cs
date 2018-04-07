using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.ExtendedCommon;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public class PageBase : AdminPage
{
	protected DataTable dataTableRole = null;
	[CompilerGenerated]
	private string string_0;
	[CompilerGenerated]
	private string string_1;
	[CompilerGenerated]
	private string string_2;
	[CompilerGenerated]
	private string string_3;
	[CompilerGenerated]
	private string string_4;
	protected string ShopNum1UserGuid
	{
		get;
		private set;
	}
	protected string SubstationID
	{
		get;
		private set;
	}
	protected string ShopNum1LoginID
	{
		get;
		private set;
	}
	protected string strDomain
	{
		get;
		private set;
	}
	public string CurrentPageName
	{
		get;
		private set;
	}
	public PageBase()
	{
		base.Error += new EventHandler(this.PageBase_Error);
	}
	protected void PageBase_Error(object sender, EventArgs e)
	{
		HttpContext current = HttpContext.Current;
		Exception lastError = current.Server.GetLastError();
		string text = current.Request.Url.ToString();
		string source = lastError.Source;
		string message = lastError.Message;
		string stackTrace = lastError.StackTrace;
		string text2 = current.Request.ServerVariables["SERVER_NAME"].ToString();
		this.method_1(string.Concat(new string[]
		{
			"http://www.shopnum1.com/ShopNum1ErrorGetMall/ErrorEet.aspx?FKshopnum1ERRORABC=FKshopnum1ERROR&OffendingUrl=",
			text,
			"&ErrorSouce= ",
			source,
			" &Message=",
			message,
			"&StackTrace= ",
			stackTrace,
			"&MainDomain=",
			text2
		}));
		current.Server.ClearError();
		ErrorShow.Show(stackTrace);
	}
	private string method_1(string string_5)
	{
		string result = string.Empty;
		Encoding encoding = Encoding.GetEncoding("utf-8");
		WebRequest webRequest = WebRequest.Create(string_5);
		try
		{
			WebResponse response = webRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
			result = streamReader.ReadToEnd();
		}
		catch (Exception)
		{
			result = "";
		}
		return result;
	}
	protected string HeaderInfo(string secondTitle)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (secondTitle == "")
		{
			stringBuilder.Append("<title>后台管理</title>\r\n");
		}
		else
		{
			stringBuilder.Append("<title>系统后台管理-" + secondTitle + "</title>\r\n");
		}
		return stringBuilder.ToString();
	}
	protected void CheckLogin()
	{
		ShopNum1_PreventIp_Action shopNum1_PreventIp_Action = (ShopNum1_PreventIp_Action)LogicFactory.CreateShopNum1_PreventIp_Action();
		if (!shopNum1_PreventIp_Action.CheckedUser(HttpContext.Current.Request.UserHostAddress, "2"))
		{
			base.Response.Redirect("~/404.aspx");
		}
		else if (this.Session["AdminLoginCookie"] == null)
		{
			base.Response.Redirect("Login.aspx");
		}
		else
		{
			HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			this.ShopNum1UserGuid = httpCookie.Values["Guid"].ToString();
			this.ShopNum1LoginID = this.Session["AdminLoginCookie"].ToString();
			this.SubstationID = httpCookie.Values["SubstationID"].ToString();
			this.CurrentPageName = PageOperator.GetCurrentPageName();
			if (this.CheckPage(this.CurrentPageName) <= 0)
			{
				base.Response.Redirect("~/Main/Admin/Html/Nopower.htm");
			}
			else
			{
				this.OperatePageControl(this.Page);
			}
		}
	}
	protected void CheckNoPowerLogin()
	{
		ShopNum1_PreventIp_Action shopNum1_PreventIp_Action = (ShopNum1_PreventIp_Action)LogicFactory.CreateShopNum1_PreventIp_Action();
		if (!shopNum1_PreventIp_Action.CheckedUser(HttpContext.Current.Request.UserHostAddress, "2"))
		{
			base.Response.Redirect("~/404.aspx");
		}
		else if (this.Session["AdminLoginCookie"] == null)
		{
			base.Response.Redirect("Login.aspx");
		}
		else
		{
			HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			this.ShopNum1UserGuid = httpCookie.Values["Guid"].ToString();
			this.ShopNum1LoginID = this.Session["AdminLoginCookie"].ToString();
			this.SubstationID = httpCookie.Values["SubstationID"].ToString();
			this.CurrentPageName = PageOperator.GetCurrentPageName();
			if (this.CheckPage(this.CurrentPageName) <= 0)
			{
				if (!(this.CurrentPageName == "index.aspx"))
				{
					base.Response.Redirect("~/Main/Admin/Html/Nopower.htm");
				}
			}
			else
			{
				this.OperatePageControl(this.Page);
			}
		}
	}
	protected int CheckPage(string pageName)
	{
		HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
		HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
		string a = httpCookie.Values["PeopleType"].ToString();
		int result;
		if (a == "0")
		{
			result = 1;
		}
		else
		{
			ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			result = shopNum1_Group_Action.CheckOperatePage(this.ShopNum1UserGuid, pageName);
		}
		return result;
	}
	protected void GetControlOperate(string pageName)
	{
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		this.dataTableRole = shopNum1_Group_Action.GetOperateControl(this.ShopNum1UserGuid, pageName);
	}
	public void OperatePageControl(Page currentPage)
	{
		foreach (Control control in currentPage.Controls)
		{
			if (control.HasControls())
			{
				this.method_2(control);
			}
			this.method_3(control);
		}
	}
	private void method_2(Control control_0)
	{
		foreach (Control control in control_0.Controls)
		{
			if (control.HasControls())
			{
				this.method_2(control);
			}
			this.method_3(control);
		}
	}
	private void method_3(Control control_0)
	{
		bool flag = false;
		bool flag2 = true;
		bool flag3 = true;
		this.GetControlOperate(this.CurrentPageName);
		try
		{
			if (this.dataTableRole == null || this.dataTableRole.Rows.Count <= 0)
			{
				return;
			}
			foreach (DataRow dataRow in this.dataTableRole.Rows)
			{
				if (dataRow["ControlID"].ToString() == control_0.ID)
				{
					if (dataRow["IsShow"].ToString() == "0")
					{
						flag3 = false;
					}
					flag = true;
					break;
				}
			}
		}
		catch
		{
			flag = false;
		}
		if (flag)
		{
			if (!flag3)
			{
				control_0.Visible = flag3;
			}
			else
			{
				string fullName = control_0.GetType().FullName;
				if (fullName != null)
				{
					if (!(fullName == "System.Web.UI.WebControls.Button"))
					{
						if (!(fullName == "System.Web.UI.WebControls.LinkButton"))
						{
							if (fullName == "System.Web.UI.WebControls.ImageButton")
							{
								ImageButton imageButton = control_0 as ImageButton;
								if (!flag2)
								{
									imageButton.Enabled = flag2;
								}
							}
						}
						else
						{
							LinkButton linkButton = control_0 as LinkButton;
							if (!flag2)
							{
								linkButton.Enabled = flag2;
							}
						}
					}
					else
					{
						Button button = control_0 as Button;
						if (!flag2)
						{
							button.Enabled = flag2;
						}
					}
				}
			}
		}
	}
	protected int OperateLog(ShopNum1_OperateLog operateLog)
	{
		ShopNum1_OperateLog_Action shopNum1_OperateLog_Action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
		return shopNum1_OperateLog_Action.Add(operateLog);
	}
	public void ClientDomainCheck()
	{
		ControlCheck controlCheck = new ControlCheck();
		HttpContext current = HttpContext.Current;
		string a = current.Request.ServerVariables["SERVER_NAME"].ToString();
		string text = ConfigurationManager.AppSettings["DoMain"].ToString();
		if (a != text)
		{
			this.FK();
			base.Response.Redirect("~/Main/Admin/Html/Nopower.htm");
		}
		int num = controlCheck.CheckCertificationModificate(text);
		if (num != 2)
		{
			this.FK();
		}
		else
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			int num2 = controlCheck.CheckCetificationA(out empty, out empty2);
			if (num2 != 2)
			{
				this.FK();
			}
			else if (!controlCheck.CheckFirstMd5(empty, text, empty2.ToLower()))
			{
				this.FK();
			}
			else if (!controlCheck.CheckSecondDes(empty2.ToLower()))
			{
				this.FK();
			}
		}
	}
	protected void FK()
	{
		HttpContext current = HttpContext.Current;
		string text = current.Request.ServerVariables["SERVER_NAME"].ToString();
		if (text != "localhost")
		{
			string a = this.method_4("http://www.shopnum1.com/ShopNum1MallDomainVerfiy/ShopNum1Verfify.aspx?shopnum1verfify=FKshopnum1verfify&&FkDomin=" + text);
			if (!(a == "YES"))
			{
				if (a == "FKENDDATE")
				{
					current.Response.Redirect("http://www.shopnum1.com/Mallbuy.html");
				}
				else
				{
					current.Response.Redirect("http://www.shopnum1.com/Mallshouldbuy.html");
				}
			}
		}
	}
	private string method_4(string string_5)
	{
		string result = string.Empty;
		Encoding encoding = Encoding.GetEncoding("utf-8");
		WebRequest webRequest = WebRequest.Create(string_5);
		try
		{
			WebResponse response = webRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
			result = streamReader.ReadToEnd();
			streamReader.Close();
			if (response != null)
			{
				response.Close();
			}
		}
		catch (Exception ex)
		{
			result = "";
			throw ex;
		}
		return result;
	}
}
