using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_SetCategoryScale : PageBase, IRequiresSessionState
{
	protected Label LabelTitle;
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
		if (!this.Page.IsPostBack)
		{
			if (Common.ReqStr("category") != "")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				base.Response.Write(this.method_5(shopNum1_ProductCategory_Action.Select_ProductCategory()));
			}
			else if (Common.ReqStr("getdata") != "")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				DataTable dataTable = shopNum1_ProductCategory_Action.dt_GetScale(Common.ReqStr("getdata"));
				if (dataTable.Rows.Count > 0)
				{
					base.Response.Write(dataTable.Rows[0]["Scale"] + "|" + dataTable.Rows[0]["IsOpen"]);
				}
			}
			else if (Common.ReqStr("updateCode") != "" && Common.ReqStr("scale") != "" && Common.ReqStr("isopen") != "")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.Update_Scale(Common.ReqStr("updateCode"), Common.ReqStr("scale"), Common.ReqStr("isopen"));
			}
		}
	}
	private string method_5(DataTable dt)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		if (dt.Rows.Count > 0)
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				stringBuilder.Append("{");
				for (int j = 0; j < dt.Columns.Count; j++)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"\"",
						dt.Columns[j].ColumnName.ToLower(),
						"\":\"",
						dt.Rows[i][j],
						"\","
					}));
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("},");
			}
		}
		stringBuilder.Remove(stringBuilder.Length - 1, 1);
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
