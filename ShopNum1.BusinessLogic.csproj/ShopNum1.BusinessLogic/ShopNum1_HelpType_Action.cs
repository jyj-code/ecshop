using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_HelpType_Action : IShopNum1_HelpType_Action
	{
		public int Add(ShopNum1_HelpType shopNum1_HelpType)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_HelpType( Guid, Name, Remark, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime  ) VALUES (  '",
				shopNum1_HelpType.Guid,
				"',  '",
				Operator.FilterString(shopNum1_HelpType.Name),
				"',  '",
				Operator.FilterString(shopNum1_HelpType.Remark),
				"',  ",
				shopNum1_HelpType.OrderID,
				",  '",
				shopNum1_HelpType.CreateUser,
				"',getdate(),  '",
				shopNum1_HelpType.ModifyUser,
				"', getdate())"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "Delete FROM ShopNum1_Help Where HelpTypeGuid in (" + guids + ")";
			list.Add(item);
			item = "Delete FROM ShopNum1_HelpType Where Guid in (" + guids + ")";
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
		public DataTable GetEditInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  Name, Remark, OrderID FROM ShopNum1_HelpType Where Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetList()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[Guid],");
			stringBuilder.Append("[Name]");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_HelpType");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string name)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, Remark, OrderID,  CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_HelpType Where ";
			text += " IsDeleted = 0";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			text += " Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int update(ShopNum1_HelpType shopNum1_HelpType)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_HelpType SET  Name='",
				Operator.FilterString(shopNum1_HelpType.Name),
				"', Remark='",
				Operator.FilterString(shopNum1_HelpType.Remark),
				"', OrderID='",
				shopNum1_HelpType.OrderID,
				"', ModifyUser='",
				shopNum1_HelpType.ModifyUser,
				"', ModifyTime=getdate() WHERE Guid='",
				shopNum1_HelpType.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string IsDeleted, int showCount)
		{
			string strProcedureName = "[dbo].[Pro_ShopNum1_GetHelpType]";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showCount";
			array2[0] = showCount.ToString();
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, array, array2);
		}
	}
}
