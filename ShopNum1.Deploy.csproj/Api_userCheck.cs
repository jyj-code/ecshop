using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class Api_userCheck : Page, IRequiresSessionState
{
	private ShopNum1_Member_Action shopNum1_Member_Action_0 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
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
		if (this.Page.Request["otype"] == null)
		{
			base.Response.Write("notarget");
		}
		else
		{
			this.method_0(this.Page.Request["otype"].ToString());
		}
	}
	private void method_0(string string_0)
	{
		if (string_0 != null)
		{
			if (!(string_0 == "checkemail"))
			{
				if (!(string_0 == "checklogin"))
				{
					if (string_0 == "checkshopname")
					{
						string name = this.Page.Request["shopname"].ToString();
						IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = LogicFactory.CreateShopNum1_ShopInfoList_Action();
						if (shopNum1_ShopInfoList_Action.CheckShopName(name) > 0)
						{
							base.Response.Write("success");
							return;
						}
						base.Response.Write("failed");
						return;
					}
				}
				else
				{
					string memLoginID = string.Empty;
					string input = string.Empty;
					try
					{
						memLoginID = base.Request["memlogid"].ToString();
						input = base.Request["pwd"].ToString();
					}
					catch
					{
						base.Response.Write("notarget");
					}
					int num = this.shopNum1_Member_Action_0.CheckPassword(memLoginID, Encryption.GetMd5Hash(input));
					if (num > 0)
					{
						base.Response.Write("success");
						return;
					}
					base.Response.Write("notfind");
					return;
				}
			}
			else
			{
				if (base.Request["email"] == null)
				{
					base.Response.Write("notarget");
					return;
				}
				string email = base.Request["email"].ToString();
				DataTable dataTable = this.shopNum1_Member_Action_0.MemberFindPwdPro(email);
				if (dataTable == null || dataTable.Rows.Count == 0)
				{
					base.Response.Write("notfind");
					return;
				}
				base.Response.Write("success");
				return;
			}
		}
		base.Response.Write("notarget");
	}
}
