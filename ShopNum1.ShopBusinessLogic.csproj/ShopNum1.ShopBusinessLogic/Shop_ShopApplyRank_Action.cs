using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ShopApplyRank_Action : IShop_ShopApplyRank_Action
	{
		public DataTable Add(ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank)
		{
			string[] array = new string[9];
			string[] array2 = new string[9];
			array[0] = "@rankguid";
			array2[0] = shopNum1_Shop_ApplyShopRank.RankGuid.ToString();
			array[1] = "@memberloginid";
			array2[1] = shopNum1_Shop_ApplyShopRank.MemberLoginID;
			array[2] = "@isaudit";
			array2[2] = shopNum1_Shop_ApplyShopRank.IsAudit.ToString();
			array[3] = "@applytime";
			array2[3] = shopNum1_Shop_ApplyShopRank.ApplyTime.ToString();
			array[4] = "@ispayment";
			array2[4] = shopNum1_Shop_ApplyShopRank.IsPayMent.ToString();
			array[5] = "@paymentname";
			array2[5] = shopNum1_Shop_ApplyShopRank.PaymentName;
			array[6] = "@paymenttype";
			array2[6] = shopNum1_Shop_ApplyShopRank.PaymentType.ToString();
			array[7] = "@RankName";
			array2[7] = shopNum1_Shop_ApplyShopRank.RankName;
			array[8] = "@VerifyTime";
			array2[8] = shopNum1_Shop_ApplyShopRank.VerifyTime.ToString();
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ApplyShopRankAdd", array, array2);
		}
		public int Check(int ID, int isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@id";
			array2[0] = ID.ToString();
			array[1] = "@isaudit";
			array2[1] = isaudit.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_ApplyShopRankCheck", array, array2);
		}
		public int Check(string ID, string isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@id";
			array2[0] = ID.ToString();
			array[1] = "@isaudit";
			array2[1] = isaudit.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_ApplyShopRankCheck", array, array2);
		}
		public int Delete(string ID)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_ApplyShopRank WHERE ID IN(" + ID + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopRankApply(string memLoginID, int isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memLoginID;
			array[1] = "@isaudit";
			array2[1] = isaudit.ToString();
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ApplyShopRankList", array, array2);
		}
		public int UpdataShopRank(int ID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"update dbo.ShopNum1_ShopInfo SET ShopRank=(select RankGuid from dbo.ShopNum1_Shop_ApplyShopRank where ID=",
				ID,
				")  where MemLoginID=(select MemberLoginID from dbo.ShopNum1_Shop_ApplyShopRank where ID=",
				ID,
				") "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdataShopRank(string ID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update dbo.ShopNum1_ShopInfo SET ShopRank=(select RankGuid from dbo.ShopNum1_Shop_ApplyShopRank where ID in(",
				ID,
				"))  where MemLoginID=(select MemberLoginID from dbo.ShopNum1_Shop_ApplyShopRank where ID in(",
				ID,
				")) "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable CheckIsApply(string guid, string memloginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT IsPayMent,ID FROM ShopNum1_Shop_ApplyShopRank WHERE RankGuid='",
				guid,
				"' AND MemberLoginID='",
				memloginID,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetShopRankByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankByGuid", array, array2);
		}
		public DataTable ShopRankPayInfoByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ShopRankPayInfoByGuid", array, array2);
		}
		public int UpdataShopRankPayStatusByID(string string_0)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = string_0;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataShopRankPayStatusByID", array, array2);
		}
		public int UpdataShopRankPayMentByID(string string_0, string PayMentType, string PayMentName)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@id";
			array2[0] = string_0;
			array[1] = "@PayMentType";
			array2[1] = PayMentType;
			array[2] = "@PayMentName";
			array2[2] = PayMentName;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataShopRankPayMentByID", array, array2);
		}
		public int CheckIsPayMentByID(string string_0)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = string_0;
			return DatabaseExcetue.RunProcedure("Pro_Shop_CheckShopRankIsPayMentByID", array, array2);
		}
		public DataTable CheckIsApplyOk(string guid, string memloginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT *   FROM ShopNum1_Shop_ApplyShopRank WHERE RankGuid='",
				guid,
				"' AND MemberLoginID='",
				memloginID,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable CheckIsApplyMax(string memloginID)
		{
			string text = string.Empty;
			text = "  SELECT MAX(B.RankValue) FROM ShopNum1_Shop_ApplyShopRank AS A  LEFT JOIN ShopNum1_ShopRank AS  B    ";
			text += "  ON A.RankGuid=b.Guid    ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  WHERE  A.MemberLoginID ='",
				memloginID,
				"'  AND  A.VerifyTime >'",
				DateTime.Now,
				"'    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetNowLv(string memloginID)
		{
			string strSql = string.Empty;
			strSql = "  SELECT *   FROM ShopNum1_Shop_ApplyShopRank  WHERE  MemberLoginID='" + memloginID + "'    ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int DeleteOutRankGuid(string RankGuid, string MemberLoginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   DELETE   ShopNum1_Shop_ApplyShopRank  WHERE  MemberLoginID='",
				MemberLoginID,
				"' AND  RankGuid NOT IN ('",
				RankGuid,
				"')      "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdataShopRank(string RankGuid, string MemberLoginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"    UPDATE    ShopNum1_ShopInfo  SET  ShopRank='",
				RankGuid,
				"'   WHERE     MemLoginID='",
				MemberLoginID,
				"'      "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdataVerifyTime(string VerifyTime, string MemberLoginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"    UPDATE    ShopNum1_Shop_ApplyShopRank  SET  VerifyTime='",
				VerifyTime,
				"'   WHERE    MemberLoginID='",
				MemberLoginID,
				"'      "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
