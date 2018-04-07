using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_PackAge_Action
	{
		int OpPackAge(ShopNum1_PackAge ShopNum1_PackAge, List<ShopNum1_PackAgeRalate> listPackAgeRalate);
		DataTable SelectPackAgeProduct(string pagesize, string currentpage, string condition, string resultnum, string sortvalue, string ordercolumn, string strColumns, string strTabName);
		DataSet GetPackAgeInfo(string strPackAgeId, string strMemloginID);
		int DeletePackAgeInfo(string strPackAgeId, string strProductGuID);
		DataSet GetPackAgeProduct(string strPackAgeId, string strProductGuID);
		int DeletePackAge(string strPackAgeId, string strMemloginId);
	}
}
