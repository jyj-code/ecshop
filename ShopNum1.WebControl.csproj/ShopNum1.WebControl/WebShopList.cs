using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class WebShopList : BaseWebControl
	{
		private string string_0 = "WebShopList.ascx";
		private Repeater repeater_0;
		private string string_1 = "";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public string ShowCount
		{
			get;
			set;
		}
		public string OrderWord
		{
			get;
			set;
		}
		public string OrderType
		{
			get;
			set;
		}
		public string type
		{
			get;
			set;
		}
		public WebShopList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShopByType");
			try
			{
				this.method_0();
			}
			catch
			{
			}
		}
		private void method_0()
		{
			if (string.IsNullOrEmpty(this.ShowCount))
			{
				this.ShowCount = "6";
			}
			if (string.IsNullOrEmpty(this.OrderWord))
			{
				this.OrderWord = "OrderID";
			}
			if (string.IsNullOrEmpty(this.OrderType))
			{
				this.OrderType = "DESC";
			}
			if (!string.IsNullOrEmpty(this.type))
			{
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
				DataTable dataTable = null;
				string type = this.type;
				if (type != null)
				{
					if (!(type == "IsSystemRecommend"))
					{
						if (!(type == "IsAgentRecommend"))
						{
							if (!(type == "IsSystemHot"))
							{
								if (type == "IsAgentHot")
								{
									dataTable = shopNum1_ShopInfoList_Action.GetAgentHotShop("1", "1", "0", "0", this.OrderWord, this.OrderType, this.ShowCount, this.string_1);
								}
							}
							else
							{
								dataTable = shopNum1_ShopInfoList_Action.GetSystemHotShop("1", "1", "0", "0", this.OrderWord, this.OrderType, this.ShowCount);
							}
						}
						else
						{
							dataTable = shopNum1_ShopInfoList_Action.GetAgentRecommendShop("1", "1", "0", "0", this.OrderWord, this.OrderType, this.ShowCount, this.string_1);
						}
					}
					else
					{
						dataTable = shopNum1_ShopInfoList_Action.GetSystemRecommendShop("1", "1", "0", "0", this.OrderWord, this.OrderType, this.ShowCount);
					}
				}
				try
				{
					if (dataTable.Rows.Count > 0 && dataTable != null)
					{
						this.repeater_0.DataSource = dataTable.DefaultView;
						this.repeater_0.DataBind();
					}
				}
				catch
				{
				}
			}
		}
	}
}
