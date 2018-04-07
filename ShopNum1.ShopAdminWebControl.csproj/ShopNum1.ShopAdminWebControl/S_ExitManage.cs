using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ExitManage : BaseShopWebControl
	{
		private string string_0 = "S_ExitManage.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_ExitManage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("repExitMoney");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			if (!this.Page.IsPostBack)
			{
				this.method_1();
			}
		}
		private string method_0()
		{
			StringBuilder stringBuilder = new StringBuilder(" and shopid='" + this.MemLoginID + "' And refundtype=0 ");
			string str = ShopNum1.Common.Common.ReqStr("rid");
			string str2 = ShopNum1.Common.Common.ReqStr("oid");
			string str3 = ShopNum1.Common.Common.ReqStr("sid");
			string a = ShopNum1.Common.Common.ReqStr("type");
			if (a == "" || a == "1")
			{
				stringBuilder.Append(" and refundstatus>0");
			}
			else
			{
				stringBuilder.Append(" and refundstatus=0");
			}
			if (ShopNum1.Common.Common.ReqStr("rid") != "")
			{
				stringBuilder.Append(" and refundid='" + str + "'");
			}
			if (ShopNum1.Common.Common.ReqStr("oid") != "")
			{
				stringBuilder.Append(" and ordernumber='" + str2 + "'");
			}
			if (ShopNum1.Common.Common.ReqStr("sid") != "")
			{
				stringBuilder.Append(" and shopid='" + str3 + "'");
			}
			return stringBuilder.ToString();
		}
		private void method_1()
		{
			ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shopNum1_Refund_Action.SelectRefundList(this.PageSize.ToString(), pageID.ToString(), this.method_0(), "3");
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/shopadmin/S_ExitManage.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			DataTable dataTable2 = shopNum1_Refund_Action.SelectRefundList(this.PageSize.ToString(), pageID.ToString(), this.method_0(), "2");
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
		public static string RefundStatus(string status, string rtype)
		{
			string text = "退款";
			string result;
			if (status != null)
			{
				if (status == "0")
				{
					result = text + "申请等待卖家确认中";
					return result;
				}
				if (status == "1")
				{
					result = text + "成功";
					return result;
				}
				if (status == "2")
				{
					result = "卖家拒绝" + text;
					return result;
				}
				if (status == "3")
				{
					result = "平台介入" + text + "成功";
					return result;
				}
			}
			result = "";
			return result;
		}
		public static string ReasonType(string rtype)
		{
			string result;
			switch (rtype)
			{
			case "1":
				result = "七天无理由退换货";
				return result;
			case "2":
				result = "收到假货";
				return result;
			case "3":
				result = "退运费";
				return result;
			case "4":
				result = "收到商品破损";
				return result;
			case "5":
				result = "协商一致退货";
				return result;
			case "6":
				result = "商品错发/漏发";
				return result;
			case "7":
				result = "商品需要维修";
				return result;
			case "8":
				result = "发票问题";
				return result;
			case "9":
				result = "收到商品与描述不符";
				return result;
			case "10":
				result = "商品质量问题";
				return result;
			case "11":
				result = "未按约定时间发货";
				return result;
			}
			result = "";
			return result;
		}
	}
}
