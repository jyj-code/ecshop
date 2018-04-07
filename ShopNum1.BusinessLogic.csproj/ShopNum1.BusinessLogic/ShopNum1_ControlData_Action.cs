using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ControlData_Action : IShopNum1_ControlData_Action
	{
		public DataTable Search(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("Href,");
			stringBuilder.Append("Image,");
			stringBuilder.Append("Price,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("GroupID,");
			stringBuilder.Append("DataType,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShow,");
			stringBuilder.Append("ControlGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_ControlData");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ControlGuid = '" + Operator.FilterString(guid) + "'");
			stringBuilder.Append(" ORDER BY OrderID DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetEditInfo(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("Href,");
			stringBuilder.Append("Image,");
			stringBuilder.Append("Price,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("GroupID,");
			stringBuilder.Append("DataType,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShow,");
			stringBuilder.Append("ControlGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_ControlData");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = " + guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Delete(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_ControlData WHERE [Guid] in (" + guid + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Insert(ShopNum1_ControlData shopNum1_ControlData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_ControlData(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("Href,");
			stringBuilder.Append("Image,");
			stringBuilder.Append("Price,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("GroupID,");
			stringBuilder.Append("DataType,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShow,");
			stringBuilder.Append("ControlGuid)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_ControlData.Guid + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.Title) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.Href) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.Image) + "',");
			stringBuilder.Append(Operator.FilterString(shopNum1_ControlData.Price) + ",");
			stringBuilder.Append(Operator.FilterString(shopNum1_ControlData.OrderID) + ",");
			stringBuilder.Append(Operator.FilterString(shopNum1_ControlData.GroupID) + ",");
			stringBuilder.Append(Operator.FilterString(shopNum1_ControlData.DataType) + ",");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.CreateUser) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.CreateTime) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.ModifyUser) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.ModifyTime) + "',");
			stringBuilder.Append(Operator.FilterString(shopNum1_ControlData.IsShow) + ",");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ControlData.ControlGuid) + "'");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(ShopNum1_ControlData shopNum1_ControlData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_ControlData");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("Title = '" + Operator.FilterString(shopNum1_ControlData.Title) + "',");
			stringBuilder.Append("Href = '" + Operator.FilterString(shopNum1_ControlData.Href) + "',");
			stringBuilder.Append("Image = '" + Operator.FilterString(shopNum1_ControlData.Image) + "',");
			stringBuilder.Append("Price = " + Operator.FilterString(shopNum1_ControlData.Price) + ",");
			stringBuilder.Append("OrderID = " + Operator.FilterString(shopNum1_ControlData.OrderID) + ",");
			stringBuilder.Append("GroupID = " + Operator.FilterString(shopNum1_ControlData.GroupID) + ",");
			stringBuilder.Append("DataType = " + Operator.FilterString(shopNum1_ControlData.DataType) + ",");
			stringBuilder.Append("ModifyUser = '" + shopNum1_ControlData.ModifyUser + "',");
			stringBuilder.Append("IsShow = " + Operator.FilterString(shopNum1_ControlData.IsShow) + ",");
			stringBuilder.Append("ModifyTime = '" + Operator.FilterString(shopNum1_ControlData.ModifyTime) + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = '" + shopNum1_ControlData.Guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetControlDataList(string controlGuid, string groupID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"Select * from ShopNum1_ControlData where ControlGuid='",
				controlGuid,
				"' AND  GroupID='",
				groupID,
				"' AND IsShow =1 order by OrderID asc"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
