using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class AddressOpreateJson : Page, IRequiresSessionState
{
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
		if (this.Page.Request["cityid"] == null)
		{
			base.Response.Write("notarget");
		}
		else
		{
			this.method_0(this.Page.Request["cityid"].ToString());
		}
	}
	private void method_0(string string_0)
	{
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
		DataTable dispatchRegionName = shopNum1_DispatchRegion_Action.GetDispatchRegionName(string_0);
		StringBuilder stringBuilder = new StringBuilder();
		if (dispatchRegionName != null && dispatchRegionName.Rows.Count != 0)
		{
			stringBuilder.Append("[");
			for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"{\"Name\":\"",
					dispatchRegionName.Rows[i]["Name"].ToString(),
					"\",\"Value\":\"",
					dispatchRegionName.Rows[i]["Code"].ToString(),
					"/",
					dispatchRegionName.Rows[i]["ID"].ToString(),
					"\"},"
				}));
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append("]");
			this.Page.Response.ContentType = "application/json";
			this.Page.Response.ContentEncoding = Encoding.UTF8;
			this.Page.Response.Write(stringBuilder.ToString());
		}
	}
}
