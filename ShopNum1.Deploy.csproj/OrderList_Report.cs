using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class OrderList_Report : PageBase, IRequiresSessionState
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
					base.Response.ContentEncoding = Encoding.UTF8;
				}
				else
				{
					base.Response.ContentType = "text/HTML";
					base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
				}
				base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
				{
					"attachment;filename=\"OrderListReport_",
					DateTime.Now.ToString("yyyymmddhhmm"),
					".",
					text,
					"\""
				}));
				this.method_5();
				Thread.Sleep(100);
				base.Response.Flush();
				base.Response.Close();
				base.Response.End();
			}
		}
	}
	private void method_5()
	{
		try
		{
			HttpCookie cookie = base.Request.Cookies["OrderListReportCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			string orderNumber = httpCookie.Values["OrderNumber"].ToString();
			string memLoginID = httpCookie.Values["MemLoginID"].ToString();
			string address = httpCookie.Values["Address"].ToString();
			string postalcode = httpCookie.Values["Postalcode"].ToString();
			string mobile = httpCookie.Values["Mobile"].ToString();
			string email = httpCookie.Values["Email"].ToString();
			string string_ = httpCookie.Values["Tel"].ToString();
			string name = httpCookie.Values["Name"].ToString();
			string shopID = httpCookie.Values["ShopID"].ToString();
			string shopName = httpCookie.Values["ShopName"].ToString();
			string orderStatus = httpCookie.Values["orderStatus"].ToString();
			decimal shouldPayPrice = 0m;
			decimal shouldPayPrice2 = 0m;
			if (httpCookie.Values["ShouldPayPrice1"].ToString() != string.Empty)
			{
				shouldPayPrice = Convert.ToDecimal(httpCookie.Values["ShouldPayPrice1"].ToString());
			}
			if (httpCookie.Values["ShouldPayPrice2"].ToString() != string.Empty)
			{
				shouldPayPrice2 = Convert.ToDecimal(httpCookie.Values["ShouldPayPrice2"].ToString());
			}
			string createTime = httpCookie.Values["CreateTime1"].ToString();
			string createTime2 = httpCookie.Values["CreateTime2"].ToString();
			string a = httpCookie.Values["PageCheck"].ToString();
			string ordernum = httpCookie.Values["Guids"].ToString();
			string orderType = httpCookie.Values["OrderType"].ToString();
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = new ShopNum1_OrderInfo_Action();
			DataTable dataTable;
			if (a == "1")
			{
				dataTable = shopNum1_OrderInfo_Action.SearchOrderInfoByOrdernum(ordernum, orderType);
			}
			else
			{
				dataTable = shopNum1_OrderInfo_Action.Search(orderNumber, memLoginID, name, address, postalcode, string_, mobile, email, shouldPayPrice, shouldPayPrice2, createTime, createTime2, 0, shopID, shopName, orderStatus, orderType);
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单号</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺名称</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >订单类型</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >详细地址</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >邮编</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >电子邮件</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >联系电话</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">下单日期</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">收货人</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">购买人</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">商品总金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">应付金额</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">订单状态</td>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", dataTable.Rows[i]["OrderNumber"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {ShopID}</td>".Replace("{ShopID}", dataTable.Rows[i]["ShopID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {ShopName}</td>".Replace("{ShopName}", dataTable.Rows[i]["ShopName"].ToString()));
					string newValue = string.Empty;
					string text = dataTable.Rows[i]["OrderType"].ToString();
					if (text != null)
					{
						if (!(text == "0"))
						{
							if (!(text == "2"))
							{
								if (text == "1")
								{
									newValue = "团购订单";
								}
							}
							else
							{
								newValue = "抢购订单";
							}
						}
						else
						{
							newValue = "普通订单";
						}
					}
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderTypes}</td>".Replace("{OrderTypes}", newValue));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Address}</td>".Replace("{Address}", dataTable.Rows[i]["Address"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Postalcode}</td>".Replace("{Postalcode}", dataTable.Rows[i]["Postalcode"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Mobile}</td>".Replace("{Mobile}", dataTable.Rows[i]["Mobile"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Email}</td>".Replace("{Email}", dataTable.Rows[i]["Email"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Tel}</td>".Replace("{Tel}", dataTable.Rows[i]["Tel"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {CreateTime}</td>".Replace("{CreateTime}", dataTable.Rows[i]["CreateTime"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Name}</td>".Replace("{Name}", dataTable.Rows[i]["Name"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {ProductPrice}</td>".Replace("{ProductPrice}", dataTable.Rows[i]["ProductPrice"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {ShouldPayPrice}</td>".Replace("{ShouldPayPrice}", dataTable.Rows[i]["ShouldPayPrice"].ToString()));
					string newValue2 = string.Empty;
					text = dataTable.Rows[i]["OderStatus"].ToString();
					switch (text)
					{
					case "0":
						newValue2 = "等待买家付款";
						break;
					case "1":
						newValue2 = "等待卖家发货";
						break;
					case "2":
						newValue2 = "等待买家确认收货";
						break;
					case "3":
						newValue2 = "交易成功";
						break;
					case "4":
						newValue2 = "系统关闭订单";
						break;
					case "5":
						newValue2 = "卖家关闭订单";
						break;
					case "6":
						newValue2 = "买家关闭订单";
						break;
					}
					base.Response.Write("<td style=\"background-color:#FFF\"> {strOderStatusDisply}</td>".Replace("{strOderStatusDisply}", newValue2));
					base.Response.Write("</tr>");
				}
				base.Response.Write("</table>");
			}
			HttpCookie httpCookie2 = base.Request.Cookies["OrderListReportCookie"];
			httpCookie2.Expires = DateTime.Now.AddDays(-99.0);
			base.Response.Cookies.Add(httpCookie2);
		}
		catch (Exception)
		{
		}
	}
}
