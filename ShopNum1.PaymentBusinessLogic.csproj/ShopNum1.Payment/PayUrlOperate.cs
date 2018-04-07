using Com.Alipay;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace ShopNum1.Payment
{
	public class PayUrlOperate
	{
		public string GetPayUrl(string paymentGuid, string shouldPayPrice, string dourl, string prNames, string strTradeID, string type, string IsAllPayMent, string PayMentMemloginID, string memloginid, string timetemp)
		{
			string text = string.Empty;
			ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
			DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid(paymentGuid);
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = new ShopNum1_ShopPayment_Action();
			string result;
			if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
			{
				paymentInfoByGuid = shopNum1_ShopPayment_Action.GetPaymentInfoByGuid(paymentGuid);
				if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
				{
					MessageBox.Show("支付有异常！");
					result = "";
					return result;
				}
			}
			text = paymentInfoByGuid.Rows[0]["PaymentType"].ToString();
			PayInfo payInfo = new PayInfo();
			Pay pay = new Pay();
			string text2 = text;
			switch (text2)
			{
			case "Xpay.aspx":
			{
				string text3 = string.Empty;
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductName = prNames;
				payInfo.ProductType = "";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.ProductPrice = shouldPayPrice;
				payInfo.Description = "";
				if (pay.XpayPay(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "KqSend.aspx":
				result = string.Concat(new string[]
				{
					"http://",
					dourl,
					"/PayReturn/ZFPay/KqSend.aspx?id=",
					strTradeID,
					"&payerName=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "Alipay.aspx":
			{
				decimal num2 = 0m;
				if (strTradeID.IndexOf("C") == -1)
				{
					num2 = decimal.Parse(ShopNum1.Common.Common.GetNameById("dispatchprice", "ShopNum1_OrderInfo", " And OrderNumber='" + strTradeID + "'"));
				}
				payInfo.Gateway = "https://www.alipay.com/cooperate/gateway.do?";
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.SignType = "MD5";
				payInfo.ProductName = prNames;
				payInfo.Description = strTradeID;
				payInfo.SiglePrice = Convert.ToString(decimal.Parse(shouldPayPrice) - num2);
				payInfo.Quantity = "1";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + dourl + "/" + ConfigurationManager.AppSettings["receivealipay1_url"];
				payInfo.Notify_url = "http://" + dourl + "/" + ConfigurationManager.AppSettings["showalipay1_url"];
				payInfo.Logistics_type = "EXPRESS";
				payInfo.Logistics_fee = Convert.ToString(num2);
				payInfo.Logistics_payment = "BUYER_PAY";
				payInfo.Show_url = "javascript:void(0)";
				payInfo.Info1 = "shop1";
				payInfo.Info2 = "shop2";
				payInfo.OrderNumber = strTradeID;
				string text3;
				pay.AlipayPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Alipay2.aspx":
			{
				payInfo.ProductName = prNames;
				payInfo.Body = strTradeID;
				payInfo.Quantity = "1";
				payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
				payInfo.OrderNumber = strTradeID;
				payInfo.Logistics_type = "EXPRESS";
				payInfo.Logistics_fee = "0";
				payInfo.Logistics_payment = "BUYER_PAY";
				payInfo.Logistics_type_1 = "POST";
				payInfo.Logistics_fee_1 = "0";
				payInfo.Logistics_payment_1 = "BUYER_PAY";
				payInfo.Show_url = "http://" + dourl;
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Seller_email = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + dourl + "/" + ConfigurationManager.AppSettings["twoAlipayreturn_url"];
				payInfo.Notify_url = "http://" + dourl + "/" + ConfigurationManager.AppSettings["twoAlipayshow_url"];
				string text3;
				pay.AlipayPay2(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Alipay3.aspx":
			{
				payInfo.ProductName = strTradeID;
				payInfo.Body = strTradeID;
				payInfo.OrderNumber = strTradeID;
				payInfo.ShouldPayPrice = Convert.ToString(shouldPayPrice);
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Seller_email = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + dourl + "/" + ConfigurationManager.AppSettings["receivealipay2_url"];
				payInfo.Notify_url = "http://" + dourl + "/" + ConfigurationManager.AppSettings["showalipay2_url"];
				payInfo.Show_url = "http://" + ShopSettings.siteDomain;
				payInfo.Payment_type = IsAllPayMent;
				string text3;
				if (pay.AlipayPay3(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "Allbuy.aspx":
			{
				payInfo.ProductName = prNames;
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.CreateTime = DateTime.Now.ToString("yyyy-M-d");
				payInfo.Description = "";
				payInfo.Payment_type = IsAllPayMent;
				string text3;
				pay.AllBuyPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Yeepay.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/YeePay/Pay_Post.aspx?order=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=Yeepay&proName=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "YeepaySZX.aspx":
			{
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.ProductName = prNames;
				payInfo.ProductType = "1";
				payInfo.Description = "";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.SellerRemark = "";
				payInfo.FormID = "";
				string empty = string.Empty;
				string text3;
				pay.YeepayPaySZX(payInfo, out text3, out empty);
				result = text3;
				return result;
			}
			case "TenpayMed.aspx":
			{
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.ProductName = prNames;
				payInfo.Description = strTradeID;
				payInfo.ProductPrice = Convert.ToString(Math.Round(Convert.ToDecimal(shouldPayPrice) * 100m, 0));
				payInfo.ProductType = "1";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.TransportType = "2";
				payInfo.TransportPrice = "0";
				payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["show_url"];
				payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["mch_returl"];
				payInfo.OrderNumber = strTradeID.Substring(0, 10);
				payInfo.ShouldPayPrice = "0";
				string text3;
				if (pay.TenpayMedPay(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "Tenpay.aspx":
			{
				payInfo.ProductName = prNames;
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Payment_type = IsAllPayMent;
				payInfo.OrderNumber = strTradeID.Trim();
				payInfo.ShouldPayPrice = Convert.ToString(Convert.ToDouble(shouldPayPrice) * 100.0);
				payInfo.Return_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["tenpayAppreturn_url"];
				payInfo.Notify_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["tenpayAppshow_url"];
				string text3;
				if (pay.TenpayPay(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "BankTransfer.aspx":
				paymentInfoByGuid.Rows[0]["Memo"].ToString();
				result = "";
				return result;
			case "PreDeposits.aspx":
			{
				Dictionary<string, string> dictionary_ = this.method_1(new SortedDictionary<string, string>
				{

					{
						"paymoney",
						shouldPayPrice
					},

					{
						"tradeid",
						strTradeID
					},

					{
						"type",
						type.ToLower()
					},

					{
						"isallpay",
						IsAllPayMent.ToLower()
					},

					{
						"paymentshopid",
						PayMentMemloginID.ToLower()
					},

					{
						"memlogid",
						memloginid.ToLower()
					},

					{
						"timetemp",
						timetemp
					}
				});
				string text4 = this.method_2(dictionary_, "GB2312");
				result = string.Concat(new string[]
				{
					"http://",
					dourl,
					"/PreDeposits.aspx?PayMoney=",
					shouldPayPrice,
					"&TradeID=",
					strTradeID,
					"&type=",
					type.ToLower(),
					"&IsAllPay=",
					IsAllPayMent,
					"&PayMentShopID=",
					PayMentMemloginID.ToLower(),
					"&memlogid=",
					Encryption.Encrypt(memloginid.ToLower()),
					"&sign=",
					text4,
					"&timetemp=",
					timetemp
				});
				return result;
			}
			case "PayPal.aspx":
			{
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.Payment_type = IsAllPayMent;
				payInfo.ProductName = prNames;
				string text3;
				pay.PayPalPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "huanxun.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/HuanXun/Hx_Post.aspx?OrderNumber=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=huanxun&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "YiShouFu.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/HuanXun/Hx_EasyPay_Post.aspx?OrderNumber=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=YiShouFu&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "wanghuitong.aspx":
			{
				payInfo.MerchantId = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID;
				payInfo.Payment_type = IsAllPayMent;
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.DesKey = paymentInfoByGuid.Rows[0]["SecretKey"].ToString().Split(new char[]
				{
					'|'
				})[0].ToUpper();
				payInfo.MPK = paymentInfoByGuid.Rows[0]["SecretKey"].ToString().Split(new char[]
				{
					'|'
				})[1].ToUpper();
				payInfo.Wht_n = paymentInfoByGuid.Rows[0]["SecredKey"].ToString().Split(new char[]
				{
					'|'
				})[0].ToUpper();
				payInfo.Wht_e = paymentInfoByGuid.Rows[0]["SecredKey"].ToString().Split(new char[]
				{
					'|'
				})[1].ToUpper();
				payInfo.MerURL = "http://" + dourl + ConfigurationManager.AppSettings["merURL"];
				payInfo.PostUrl = "http://www.udpay.com.cn/gateway/cashback.jsp";
				string text3 = pay.wanghuitong(payInfo);
				result = text3;
				return result;
			}
			case "Send.aspx":
				result = string.Concat(new string[]
				{
					"http://",
					dourl.Split(new char[]
					{
						'/'
					})[0],
					ConfigurationManager.AppSettings["showbank_url"],
					"?id=",
					strTradeID,
					"&&PayType=",
					IsAllPayMent,
					"&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "BankOnline.aspx":
				result = string.Concat(new string[]
				{
					"PayReturn/BankSend.aspx?ID=",
					strTradeID,
					"&&PayType=",
					IsAllPayMent,
					"&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "NetPayClient.aspx":
				result = string.Concat(new object[]
				{
					"/PayReturn/unionpay/NetPaySubmit.aspx?payprice=",
					shouldPayPrice,
					"&mcode=",
					paymentInfoByGuid.Rows[0]["MerchantCode"],
					"&email=",
					paymentInfoByGuid.Rows[0]["Email"],
					"&tradeid=",
					strTradeID,
					"&pname=",
					Encryption.Encrypt(prNames),
					"&isPayMent=",
					IsAllPayMent,
					"&sign=unionpay"
				});
				return result;
			case "ChinaPayClient.aspx":
				if (prNames.IndexOf("充值") != -1)
				{
					result = "/PayReturn/ChinaPay/ChinaPay_Post.aspx?type=charge&Orid=" + strTradeID + "&sign=submit&prNames=" + Encryption.Encrypt(prNames);
					return result;
				}
				result = "/PayReturn/ChinaPay/ChinaPay_Post.aspx?type=buy&Orid=" + strTradeID + "&sign=submit&prNames=" + Encryption.Encrypt(prNames);
				return result;
			case "ABCPay.aspx":
			{
				payInfo.ABCOrderNO = strTradeID;
				payInfo.ABCExpiredDate = 10;
				payInfo.ABCOrderDesc = type;
				payInfo.ABCOrderDate = DateTime.Now.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
				payInfo.ABCOrderTime = DateTime.Now.ToString("hh:MM:ss");
				payInfo.ABCOrderAmount = double.Parse(shouldPayPrice);
				payInfo.ABCOrderURL = string.Format("http://{0}{1}", dourl, ConfigurationManager.AppSettings["abcsearch_url"]);
				payInfo.ABCBuyIP = "127.0.0.1";
				payInfo.ABCProductType = "1";
				payInfo.ABCPaymentType = "1";
				payInfo.ABCPaymentLinkType = "1";
				payInfo.ABCNotifyType = "1";
				payInfo.ABCResultNotifyURL = string.Format("http://{0}{1}?memloginid={2}&TradeID={3}&OperateType={4}&OrderAmount={5}", new object[]
				{
					dourl,
					ConfigurationManager.AppSettings["abcpayreceive_url"],
					memloginid,
					strTradeID,
					type,
					shouldPayPrice
				});
				payInfo.ABCMerchantRemarks = "";
				string text3;
				pay.ABCPayMent(payInfo, out text3);
				result = text3;
				return result;
			}
			case "CCBPay.aspx":
			{
				payInfo.CCBMerchantID = string.Format("{0}", paymentInfoByGuid.Rows[0]["MerchantCode"]);
				payInfo.CCBPosID = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecretKey"]);
				payInfo.CCBBranchID = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecondKey"]);
				payInfo.CCBOrderID = strTradeID;
				payInfo.CCBPayMent = shouldPayPrice;
				payInfo.CCBCurCode = "01";
				payInfo.CCBTxCode = "520100";
				payInfo.CCBRemark1 = type;
				payInfo.CCBRemark2 = memloginid;
				string text3;
				pay.CCBPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Baofoo.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/Baofoo/Baofoopay_post.aspx?OrderNumber=",
					strTradeID,
					"&price=",
					shouldPayPrice,
					"&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "ShengPay.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/ShengPay/SP_Post.aspx?OrderNumber=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=ShengPay&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			case "alidirectpay.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/Alipay/alidirect_pay_send.aspx?aliorderId=",
					strTradeID,
					"&productname=",
					Encryption.Encrypt(prNames),
					"&total_fee=",
					shouldPayPrice,
					"&sign=alipaydirect"
				});
				return result;
			case "TL.aspx":
			{
				TLPay tLPay = new TLPay();
				tLPay.merchantId = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				tLPay.orderNo = strTradeID;
				tLPay.orderAmount = (Convert.ToDecimal(shouldPayPrice) * 100m).ToString("G0");
				tLPay.orderDatetime = DateTime.Now.ToString("yyyyMMddhhmmss");
				tLPay.key=paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				TLPayReq tLPayReq = new TLPayReq(tLPay);
				result = tLPayReq.requestUrl + "?" + tLPayReq.GetParastring();
				return result;
			}
			case "Boc.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/BocBank/Pay_Post.aspx?orid=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=bocpay&prNames=",
					Encryption.Encrypt(prNames)
				});
				return result;
			}
			result = "";
			return result;
		}
		public string GetPayUrl(string paymentGuid, string shouldPayPrice, string Disp, string dourl, string prNames, string strTradeID, string type, string IsAllPayMent, string PayMentMemloginID, string memloginid, string timetemp)
		{
			string text = string.Empty;
			ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
			DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid(paymentGuid);
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = new ShopNum1_ShopPayment_Action();
			string result;
			if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
			{
				paymentInfoByGuid = shopNum1_ShopPayment_Action.GetPaymentInfoByGuid(paymentGuid);
				if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
				{
					MessageBox.Show("支付有异常！");
					result = "";
					return result;
				}
			}
			text = paymentInfoByGuid.Rows[0]["PaymentType"].ToString();
			PayInfo payInfo = new PayInfo();
			Pay pay = new Pay();
			string text2 = text;
			switch (text2)
			{
			case "Xpay.aspx":
			{
				string text3 = string.Empty;
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductName = strTradeID;
				payInfo.ProductType = "";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.ProductPrice = shouldPayPrice;
				payInfo.Description = "";
				if (pay.XpayPay(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "Alipay.aspx":
			{
				payInfo.Gateway = "https://www.alipay.com/cooperate/gateway.do?";
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.SignType = "MD5";
				payInfo.ProductName = strTradeID;
				payInfo.Description = strTradeID;
				payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
				payInfo.Quantity = "1";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["receivealipay1_url"];
				payInfo.Notify_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["showalipay1_url"];
				payInfo.Logistics_type = "EXPRESS";
				payInfo.Logistics_fee = "0";
				payInfo.Logistics_payment = "BUYER_PAY";
				payInfo.Show_url = "javascript:void(0)";
				payInfo.Info1 = "shop1";
				payInfo.Info2 = "shop2";
				payInfo.OrderNumber = strTradeID;
				string text3;
				pay.AlipayPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Alipay2.aspx":
			{
				payInfo.ProductName = strTradeID;
				payInfo.Body = prNames;
				payInfo.Quantity = "1";
				payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
				payInfo.OrderNumber = strTradeID;
				payInfo.Logistics_type = "EXPRESS";
				payInfo.Logistics_fee = "0";
				payInfo.Logistics_payment = "BUYER_PAY";
				payInfo.Logistics_type_1 = "POST";
				payInfo.Logistics_fee_1 = "0";
				payInfo.Logistics_payment_1 = "BUYER_PAY";
				payInfo.Show_url = "http://" + dourl;
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Seller_email = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + ShopSettings.siteDomain + "/" + ConfigurationManager.AppSettings["twoAlipayreturn_url"];
				payInfo.Notify_url = "http://" + ShopSettings.siteDomain + "/" + ConfigurationManager.AppSettings["twoAlipayshow_url"];
				string text3;
				pay.AlipayPay2(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Alipay3.aspx":
			{
				payInfo.ProductName = strTradeID + "|" + this.method_0();
				payInfo.Body = strTradeID;
				payInfo.OrderNumber = strTradeID;
				payInfo.ShouldPayPrice = Convert.ToString(shouldPayPrice);
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Seller_email = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["receivealipay2_url"];
				payInfo.Notify_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["showalipay2_url"];
				payInfo.Show_url = "http://" + ShopSettings.siteDomain;
				payInfo.Payment_type = IsAllPayMent;
				string text3;
				if (pay.AlipayPay3(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "Allbuy.aspx":
			{
				payInfo.ProductName = strTradeID;
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.CreateTime = DateTime.Now.ToString("yyyy-M-d");
				payInfo.Description = "";
				payInfo.Payment_type = IsAllPayMent;
				string text3;
				pay.AllBuyPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Yeepay.aspx":
			{
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.OrderNumber = strTradeID;
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.ProductName = strTradeID;
				payInfo.ProductType = "1";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.Description = "";
				payInfo.SellerRemark = "";
				payInfo.Return_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["callback"];
				string text3;
				pay.YeepayPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "YeepaySZX.aspx":
			{
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.ProductName = strTradeID;
				payInfo.ProductType = "1";
				payInfo.Description = "";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.SellerRemark = "";
				payInfo.FormID = "";
				string empty = string.Empty;
				string text3;
				pay.YeepayPaySZX(payInfo, out text3, out empty);
				result = text3;
				return result;
			}
			case "TenpayMed.aspx":
			{
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.ProductName = strTradeID;
				payInfo.Description = strTradeID;
				payInfo.ProductPrice = Convert.ToString(Math.Round(Convert.ToDecimal(shouldPayPrice) * 100m, 0));
				payInfo.ProductType = "1";
				payInfo.Payment_type = IsAllPayMent;
				payInfo.TransportType = "2";
				payInfo.TransportPrice = "0";
				payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["show_url"];
				payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["mch_returl"];
				payInfo.OrderNumber = strTradeID.Substring(0, 10);
				payInfo.ShouldPayPrice = "0";
				string text3;
				if (pay.TenpayMedPay(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "Tenpay.aspx":
			{
				payInfo.ProductName = strTradeID;
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.Payment_type = IsAllPayMent;
				payInfo.OrderNumber = strTradeID.Trim();
				payInfo.ShouldPayPrice = Convert.ToString(Convert.ToDouble(shouldPayPrice) * 100.0);
				payInfo.Return_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["tenpayAppreturn_url"];
				payInfo.Notify_url = "http://" + ShopSettings.siteDomain + ConfigurationManager.AppSettings["tenpayAppshow_url"];
				string text3;
				if (pay.TenpayPay(payInfo, out text3))
				{
					result = text3;
					return result;
				}
				result = "";
				return result;
			}
			case "BankTransfer.aspx":
				paymentInfoByGuid.Rows[0]["Memo"].ToString();
				result = "";
				return result;
			case "PreDeposits.aspx":
			{
				Dictionary<string, string> dictionary_ = this.method_1(new SortedDictionary<string, string>
				{

					{
						"paymoney",
						shouldPayPrice
					},

					{
						"tradeid",
						strTradeID
					},

					{
						"type",
						type.ToLower()
					},

					{
						"isallpay",
						IsAllPayMent.ToLower()
					},

					{
						"paymentshopid",
						PayMentMemloginID.ToLower()
					},

					{
						"memlogid",
						memloginid.ToLower()
					},

					{
						"timetemp",
						timetemp
					}
				});
				string text4 = this.method_2(dictionary_, "GB2312");
				result = string.Concat(new string[]
				{
					"~/PreDeposits.aspx?PayMoney=",
					shouldPayPrice,
					"&TradeID=",
					strTradeID,
					"&type=",
					type.ToLower(),
					"&IsAllPay=",
					IsAllPayMent,
					"&PayMentShopID=",
					PayMentMemloginID.ToLower(),
					"&memlogid=",
					Encryption.Encrypt(memloginid.ToLower()),
					"&sign=",
					text4,
					"&timetemp=",
					timetemp
				});
				return result;
			}
			case "PayPal.aspx":
			{
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID.Substring(0, 6);
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.Payment_type = IsAllPayMent;
				payInfo.ProductName = prNames;
				string text3;
				pay.PayPalPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "huanxun.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/HuanXun/Hx_Post.aspx?OrderNumber=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=huanxun"
				});
				return result;
			case "YiShouFu.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/HuanXun/Hx_EasyPay_Post.aspx?OrderNumber=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=YiShouFu"
				});
				return result;
			case "wanghuitong.aspx":
			{
				payInfo.MerchantId = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID;
				payInfo.Payment_type = IsAllPayMent;
				payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
				payInfo.DesKey = paymentInfoByGuid.Rows[0]["SecretKey"].ToString().Split(new char[]
				{
					'|'
				})[0].ToUpper();
				payInfo.MPK = paymentInfoByGuid.Rows[0]["SecretKey"].ToString().Split(new char[]
				{
					'|'
				})[1].ToUpper();
				payInfo.Wht_n = paymentInfoByGuid.Rows[0]["SecredKey"].ToString().Split(new char[]
				{
					'|'
				})[0].ToUpper();
				payInfo.Wht_e = paymentInfoByGuid.Rows[0]["SecredKey"].ToString().Split(new char[]
				{
					'|'
				})[1].ToUpper();
				payInfo.MerURL = "http://" + dourl + ConfigurationManager.AppSettings["merURL"];
				payInfo.PostUrl = "http://www.udpay.com.cn/gateway/cashback.jsp";
				string text3 = pay.wanghuitong(payInfo);
				result = text3;
				return result;
			}
			case "Send.aspx":
				result = string.Concat(new string[]
				{
					"http://",
					dourl.Split(new char[]
					{
						'/'
					})[0],
					ConfigurationManager.AppSettings["showbank_url"],
					"?id=",
					strTradeID,
					"&&PayType=",
					IsAllPayMent
				});
				return result;
			case "BankOnline.aspx":
				result = "PayReturn/BankSend.aspx?ID=" + strTradeID + "&&PayType=" + IsAllPayMent;
				return result;
			case "NetPayClient.aspx":
			{
				payInfo.Gateway = "http://payment.chinapay.com/pay/TransGet";
				payInfo.Mer_code = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.OrderNumber = strTradeID;
				PayInfo arg_FE5_0 = payInfo;
				int num = Convert.ToInt32(decimal.Parse(shouldPayPrice) * 100m);
				arg_FE5_0.ProductPrice = num.ToString();
				payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
				payInfo.SignType = "MD5";
				payInfo.ProductName = strTradeID;
				payInfo.Payment_type = IsAllPayMent;
				payInfo.Description = prNames;
				payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
				payInfo.Quantity = "1";
				payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
				payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
				payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["unionreturn_url"];
				payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["unionshow_url"];
				payInfo.Logistics_type = "EXPRESS";
				payInfo.Logistics_fee = "0";
				payInfo.Logistics_payment = "BUYER_PAY";
				payInfo.Show_url = "http://" + dourl;
				payInfo.OrderNumber = strTradeID;
				string text3;
				Encoding arg;
				pay.UnionNetPay(payInfo, out text3, out arg);
				result = arg + "|" + text3;
				return result;
			}
			case "ChinaPayClient.aspx":
				result = "/PayReturn/ChinaPay/ChinaPay_Post.aspx?Orid=" + strTradeID + "&sign=submit";
				return result;
			case "ABCPay.aspx":
			{
				payInfo.ABCOrderNO = strTradeID;
				payInfo.ABCExpiredDate = 10;
				payInfo.ABCOrderDesc = type;
				payInfo.ABCOrderDate = DateTime.Now.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
				payInfo.ABCOrderTime = DateTime.Now.ToString("hh:MM:ss");
				payInfo.ABCOrderAmount = double.Parse(shouldPayPrice);
				payInfo.ABCOrderURL = string.Format("http://{0}{1}", dourl, ConfigurationManager.AppSettings["abcsearch_url"]);
				payInfo.ABCBuyIP = "127.0.0.1";
				payInfo.ABCProductType = "1";
				payInfo.ABCPaymentType = "1";
				payInfo.ABCPaymentLinkType = "1";
				payInfo.ABCNotifyType = "1";
				payInfo.ABCResultNotifyURL = string.Format("http://{0}{1}?memloginid={2}&TradeID={3}&OperateType={4}&OrderAmount={5}", new object[]
				{
					dourl,
					ConfigurationManager.AppSettings["abcpayreceive_url"],
					memloginid,
					strTradeID,
					type,
					shouldPayPrice
				});
				payInfo.ABCMerchantRemarks = "";
				string text3;
				pay.ABCPayMent(payInfo, out text3);
				result = text3;
				return result;
			}
			case "CCBPay.aspx":
			{
				payInfo.CCBMerchantID = string.Format("{0}", paymentInfoByGuid.Rows[0]["MerchantCode"]);
				payInfo.CCBPosID = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecretKey"]);
				payInfo.CCBBranchID = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecondKey"]);
				payInfo.CCBOrderID = strTradeID;
				payInfo.CCBPayMent = shouldPayPrice;
				payInfo.CCBCurCode = "01";
				payInfo.CCBTxCode = "520100";
				payInfo.CCBRemark1 = type;
				payInfo.CCBRemark2 = memloginid;
				string text3;
				pay.CCBPay(payInfo, out text3);
				result = text3;
				return result;
			}
			case "Baofoo.aspx":
				result = "/PayReturn/Baofoo/Baofoopay_post.aspx?OrderNumber=" + strTradeID + "&price=" + shouldPayPrice;
				return result;
			case "ShengPay.aspx":
				result = string.Concat(new string[]
				{
					"/PayReturn/ShengPay/SP_Post.aspx?OrderNumber=",
					strTradeID,
					"&amount=",
					shouldPayPrice,
					"&sign=ShengPay"
				});
				return result;
			}
			result = "";
			return result;
		}
		private string method_0()
		{
			string result = "jely";
			if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				result = httpCookie.Values["MemLoginID"].ToString();
			}
			return result;
		}
		public string GetPayUrl(string shopid, string paymentGuid, string shouldPayPrice, string DispatchPrice, string dourl, string prNames, string strTradeID, string type, string IsAllPayMent, string PayMentMemloginID, string memloginid, string timetemp)
		{
			string text = string.Empty;
			ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
			DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid(paymentGuid);
			string result;
			if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
			{
				MessageBox.Show("支付有异常！");
				result = "";
			}
			else
			{
				text = paymentInfoByGuid.Rows[0]["PaymentType"].ToString();
				PayInfo payInfo = new PayInfo();
				Pay pay = new Pay();
				string text2 = text;
				if (text2 != null && text2 == "NetPayClient.aspx")
				{
					string empty = string.Empty;
					payInfo.SellerID = shopid;
					payInfo.Gateway = "http://payment.chinapay.com/pay/TransGet";
					payInfo.Mer_code = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
					payInfo.OrderNumber = strTradeID;
					payInfo.ProductPrice = Convert.ToInt32(decimal.Parse(shouldPayPrice) * 100m).ToString();
					payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
					payInfo.SignType = "MD5";
					payInfo.ProductName = strTradeID;
					payInfo.Payment_type = IsAllPayMent;
					payInfo.Description = prNames;
					payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
					payInfo.Quantity = "1";
					payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
					payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
					payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["unionreturn_url"];
					payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["unionshow_url"];
					payInfo.Logistics_type = "EXPRESS";
					payInfo.Logistics_fee = "0";
					payInfo.Logistics_payment = "BUYER_PAY";
					payInfo.Show_url = "http://" + dourl;
					payInfo.OrderNumber = strTradeID;
					Encoding arg;
					pay.UnionNetPay(payInfo, out empty, out arg);
					result = arg + "|" + empty;
				}
				else
				{
					result = "";
				}
			}
			return result;
		}
		public bool CheckSign(SortedDictionary<string, string> dicArrayPre, string sign)
		{
			Dictionary<string, string> dictionary_ = this.method_1(dicArrayPre);
			string a = this.method_2(dictionary_, "GB2312");
			return !(a != sign);
		}
		public string ConfimSendProduct(string partner, string trade_no, string LogisticsCompany, string ShipmentNumber)
		{
			ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
			DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
			string key = string.Empty;
			if (paymentKey.Rows.Count > 0)
			{
				key = paymentKey.Rows[0]["SecretKey"].ToString();
			}
			Submit._key = key;
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary.Add("partner", partner);
			sortedDictionary.Add("_input_charset", Config.Input_charset.ToLower());
			sortedDictionary.Add("service", "send_goods_confirm_by_platform");
			sortedDictionary.Add("trade_no", trade_no);
			sortedDictionary.Add("logistics_name", LogisticsCompany);
			sortedDictionary.Add("invoice_no", ShipmentNumber);
			sortedDictionary.Add("transport_type", "EXPRESS");
			File.AppendAllText(HttpContext.Current.Server.MapPath("/log/sendpost.txt"), string.Concat(new string[]
			{
				"partner:",
				partner,
				"|_input_charset:",
				Config.Input_charset.ToLower(),
				"|service:send_goods_confirm_by_platform|trade_no:",
				trade_no,
				"|logistics_name:",
				LogisticsCompany,
				"|invoice_no:",
				ShipmentNumber,
				"|transport_type:EXPRESS"
			}));
			return Submit.BuildRequest(sortedDictionary);
		}
		public string ConfimSendProduct2(string partner, string trade_no, string LogisticsCompany, string ShipmentNumber)
		{
			ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
			DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay2.aspx");
			string key = string.Empty;
			if (paymentKey.Rows.Count > 0)
			{
				key = paymentKey.Rows[0]["SecretKey"].ToString();
			}
			Submit._key = key;
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary.Add("partner", partner);
			sortedDictionary.Add("_input_charset", Config.Input_charset.ToLower());
			sortedDictionary.Add("service", "send_goods_confirm_by_platform");
			sortedDictionary.Add("trade_no", trade_no);
			sortedDictionary.Add("logistics_name", LogisticsCompany);
			sortedDictionary.Add("invoice_no", ShipmentNumber);
			sortedDictionary.Add("transport_type", "EXPRESS");
			File.AppendAllText(HttpContext.Current.Server.MapPath("/log/sendpost.txt"), string.Concat(new string[]
			{
				"partner:",
				partner,
				"|_input_charset:",
				Config.Input_charset.ToLower(),
				"|service:send_goods_confirm_by_platform|trade_no:",
				trade_no,
				"|logistics_name:",
				LogisticsCompany,
				"|invoice_no:",
				ShipmentNumber,
				"|transport_type:EXPRESS"
			}));
			return Submit.BuildRequest(sortedDictionary);
		}
		public string Sign(string prestr, string _input_charset)
		{
			prestr = "~(*&^%$#@!" + prestr + "shopnum1mall123456";
			StringBuilder stringBuilder = new StringBuilder(32);
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}
		private Dictionary<string, string> method_1(SortedDictionary<string, string> sortedDictionary_0)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> current in sortedDictionary_0)
			{
				if (current.Key.ToLower() != "sign" && current.Value != "")
				{
					dictionary.Add(current.Key.ToLower(), current.Value);
				}
			}
			return dictionary;
		}
		private string method_2(Dictionary<string, string> dictionary_0, string string_0)
		{
			string text = this.method_3(dictionary_0);
			int length = text.Length;
			text = text.Substring(0, length - 1);
			return this.Sign(text, string_0);
		}
		private string method_3(Dictionary<string, string> dictionary_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> current in dictionary_0)
			{
				stringBuilder.Append(current.Key + "=" + current.Value + "&");
			}
			return stringBuilder.ToString();
		}
	}
}
