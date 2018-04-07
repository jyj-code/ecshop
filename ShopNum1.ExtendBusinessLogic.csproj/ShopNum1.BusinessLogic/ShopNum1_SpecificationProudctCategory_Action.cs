using ShopNum1.DataAccess;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SpecificationProudctCategory_Action : IShopNum1_SpecificationProudctCategory_Action
	{
		public int Insert(string string_0, string productcategoryid, string productcategorycode, string specificationid)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@id";
			array2[0] = string_0;
			array[1] = "@productcategoryid";
			array2[1] = productcategoryid;
			array[2] = "@productcategorycode";
			array2[2] = productcategorycode;
			array[3] = "@specificationid";
			array2[3] = specificationid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_SpecificationProudctCategoryInsert", array, array2);
		}
		public bool InsertMuch(string productcategoryid, string productcategorycode, string specificationid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@productcategoryid";
			array2[0] = productcategoryid;
			array[1] = "@productcategorycode";
			array2[1] = productcategorycode;
			array[2] = "@specificationid";
			array2[2] = specificationid;
			int num = DatabaseExcetue.RunProcedure("Pro_ShopNum1_SpecificationProudctCategoryInsertMuch", array, array2);
			return num > 0;
		}
		public bool Check(string productcategoryid)
		{
			string strSql = "SELECT COUNT(ID) AS AllCount FROM dbo.ShopNum1_SpecificationProudctCategory WHERE ProductCategoryID=@ProductCategoryID";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productcategoryid";
			array2[0] = productcategoryid;
			return DatabaseExcetue.CheckExists(strSql, array, array2);
		}
		public string GetSpecNamesString(string productcategoryid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productcategoryid";
			array2[0] = productcategoryid;
			object obj = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_SpecificationProudctCategoryGetName", array, array2);
			string result;
			if (obj == null)
			{
				result = string.Empty;
			}
			else
			{
				result = obj.ToString();
			}
			return result;
		}
		public DataTable GetSpecs(string productcategoryid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productcategoryid";
			array2[0] = productcategoryid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecificationProdCategoryGetspecs", array, array2);
		}
		public int DeleteByProductCategoryID(string productCategoryID)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_SpecificationProudctCategory where ProductCategoryID=" + productCategoryID + " ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
