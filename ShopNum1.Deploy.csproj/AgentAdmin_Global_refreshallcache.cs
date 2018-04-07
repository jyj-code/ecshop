using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class AgentAdmin_Global_refreshallcache : Page, IRequiresSessionState
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
	private void method_0(object sender, EventArgs e)
	{
		if (base.Request.Cookies["AdminLoginCookie"] == null)
		{
			base.Response.Redirect("../Login.aspx");
		}
		else
		{
			int num = 0;
			int num2;
			if (this.Page.Request.QueryString["opnumber"] != null)
			{
				num = 0;
				num = 0;
				try
				{
					num = Convert.ToInt32(this.Page.Request.QueryString["opnumber"]);
				}
				catch
				{
				}
				num2 = -1;
				switch (num)
				{
				case 1:
					ShopSettings.ResetShopSetting();
					num2 = 2;
					break;
				case 2:
					ShopNum1_ShopCategory_Action.ShopCategoryTable = null;
					num2 = 3;
					break;
				case 3:
					num2 = 4;
					break;
				case 4:
					ShopNum1_ProductCategory_Action.ProductCategoryTable = null;
					num2 = 5;
					break;
				case 5:
					num2 = 6;
					break;
				case 6:
					ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
					num2 = 7;
					break;
				case 7:
					num2 = 8;
					break;
				case 8:
					ShopNum1_CategoryChecked_Action.CategoryTable = null;
					num2 = 9;
					break;
				case 9:
					num2 = 10;
					break;
				case 10:
					ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
					num2 = 11;
					break;
				case 11:
					num2 = 12;
					break;
				case 12:
					num2 = 13;
					break;
				case 13:
					num2 = 14;
					break;
				case 14:
					num2 = 15;
					break;
				case 15:
					ShopNum1_ExtendSiteMota_Action.ResetMeto();
					num2 = 16;
					break;
				case 16:
					num2 = 17;
					break;
				case 17:
					num2 = 18;
					break;
				case 18:
					DefaultAdvertismentOperate.ResetDe();
					num2 = 19;
					break;
				}
			}
			else
			{
				num = 0;
				num = 0;
				num2 = -1;
			}
			base.Response.Write(num2);
		}
	}
}
