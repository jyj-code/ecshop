using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SpecProudct_Action
	{
		DataTable dt_SpecProducts(string strPid);
		DataTable dt_SpecProducts(string strPid, string strCtype, string strV);
		DataTable dt_SpecProducts(string strPid, string strSpecDetail);
		int AddListSpecProducts(List<ShopNum1_SpecProudct> SpecificationProudcts);
		int UpdateListSpecProducts(List<ShopNum1_SpecProudct> SpecificationProudcts);
		int DeleteSpecProduct(string strPGuID);
		DataTable GetSpecificationByProduct(string productGuid, string Detail);
	}
}
