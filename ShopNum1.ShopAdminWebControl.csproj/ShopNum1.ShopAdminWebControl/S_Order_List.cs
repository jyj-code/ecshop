using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Order_List : BaseShopWebControl
	{
		private string string_0 = "S_Order_List.ascx";
		public static DataTable dt_OrderList = null;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private LinkButton linkButton_0;
		private HtmlInputHidden htmlInputHidden_0;
		private Label label_0;
		private Label label_1;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_Order_List()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("lbTotalOrder");
			this.label_1 = (Label)skin.FindControl("lbTotalMoney");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv1");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("pageDiv2");
			this.linkButton_0 = (LinkButton)skin.FindControl("btnSub");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidOrderGuId");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_2();
			}
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			shopNum1_OrderInfo_Action.SetOderStatus1(this.htmlInputHidden_0.Value, 1, 1, 0, DateTime.Now);
			ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
			shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
			{
				Guid = Guid.NewGuid(),
				OrderInfoGuid = new Guid(this.htmlInputHidden_0.Value),
				CreateUser = this.MemLoginID,
				OderStatus = 1,
				ShipmentStatus = 0,
				PaymentStatus = 1,
				CurrentStateMsg = "卖家已确认订单",
				NextStateMsg = "等待卖家发货",
				Memo = "",
				OperateDateTime = DateTime.Now,
				IsDeleted = 0
			});
			this.method_2();
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("sign") == "del" && ShopNum1.Common.Common.ReqStr("del") != "")
			{
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				shopNum1_OrderInfo_Action.DeleteOrderInfoByOrdernum(ShopNum1.Common.Common.ReqStr("del"), 0, this.MemLoginID);
			}
		}
		private string method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" and shopid='" + this.MemLoginID + "' and BuyIsDeleted=0 and feetype!=2");
			string text = ShopNum1.Common.Common.ReqStr("ord");
			string text2 = ShopNum1.Common.Common.ReqStr("sd");
			string text3 = ShopNum1.Common.Common.ReqStr("ed");
			string text4 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("mid"));
			string text5 = ShopNum1.Common.Common.ReqStr("ostate");
			string text6 = ShopNum1.Common.Common.ReqStr("sstate");
			string a = ShopNum1.Common.Common.ReqStr("pstate");
			string a2 = ShopNum1.Common.Common.ReqStr("quit");
			if (text != "")
			{
				stringBuilder.Append(" and ordernumber='" + text + "'");
			}
			if (text2 != "")
			{
				stringBuilder.Append(" and createtime>='" + text2 + "'");
			}
			if (text3 != "")
			{
				stringBuilder.Append(" and createtime<='" + text3 + "'");
			}
			if (text4 != "")
			{
				stringBuilder.Append(" and memloginid like '%" + text4 + "%'");
			}
			if (a2 != "")
			{
				stringBuilder.Append(" and oderstatus>3");
			}
			else if (ShopNum1.Common.Common.ReqStr("stype") != "0" && ShopNum1.Common.Common.ReqStr("stype") != "" && text5 != "")
			{
				if (text6 == "4")
				{
					stringBuilder.Append(" and shipmentstatus=4 ");
				}
				else if (a == "3")
				{
					stringBuilder.Append(" and paymentstatus=3 ");
				}
				else if (text5 == "1")
				{
					stringBuilder.Append(" and oderstatus=1 ");
				}
				else if (ShopNum1.Common.Common.ReqStr("iscomment") == "0")
				{
					stringBuilder.Append(" and  oderstatus=" + text5 + " and IsBuyComment=0");
				}
				else if (text6 != "")
				{
					stringBuilder.Append(" and oderstatus=" + text5);
				}
				else
				{
					stringBuilder.Append(" and shipmentstatus=" + text6 + " and oderstatus=" + text5);
				}
			}
			return stringBuilder.ToString();
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
				result = "交易成功";
				return result;
			case "4":
				result = "订单关闭";
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
		public static string setOrderState(string strState)
		{
			string result;
			switch (strState)
			{
			case "0":
				result = "等待买家付款";
				return result;
			case "1":
				result = "等待卖家发货";
				return result;
			case "2":
				result = "等待买家确认收货";
				return result;
			case "3":
				result = "交易成功";
				return result;
			case "4":
				result = "订单关闭";
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
			switch (strState)
			{
			case "0":
				result = "未发货";
				return result;
			case "1":
				result = "已发货";
				return result;
			case "2":
				result = "已收货";
				return result;
			case "3":
				result = "已退货";
				return result;
			case "4":
				result = "退货成功";
				return result;
			case "5":
				result = "卖家拒绝退货";
				return result;
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
					result = "已退款";
					return result;
				}
				if (strState == "3")
				{
					result = "退款成功";
					return result;
				}
				if (strState == "4")
				{
					result = "卖家拒绝退款";
					return result;
				}
			}
			result = "非法状态";
			return result;
		}
		private void method_2()
		{
			this.label_0.Text = "订单总数 : " + DatabaseExcetue.ReturnString("select count(*) from ShopNum1_OrderInfo group by ShopID having ShopID='" + this.MemLoginID + "'");
			this.label_1.Text = "销售总金额 : " + DatabaseExcetue.ReturnString("select sum(ShouldPayPrice) from ShopNum1_OrderInfo where ShopID='" + this.MemLoginID + "'");
			this.label_0.ForeColor = Color.Red;
			this.label_1.ForeColor = Color.Red;
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			int num = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				num = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shopNum1_OrderInfo_Action.SelectOrderList(this.PageSize.ToString(), num.ToString(), this.method_1(), "3", HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pn")));
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_Order_List.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = num;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			this.htmlGenericControl_1.InnerHtml = pageListBll.GetPageListNew(pageList);
			pageList.PageCount = pageList.RecordCount / pageList.PageSize;
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (num > pageList.PageCount)
			{
				num = pageList.PageCount;
			}
			S_Order_List.dt_OrderList = shopNum1_OrderInfo_Action.SelectOrderList(this.PageSize.ToString(), num.ToString(), this.method_1(), "2", HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pn")));
			if (S_Order_List.dt_OrderList.Rows.Count == 0)
			{
				S_Order_List.dt_OrderList = null;
			}
		}
		public static DataTable dt_GetOrderProduct(string OrderGuId)
		{
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			return shopNum1_OrderProduct_Action.SelectOrderProductByGuIdorAll(OrderGuId, HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pn")));
		}
	}
}
