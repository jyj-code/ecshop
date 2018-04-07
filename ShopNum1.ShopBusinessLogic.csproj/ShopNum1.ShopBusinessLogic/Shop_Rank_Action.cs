using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Rank_Action : IShop_Rank_Action
	{
		public DataTable Search(int isDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tGuid, \tName, \tRankValue,    MaxProductCount ,   MaxFileCount ,   StartTime ,\tvalidityDate, \tprice, \tPic,    shopTemplate ,   IsOverrideDomain ,\tMaxSpellBuyCount, \tMaxPanicBuyCount,   MaxArticleCout,\tMaxVedioCount, \tIsDefault, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopRank   WHERE IsDeleted = " + isDeleted + " Order By RankValue ASC ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable ShopRankSearch(string name)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@name";
			array2[0] = name;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopRankSearch", array, array2);
		}
		public DataTable Search(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid, \tName, \tRankValue,    MaxProductCount ,   MaxFileCount ,   StartTime ,\tvalidityDate, \tprice, \tPic,    shopTemplate ,   IsOverrideDomain ,\tMaxSpellBuyCount, \tMaxPanicBuyCount,   MaxArticleCout,\tMaxVedioCount, \tIsDefault, \tIsSetSEO, \tCreateUser, \tCreateTime\t, \tModifyUser, \tRankValue\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopRank   WHERE 0=0 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted = ",
					isDeleted,
					" "
				});
			}
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND Guid = " + guid + " ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_ShopRank shopRank)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ShopRank( \tGuid, \tName,    MaxProductCount ,   MaxFileCount ,   StartTime ,\tvalidityDate, \tprice, \tPic,    shopTemplate ,   IsOverrideDomain ,\tMaxSpellBuyCount, \tMaxPanicBuyCount,    MaxArticleCout,\tMaxVedioCount, \tIsDefault, \tIsSetSEO, \tCreateUser, \tCreateTime\t, \tRankValue\t, \tIsDeleted  ) VALUES (  '",
				shopRank.Guid,
				"',  '",
				Operator.FilterString(shopRank.Name),
				"',  ",
				Operator.FilterString(shopRank.MaxProductCount),
				",  ",
				Operator.FilterString(shopRank.MaxFileCount),
				",  '",
				Operator.FilterString(shopRank.StartTime),
				"',  '",
				Operator.FilterString(shopRank.validityDate),
				"',  '",
				Operator.FilterString(shopRank.price),
				"', '",
				shopRank.Pic,
				"', '",
				Operator.FilterString(shopRank.shopTemplate),
				"',  ",
				shopRank.IsOverrideDomain,
				",  ",
				Operator.FilterString(shopRank.MaxSpellBuyCount),
				",  ",
				Operator.FilterString(shopRank.MaxPanicBuyCount),
				",  ",
				Operator.FilterString(shopRank.MaxArticleCout),
				", ",
				Operator.FilterString(shopRank.MaxVedioCount),
				",  ",
				shopRank.IsDefault,
				", ",
				shopRank.IsSetSEO,
				", '",
				shopRank.CreateUser,
				"', '",
				shopRank.CreateTime,
				"',  '",
				shopRank.RankValue,
				"',  ",
				shopRank.IsDeleted,
				")"
			});
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Update(ShopNum1_ShopRank shopRank)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_ShopRank SET  Name='",
				Operator.FilterString(shopRank.Name),
				"', MaxProductCount=",
				Operator.FilterString(shopRank.MaxProductCount),
				", MaxFileCount=",
				Operator.FilterString(shopRank.MaxFileCount),
				", StartTime='",
				Operator.FilterString(shopRank.StartTime),
				"', validityDate='",
				Operator.FilterString(shopRank.validityDate),
				"', price='",
				Operator.FilterString(shopRank.price),
				"', Pic='",
				shopRank.Pic,
				"', shopTemplate='",
				Operator.FilterString(shopRank.shopTemplate),
				"', IsOverrideDomain=",
				Operator.FilterString(shopRank.IsOverrideDomain),
				", MaxSpellBuyCount=",
				Operator.FilterString(shopRank.MaxSpellBuyCount),
				", MaxPanicBuyCount=",
				Operator.FilterString(shopRank.MaxPanicBuyCount),
				", MaxArticleCout=",
				Operator.FilterString(shopRank.MaxArticleCout),
				", MaxVedioCount=",
				Operator.FilterString(shopRank.MaxVedioCount),
				", IsDefault=",
				Operator.FilterString(shopRank.IsDefault),
				", IsSetSEO=",
				Operator.FilterString(shopRank.IsSetSEO),
				", ModifyUser='",
				shopRank.ModifyUser,
				"', RankValue='",
				shopRank.RankValue,
				"', ModifyTime='",
				shopRank.ModifyTime,
				"' WHERE Guid='",
				shopRank.Guid,
				"'"
			});
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			string strSql2 = string.Empty;
			string strSql3 = string.Empty;
			strSql = "SELECT  COUNT(*) AS NUM FROM ShopNum1_ShopRank WHERE IsDefault=0 AND Guid IN(" + guids + ")";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["NUM"].ToString() != "0")
			{
				return -1;
			}
			strSql2 = "SELECT COUNT(*) AS NUM FROM ShopNum1_ShopInfo WHERE ShopRank in (" + guids + ")";
			DataTable dataTable2 = DatabaseExcetue.ReturnDataTable(strSql2);
			if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["NUM"].ToString() != "0")
			{
				return -2;
			}
			strSql3 = "DELETE FROM ShopNum1_ShopRank  WHERE  Guid IN(" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql3);
		}
		public DataTable GetDefaultRank()
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopDefaultRank");
		}
		public int EditIsDefault()
		{
			string strSql = string.Empty;
			strSql = "update ShopNum1_ShopRank set IsDefault=1 where IsDefault=0";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopRankByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT NAME,pic FROM ShopNum1_ShopRank WHERE GUID=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetShopRank()
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid,NAME,price FROM ShopNum1_ShopRank ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetTemplateByRankGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetTemplateByRankGuid", array, array2);
		}
		public DataTable GetShopRankInfoByMemLoginID(string memloginid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Guid,A.Name,A.price,B.IsPayMent FROM ShopNum1_ShopRank AS A LEFT JOIN ShopNum1_Shop_ApplyShopRank AS B ON A.Guid=B.RankGuid AND B.MemberLoginID='" + memloginid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetDefaultTemplate()
		{
			string strSql = string.Empty;
			strSql = "SELECT *  FROM ShopNum1_Shop_Template WHERE   IsDefault=1";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetTemplateByPath(string Path)
		{
			string strSql = string.Empty;
			strSql = "   SELECT * FROM  ShopNum1_Shop_Template  WHERE  Path='" + Path + "'    ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateUserRank(string ShopRank, string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   UPDATE  ShopNum1_ShopInfo  SET  ShopRank='",
				ShopRank,
				"'  WHERE  MemLoginID='",
				MemLoginID,
				"'  "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int ClearApplyShopRank(string MemberLoginID)
		{
			string strSql = string.Empty;
			strSql = "      DELETE  ShopNum1_Shop_ApplyShopRank    WHERE   MemberLoginID='" + MemberLoginID + "'     ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopRankPrice(string Guid)
		{
			string strSql = string.Empty;
			strSql = "   SELECT   price     FROM  ShopNum1_ShopRank  WHERE  Guid='" + Guid + "'    ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
