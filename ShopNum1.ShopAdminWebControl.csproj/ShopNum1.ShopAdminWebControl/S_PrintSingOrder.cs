using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_PrintSingOrder : BaseShopWebControl
	{
		public string flashVars;
		private IShopNum1_OrderInfo_Action ishopNum1_OrderInfo_Action_0 = new ShopNum1_OrderInfo_Action();
		private IShopNum1_OrderExpress_Action ishopNum1_OrderExpress_Action_0 = new ShopNum1_OrderExpress_Action();
		private IShopNum1_Region_Action ishopNum1_Region_Action_0 = new ShopNum1_Region_Action();
		private EvalData<ShopNum1_OrderInfo> evalData_0 = new EvalData<ShopNum1_OrderInfo>();
		private EvalData<ShopNum1_OrderExpressInfo> evalData_1 = new EvalData<ShopNum1_OrderExpressInfo>();
		private EvalData<ShopNum1_Shipper> evalData_2 = new EvalData<ShopNum1_Shipper>();
		private IShopNum1_Shipper_Action ishopNum1_Shipper_Action_0 = new ShopNum1_Shipper_Action();
		private HiddenField hiddenField_0;
		public string shopid
		{
			get
			{
				HttpCookie httpCookie = HttpSecureCookie.Decode(this.Page.Request.Cookies["MemberLoginCookie"]);
				return httpCookie.Values["shopid"].ToString();
			}
		}
		public S_PrintSingOrder()
		{
			if (string.IsNullOrEmpty(base.SkinFilename))
			{
				base.SkinFilename = "S_PrintSingOrder.ascx";
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hiddenField_0 = (skin.FindControl("Hflash") as HiddenField);
			if (!this.Page.IsPostBack)
			{
				try
				{
					ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
					ShopNum1_OrderExpressInfo shopNum1_OrderExpressInfo = new ShopNum1_OrderExpressInfo();
					ShopNum1_Shipper shopNum1_Shipper = new ShopNum1_Shipper();
					shopNum1_OrderInfo = this.evalData_0.GetData(this.ishopNum1_OrderInfo_Action_0.Search(this.Page.Request["guid"])).First<ShopNum1_OrderInfo>();
					if (shopNum1_OrderInfo == null)
					{
						MessageBox.Show("订单不存在!");
					}
					else
					{
						shopNum1_Shipper = this.evalData_2.GetData(this.ishopNum1_Shipper_Action_0.Search("and isdefault=1 and shopid='" + this.shopid + "'")).First<ShopNum1_Shipper>();
						if (shopNum1_Shipper == null)
						{
							MessageBox.Show("订单不存在!");
						}
						else
						{
							if (shopNum1_OrderInfo.LogisticsCompanyCode != null)
							{
								shopNum1_OrderExpressInfo = this.evalData_1.GetData(this.ishopNum1_OrderExpress_Action_0.SearchByLogisticsID(shopNum1_OrderInfo.LogisticsCompanyCode)).First<ShopNum1_OrderExpressInfo>();
							}
							if (shopNum1_OrderExpressInfo != null)
							{
								this.hiddenField_0.Value = this.GetflashVarsFormat(shopNum1_OrderInfo, shopNum1_Shipper, shopNum1_OrderExpressInfo);
							}
							else
							{
								MessageBox.Show("您选择的快递没有模板信息,请设置后重试!");
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}
		public string GetflashVarsFormat(ShopNum1_OrderInfo order, ShopNum1_Shipper shiper, ShopNum1_OrderExpressInfo express)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<data>");
			stringBuilder.Append("<dly_name><![CDATA[" + shiper.SendName + "]]></dly_name>");
			stringBuilder.Append(string.Concat(new string[]
			{
				"<dly_address><![CDATA[",
				this.ishopNum1_Region_Action_0.GetAreaByRegionCode(shiper.RegionCode),
				"  ",
				shiper.Address,
				"]]></dly_address>"
			}));
			stringBuilder.Append("<dly_mobile>" + shiper.Mobile + "</dly_mobile>");
			stringBuilder.Append("<dly_tel><![CDATA[" + shiper.Phone + "]]></dly_tel>");
			stringBuilder.Append("<dly_tel><![CDATA[" + shiper.Phone + "]]></dly_tel>");
			stringBuilder.Append("<dly_zip><![CDATA[" + shiper.PostalCode + "]]></dly_zip>");
			stringBuilder.Append("<ship_name><![CDATA[" + order.Name + "]]></ship_name>");
			stringBuilder.Append("<ship_addr><![CDATA[" + order.Address + "]]></ship_addr>");
			stringBuilder.Append("<ship_tel><![CDATA[" + order.Tel + "]]></ship_tel>");
			stringBuilder.Append("<ship_mobile><![CDATA[" + order.Mobile + "]]></ship_mobile>");
			stringBuilder.Append("<ship_zip><![CDATA[" + order.Postalcode + "]]></ship_zip>");
			stringBuilder.Append("</data>");
			return string.Concat(new string[]
			{
				"xml=",
				HttpUtility.HtmlEncode(express.hidden),
				"&data=",
				stringBuilder.ToString(),
				"&bg=",
				express.imgPath,
				"&copyright=ecshop"
			});
		}
	}
}
