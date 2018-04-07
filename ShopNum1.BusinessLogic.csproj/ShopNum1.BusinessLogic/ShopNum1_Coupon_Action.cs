using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Coupon_Action : IShopNum1_Coupon_Action
	{
		public DataTable GetCouponTitleByAdressCode(string adresscode, string showcount)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@adresscode";
			array2[0] = adresscode;
			array[1] = "@showcount";
			array2[1] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByAdressCode", array, array2);
		}
		public DataTable GetCouponTitleByAdressCode(string adresscode, string showcount, string SubstationID)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@adresscode";
			array2[0] = adresscode;
			array[1] = "@showcount";
			array2[1] = showcount;
			array[2] = "@SubstationID";
			array2[2] = SubstationID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByAdressCode1", array, array2);
		}
		public DataSet SearchCouponByCategory(string category, string pagesize, string current_page)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@category";
			array2[0] = category;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@current_page";
			array2[2] = current_page;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchCouponByCategory", array, array2);
		}
		public DataTable GetCouponTitleByBrowserCount(string showcount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showcount";
			array2[0] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByBrowserCount", array, array2);
		}
		public DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc, string pagesize, string current_page, string isReturCount)
		{
			string text = "";
			if (!string.IsNullOrEmpty(category) && category != "-1")
			{
				text = " AND A.type=" + category;
			}
			if (!string.IsNullOrEmpty(addcode) && addcode != "-1")
			{
				text = text + " AND A.AdressCode like '" + addcode + "%' ";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perPageNum";
			array2[0] = pagesize;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.Guid,A.CouponName,A.MemLoginID,A.BrowserCount,A.Type,A.SaleTitle,A.ImgPath,B.shopID ";
			array[3] = "@OrderName";
			array2[3] = ordername;
			array[4] = "@searchName";
			array2[4] = text;
			array[5] = "@sDesc";
			array2[5] = sDesc;
			array[6] = "@isReturCount";
			array2[6] = isReturCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponByType", array, array2);
		}
		public DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc, string pagesize, string current_page, string isReturCount, string SubstationID)
		{
			string text = "";
			if (!string.IsNullOrEmpty(category) && category != "-1")
			{
				text = " AND A.type=" + category;
			}
			if (!string.IsNullOrEmpty(addcode) && addcode != "-1")
			{
				text = text + " AND A.AdressCode like '" + addcode + "%' ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  A.SubstationID= '" + SubstationID + "' ";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perPageNum";
			array2[0] = pagesize;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.Guid,A.CouponName,A.MemLoginID,A.BrowserCount,A.Type,A.SaleTitle,A.ImgPath,B.shopID ";
			array[3] = "@OrderName";
			array2[3] = ordername;
			array[4] = "@searchName";
			array2[4] = text;
			array[5] = "@sDesc";
			array2[5] = sDesc;
			array[6] = "@isReturCount";
			array2[6] = isReturCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponByType", array, array2);
		}
	}
}
