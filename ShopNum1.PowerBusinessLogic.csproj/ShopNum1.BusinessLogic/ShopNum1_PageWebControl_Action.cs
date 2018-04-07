using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_PageWebControl_Action : IShopNum1_PageWebControl_Action
	{
		public DataTable Search(string pageGuid, string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Guid, \tName\t,\tPageGuid\t,\tControlID\t,\tControlType\t,\tDescription\t,\tCreateUser\t,\tCreateTime\t,\tModifyUser\t,\tModifyTime\t,\tIsDeleted FROM ShopNum1_PageWebControl  WHERE 0=0 ";
			if (Operator.FormatToEmpty(pageGuid) != string.Empty)
			{
				text = text + " AND PageGuid='" + Operator.FilterString(pageGuid) + "'";
			}
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND Guid='" + Operator.FilterString(guid) + "'";
			}
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
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_PageWebControl pageWebControl)
		{
			string strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_PageWebControl( Guid,  Name,  PageGuid,  ControlID,  ControlType,  Description, CreateUser, CreateTime,  ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				pageWebControl.Guid,
				"',  '",
				Operator.FilterString(pageWebControl.Name),
				"',  '",
				pageWebControl.PageGuid,
				"',  '",
				pageWebControl.ControlID,
				"',  '",
				pageWebControl.ControlType,
				"',  '",
				Operator.FilterString(pageWebControl.Description),
				"', '",
				pageWebControl.CreateUser,
				"',  '",
				pageWebControl.CreateTime,
				"',  '",
				pageWebControl.ModifyUser,
				"' , '",
				pageWebControl.ModifyTime,
				"',  ",
				pageWebControl.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_PageWebControl pageWebControl)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_PageWebControl SET  ControlType='",
				pageWebControl.ControlType,
				"', ControlID='",
				pageWebControl.ControlID,
				"', Name='",
				Operator.FilterString(pageWebControl.Name),
				"', Description='",
				Operator.FilterString(pageWebControl.Description),
				"', ModifyUser='",
				pageWebControl.ModifyUser,
				"', ModifyTime='",
				pageWebControl.ModifyTime,
				"' WHERE Guid='",
				pageWebControl.Guid,
				"'"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_GroupPageWebControl SET ControlType='",
				pageWebControl.ControlType,
				"', ControlID='",
				pageWebControl.ControlID,
				"', ModifyUser='",
				pageWebControl.ModifyUser,
				"', ModifyTime='",
				pageWebControl.ModifyTime,
				"' WHERE  PageWebControlGuid='",
				pageWebControl.Guid,
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
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "DELETE FROM ShopNum1_PageWebControl WHERE Guid IN (" + guids + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_GroupPageWebControl WHERE Guid IN (" + guids + ")";
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
	}
}
