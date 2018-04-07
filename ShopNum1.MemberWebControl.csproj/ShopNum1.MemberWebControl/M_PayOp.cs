using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_PayOp : BaseMemberWebControl
	{
		private string string_0 = "M_PayOp.ascx";
		public M_PayOp()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (!this.Page.IsPostBack)
			{
				string text = ShopNum1.Common.Common.ReqStr("orderguid");
				string a = ShopNum1.Common.Common.ReqStr("mid");
				string text2 = ShopNum1.Common.Common.ReqStr("ordertype");
				string a2 = ShopNum1.Common.Common.ReqStr("sign");
				string prNames = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("pname"));
				if ((a2 == "welcomeshopnum1" & text != "" & a != "") && text2 != "")
				{
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
					DataTable dataTable = shopNum1_OrderInfo_Action.Search1(text.Trim());
					if (dataTable != null && dataTable.Rows.Count > 0)
					{
						dataTable.Rows[0]["ShopID"].ToString();
						string shouldPayPrice = dataTable.Rows[0]["ShouldPayPrice"].ToString();
						string text3 = dataTable.Rows[0]["OrderNumber"].ToString();
						string paymentGuid = dataTable.Rows[0]["PaymentGuid"].ToString();
						string a3 = dataTable.Rows[0]["PaymentStatus"].ToString();
						ShopNum1_Member_Action arg_160_0 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
						if (a3 == "0")
						{
							string payMentMemloginID = dataTable.Rows[0]["PayMentMemLoginID"].ToString();
							string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
							PayUrlOperate payUrlOperate = new PayUrlOperate();
							string str = string.Empty;
							string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_OrderInfo", " and OrderNumber='" + text3 + "'");
							if (!string.IsNullOrEmpty(nameById))
							{
								str = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", " and  SubstationID='" + nameById + "'");
							}
							string dourl = str + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
							this.Page.Response.Redirect(payUrlOperate.GetPayUrl(paymentGuid, shouldPayPrice, dourl, prNames, text3, "product", "0", payMentMemloginID, this.MemLoginID, timetemp));
						}
						else
						{
							this.Page.Response.Redirect(string.Concat(new string[]
							{
								"M_OrderDetail.aspx?guid=",
								text,
								"&orderType=",
								text2,
								"&"
							}));
						}
					}
				}
				else
				{
					this.Page.Response.Redirect(string.Concat(new string[]
					{
						"M_OrderDetail.aspx?guid=",
						text,
						"&orderType=",
						text2,
						"&"
					}));
				}
			}
			else
			{
				this.Page.Response.Redirect("http://" + ShopSettings.siteDomain);
			}
		}
	}
}
