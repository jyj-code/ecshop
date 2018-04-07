using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public interface IShopNum1_SpecificationProudctCategory_Action
	{
		int Insert(string string_0, string productcategoryid, string productcategorycode, string specificationid);
		bool Check(string productcategoryid);
		bool InsertMuch(string productcategoryid, string productcategorycode, string specificationid);
		string GetSpecNamesString(string productcategoryid);
		DataTable GetSpecs(string productcategoryid);
		int DeleteByProductCategoryID(string productCategoryID);
	}
}
