using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_CategoryChecked_Action : IShopNum1_CategoryChecked_Action
	{
		private static DataTable dataTable_0 = null;
		public static DataTable CategoryTable
		{
			get
			{
				if (ShopNum1_CategoryChecked_Action.dataTable_0 == null)
				{
					string strSql = "SELECT ID,[Name],[Code],OrderID,FatherID FROM ShopNum1_Category WHERE IsDeleted=0 and isshow=1 ORDER BY OrderID DESC";
					ShopNum1_CategoryChecked_Action.dataTable_0 = DatabaseExcetue.ReturnDataTable(strSql);
				}
				return ShopNum1_CategoryChecked_Action.dataTable_0;
			}
			set
			{
				ShopNum1_CategoryChecked_Action.dataTable_0 = null;
			}
		}
		public DataTable Search(string Code, string isAudit)
		{
			return null;
		}
		public int Update(string guids, string state)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_CategoryInfo");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("IsAudit = " + state);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] in (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" SELECT AssociatedMemberID ");
			stringBuilder.Append("FROM  ShopNum1_CategoryInfo");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] = '" + guids + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_CategoryInfo ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("[Guid] IN ");
			stringBuilder.Append("(" + guids + ") ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetList(string categoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[ID],");
			stringBuilder.Append("[Name],");
			stringBuilder.Append("[code]");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Category");
			stringBuilder.Append(" WHERE fatherID=" + categoryID);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public string GetMemberID(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select AssociatedMemberID from dbo.ShopNum1_CategoryInfo WHERE guid=" + guid);
			return DatabaseExcetue.ReturnString(stringBuilder.ToString());
		}
		public int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_CategoryInfo");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("Title = '" + Operator.FilterString(shopNum1_CategoryInfo.Title) + "',");
			stringBuilder.Append("Type = '" + Operator.FilterString(shopNum1_CategoryInfo.Type) + "',");
			stringBuilder.Append("Content = '" + Operator.FilterString(shopNum1_CategoryInfo.Content) + "',");
			stringBuilder.Append("Keywords = '" + Operator.FilterString(shopNum1_CategoryInfo.Keywords) + "',");
			stringBuilder.Append("ValidTime = '" + Operator.FilterString(shopNum1_CategoryInfo.ValidTime) + "',");
			stringBuilder.Append("Tel = '" + Operator.FilterString(shopNum1_CategoryInfo.Tel) + "',");
			stringBuilder.Append("Email = '" + Operator.FilterString(shopNum1_CategoryInfo.Email) + "',");
			stringBuilder.Append("OtherContactWay = '" + Operator.FilterString(shopNum1_CategoryInfo.OtherContactWay) + "',");
			stringBuilder.Append("AssociatedCategoryGuid = '" + shopNum1_CategoryInfo.AssociatedCategoryGuid + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" Guid = '" + shopNum1_CategoryInfo.Guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetCategoryNewList(string showCount)
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetNewShopNum1CategoryInfo", "@showCount", showCount);
		}
		public DataTable GetCategoryDetails(string guid)
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CategoryInfoDetail", "@guid", guid);
		}
		public DataTable SearchByType(string code, string showCount)
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryInfoByType", new string[]
			{
				"@code",
				"@showCount"
			}, new string[]
			{
				code,
				showCount
			});
		}
		public DataSet Search(string pageindex, string pagesize, string addresscode, string associatedcategoryguid, string createtime1, string createtime2, string keywords, string title)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pageindex";
			array2[0] = pageindex;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@addresscode";
			array2[2] = addresscode;
			array[3] = "@associatedcategoryguid";
			array2[3] = associatedcategoryguid;
			array[4] = "@createtime1";
			array2[4] = createtime1;
			array[5] = "@createtime2";
			array2[5] = createtime2;
			array[6] = "@keywords";
			array2[6] = keywords;
			array[7] = "@title";
			array2[7] = title;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetCategoryInfoSearch", array, array2);
		}
		public int AddCategoryInfo(ShopNum1_CategoryInfo categoryInfo)
		{
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@title";
			array2[0] = categoryInfo.Title;
			array[1] = "@type";
			array2[1] = categoryInfo.Type.ToString();
			array[2] = "@content";
			array2[2] = categoryInfo.Content;
			array[3] = "@keywords";
			array2[3] = categoryInfo.Keywords;
			array[4] = "@validtime";
			array2[4] = categoryInfo.ValidTime;
			array[5] = "@createtime";
			array2[5] = categoryInfo.CreateTime.ToString();
			array[6] = "@tel";
			array2[6] = categoryInfo.Tel;
			array[7] = "@email";
			array2[7] = categoryInfo.Email;
			array[8] = "@othercontactway";
			array2[8] = categoryInfo.OtherContactWay;
			array[9] = "@associatedcategoryguid";
			array2[9] = categoryInfo.AssociatedCategoryGuid;
			array[10] = "@associatedmemberid";
			array2[10] = categoryInfo.AssociatedMemberID;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddCategoryInfo", array, array2);
		}
		public DataTable Search(string MemberID)
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryInfo", "@memberID", MemberID);
		}
		public DataTable SearchCategoryInfo(string memloginid, string isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@isaudit";
			array2[1] = isaudit;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCategoryInfo", array, array2);
		}
		public DataTable EditCategoryInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_EditCategoryInfo", array, array2);
		}
		public int UpdateCategoryInfo(ShopNum1_CategoryInfo categoryInfo)
		{
			string[] array = new string[10];
			string[] array2 = new string[10];
			array[0] = "@guid";
			array[1] = "@title";
			array[2] = "@type";
			array[3] = "@content";
			array[4] = "@keywords";
			array[5] = "@validTime";
			array[6] = "@tel";
			array[7] = "@email";
			array[8] = "@otherContactWay";
			array[9] = "@associatedCategoryGuid";
			array2[0] = categoryInfo.Guid.ToString();
			array2[1] = categoryInfo.Title;
			array2[2] = categoryInfo.Type.ToString();
			array2[3] = categoryInfo.Content;
			array2[4] = categoryInfo.Keywords;
			array2[5] = categoryInfo.ValidTime;
			array2[6] = categoryInfo.Tel;
			array2[7] = categoryInfo.Email;
			array2[8] = categoryInfo.OtherContactWay;
			array2[9] = categoryInfo.AssociatedCategoryGuid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateCategoryInfo", array, array2);
		}
		public DataTable GetCategoryByCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryByCode", array, array2);
		}
		public DataTable GetCategoryOnAndNext(string guid, string onCategoryName, string nextCategoryName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @CreateTime datetime ");
			stringBuilder.Append("SELECT @CreateTime = CreateTime FROM ShopNum1_CategoryInfo ");
			stringBuilder.Append("WHERE Guid = '" + guid + "' ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 Guid,Title,'" + onCategoryName + "' as [Name] FROM ShopNum1_CategoryInfo ");
			stringBuilder.Append("WHERE CreateTime < @CreateTime ");
			stringBuilder.Append("ORDER BY CreateTime DESC");
			stringBuilder.Append(") as a ");
			stringBuilder.Append("UNION ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 Guid,Title,'" + nextCategoryName + "' as [Name] FROM ShopNum1_CategoryInfo ");
			stringBuilder.Append("WHERE CreateTime > @CreateTime and IsAudit=1");
			stringBuilder.Append(" ORDER BY CreateTime ASC ");
			stringBuilder.Append(") as b");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Add(ShopNum1_CategoryInfo categoryInfo)
		{
			throw new NotImplementedException();
		}
		public DataTable GetCategoryInfoMeto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryInfoMeto", array, array2);
		}
		public DataTable Search(int fatherID, int isDeleted, string ShowCount)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT TOP  ",
				ShowCount,
				"\t[ID]\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_Category  WHERE  FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchByCategoryIDFrist(string CategoryCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT  TOP 1 Guid,Title,Description,Content FROM ShopNum1_CategoryInfo where AssociatedCategoryGuid like  '" + CategoryCode + "%'");
			stringBuilder.Append("AND IsAudit = 1 ");
			stringBuilder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
			stringBuilder.Append(" ORDER BY ValidTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showCount + " Guid,Title,Description,Content, ValidTime,CreateTime ");
			stringBuilder.Append(" FROM ShopNum1_CategoryInfo ");
			stringBuilder.Append(" where AssociatedCategoryGuid like  '" + CategoryCode + "%'");
			stringBuilder.Append("AND IsAudit = 1 ");
			stringBuilder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
			stringBuilder.Append(" ORDER BY ShopNum1_CategoryInfo.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataSet Search(string perpagenum, string current_page, string supplyName, string supplyCategoryCode, string supplyAddressCode, string ordername, string isreturcount)
		{
			string text = string.Empty;
			if (supplyCategoryCode != "-1")
			{
				text = " AND A.AssociatedCategoryGuid like '" + Operator.FilterString(supplyCategoryCode) + "%'";
			}
			if (supplyName != "-1")
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(supplyName) + "%'";
			}
			if (supplyAddressCode != "-1")
			{
				text = text + " AND A.AddressCode LIKE '%" + Operator.FilterString(supplyAddressCode) + "%'";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.Guid,A.Title,A.Content,A.Description,A.Keywords,A.CreateTime,A.ValidTime,A.AssociatedCategoryGuid,A.AddressCode,A.AddressValue,A.AssociatedCategoryName,A.AssociatedMemberID ";
			array[3] = "@OrderName";
			array2[3] = " A.CreateTime ";
			array[4] = "@searchName";
			array2[4] = text;
			array[5] = "@sDesc";
			array2[5] = "";
			array[6] = "@isReturCount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetCategoryListSearch", array, array2);
		}
	}
}
