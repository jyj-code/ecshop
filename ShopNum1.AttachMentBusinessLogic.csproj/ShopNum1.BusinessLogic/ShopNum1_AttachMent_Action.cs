using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_AttachMent_Action : IShopNum1_AttachMent_Action
	{
		public DataTable Search(string AssociatedCategoryGuid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.AttachmentURL,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.UploadTime,");
			stringBuilder.Append("b.CategoryName");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_AttachMent as a,");
			stringBuilder.Append("ShopNum1_AttachMentCateGory as b");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("a.AssociatedCategoryGuid = b.Guid ");
			if (AssociatedCategoryGuid != "-1")
			{
				stringBuilder.Append(" and a.AssociatedCategoryGuid = '" + AssociatedCategoryGuid + "'");
			}
			stringBuilder.Append(" ORDER BY a.UploadTime DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataRow SearchAttachMent(string Guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("AttachmentURL,");
			stringBuilder.Append("Description,");
			stringBuilder.Append("AssociatedCategoryGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_AttachMent");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("Guid = " + Guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0];
		}
		public int Delete(string Guid)
		{
			string strSql = "DELETE FROM ShopNum1_AttachMent WHERE [Guid] in (" + Guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Insert(ShopNum1_AttachMent shopNum1_AttachMent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_AttachMent(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("AttachmentURL,");
			stringBuilder.Append("Description,");
			stringBuilder.Append("UploadTime,");
			stringBuilder.Append("AssociatedCategoryGuid )");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_AttachMent.Guid + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_AttachMent.Title) + "',");
			stringBuilder.Append("'" + shopNum1_AttachMent.AttachmentURL + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_AttachMent.Description) + "',");
			stringBuilder.Append("getdate(),");
			stringBuilder.Append("'" + shopNum1_AttachMent.AssociatedCategoryGuid + "' )");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
	}
}
