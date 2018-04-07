using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_PrintOrder : BaseShopWebControl
	{
		private string string_0 = "S_PrintOrder.ascx";
		public static DataTable dt_OrderInfo = null;
		private DataTable dataTable_0 = null;
		public static string ShopName = null;
		public static string ShopId = null;
		public static string Name = null;
		public static string Tel = null;
		public static string Mobile = null;
		public static string Address = null;
		public static string PostCode = null;
		public static string OrderNumber = null;
		public static string CreateTime = null;
		public static string ShipmentNumber = null;
		public static string TotalPrice = null;
		public static string DispatchPrice = null;
		public static string Email = null;
		public static string ShopMobile = null;
		public static string Logisticscompany = null;
		public static string PaymentPrice = null;
		public S_PrintOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string strOrderGuId = ShopNum1.Common.Common.ReqStr("guid");
			string strOrderType = ShopNum1.Common.Common.ReqStr("ordertype");
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataSet orderDetail = shopNum1_OrderInfo_Action.GetOrderDetail(strOrderGuId, this.MemLoginID, strOrderType, "1");
			if (orderDetail != null && orderDetail.Tables.Count == 4)
			{
				S_PrintOrder.dt_OrderInfo = orderDetail.Tables[0];
				if (S_PrintOrder.dt_OrderInfo.Rows.Count != 0)
				{
					int index = 0;
					int i = 0;
					while (i < S_PrintOrder.dt_OrderInfo.Rows.Count)
					{
						if (!(S_PrintOrder.dt_OrderInfo.Rows[i]["ordernumber"].ToString() != ""))
						{
							i++;
						}
						else
						{
							index = i;
							IL_D9:
							DataRow dataRow = S_PrintOrder.dt_OrderInfo.Rows[index];
							S_PrintOrder.ShopName = dataRow["ShopName"].ToString();
							S_PrintOrder.ShopId = dataRow["ShopId"].ToString();
							S_PrintOrder.Name = dataRow["name"].ToString();
							S_PrintOrder.Tel = dataRow["tel"].ToString();
							S_PrintOrder.Mobile = dataRow["Mobile"].ToString();
							S_PrintOrder.Address = dataRow["Address"].ToString();
							S_PrintOrder.PostCode = dataRow["postalcode"].ToString();
							S_PrintOrder.OrderNumber = dataRow["OrderNumber"].ToString();
							S_PrintOrder.CreateTime = dataRow["CreateTime"].ToString();
							S_PrintOrder.ShipmentNumber = dataRow["shipmentnumber"].ToString();
							S_PrintOrder.TotalPrice = dataRow["shouldpayprice"].ToString();
							S_PrintOrder.DispatchPrice = dataRow["DispatchPrice"].ToString();
							S_PrintOrder.Logisticscompany = dataRow["Logisticscompany"].ToString();
							S_PrintOrder.PaymentPrice = dataRow["PaymentPrice"].ToString();
							this.dataTable_0 = orderDetail.Tables[3];
							if (this.dataTable_0.Rows.Count == 0)
							{
								this.dataTable_0 = null;
								return;
							}
							S_PrintOrder.Email = this.dataTable_0.Rows[0]["Email"].ToString();
							S_PrintOrder.ShopMobile = this.dataTable_0.Rows[0]["Mobile"].ToString();
							return;
						}
					}
                    //goto IL_D9;
				}
				S_PrintOrder.dt_OrderInfo = null;
			}
		}
	}
}
