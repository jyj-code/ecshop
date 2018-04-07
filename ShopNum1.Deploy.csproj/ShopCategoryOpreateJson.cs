using ShopNum1.Factory;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class ShopCategoryOpreateJson : Page, IRequiresSessionState
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
		if (this.Page.Request["category"] == null)
		{
			base.Response.Write("notarget");
		}
		else
		{
			this.method_0(this.Page.Request["category"].ToString());
		}
	}
	private void method_0(string string_0)
	{
		IShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = LogicFactory.CreateShopNum1_ShopCategory_Action();
		DataTable list = shopNum1_ShopCategory_Action.GetList(string_0);
		StringBuilder stringBuilder = new StringBuilder();
		if (list != null && list.Rows.Count != 0)
		{
			stringBuilder.Append("[");
			for (int i = 0; i < list.Rows.Count; i++)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"{\"Name\":\"",
					list.Rows[i]["Name"].ToString(),
					"\",\"Value\":\"",
					list.Rows[i]["Code"].ToString(),
					"/",
					list.Rows[i]["ID"].ToString(),
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
