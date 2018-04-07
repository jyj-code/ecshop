using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class PreDeposits : BaseWebControl
	{
		private string string_0 = "PreDeposits.ascx";
		private TextBox textBox_0;
		private Label label_0;
		private Label label_1;
		private TextBox textBox_1;
		private Button button_0;
		private string string_1;
		private string string_2;
		private DataSet dataSet_0;
		private DataTable dataTable_0;
		private DataSet dataSet_1;
		private string string_3;
		private string string_4;
		private string string_5;
		private byte byte_0 = 0;
		private TextBox textBox_2;
		private HtmlGenericControl htmlGenericControl_0;
		private string string_6 = string.Empty;
		private string string_7 = string.Empty;
		public PreDeposits()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.string_1 = httpCookie.Values["MemLoginID"].ToString();
				PayUrlOperate payUrlOperate = new PayUrlOperate();
				SortedDictionary<string, string> requestGet = this.GetRequestGet();
				if (requestGet.Count != 8)
				{
					this.byte_0 = 1;
				}
				else if (this.Page.Request.QueryString["sign"] != null)
				{
					if (!payUrlOperate.CheckSign(requestGet, this.Page.Request.QueryString["sign"].ToString()))
					{
						this.byte_0 = 2;
					}
					else if (this.Page.Request.QueryString["timetemp"] != null)
					{
						long num = Convert.ToInt64(this.Page.Request.QueryString["timetemp"]);
						if (DateTime.Now.Ticks - num > 0L)
						{
							this.byte_0 = 3;
						}
						else
						{
							string text = Encryption.Decrypt(this.Page.Request.QueryString["memlogid"].Trim());
							if (this.string_1.Trim().ToLower() != text.Trim().ToLower())
							{
								this.byte_0 = 4;
							}
							else
							{
								this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("noPay");
								this.textBox_2 = (TextBox)skin.FindControl("txtMobileCode");
								this.textBox_0 = (TextBox)skin.FindControl("TextBoxPayPassword");
								this.label_0 = (Label)skin.FindControl("LabelShouldPay");
								this.label_1 = (Label)skin.FindControl("LabelAdvancePayment");
								this.button_0 = (Button)skin.FindControl("ButtonPay");
								this.textBox_1 = (TextBox)skin.FindControl("TextBoxOrderID");
								this.button_0.Click += new EventHandler(this.button_0_Click);
								if (this.Page.Request.QueryString["TradeID"] == null || this.Page.Request.Cookies["MemberLoginCookie"] == null)
								{
									this.Page.Response.Redirect("http://" + ShopSettings.siteDomain);
								}
								else
								{
									this.method_1();
								}
								string nameById = ShopNum1.Common.Common.GetNameById("PayPwd", "ShopNum1_Member", "    AND  MemLoginID='" + this.string_1 + "'");
								if (string.IsNullOrEmpty(nameById))
								{
									this.htmlGenericControl_0.Visible = true;
								}
								else
								{
									this.htmlGenericControl_0.Visible = false;
								}
							}
						}
					}
					else
					{
						this.byte_0 = 3;
					}
				}
				else
				{
					this.byte_0 = 2;
				}
			}
			else
			{
				GetUrl.RedirectLogin();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			if (ShopSettings.GetValue("IsMobileCheckPay") == "1")
			{
				int num = 0;
				try
				{
					string nameById = ShopNum1.Common.Common.GetNameById("mobile", "shopnum1_member", " and memloginId='" + this.string_1 + "' and mobile!=''");
					ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberActivate_Action();
					if (shopNum1_MemberActivate_Action.CheckMobileCode(this.textBox_2.Text, nameById, "2") != "0")
					{
						num = 1;
					}
				}
				catch
				{
				}
				if (num != 1)
				{
					MessageBox.Show("手机验证码不正确！");
					return;
				}
			}
			string payPwd = shopNum1_Member_Action.GetPayPwd(this.string_1);
			if (payPwd == "")
			{
				this.Page.RegisterStartupScript("pop", "<script>alert(\"请先设置支付密码才能进行支付交易！\");location.href='http://" + ShopSettings.siteDomain + "/Main/Account/a_index.aspx?toaurl=A_PwdSer.aspx';</script>");
			}
			else
			{
				string md5SecondHash = Encryption.GetMd5SecondHash(this.textBox_0.Text.Trim());
				if (payPwd != md5SecondHash)
				{
					MessageBox.Show("您输入的交易密码不正确！");
				}
				else
				{
					ShopNum1_OrderOperateLog_Action arg_122_0 = (ShopNum1_OrderOperateLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderOperateLog_Action();
					decimal num2 = Convert.ToDecimal(this.label_0.Text);
					decimal num3 = Convert.ToDecimal(this.label_1.Text);
					string a = this.Page.Request.QueryString["type"].ToString();
					if (num2 > num3)
					{
						MessageBox.Show("您当前帐户上面的金额不足，无法支付!");
						this.textBox_0.Text = "";
					}
					else if (a == "product")
					{
						string text = this.Page.Request.QueryString["TradeID"].ToString();
						string text2 = this.Page.Request.QueryString["IsAllPay"].ToString();
						int num4 = shopNum1_Member_Action.PreDepositsPay(this.string_1, num2, num3, text, text2);
						if (num4 > 0)
						{
							this.string_5 = "订单" + this.Page.Request.QueryString["TradeID"].ToString() + "预存款支付";
							ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
							DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(text);
							if (text2 == "1")
							{
								if (orderGuIdByTradeId.Rows.Count > 0)
								{
									this.MoneyModifyLog(this.string_5);
									this.OrderOperateLog(this.string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(), orderGuIdByTradeId.Rows[0]["feeType"].ToString());
									for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
									{
										ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderProduct_Action();
										shopNum1_OrderProduct_Action.UpdateStock(orderGuIdByTradeId.Rows[i]["guid"].ToString());
										if (orderGuIdByTradeId.Rows[i]["FeeType"].ToString() == "2")
										{
											this.IsMMS(orderGuIdByTradeId.Rows[i]["ordernumber"].ToString(), orderGuIdByTradeId.Rows[i]["IdentifyCode"].ToString(), orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(), orderGuIdByTradeId.Rows[i]["Mobile"].ToString(), orderGuIdByTradeId.Rows[i]["ProductName"].ToString(), orderGuIdByTradeId.Rows[i]["BuyNumber"].ToString());
										}
									}
								}
							}
							else
							{
								this.MoneyModifyLog(this.string_5);
								this.OrderOperateLog(this.string_5, this.string_6, this.string_7);
								ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderProduct_Action();
								shopNum1_OrderProduct_Action.UpdateStock(this.string_6);
								if (orderGuIdByTradeId.Rows.Count > 0 && orderGuIdByTradeId.Rows[0]["FeeType"].ToString() == "2")
								{
									this.IsMMS(orderGuIdByTradeId.Rows[0]["ordernumber"].ToString(), orderGuIdByTradeId.Rows[0]["IdentifyCode"].ToString(), orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(), orderGuIdByTradeId.Rows[0]["Mobile"].ToString(), orderGuIdByTradeId.Rows[0]["ProductName"].ToString(), orderGuIdByTradeId.Rows[0]["BuyNumber"].ToString());
								}
							}
							if (ShopSettings.GetValue("PayIsMMS") == "1")
							{
								string nameById = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " And MemloginId='" + orderGuIdByTradeId.Rows[0]["ShopId"].ToString() + "'");
								this.method_0(orderGuIdByTradeId.Rows[0]["ShopID"].ToString(), orderGuIdByTradeId.Rows[0]["ordernumber"].ToString(), nameById);
							}
							if (ShopSettings.GetValue("PayIsEmail") == "1")
							{
								this.IsEmail();
							}
							this.Page.RegisterStartupScript("pop", "<script>alert(\"您所买的商品,已经成功付款!您可以通知卖家及时发货\");location.href='http://" + ShopSettings.siteDomain + "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");
						}
						else
						{
							MessageBox.Show("支付失败");
						}
					}
					else if (a == "categoryad")
					{
						string tradeID = this.Page.Request.QueryString["TradeID"].ToString();
						int num4 = shopNum1_Member_Action.CategoryAdPay(this.string_1, num2, num3, tradeID);
						if (num4 > 0)
						{
							this.MoneyModifyLog("购买广告");
							this.Page.RegisterStartupScript("pop", "<script>alert(\"支付成功\");location.href='http://" + ShopSettings.siteDomain + "/Main/Member/m_index.aspx';</script>");
						}
						else
						{
							this.Page.RegisterStartupScript("pop", "<script>alert(\"支付失败\");window.close()</script>");
						}
					}
					else if (a == "shoprank" || a == "shopensure")
					{
						string text = this.Page.Request.QueryString["TradeID"].ToString();
						int num4 = shopNum1_Member_Action.OtherOrderIDPay(this.string_1, num2, num3, text);
						if (num4 > 0)
						{
							int num5 = 0;
							if (this.string_3 == "1")
							{
								Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
								num5 = shop_ShopApplyRank_Action.UpdataShopRankPayStatusByID(this.string_4);
								this.string_5 = "购买店铺等级";
							}
							else if (this.string_3 == "2")
							{
								Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
								num5 = shop_Ensure_Action.UpdataEnsurePayStatusByGuid(this.string_4);
								this.string_5 = "购买店铺担保";
							}
							if (num5 > 0)
							{
								this.MoneyModifyLog(this.string_5);
								this.Page.RegisterStartupScript("pop", "<script>alert(\"支付成功\");location.href='http://" + ShopSettings.siteDomain + "/Main/Member/m_index.aspx';</script>");
							}
							else
							{
								this.Page.RegisterStartupScript("pop", "<script>alert(\"支付失败\");window.close()</script>");
							}
						}
						else
						{
							this.Page.RegisterStartupScript("pop", "<script>alert(\"支付失败\");window.close()</script>");
						}
					}
				}
			}
		}
		private void method_0(string string_8, string string_9, string string_10)
		{
			string_10 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " And memloginid='" + string_8 + "'");
			if (!string.IsNullOrEmpty(string_10))
			{
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'204e827c-a610-4212-836e-709cd59cba83'", 0);
				if (editInfo.Rows.Count > 0)
				{
					OrderInfo orderInfo = new OrderInfo();
					orderInfo.ShopName = ShopSettings.GetValue("Name");
					string text = editInfo.Rows[0]["Remark"].ToString();
					string mMsTitle = editInfo.Rows[0]["Title"].ToString();
					text = text.Replace("{$Name}", string_8);
					text = text.Replace("{$OrderNumber}", string_9);
					text = text.Replace("{$ShopName}", orderInfo.ShopName);
					text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
					SMS sMS = new SMS();
					text = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
					string empty = string.Empty;
					sMS.Send(string_10, text, out empty);
					if (empty.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(string_8, string_10.Trim(), mMsTitle, text, 2, "204e827c-a610-4212-836e-709cd59cba83");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(string_8, string_10.Trim(), mMsTitle, text, 0, "204e827c-a610-4212-836e-709cd59cba83");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
		}
		protected void IsMMS(string OrderNumber, string strCode, string memloginID, string string_8, string strProductName, string strBuyNum)
		{
			string nameById = ShopNum1.Common.Common.GetNameById("mobile", "ShopNum1_Member", " and memloginid='" + memloginID + "'");
			if (!(nameById.Trim() == "") && !(strCode == "0" | strCode == ""))
			{
				string_8 = nameById;
				OrderInfo orderInfo = new OrderInfo();
				orderInfo.Name = memloginID;
				orderInfo.OrderNumber = OrderNumber;
				orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				orderInfo.ShopName = ShopSettings.GetValue("Name");
				string text = "73370552-efdb-47ec-9e0f-f813261375b8";
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text + "'", 0);
				if (editInfo != null && editInfo.Rows.Count > 0)
				{
					string text2 = editInfo.Rows[0]["Remark"].ToString();
					text2 = text2.Replace("{$Name}", orderInfo.Name);
					text2 = text2.Replace("{$IdentifyCode}", strCode);
					text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
					text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
					text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
					text2 = text2.Replace("{$ProductName}", strProductName);
					text2 = text2.Replace("{$BuyNum}", strBuyNum);
					string mMsTitle = editInfo.Rows[0]["Title"].ToString();
					SMS sMS = new SMS();
					string text3 = "";
					text2 = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text2));
					sMS.Send(string_8.Trim(), text2, out text3);
					if (text3.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(memloginID, string_8.Trim(), mMsTitle, text2, 2, text);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(memloginID, string_8.Trim(), mMsTitle, text2, 0, text);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
		}
		protected void MoneyModifyLog(string memo)
		{
			ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
			shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
			shopNum1_AdvancePaymentModifyLog.OperateType = 3;
			shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(this.label_1.Text);
			shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.label_0.Text);
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.label_1.Text) - Convert.ToDecimal(this.label_0.Text);
			shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
			shopNum1_AdvancePaymentModifyLog.Memo = memo;
			shopNum1_AdvancePaymentModifyLog.MemLoginID = this.string_1;
			shopNum1_AdvancePaymentModifyLog.CreateUser = this.string_1;
			shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
		}
		protected void OrderOperateLog(string memo, string strOrdGuId, string strFeeType)
		{
			if (!string.IsNullOrEmpty(strOrdGuId))
			{
				ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
				shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
				shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(strOrdGuId);
				shopNum1_OrderOperateLog.OderStatus = 1;
				shopNum1_OrderOperateLog.ShipmentStatus = 0;
				shopNum1_OrderOperateLog.PaymentStatus = 1;
				shopNum1_OrderOperateLog.CurrentStateMsg = "已付款";
				if (strFeeType.Equals("2"))
				{
					shopNum1_OrderOperateLog.NextStateMsg = "等待买家消费";
				}
				else
				{
					shopNum1_OrderOperateLog.NextStateMsg = "等待发货";
				}
				shopNum1_OrderOperateLog.Memo = memo;
				shopNum1_OrderOperateLog.OperateDateTime = DateTime.Now;
				shopNum1_OrderOperateLog.IsDeleted = 0;
				shopNum1_OrderOperateLog.CreateUser = this.string_1;
				ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderOperateLog_Action();
				shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
			}
		}
		private void method_1()
		{
			string text = this.Page.Request.QueryString["TradeID"].ToString();
			this.textBox_1.Text = text;
			IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			object obj = this.Page.Request.QueryString["type"];
			if (obj.ToString() == "product")
			{
				string a = (this.Page.Request.QueryString["IsAllPay"] == null) ? "-1" : this.Page.Request.QueryString["IsAllPay"].ToString();
				if (a == "1")
				{
					this.dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(text, this.string_1);
					if (this.dataSet_0 != null && this.dataSet_0.Tables.Count == 2 && !(this.dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
					{
						this.label_0.Text = this.dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
						this.string_6 = this.dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
						this.string_7 = this.dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
						this.label_1.Text = this.dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
						this.string_2 = this.dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();
					}
				}
				else if (a == "0")
				{
					this.dataSet_0 = shopNum1_OrderInfo_Action.SingleTradePayMent(text, this.string_1);
					if (this.dataSet_0 != null && this.dataSet_0.Tables.Count == 2 && !(this.dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
					{
						this.label_0.Text = this.dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
						this.string_6 = this.dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
						this.string_7 = this.dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
						this.label_1.Text = this.dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
						this.string_2 = this.dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();
					}
				}
			}
			else if (obj.ToString() == "shoprank" || obj.ToString() == "shopensure")
			{
				this.dataTable_0 = shopNum1_OrderInfo_Action.GetOtherOrderInfoByTradeID(text, this.string_1);
				this.label_0.Text = this.dataTable_0.Rows[0]["TotalPrice"].ToString();
				this.label_1.Text = this.dataTable_0.Rows[0]["AdvancePayment"].ToString();
				this.string_3 = this.dataTable_0.Rows[0]["Type"].ToString();
				this.string_4 = this.dataTable_0.Rows[0]["RelevanceID"].ToString();
			}
			else if (obj.ToString() == "categoryad")
			{
				ShopNum1_CategoryAdPayMent_Action shopNum1_CategoryAdPayMent_Action = (ShopNum1_CategoryAdPayMent_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_CategoryAdPayMent_Action();
				this.dataSet_1 = shopNum1_CategoryAdPayMent_Action.PayCategoryAdPrice(text, this.string_1);
				if (this.dataSet_1 == null || this.dataSet_1.Tables.Count != 2 || this.dataSet_1.Tables[0].Rows[0][0].ToString() == "-1")
				{
					this.byte_0 = 2;
				}
				else
				{
					this.label_0.Text = this.dataSet_1.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
					this.label_1.Text = this.dataSet_1.Tables[1].Rows[0]["AdvancePayment"].ToString();
				}
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (this.byte_0 == 0)
			{
				base.Render(writer);
			}
			else if (this.byte_0 == 1)
			{
				writer.Write("<span style=\"color:red\">支付参数不对!</span><span class='gohome'><a href=\"http://" + ShopSettings.siteDomain + "\">返回首页</a></span>");
			}
			else if (this.byte_0 == 2)
			{
				writer.Write("<span style=\"color:red\">错误的签名!</span><span class='gohome'><a href=\"http://" + ShopSettings.siteDomain + "\">返回首页</a></span>");
			}
			else if (this.byte_0 == 3)
			{
				writer.Write("<span style=\"color:red\">支付已经过期请重新点击支付!</span><span class='gohome'><a href=\"http://" + ShopSettings.siteDomain + "\">返回首页</a></span>");
			}
			else
			{
				writer.Write("<span style=\"color:red\">非法的支付请求!</span><span class='gohome'><a href=\"http://" + ShopSettings.siteDomain + "\">返回首页</a></span>");
			}
		}
		public SortedDictionary<string, string> GetRequestGet()
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			NameValueCollection queryString = HttpContext.Current.Request.QueryString;
			string[] allKeys = queryString.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				if (HttpContext.Current.Request.QueryString[allKeys[i]] != null && allKeys[i].ToLower().IndexOf("substationid") == -1)
				{
					sortedDictionary.Add(allKeys[i], Encryption.Decrypt(HttpContext.Current.Request.QueryString[allKeys[i]].ToString()));
				}
			}
			return sortedDictionary;
		}
		protected void IsMMS()
		{
			try
			{
				string text = string.Empty;
				IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
				string text2 = this.Page.Request.QueryString["TradeID"].ToString();
				string a = this.Page.Request.QueryString["IsAllPay"].ToString();
				DataTable dataTable = null;
				if (a == "1")
				{
					dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByTradeIDAndMemloginid(text2, this.string_1);
				}
				else if (a == "0")
				{
					dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(text2, this.string_1);
				}
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					text = dataTable.Rows[0]["guid"].ToString();
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
					DataTable orderInfoByGuid = shopNum1_OrderInfo_Action2.GetOrderInfoByGuid(text);
					string text3 = string.Empty;
					text3 = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " And MemLoginID=(Select ShopID from ShopNum1_OrderInfo where guid='" + text + "')");
					UpdateOrderStute updateOrderStute = new UpdateOrderStute();
					updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
					updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
					updateOrderStute.ShopName = ShopSettings.GetValue("Name");
					updateOrderStute.UpdateTime = DateTime.Now.ToString();
					updateOrderStute.SysSendTime = DateTime.Now.ToString();
					string text4 = "204e827c-a610-4212-836e-709cd59cba83";
					IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
					DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text4 + "'", 0);
					string text5 = string.Empty;
					string mMsTitle = string.Empty;
					if (editInfo.Rows.Count > 0)
					{
						text5 = editInfo.Rows[0]["Remark"].ToString();
						mMsTitle = editInfo.Rows[0]["Title"].ToString();
						text5 = text5.Replace("{$Name}", updateOrderStute.Name);
						text5 = text5.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
						text5 = text5.Replace("{$ShopName}", ShopSettings.GetValue("Name"));
						text5 = text5.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
					}
					SMS sMS = new SMS();
					string text6 = "";
					text5 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text5));
					sMS.Send(text3.Trim(), text5, out text6);
					if (text6.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), text3, mMsTitle, text5, 2, text4);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), text3, mMsTitle, text5, 0, text4);
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
			catch (Exception)
			{
			}
		}
		private bool method_2(string string_8)
		{
			bool result = false;
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(string_8);
			if (dataTable.Rows.Count > 0 && string.Format("{0}", dataTable.Rows[0]["FeeType"]).Equals("1"))
			{
				string string_9 = string.Format("{0}", dataTable.Rows[0]["Name"]);
				string string_10 = string.Format("{0}", dataTable.Rows[0]["IdentifyCode"]);
				string string_11 = string.Format("{0}", dataTable.Rows[0]["Mobile"]);
				string string_12 = string.Format("{0}", dataTable.Rows[0]["MemLoginID"]);
				this.method_3(string_9, string_8, string_10, string_12, string_11);
				result = true;
			}
			return result;
		}
		private void method_3(string string_8, string string_9, string string_10, string string_11, string string_12)
		{
			if (!string.IsNullOrEmpty(string_12))
			{
				IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'73370552-EFDB-47EC-9E0F-F813261375B8'", 0);
				if (editInfo.Rows.Count > 0)
				{
					string text = editInfo.Rows[0]["Remark"].ToString();
					string mMsTitle = editInfo.Rows[0]["Title"].ToString();
					text = text.Replace("{$Name}", string_8);
					text = text.Replace("{$OrderNumber}", string_9);
					text = text.Replace("{$IdentifyCode}", string_10);
					text = text.Replace("{$ShopName}", ShopSettings.GetValue("Name"));
					OrderInfo orderInfo = new OrderInfo();
					SMS sMS = new SMS();
					text = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text));
					string empty = string.Empty;
					sMS.Send(string_12, text, out empty);
					if (empty.IndexOf("发送成功") != -1)
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(string_11, string_12.Trim(), mMsTitle, text, 2, "73370552-EFDB-47EC-9E0F-F813261375B8");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
					else
					{
						ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(string_11, string_12.Trim(), mMsTitle, text, 0, "73370552-EFDB-47EC-9E0F-F813261375B8");
						shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
					}
				}
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, string strContent, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")),
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = strContent,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		protected void IsEmail()
		{
			try
			{
				string guid = string.Empty;
				IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
				string text = this.Page.Request.QueryString["TradeID"].ToString();
				string a = this.Page.Request.QueryString["IsAllPay"].ToString();
				DataTable dataTable = null;
				if (a == "1")
				{
					dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByTradeIDAndMemloginid(text, this.string_1);
				}
				else if (a == "0")
				{
					dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(text, this.string_1);
				}
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					guid = dataTable.Rows[0]["guid"].ToString();
					DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
					string nameById = ShopNum1.Common.Common.GetNameById("Email", "ShopNum1_Member", " and MemLoginID='" + orderInfoByGuid.Rows[0]["ShopId"].ToString() + "'");
					if (!string.IsNullOrEmpty(nameById))
					{
						string value = ShopSettings.GetValue("Name");
						UpdateOrderStute updateOrderStute = new UpdateOrderStute();
						string memLoginID = updateOrderStute.Name = orderInfoByGuid.Rows[0]["ShopId"].ToString();
						updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
						updateOrderStute.OrderStatus = OrderStatus.ChangeOrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
						updateOrderStute.UpdateTime = DateTime.Now.ToString();
						updateOrderStute.SysSendTime = DateTime.Now.ToString();
						updateOrderStute.ShopName = value;
						string text2 = string.Empty;
						string emailTitle = string.Empty;
						string text3 = "204e827c-a610-4212-836e-709cd59cba83";
						ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Email_Action();
						DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
						if (editInfo.Rows.Count > 0)
						{
							text2 = editInfo.Rows[0]["Remark"].ToString();
							emailTitle = editInfo.Rows[0]["Title"].ToString();
						}
						text2 = text2.Replace("{$Name}", updateOrderStute.Name);
						text2 = text2.Replace("{{$OrderNumber}", updateOrderStute.OrderNumber);
						text2 = text2.Replace("{$ShopName}", value);
						text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString());
						string emailBody = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text2));
						SendEmail sendEmail = new SendEmail();
						sendEmail.Emails(nameById, memLoginID, emailTitle, text3, emailBody);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
