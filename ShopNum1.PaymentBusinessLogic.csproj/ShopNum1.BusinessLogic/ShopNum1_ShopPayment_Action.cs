using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopPayment_Action : IShopNum1_ShopPayment_Action
	{
		public DataTable Search(int isDeleted, string memloginID)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name,Memo,Charge,IsPercent  FROM ShopNum1_ShopPayment  WHERE memloginID='" + memloginID + "' ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string memloginid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, IsDeleted   FROM ShopNum1_ShopPayment WHERE memloginid='" + memloginid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_ShopPayment payment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"Insert into ShopNum1_ShopPayment( \tGuid\t,\tPaymentType\t,\tName\t,\tMerchantCode\t,\tSecretKey\t,\tSecondKey\t,\tPwd\t,\tPartner\t,\tCharge\t,\tEmail\t,\tIsPercent\t,\tMemo\t,\tIsCOD\t,\tOrderID\t,   memloginID ,\tIsDeleted   ) VALUES (  '",
				payment.Guid,
				"',  '",
				Operator.FilterString(payment.PaymentType),
				"',  '",
				Operator.FilterString(payment.Name),
				"',  '",
				Operator.FilterString(payment.MerchantCode),
				"',  '",
				payment.SecretKey,
				"',  '",
				payment.SecondKey,
				"',  '",
				payment.Pwd,
				"',  '",
				payment.Partner,
				"',  '",
				payment.Charge,
				"',  '",
				payment.Email,
				"',  ",
				payment.IsPercent,
				",  '",
				payment.Memo,
				"',  ",
				payment.IsCOD,
				",  ",
				payment.OrderID,
				",  '",
				payment.memloginID,
				"',  ",
				payment.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "Delete from ShopNum1_ShopPayment where guid in (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchPayInfo(string guid, int isdelete)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  IsDeleted    FROM ShopNum1_ShopPayment where 1=1 ";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " and guid=" + guid + " ";
			}
			if (isdelete == 0 || isdelete == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isdelete,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_ShopPayment payment, string guid, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ShopPayment SET  PaymentType='",
				payment.PaymentType,
				"', Name='",
				Operator.FilterString(payment.Name),
				"', MerchantCode='",
				Operator.FilterString(payment.MerchantCode),
				"', SecretKey='",
				Operator.FilterString(payment.SecretKey),
				"', SecondKey='",
				Operator.FilterString(payment.SecondKey),
				"', Pwd='",
				Operator.FilterString(payment.Pwd),
				"', Email='",
				Operator.FilterString(payment.Email),
				"', Memo='",
				Operator.FilterString(payment.Memo),
				"', IsPercent=",
				payment.IsPercent,
				", Charge='",
				Operator.FilterString(payment.Charge),
				"', IsCOD=",
				payment.IsCOD,
				", OrderID=",
				Operator.FilterString(payment.OrderID),
				", IsDeleted=",
				payment.IsDeleted,
				" WHERE Guid='",
				payment.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string GetPaymentType(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, PaymentType  FROM ShopNum1_ShopPayment WHERE Guid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["PaymentType"].ToString();
		}
		public DataTable GetPaymentInfoByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  IsDeleted    FROM ShopNum1_ShopPayment where 1=1 ";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " and guid='" + guid + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPaymentInfoByGuid(string guid, string memloginid)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  IsDeleted    FROM ShopNum1_ShopPayment where 1=1 ";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " and guid='" + guid + "' ";
			}
			if (Operator.FormatToEmpty(memloginid) != string.Empty && Operator.FormatToEmpty(memloginid) != "0")
			{
				text = text + " and memloginID='" + memloginid + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPaymentKey(string paymentType, string memloginid)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  memloginid ,  IsDeleted    FROM ShopNum1_ShopPayment where 1=1 ";
			text = string.Concat(new string[]
			{
				text,
				" and PaymentType='",
				paymentType,
				"' and memloginid='",
				memloginid,
				"' "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string PaymentType, string memloginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"Delete from ShopNum1_ShopPayment where   PaymentType='",
				PaymentType,
				"'  AND   memloginID ='",
				memloginID,
				"'  "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetDataInfo(string PaymentType, string memloginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT * FROM   ShopNum1_ShopPayment    WHERE    PaymentType='",
				PaymentType,
				"'  AND   memloginID ='",
				memloginID,
				"'  "
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
