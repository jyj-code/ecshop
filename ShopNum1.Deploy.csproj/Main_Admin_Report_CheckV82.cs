using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.ShopLocalization;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class Main_Admin_Report_CheckV82 : Page, IRequiresSessionState
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
		if (base.Request.Cookies["AdminLoginCookie"] == null)
		{
			base.Response.Write("<script type=\"text/javascript\">window.top.location.href='Login.aspx';</script>");
		}
		else if (!this.Page.IsPostBack)
		{
			base.Response.Clear();
			if (base.Request.QueryString["Type"] != null)
			{
				string text = base.Request.QueryString["Type"].ToString();
				if (text == "xls")
				{
					base.Response.ContentType = "Application/ms-excel";
					base.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
				}
				else
				{
					base.Response.ContentType = "text/HTML";
					base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
				}
				base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
				{
					"attachment;filename=\"MoneyReport_",
					DateTime.Now.ToString("yyyymmddhhmm"),
					".",
					text,
					"\""
				}));
				this.method_0();
				Thread.Sleep(100);
				base.Response.Flush();
				base.Response.Close();
				base.Response.End();
			}
		}
	}
	private void method_0()
	{
		HttpCookie cookie = base.Request.Cookies["MoneyReportCookie"];
		HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
		string orderNumber = httpCookie.Values["OrderNumber"].ToString();
		string text = httpCookie.Values["MemLoginID"].ToString();
		string a = httpCookie.Values["reportType"].ToString();
		if (a == "1")
		{
			string text2 = httpCookie.Values["State"].ToString();
			text2 = ((text2 == "") ? "-1" : text2);
			string date = httpCookie.Values["Sdate"].ToString();
			string date2 = httpCookie.Values["Edate"].ToString();
			ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
			DataTable dataTable = shopNum1_AdvancePaymentApplyLog_Action.Search(text, date, date2, 1, Convert.ToInt32(text2), 0);
			if (dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">充值单号</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >会员名</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >操作日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >当前预存款</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >充值方式</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >状态</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", dataTable.Rows[i]["OrderNumber"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", "&nbsp;" + dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Date}</td>".Replace("{Date}", dataTable.Rows[i]["Date"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {CurrentAdvancePayment}</td>".Replace("{CurrentAdvancePayment}", dataTable.Rows[i]["CurrentAdvancePayment"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateMoney}</td>".Replace("{OperateMoney}", dataTable.Rows[i]["OperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {PaymentName}</td>".Replace("{PaymentName}", dataTable.Rows[i]["PaymentName"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateStatus}</td>".Replace("{OperateStatus}", this.ChangeOperateStatus(dataTable.Rows[i]["OperateStatus"].ToString())));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
		else if (a == "2")
		{
			string text2 = httpCookie.Values["State"].ToString();
			text2 = ((text2 == "") ? "-1" : text2);
			string date = httpCookie.Values["Sdate"].ToString();
			string date2 = httpCookie.Values["Edate"].ToString();
			ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
			DataTable dataTable = shopNum1_AdvancePaymentApplyLog_Action.Search(text, date, date2, 0, Convert.ToInt32(text2), 0);
			if (dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">提现单号</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >会员名</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >操作日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >当前预存款</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >状态</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", dataTable.Rows[i]["OrderNumber"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Date}</td>".Replace("{Date}", dataTable.Rows[i]["Date"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {CurrentAdvancePayment}</td>".Replace("{CurrentAdvancePayment}", dataTable.Rows[i]["CurrentAdvancePayment"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateMoney}</td>".Replace("{OperateMoney}", dataTable.Rows[i]["OperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateStatus}</td>".Replace("{OperateStatus}", this.ChangeOperateStatus(dataTable.Rows[i]["OperateStatus"].ToString())));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
		else if (a == "3")
		{
			string text2 = httpCookie.Values["State"].ToString();
			string arg_6BB_0 = (text2 == "") ? "-1" : text2;
			string date = httpCookie.Values["Sdate"].ToString();
			string date2 = httpCookie.Values["Edate"].ToString();
			string getMemLoginID = httpCookie.Values["Edate"].ToString();
			base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			ShopNum1_PreTransfer_Action shopNum1_PreTransfer_Action = (ShopNum1_PreTransfer_Action)LogicFactory.CreateShopNum1_PreTransfer_Action();
			DataTable dataTable = shopNum1_PreTransfer_Action.Search(orderNumber, text, getMemLoginID, date, date2, 0);
			if (dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">转账单号</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >转账会员ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >转账金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收款人ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >备注</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", dataTable.Rows[i]["OrderNumber"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateMoney}</td>".Replace("{OperateMoney}", dataTable.Rows[i]["OperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {RMemberID}</td>".Replace("{RMemberID}", dataTable.Rows[i]["RMemberID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Date}</td>".Replace("{Date}", dataTable.Rows[i]["Date"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Memo}</td>".Replace("{Memo}", dataTable.Rows[i]["Memo"].ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
		else if (a == "4")
		{
			string value = "-1";
			string date = "";
			string date2 = "";
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			DataTable dataTable = shopNum1_AdvancePaymentModifyLog_Action.Search(text, date, date2, Convert.ToInt32(value), 0);
			if (dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">会员ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >变更日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >变更类型</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >当前预存款</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >变更金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >变更后金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >备注</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Date}</td>".Replace("{Date}", dataTable.Rows[i]["Date"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateType}</td>".Replace("{OperateType}", this.ChangeOperateType(dataTable.Rows[i]["OperateType"].ToString())));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {CurrentAdvancePayment}</td>".Replace("{CurrentAdvancePayment}", dataTable.Rows[i]["CurrentAdvancePayment"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateMoney}</td>".Replace("{OperateMoney}", dataTable.Rows[i]["OperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {LastOperateMoney}</td>".Replace("{LastOperateMoney}", dataTable.Rows[i]["LastOperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Memo}</td>".Replace("{Memo}", dataTable.Rows[i]["Memo"].ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
		else if (a == "5")
		{
			string value = "-1";
			string date = "";
			string date2 = "";
			ShopNum1_AdvancePaymentFreezeLog_Action shopNum1_AdvancePaymentFreezeLog_Action = (ShopNum1_AdvancePaymentFreezeLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentFreezeLog_Action();
			DataTable dataTable = shopNum1_AdvancePaymentFreezeLog_Action.Search(text, date, date2, Convert.ToInt32(value), 0);
			if (dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">会员ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >变更日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >变更类型</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >当前冻结预存款</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >冻结|解冻金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >冻结|解冻后金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >备注</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Date}</td>".Replace("{Date}", dataTable.Rows[i]["Date"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateType}</td>".Replace("{OperateType}", this.ChangeOperateTypeNew(dataTable.Rows[i]["OperateType"].ToString())));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {CurrentAdvancePayment}</td>".Replace("{CurrentAdvancePayment}", dataTable.Rows[i]["CurrentAdvancePayment"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OperateMoney}</td>".Replace("{OperateMoney}", dataTable.Rows[i]["OperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {LastOperateMoney}</td>".Replace("{LastOperateMoney}", dataTable.Rows[i]["LastOperateMoney"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Memo}</td>".Replace("{Memo}", dataTable.Rows[i]["Memo"].ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
		else if (a == "6")
		{
			string date = httpCookie.Values["Sdate"].ToString();
			string date2 = httpCookie.Values["Edate"].ToString();
			string getMemLoginID = httpCookie.Values["Edate"].ToString();
			string shopname = httpCookie.Values["shopname"].ToString();
			ShopNum1_Report_Action shopNum1_Report_Action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
			DataTable dataTable = shopNum1_Report_Action.SearchShopDailysales(text, date, date2, shopname);
			if (dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">店铺名称</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >交易日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺名称</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺日收入</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {memloginid}</td>".Replace("{memloginid}", dataTable.Rows[i]["memloginid"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {date}</td>".Replace("{date}", dataTable.Rows[i]["date"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {shopname}</td>".Replace("{shopname}", dataTable.Rows[i]["shopname"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {moneycount}</td>".Replace("{moneycount}", dataTable.Rows[i]["moneycount"].ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
		else if (a == "7")
		{
			base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(DatabaseExcetue.GetConnstring());
			List<ShopNum1_ThreePaymentRecord> list = dataClassesDataContext.ShopNum1_ThreePaymentRecord.ToList<ShopNum1_ThreePaymentRecord>();
			if (list.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单编号</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >支付方式</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >支付类型</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >支付金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >支付完成时间</td>");
				base.Response.Write("</tr>");
				for (int i = 0; i < list.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", list[i].OrderNumber.ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {PayTypeName}</td>".Replace("{PayTypeName}", list[i].PayTypeName.ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {PayTypeCode}</td>".Replace("{PayTypeCode}", list[i].PayTypeCode.ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {PayMoney}</td>".Replace("{PayMoney}", list[i].PayMoney.ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {HasPayTime}</td>".Replace("{HasPayTime}", list[i].HasPayTime.ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
		}
	}
	public string ChangeOperateType(string operateType)
	{
		string result;
		if (operateType == "0")
		{
			result = "后台提取";
		}
		else if (operateType == "1")
		{
			result = "后台充值";
		}
		else if (operateType == "2")
		{
			result = "会员自助提取";
		}
		else if (operateType == "3")
		{
			result = "会员自助充值";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeOperateTypeNew(string operateType)
	{
		string result;
		if (operateType == "0")
		{
			result = LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "0");
		}
		else if (operateType == "1")
		{
			result = LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "1");
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeOperateStatus(string operateStatus)
	{
		string result;
		if (operateStatus == "0")
		{
			result = "未确认";
		}
		else if (operateStatus == "1")
		{
			result = "已完成";
		}
		else
		{
			result = "已拒绝";
		}
		return result;
	}
}
