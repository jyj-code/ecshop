using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Payment_Action : IShopNum1_Payment_Action
	{
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name,Memo,Charge,IsPercent,PaymentType FROM ShopNum1_Payment  WHERE 0 =0 ";
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
		public DataTable Search()
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, PaymentType,  ForAdvancePayment,IsDeleted   FROM ShopNum1_Payment WHERE  IsDeleted=0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchPre()
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, PaymentType, IsDeleted   FROM ShopNum1_Payment WHERE PaymentType ='PreDeposits.aspx'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_Payment payment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"Insert into ShopNum1_Payment( \tGuid\t,\tPaymentType\t,\tName\t,\tMerchantCode\t,\tSecretKey\t,\tSecondKey\t,\tPwd\t,\tPartner\t,\tCharge\t,\tEmail\t,\tIsPercent\t,\tMemo\t,\tIsCOD\t,\tOrderID\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tForAdvancePayment\t,\tIsDeleted   ) VALUES (  '",
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
				payment.CreateUser,
				"',  '",
				payment.CreateTime,
				"',  '",
				payment.ModifyUser,
				"',  '",
				payment.ModifyTime,
				"',  ",
				payment.ForAdvancePayment,
				",  ",
				payment.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchMobile(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name,Memo,Charge,IsPercent,PaymentType,paytype,private_key,public_key  FROM ShopNum1_MobilePayment  WHERE 0 =0 ";
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
		public int AddMobile(ShopNum1_MobilePayment payment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"Insert into ShopNum1_MobilePayment( \tGuid\t,\tPaymentType\t,\tName\t,\tMerchantCode\t,\tSecretKey\t,\tSecondKey\t,\tPwd\t,\tPartner\t,\tCharge\t,\tEmail\t,\tIsPercent\t,\tMemo\t,\tIsCOD\t,\tOrderID\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tForAdvancePayment\t,\tIsDeleted,  \tprivate_key,  \tpublic_key,  \tpaytype  ) VALUES (  '",
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
				payment.CreateUser,
				"',  '",
				payment.CreateTime,
				"',  '",
				payment.ModifyUser,
				"',  '",
				payment.ModifyTime,
				"',  ",
				payment.ForAdvancePayment,
				",  '",
				payment.IsDeleted,
				"',  '",
				payment.private_key,
				"',  '",
				payment.public_key,
				"',  '",
				payment.paytype,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteMobile(string guids)
		{
			string strSql = string.Empty;
			strSql = "Delete from ShopNum1_MobilePayment where guid in (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "Delete from ShopNum1_Payment where guid in (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchPayInfo(string guid, int isdelete)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  ForAdvancePayment ,  IsDeleted    FROM ShopNum1_Payment where 1=1 ";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " and guid='" + guid + "' ";
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
		public DataTable SearchPayInfoMobile(string guid, int isdelete)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  ForAdvancePayment ,  IsDeleted,private_key,public_key,paytype    FROM ShopNum1_MobilePayment where 1=1 ";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " and guid='" + guid + "' ";
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
		public int Update(ShopNum1_Payment payment, string guid, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Payment SET  PaymentType='",
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
				", ModifyUser='",
				payment.ModifyUser,
				"', ModifyTime='",
				payment.ModifyTime,
				"', ForAdvancePayment=",
				payment.ForAdvancePayment,
				", IsDeleted=",
				payment.IsDeleted,
				" WHERE Guid='",
				payment.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateMobile(ShopNum1_MobilePayment payment, string guid, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_MobilePayment SET  PaymentType='",
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
				", ModifyUser='",
				payment.ModifyUser,
				"', ModifyTime='",
				payment.ModifyTime,
				"', ForAdvancePayment=",
				payment.ForAdvancePayment,
				", IsDeleted=",
				payment.IsDeleted,
				", private_key='",
				payment.private_key,
				"', public_key='",
				payment.public_key,
				"', paytype='",
				payment.paytype,
				"' WHERE Guid='",
				payment.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string GetPaymentType(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, PaymentType  FROM ShopNum1_Payment WHERE Guid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["PaymentType"].ToString();
		}
		public DataTable GetPaymentInfoByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  IsDeleted    FROM ShopNum1_Payment where 1=1 ";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " and guid='" + guid + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPaymentKey(string paymentType)
		{
			string text = string.Empty;
			text = "SELECT  PaymentType ,  Name ,  MerchantCode ,  SecretKey ,  SecondKey ,  Pwd ,  Partner ,  Charge ,  Email ,  IsPercent ,  Memo ,  IsCOD ,  OrderID ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  IsDeleted    FROM ShopNum1_Payment where 1=1 ";
			text = text + " and PaymentType='" + paymentType + "' ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetShopPayMentByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT IsPayMentShop from ShopNum1_ShopInfo where guid ='" + guid + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public int UpdataShopPayMentByGuid(string guid, string IsPayMentShop)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_ShopInfo SET IsPayMentShop=",
				IsPayMentShop,
				" where guid ='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchnotPreDeposits()
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, PaymentType,  ForAdvancePayment,IsDeleted   FROM ShopNum1_Payment WHERE  IsDeleted=0 and paymenttype!='PreDeposits.aspx'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable PaymentTypeName(string PaymentType)
		{
			string text = string.Empty;
			text = "   SELECT * FROM  ShopNum1_PaymentType  WHERE 1=1   ";
			if (!string.IsNullOrEmpty(PaymentType))
			{
				text = text + "   AND   PaymentType ='" + PaymentType + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchType()
		{
			string strSql = string.Empty;
			strSql = "   SELECT * FROM  ShopNum1_PaymentType  WHERE 1=1   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchTypeByGuid(string guid)
		{
			string text = string.Empty;
			text += "   SELECT * FROM  ShopNum1_PaymentType  WHERE 1=1   ";
			text = text + "   AND  Guid='" + guid + "'    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpDatePaymentType(ShopNum1_PaymentType PaymentType)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_PaymentType SET  PaymentType='",
				PaymentType.PaymentType,
				"', Name='",
				Operator.FilterString(PaymentType.Name),
				"', BakcImg='",
				PaymentType.BakcImg,
				"', Memo='",
				Operator.FilterString(PaymentType.Memo),
				"', OrderID='",
				PaymentType.OrderID,
				"', IsShopUse='",
				PaymentType.IsShopUse,
				"' WHERE Guid='",
				PaymentType.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchByShop(int ForAdvancePayment)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, PaymentType,  ForAdvancePayment,IsDeleted   FROM ShopNum1_Payment WHERE  IsDeleted=0";
			if (ForAdvancePayment == 1 || ForAdvancePayment == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"  AND   ForAdvancePayment =",
					ForAdvancePayment,
					"   "
				});
			}
			text += "    ORDER  BY   OrderID DESC     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int InsertPayRecord(ShopNum1_ThreePaymentRecord record)
		{
			int result;
			try
			{
				DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(DatabaseExcetue.GetConnstring());
				using (dataClassesDataContext)
				{
					dataClassesDataContext.ShopNum1_ThreePaymentRecord.InsertOnSubmit(record);
					dataClassesDataContext.SubmitChanges();
				}
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public List<ShopNum1_ThreePaymentRecord> SelectPaymentRecords()
		{
			DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(DatabaseExcetue.GetConnstring());
			return dataClassesDataContext.ShopNum1_ThreePaymentRecord.ToList<ShopNum1_ThreePaymentRecord>();
		}
	}
}
