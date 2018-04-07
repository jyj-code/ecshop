using com.hitrust.trustpay.client;
using com.hitrust.trustpay.client.b2c;
using System;
namespace ShopNum1.Payment.ABCPay
{
	public class ABCPayMent
	{
		public bool GetUrlABCPayMent(PayInfo payInfo, out string strUrl)
		{
			Order order = new Order();
			order.OrderNo = payInfo.ABCOrderNO;
			order.ExpiredDate = payInfo.ABCExpiredDate;
			order.OrderDesc = payInfo.ABCOrderDesc;
			order.OrderDate = payInfo.ABCOrderDate;
			order.OrderTime = payInfo.ABCOrderTime;
			order.OrderAmount = payInfo.ABCOrderAmount;
			order.OrderURL = payInfo.ABCOrderURL;
			order.BuyIP = payInfo.ABCBuyIP;
			TrxResponse trxResponse = new PaymentRequest
			{
				Order = order,
				ProductType = payInfo.ABCProductType,
				PaymentType = payInfo.ABCPaymentType,
				PayLinkType = payInfo.ABCPaymentLinkType,
				NotifyType = payInfo.ABCNotifyType,
				ResultNotifyURL = payInfo.ABCResultNotifyURL,
				MerchantRemarks = payInfo.ABCMerchantRemarks
			}.postRequest();
			strUrl = string.Empty;
			bool result;
			if (result = trxResponse.isSuccess())
			{
				strUrl = trxResponse.getValue("PaymentURL");
			}
			return result;
		}
	}
}
