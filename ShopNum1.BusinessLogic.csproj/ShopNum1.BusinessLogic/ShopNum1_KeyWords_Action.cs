using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_KeyWords_Action : IShopNum1_KeyWords_Action
	{
		public int Add(ShopNum1_KeyWords shopnum1_keywords)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert ShopNum1_KeyWords(  Guid, Name, Count, Type, IfShow, CreateUser, CreateTime, ModifyUser, ModifyTime, SubstationID, IsDeleted ) VALUES (  '",
				shopnum1_keywords.Guid,
				"',  '",
				Operator.FilterString(shopnum1_keywords.Name),
				"',  ",
				shopnum1_keywords.Count,
				",  ",
				shopnum1_keywords.Type,
				",  ",
				shopnum1_keywords.IfShow,
				",  '",
				shopnum1_keywords.CreateUser,
				"',   '",
				shopnum1_keywords.CreateTime,
				"',   '",
				shopnum1_keywords.ModifyUser,
				"',   '",
				shopnum1_keywords.ModifyTime,
				"',   '",
				shopnum1_keywords.SubstationID,
				"',   ",
				shopnum1_keywords.IsDeleted,
				"  )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable CheckIsExist(string name, int type)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT  Guid, Name,Type,Count   FROM ShopNum1_KeyWords WHERE Name='",
				Operator.FilterString(name),
				"'  AND Type =",
				type
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Delete(string guid)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_KeyWords WHERE Guid IN (" + guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, Type, Count, IfShow,  CreateUser, CreateTime,ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_KeyWords WHERE Guid =" + guid + " ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string name, string count, int type, int ifshow, int isDelete)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, Type, Count, IfShow,  CreateUser, CreateTime,ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_KeyWords WHERE 1=1 ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name Like '%" + Operator.FilterString(name) + "%'";
			}
			if (type == 0 || type == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND Type=",
					type,
					" "
				});
			}
			if (Operator.FormatToEmpty(count) != string.Empty)
			{
				text = text + " AND Count= '" + Operator.FilterString(count) + "' ";
			}
			if (ifshow == 0 || ifshow == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IfShow=",
					ifshow,
					" "
				});
			}
			if (isDelete == 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDelete,
					" "
				});
			}
			text += " Order By CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string name, string count, int type, int ifshow, int isDelete, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, Type, Count, IfShow,  CreateUser, CreateTime,ModifyUser, ModifyTime, IsDeleted,SubstationID FROM ShopNum1_KeyWords WHERE 1=1 ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name Like '%" + Operator.FilterString(name) + "%'";
			}
			if (type == 0 || type == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND Type=",
					type,
					" "
				});
			}
			if (Operator.FormatToEmpty(count) != string.Empty)
			{
				text = text + " AND Count= '" + Operator.FilterString(count) + "' ";
			}
			if (ifshow == 0 || ifshow == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IfShow=",
					ifshow,
					" "
				});
			}
			if (isDelete == 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDelete,
					" "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  SubstationID='" + SubstationID + "'  ";
			}
			text += " Order By CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchName(int count, int type)
		{
			string text = string.Empty;
			if (count > 0)
			{
				text = "SELECT top " + count + " Guid, Name, Type, Count , IsDeleted FROM ShopNum1_KeyWords WHERE  IfShow =1 AND IsDeleted=0  ";
			}
			else
			{
				text = "SELECT  Guid, Name, Type, Count, IsDeleted FROM ShopNum1_KeyWords WHERE  IfShow =1 AND IsDeleted=0  ";
			}
			text += "ORDER BY Count DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchName(int count, int type, string SubstationID)
		{
			string text = string.Empty;
			if (count > 0)
			{
				text = string.Concat(new object[]
				{
					"SELECT top ",
					count,
					" Guid, Name, Type, Count , IsDeleted FROM ShopNum1_KeyWords WHERE  IfShow =1 AND IsDeleted=0   AND  SubstationID='",
					SubstationID,
					"'  "
				});
			}
			else
			{
				text = "SELECT  Guid, Name, Type, Count, IsDeleted FROM ShopNum1_KeyWords WHERE  IfShow =1 AND IsDeleted=0   AND  SubstationID='" + SubstationID + "'     ";
			}
			text += "ORDER BY Count DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_KeyWords shopnum1_keywords)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_KeyWords SET  Name='",
				Operator.FilterString(shopnum1_keywords.Name),
				"', Type='",
				shopnum1_keywords.Type,
				"', Count=",
				shopnum1_keywords.Count,
				", IfShow='",
				shopnum1_keywords.IfShow,
				"', ModifyUser='",
				shopnum1_keywords.ModifyUser,
				"', ModifyTime='",
				shopnum1_keywords.ModifyTime,
				"'WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateCount(string name, int type, int count)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_KeyWords SET  Count=",
				count,
				", ModifyUser='",
				string.Empty,
				"', ModifyTime='",
				DateTime.Now,
				"' WHERE Name='",
				Operator.FilterString(name),
				"'  AND Type =",
				type
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetKeyWords(string showCount)
		{
			string strProcedureName = "Pro_ShopNum1_GetKeyWords";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showCount";
			array2[0] = showCount;
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, array, array2);
		}
	}
}
