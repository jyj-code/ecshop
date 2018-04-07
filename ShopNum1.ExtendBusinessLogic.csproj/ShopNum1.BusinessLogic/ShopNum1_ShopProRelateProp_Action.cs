using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopProRelateProp_Action : IShopNum1_ShopProRelateProp_Action
	{
		public int AddListPropValue(List<ShopNum1_ShopProRelateProp> ShopProRelateProp)
		{
			List<string> list = new List<string>();
			if (ShopProRelateProp != null)
			{
				list.Add("delete from ShopNum1_ShopProRelateProp where productguid='" + ShopProRelateProp[0].ProductGuid + "'");
				for (int i = 0; i < ShopProRelateProp.Count; i++)
				{
					string item = string.Concat(new object[]
					{
						"INSERT INTO dbo.ShopNum1_ShopProRelateProp \r\n        ( productguid ,\r\n          PCategoryID ,\r\n          CTypeID ,\r\n          ShowType,\r\n          PropID ,\r\n          PropValueID ,\r\n          InputValue\r\n        ) Values('",
						ShopProRelateProp[i].ProductGuid,
						"','",
						ShopProRelateProp[i].PCategoryID,
						"','",
						ShopProRelateProp[i].CTypeID,
						"','",
						ShopProRelateProp[i].ShowType,
						"','",
						ShopProRelateProp[i].PropID,
						"','",
						ShopProRelateProp[i].PropValueID,
						"','",
						ShopProRelateProp[i].InputValue,
						"')"
					});
					list.Add(item);
				}
			}
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
		public DataTable SelectProp(string strPid)
		{
			string strSql = "SELECT * FROM ShopNum1_ShopProRelateProp WHERE productguid='" + strPid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SelectPropByIdAndPid(string strId, string strPid)
		{
			string strSql = string.Concat(new string[]
			{
				"SELECT * FROM ShopNum1_ShopProRelateProp WHERE propid='",
				strId,
				"' and productguid='",
				strPid,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
