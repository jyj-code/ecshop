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
	public class ShopNum1_AttachMentCategory_Action : IShopNum1_AttachMentCategory_Action
	{
		public DataTable Search()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("CategoryName,");
			stringBuilder.Append("Description,");
			stringBuilder.Append("Isdeleted ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_AttachMentCateGory");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" Isdeleted = 0");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataRow EditShow(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("CategoryName,");
			stringBuilder.Append("Description");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_AttachMentCateGory");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = " + guid);
			stringBuilder.Append(" AND Isdeleted = 0");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0];
		}
		public int Delete(string guid)
		{
			List<string> list = new List<string>();
			string text = "DELETE FROM ShopNum1_AttachMent WHERE AssociatedCategoryGuid in (" + guid + ")";
			list.Add(text);
			text = "DELETE FROM ShopNum1_AttachMentCateGory WHERE [Guid] in (" + guid + ")";
			list.Add(text);
			int result;
			try
			{
				DatabaseExcetue.CheckExists(text);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Update(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_AttachMentCateGory");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("CateGoryName = '" + Operator.FilterString(shopNum1_AttachMentCateGory.CateGoryName) + "',");
			stringBuilder.Append("[Description] ='" + Operator.FilterString(shopNum1_AttachMentCateGory.Description) + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] = '" + shopNum1_AttachMentCateGory.Guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Insert(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ");
			stringBuilder.Append("ShopNum1_AttachMentCateGory(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("CateGoryName,");
			stringBuilder.Append("[Description],");
			stringBuilder.Append("[Isdeleted] )");
			stringBuilder.Append("VALUES(");
			stringBuilder.Append("'" + shopNum1_AttachMentCateGory.Guid + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_AttachMentCateGory.CateGoryName) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_AttachMentCateGory.Description) + "',");
			stringBuilder.Append("0 )");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
	}
}
