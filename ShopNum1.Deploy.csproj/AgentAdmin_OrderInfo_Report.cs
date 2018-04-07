using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AgentAdmin_OrderInfo_Report : PageBase, IRequiresSessionState
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
		if (!this.Page.IsPostBack)
		{
			if (this.Page.Request.QueryString["type"] == null)
			{
				if (this.Page.Request["OrderNumber"] != null)
				{
					base.Response.Buffer = true;
					base.Response.Clear();
					base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
					base.Response.ContentType = "text/HTML";
					base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"OrderInfoReport_" + DateTime.Now.ToString("yyyymmddhhmm") + ".html\"");
					this.method_5();
					base.Response.Flush();
					base.Response.Close();
					base.Response.End();
				}
				else
				{
					base.Response.Write("访问缺少'OrderNumber'编号");
				}
			}
			else if (this.Page.Request["OrderNumber"] != null)
			{
				base.Response.Buffer = true;
				base.Response.Clear();
				base.Response.Charset = "utf-8";
				base.Response.ContentEncoding = Encoding.GetEncoding(0);
				base.Response.ContentType = "Application/ms-excel";
				base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"OrderInfoReport_" + DateTime.Now.ToString("yyyymmddhhmm") + ".xls\"");
				this.method_5();
				base.Response.Flush();
				base.Response.Close();
				base.Response.End();
			}
			else
			{
				base.Response.Write("访问缺少'OrderNumber'编号");
			}
		}
	}
	private void method_5()
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = new ShopNum1_OrderInfo_Action();
		DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrder(this.Page.Request["OrderNumber"]);
		base.Response.Write("<Tr>");
		base.Response.Write("<Tr><td align=\"center\"><h1>订单详细</h1></td></Tr>");
		base.Response.Write("</Tr>");
		base.Response.Write("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
		if (dataTable.Rows.Count > 0)
		{
			base.Response.Write("<tr>");
			base.Response.Write(" <td width=\"2%\">订单号:</td>");
			base.Response.Write("<td width=\"2%\"> {OrderNumber}</td>".Replace("{OrderNumber}", dataTable.Rows[0]["OrderNumber"].ToString()));
			base.Response.Write(" <td width=\"7%\">买家:</td>");
			base.Response.Write("<td width=\"12%\"> {memloginID}</td>".Replace("{memloginID}", dataTable.Rows[0]["memloginID"].ToString()));
			base.Response.Write(" <td width=\"8%\">下单时间:</td>");
			base.Response.Write("<td width=\"14%\"> {createtime}</td>".Replace("{createtime}", dataTable.Rows[0]["createtime"].ToString()));
			base.Response.Write(" <td width=\"8%\">支付方式:</td>");
			base.Response.Write("<td width=\"10%\" TextMode=\"SingleLine\"> {PaymentName}</td>".Replace("{PaymentName}", dataTable.Rows[0]["PaymentName"].ToString()));
			base.Response.Write("</tr>");
			base.Response.Write("<tr>");
			base.Response.Write(" <td width=\"7%\">付款时间:</td>");
			base.Response.Write("<td width=\"12%\"> {PayTime}</td>".Replace("{PayTime}", dataTable.Rows[0]["PayTime"].ToString()));
			base.Response.Write("</tr>");
			base.Response.Write("<tr>");
			base.Response.Write(" <td width=\"3%\">发票类型:</td>");
			base.Response.Write("<td width=\"7%\"> {InvoiceType}</td>".Replace("{InvoiceType}", dataTable.Rows[0]["InvoiceType"].ToString()));
			base.Response.Write(" <td width=\"7%\">发票抬头:</td>");
			base.Response.Write("<td width=\"7%\"> {InvoiceTitle}</td>".Replace("{InvoiceTitle}", dataTable.Rows[0]["InvoiceTitle"].ToString()));
			base.Response.Write(" <td width=\"7%\">发票内容:</td>");
			base.Response.Write("<td  width=\"7%\"> {InvoiceContent}</td>".Replace("{InvoiceContent}", dataTable.Rows[0]["InvoiceContent"].ToString()));
			base.Response.Write(" <td width=\"13%\">客户给商家的留言:</td>");
			base.Response.Write("<td colspan=\"3\" width=\"5%\"> {ClientToSellerMsg}</td>".Replace("{ClientToSellerMsg}", dataTable.Rows[0]["ClientToSellerMsg"].ToString()));
			base.Response.Write("</tr>");
			base.Response.Write("<tr>");
			base.Response.Write(" <td width=\"12%\">商家给客户的留言:</td>");
			base.Response.Write("<td colspan=\"3\"> {SellerToClientMsg}</td>".Replace("{SellerToClientMsg}", dataTable.Rows[0]["SellerToClientMsg"].ToString()));
			base.Response.Write("</tr>");
			base.Response.Write("<tr>");
			base.Response.Write(" <td width=\"7%\">收货人:</td>");
			base.Response.Write("<td width=\"7%\"> {Name}</td>".Replace("{Name}", dataTable.Rows[0]["Name"].ToString()));
			base.Response.Write(" <td width=\"7%\">电子邮件:</td>");
			base.Response.Write("<td width=\"7%\"> {Email}</td>".Replace("{Email}", dataTable.Rows[0]["Email"].ToString()));
			base.Response.Write(" <td width=\"7%\">地址:</td>");
			base.Response.Write("<td width=\"7%\"> {Address}</td>".Replace("{Address}", dataTable.Rows[0]["Address"].ToString()));
			base.Response.Write(" <td width=\"7%\">邮编:</td>");
			base.Response.Write("<td width=\"7%\"> {Postalcode}</td>".Replace("{Postalcode}", dataTable.Rows[0]["Postalcode"].ToString()));
			base.Response.Write(" <td width=\"7%\">电话(手机):</td>");
			base.Response.Write("<td width=\"7%\"> {Tel}</td>".Replace("{Tel}", dataTable.Rows[0]["Tel"].ToString()));
			base.Response.Write("<td width=\"3%\"> ({Mobile})</td>".Replace("{Mobile}", dataTable.Rows[0]["Mobile"].ToString()));
			base.Response.Write("</tr>");
			base.Response.Write("</table>");
			base.Response.Write("</td>");
			base.Response.Write("</Tr>");
			DataTable dataTable2 = shopNum1_OrderInfo_Action.SearchOrder(this.Page.Request["OrderNumber"].ToString());
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			DataTable dataTable3 = shopNum1_OrderProduct_Action.Search(dataTable2.Rows[0]["Guid"].ToString());
			if (dataTable3 != null && dataTable3.Rows.Count > 0)
			{
				base.Response.Write("<Tr>");
				base.Response.Write("<td>");
				base.Response.Write("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" bgcolor=\"#666666\">");
				base.Response.Write("<tr align=\"center\" >");
				base.Response.Write("<td  bgcolor=\"#CCCCCC\" height=\"30\">商品名称</td>");
				base.Response.Write("<td bgcolor=\"#CCCCCC\">货号</td>");
				base.Response.Write("<td bgcolor=\"#CCCCCC\">购买价格</td>");
				base.Response.Write("<td bgcolor=\"#CCCCCC\">购买数量</td>");
				base.Response.Write("<td bgcolor=\"#CCCCCC\">小计</td>");
				base.Response.Write("</tr>");
				decimal d = Convert.ToDecimal(0.0);
				for (int i = 0; i < dataTable3.Rows.Count; i++)
				{
					base.Response.Write("<tr align=\"center\">");
					base.Response.Write("<td bgcolor=\"#ffffff\" height=\"20\"> {Name}</td>".Replace("{Name}", dataTable3.Rows[i]["Name"].ToString()));
					base.Response.Write("<td bgcolor=\"#ffffff\"> {RepertoryNumber}</td>".Replace("{RepertoryNumber}", dataTable3.Rows[i]["RepertoryNumber"].ToString()));
					base.Response.Write("<td bgcolor=\"#ffffff\"> {BuyPrice}</td>".Replace("{BuyPrice}", dataTable3.Rows[i]["BuyPrice"].ToString()));
					base.Response.Write("<td bgcolor=\"#ffffff\"> {BuyNumber}</td>".Replace("{BuyNumber}", dataTable3.Rows[i]["BuyNumber"].ToString()));
					decimal d2 = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()) * Convert.ToDecimal(dataTable3.Rows[i]["BuyNumber"].ToString());
					d += d2;
					base.Response.Write("<td bgcolor=\"#ffffff\"> {decimalCount}</td>".Replace("{decimalCount}", d2.ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table >");
				base.Response.Write("</td >");
				base.Response.Write("</Tr >");
				base.Response.Write("<Tr>");
				base.Response.Write(" <td Align=\"right\">商名总金额:</td>");
				base.Response.Write("{decimalAllCount}".Replace("{decimalAllCount}", d.ToString()));
				base.Response.Write(" +发票税额:");
				base.Response.Write("{InvoiceTax}".Replace("{InvoiceTax}", dataTable.Rows[0]["InvoiceTax"].ToString()));
				base.Response.Write(" +配送费用:");
				base.Response.Write("{DispatchPrice}".Replace("{DispatchPrice}", dataTable.Rows[0]["DispatchPrice"].ToString()));
				base.Response.Write(" +支付费用:");
				base.Response.Write("{PaymentPrice}".Replace("{PaymentPrice}", dataTable.Rows[0]["PaymentPrice"].ToString()));
				base.Response.Write("<br/>");
				base.Response.Write(" <td>订单总金额:</td>");
				decimal d3 = d - Convert.ToDecimal(dataTable.Rows[0]["InvoiceTax"].ToString()) + Convert.ToDecimal(dataTable.Rows[0]["DispatchPrice"].ToString()) + Convert.ToDecimal(dataTable.Rows[0]["PaymentPrice"].ToString());
				base.Response.Write("{decimalOrderAllFee}".Replace("{decimalOrderAllFee}", d3.ToString()));
				base.Response.Write(" -已付款金额:");
				base.Response.Write("{AlreadPayPrice}".Replace("{AlreadPayPrice}", dataTable.Rows[0]["AlreadPayPrice"].ToString()));
				base.Response.Write("<br/>");
				base.Response.Write(" 应付款金额:");
				decimal num = d3 - Convert.ToDecimal(dataTable.Rows[0]["AlreadPayPrice"].ToString()) - Convert.ToDecimal(dataTable.Rows[0]["SurplusPrice"].ToString()) - Convert.ToDecimal(dataTable.Rows[0]["ScorePrice"].ToString());
				base.Response.Write("{decimalShouldPayFee}".Replace("{decimalShouldPayFee}", num.ToString()));
				base.Response.Write("</td>");
				base.Response.Write("</tr>");
				base.Response.Write("<tr>");
				base.Response.Write("<td>&nbsp;</td>");
				base.Response.Write("</tr>");
				base.Response.Write("</table>");
			}
		}
	}
}
