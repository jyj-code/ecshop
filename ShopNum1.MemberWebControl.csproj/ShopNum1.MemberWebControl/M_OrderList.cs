using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_OrderList : BaseMemberWebControl
	{
		private string string_0 = "M_OrderList.ascx";
		public static DataTable dt_OrderList = null;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public M_OrderList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv1");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("pageDiv2");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_2();
			}
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("sign") == "del" && ShopNum1.Common.Common.ReqStr("del") != "")
			{
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				shopNum1_OrderInfo_Action.DeleteOrderInfoByOrdernum(ShopNum1.Common.Common.ReqStr("del"), 1, this.MemLoginID);
			}
		}
		private string method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" and memloginId='" + this.MemLoginID + "' and BuyIsDeleted=0 and feetype!=2");
			string text = ShopNum1.Common.Common.ReqStr("st");
			string text2 = text;
			if (text2 != null)
			{
				if (!(text2 == "0"))
				{
					if (!(text2 == "1"))
					{
						if (!(text2 == "2"))
						{
							if (!(text2 == "3"))
							{
								if (text2 == "4")
								{
									stringBuilder.Append(" and oderstatus>3 ");
								}
							}
							else
							{
								stringBuilder.Append(" and oderstatus='" + text + "'");
							}
						}
						else
						{
							stringBuilder.Append(" and oderstatus='" + text + "'");
						}
					}
					else
					{
						stringBuilder.Append(" and oderstatus='" + text + "'");
					}
				}
				else
				{
					stringBuilder.Append(" and oderstatus='" + text + "'");
				}
			}
			string text3 = ShopNum1.Common.Common.ReqStr("ord");
			string text4 = ShopNum1.Common.Common.ReqStr("sd");
			string text5 = ShopNum1.Common.Common.ReqStr("ed");
			string text6 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("sn"));
			if (text3 != "")
			{
				stringBuilder.Append(" and ordernumber='" + text3 + "'");
			}
			if (text4 != "")
			{
				stringBuilder.Append(" and createtime>='" + text4 + "'");
			}
			if (text5 != "")
			{
				stringBuilder.Append(" and createtime<='" + text5 + "'");
			}
			if (text6 != "")
			{
				stringBuilder.Append(" and shopname like '%" + text6 + "%'");
			}
			return stringBuilder.ToString();
		}
		private void method_2()
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shopNum1_OrderInfo_Action.SelectOrderList(this.PageSize.ToString(), pageID.ToString(), this.method_1(), "3", HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pn")));
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("main/member/M_OrderList.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			this.htmlGenericControl_1.InnerHtml = pageListBll.GetPageListNew(pageList);
			M_OrderList.dt_OrderList = shopNum1_OrderInfo_Action.SelectOrderList(this.PageSize.ToString(), pageID.ToString(), this.method_1(), "2", HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pn")));
			if (M_OrderList.dt_OrderList.Rows.Count == 0)
			{
				M_OrderList.dt_OrderList = null;
			}
		}
		public static DataTable dt_GetOrderProduct(string OrderGuId)
		{
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			return shopNum1_OrderProduct_Action.SelectOrderProductByGuIdorAll(OrderGuId, HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pn")));
		}
		public static string setOrderState(string strState, string paymentstatus, string refundstatus)
		{
			string result;
			switch (strState)
			{
			case "0":
				result = "等待买家付款";
				return result;
			case "1":
				if (paymentstatus == "2" && refundstatus == "1")
				{
					result = "等待卖家处理退款";
					return result;
				}
				result = "等待卖家发货";
				return result;
			case "2":
				if (paymentstatus == "1" && refundstatus == "1")
				{
					result = "等待卖家处理退货";
					return result;
				}
				result = "等待买家确认收货";
				return result;
			case "3":
				result = "<font color=\"green\">交易成功</font>";
				return result;
			case "4":
				result = "系统订单关闭";
				return result;
			case "5":
				result = "卖家关闭订单";
				return result;
			case "6":
				result = "买家关闭订单";
				return result;
			}
			result = "非法状态";
			return result;
		}
		public static string setShipmentState(string strState)
		{
			string result;
			if (strState != null)
			{
				if (strState == "0")
				{
					result = "未发货";
					return result;
				}
				if (strState == "1")
				{
					result = "已发货";
					return result;
				}
				if (strState == "2")
				{
					result = "已收货";
					return result;
				}
				if (strState == "3")
				{
					result = "退货";
					return result;
				}
			}
			result = "非法状态";
			return result;
		}
		public static string setPaymentState(string strState)
		{
			string result;
			if (strState != null)
			{
				if (strState == "0")
				{
					result = "未付款";
					return result;
				}
				if (strState == "1")
				{
					result = "已付款";
					return result;
				}
				if (strState == "2")
				{
					result = "退款成功";
					return result;
				}
				if (strState == "3")
				{
					result = "卖家拒绝退款";
					return result;
				}
			}
			result = "非法状态";
			return result;
		}
	}
}
