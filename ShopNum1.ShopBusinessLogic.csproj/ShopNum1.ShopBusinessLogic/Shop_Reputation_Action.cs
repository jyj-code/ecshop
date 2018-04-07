using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Reputation_Action : IShop_Reputation_Action
	{
		public DataTable Search(int isDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopReputation   WHERE IsDeleted = " + isDeleted + " Order By CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string type)
		{
			string text = string.Empty;
			text = "SELECT \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopReputation   WHERE IsDeleted = 0 ";
			if (type != "-1")
			{
				text = text + " And Type=" + type;
			}
			text += " Order By minScore";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int GetMaxScore()
		{
			return DatabaseExcetue.ReturnMaxID("maxScore", "ShopNum1_ShopReputation");
		}
		public DataTable ShopReputationSearch(string shopReputation, string isdeleted, string type)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@shopReputation";
			array2[0] = shopReputation;
			array[1] = "@isdeleted";
			array2[1] = isdeleted;
			array[2] = "@type";
			array2[2] = type;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopReputationSearch", array, array2);
		}
		public DataTable Search(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopReputation   WHERE 0=0 ";
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
		public int Add(ShopNum1_ShopReputation Shop_Reputation)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ShopReputation( \tGuid, \tName,    minScore ,   maxScore ,   Pic ,\tMemo, \tType, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted  ) VALUES (  '",
				Shop_Reputation.Guid,
				"',  '",
				Operator.FilterString(Shop_Reputation.Name),
				"',  ",
				Shop_Reputation.minScore,
				",  ",
				Shop_Reputation.maxScore,
				",  '",
				Shop_Reputation.Pic,
				"',  '",
				Operator.FilterString(Shop_Reputation.Memo),
				"',  ",
				Shop_Reputation.Type,
				", '",
				Shop_Reputation.CreateUser,
				"', '",
				Shop_Reputation.CreateTime,
				"',  '",
				Shop_Reputation.ModifyUser,
				"' , '",
				Shop_Reputation.ModifyTime,
				"',  ",
				Shop_Reputation.IsDeleted,
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
		public int Update(ShopNum1_ShopReputation Shop_Reputation)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_ShopReputation SET  Name='",
				Operator.FilterString(Shop_Reputation.Name),
				"', minScore=",
				Operator.FilterString(Shop_Reputation.minScore),
				", maxScore=",
				Operator.FilterString(Shop_Reputation.maxScore),
				", Pic='",
				Shop_Reputation.Pic,
				"', Memo='",
				Operator.FilterString(Shop_Reputation.Memo),
				"', Type=",
				Shop_Reputation.Type,
				", ModifyUser='",
				Shop_Reputation.ModifyUser,
				"', ModifyTime='",
				Shop_Reputation.ModifyTime,
				"' WHERE Guid='",
				Shop_Reputation.Guid,
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
			strSql = "DELETE FROM ShopNum1_ShopReputation  WHERE  Guid IN(" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
