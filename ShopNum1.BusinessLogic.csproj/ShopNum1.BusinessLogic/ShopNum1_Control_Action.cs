using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
using System.Web;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Control_Action : IShopNum1_Control_Action
	{
		public DataTable Search(string PageName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("PageName,");
			stringBuilder.Append("PageFileName,");
			stringBuilder.Append("ControlName,");
			stringBuilder.Append("ControlFileName,");
			stringBuilder.Append("ControlKey,");
			stringBuilder.Append("ControlImg,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShow");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Control");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" PageName like '%" + Operator.FilterString(PageName) + "%'");
			stringBuilder.Append(" ORDER BY CreateTime DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetEditInfo(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("PageName,");
			stringBuilder.Append("PageFileName,");
			stringBuilder.Append("ControlName,");
			stringBuilder.Append("ControlFileName,");
			stringBuilder.Append("ControlKey,");
			stringBuilder.Append("ControlImg,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShow");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Control");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = " + guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Delete(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_Control WHERE [Guid] in (" + guid + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Insert(ShopNum1_Control shopNum1_Control)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_Control(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("PageName,");
			stringBuilder.Append("PageFileName,");
			stringBuilder.Append("ControlName,");
			stringBuilder.Append("ControlFileName,");
			stringBuilder.Append("ControlKey,");
			stringBuilder.Append("ControlImg,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime,");
			stringBuilder.Append("IsShow)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_Control.Guid + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.PageName) + "',");
			stringBuilder.Append("'" + shopNum1_Control.PageFileName + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.ControlName) + "',");
			stringBuilder.Append("'" + shopNum1_Control.ControlFileName + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.ControlKey) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.ControlImg) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.CreateUser) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.CreateTime) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.ModifyUser) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_Control.ModifyTime) + "',");
			stringBuilder.Append(Operator.FilterString(shopNum1_Control.IsShow) ?? "");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(ShopNum1_Control shopNum1_Control)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_Control");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("PageName = '" + Operator.FilterString(shopNum1_Control.PageName) + "',");
			stringBuilder.Append("PageFileName = '" + shopNum1_Control.PageFileName + "',");
			stringBuilder.Append("ControlName = '" + Operator.FilterString(shopNum1_Control.ControlName) + "',");
			stringBuilder.Append("ControlFileName = '" + shopNum1_Control.ControlFileName + "',");
			stringBuilder.Append("ControlKey = '" + Operator.FilterString(shopNum1_Control.ControlKey) + "',");
			stringBuilder.Append("ControlImg = '" + Operator.FilterString(shopNum1_Control.ControlImg) + "',");
			stringBuilder.Append("IsShow = '" + shopNum1_Control.IsShow + "',");
			stringBuilder.Append("ModifyUser = '" + shopNum1_Control.ModifyUser + "',");
			stringBuilder.Append("ModifyTime = '" + Operator.FilterString(shopNum1_Control.ModifyTime) + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = '" + shopNum1_Control.Guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetControlGuid(string controlKey)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"Select Guid from ShopNum1_Control where PageFileName='",
				HttpContext.Current.Request.Path.Substring(HttpContext.Current.Request.Path.LastIndexOf('/') + 1),
				"' and ControlKey='",
				controlKey,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
