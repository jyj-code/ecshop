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
	public class ShopNum1_Shipper_Action : IShopNum1_Shipper_Action
	{
		public DataTable Search()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("ShipperName,");
			stringBuilder.Append("SendName,");
			stringBuilder.Append("Address,");
			stringBuilder.Append("Mobile,");
			stringBuilder.Append("Phone,");
			stringBuilder.Append("PostalCode,");
			stringBuilder.Append("IsDefault,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("ShopID");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shipper");
			stringBuilder.Append(" ORDER BY CreateTime DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetEditInfo(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("ShipperName,");
			stringBuilder.Append("SendName,");
			stringBuilder.Append("Address,");
			stringBuilder.Append("Mobile,");
			stringBuilder.Append("Phone,");
			stringBuilder.Append("PostalCode,");
			stringBuilder.Append("IsDefault,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("RegionCode");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shipper");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = " + guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Delete(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_Shipper WHERE [Guid] in (" + guid + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Insert(ShopNum1_Shipper shopNum1_Shipper)
		{
			List<string> list = new List<string>();
			if (shopNum1_Shipper.IsDefault == 1)
			{
				list.Add("UPDATE ShopNum1_Shipper Set IsDefault=0 WHERE IsDefault=1");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_Shipper(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("ShipperName,");
			stringBuilder.Append("SendName,");
			stringBuilder.Append("Address,");
			stringBuilder.Append("Mobile,");
			stringBuilder.Append("Phone,");
			stringBuilder.Append("PostalCode,");
			stringBuilder.Append("IsDefault,");
			stringBuilder.Append("Remark,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,regioncode,ShopID)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_Shipper.Guid + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.ShipperName) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.SendName) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.Address) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.Mobile) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.Phone) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.PostalCode) + "',");
			stringBuilder.Append("'" + shopNum1_Shipper.IsDefault + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.Remark) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.CreateUser) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.CreateTime) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Shipper.ModifyUser) + "',");
			stringBuilder.Append(string.Concat(new string[]
			{
				"'",
				Operator.FilterString(shopNum1_Shipper.ModifyTime),
				"','",
				Operator.FilterString(shopNum1_Shipper.RegionCode),
				"','",
				Operator.FilterString(shopNum1_Shipper.ShopId),
				"')"
			}));
			list.Add(stringBuilder.ToString());
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
		public int Update(ShopNum1_Shipper shopNum1_Shipper)
		{
			List<string> list = new List<string>();
			if (shopNum1_Shipper.IsDefault == 1)
			{
				list.Add("UPDATE ShopNum1_Shipper Set IsDefault=0 WHERE IsDefault=1 AND Guid!='" + shopNum1_Shipper.Guid + "'");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_Shipper");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("ShipperName = '" + Operator.FilterString(shopNum1_Shipper.ShipperName) + "',");
			stringBuilder.Append("SendName = '" + Operator.FilterString(shopNum1_Shipper.SendName) + "',");
			stringBuilder.Append("Address = '" + Operator.FilterString(shopNum1_Shipper.Address) + "',");
			stringBuilder.Append("Mobile = '" + Operator.FilterString(shopNum1_Shipper.Mobile) + "',");
			stringBuilder.Append("Phone = '" + Operator.FilterString(shopNum1_Shipper.Phone) + "',");
			stringBuilder.Append("PostalCode = '" + Operator.FilterString(shopNum1_Shipper.PostalCode) + "',");
			stringBuilder.Append("IsDefault = '" + shopNum1_Shipper.IsDefault + "',");
			stringBuilder.Append("Remark = '" + Operator.FilterString(shopNum1_Shipper.Remark) + "',");
			stringBuilder.Append("ModifyUser = '" + Operator.FilterString(shopNum1_Shipper.ModifyUser) + "',");
			stringBuilder.Append("ModifyTime = '" + Operator.FilterString(shopNum1_Shipper.ModifyTime) + "',");
			stringBuilder.Append("regioncode = '" + Operator.FilterString(shopNum1_Shipper.RegionCode) + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = '" + shopNum1_Shipper.Guid + "'");
			list.Add(stringBuilder.ToString());
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
		public DataTable Search(string condititon)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Select *  FROM ShopNum1_Shipper WHERE 1=1 ");
			if (!string.IsNullOrEmpty(condititon))
			{
				stringBuilder.Append(condititon);
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
