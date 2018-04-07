using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_MMSType_Action : IShopNum1_MMSType_Action
	{
		public int Add(ShopNum1_MMSType mMSType)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MMSType( Guid, TypeName, Description, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				mMSType.Guid,
				"',  '",
				Operator.FilterString(mMSType.TypeName),
				"',  '",
				Operator.FilterString(mMSType.Description),
				"',  '",
				mMSType.CreateUser,
				"', '",
				mMSType.CreateTime,
				"',  '",
				mMSType.ModifyUser,
				"' , '",
				mMSType.ModifyTime,
				"',  ",
				mMSType.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "Delete from ShopNum1_MMS where TypeName in ( " + guids + " )";
			list.Add(item);
			item = "DELETE FROM ShopNum1_MMSType WHERE  Guid in ( " + guids + " )";
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
		public DataTable GetEditInfo(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "select Guid,TypeName,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_MMSType where Guid=" + guid;
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
		public DataTable Search(string typename, int isDeleted)
		{
			string text = string.Empty;
			text = "select Guid,TypeName,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_MMSType where 0=0";
			if (typename != string.Empty)
			{
				text = text + " AND TypeName Like '%" + Operator.FilterString(typename) + "%'";
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
			text += "Order By CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_MMSType mMSType)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_MMSType SET  TypeName='",
				Operator.FilterString(mMSType.TypeName),
				"', Description='",
				Operator.FilterString(mMSType.Description),
				"', ModifyUser='",
				mMSType.ModifyUser,
				"', ModifyTime='",
				mMSType.ModifyTime,
				"'WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
