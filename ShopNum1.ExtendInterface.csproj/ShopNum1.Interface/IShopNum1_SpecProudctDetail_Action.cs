using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SpecProudctDetail_Action
	{
		int AddListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials);
		int UpdateListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials, string strDelSpecId, string strNewSpec);
		DataTable GetDetailByDGuid(string guids, string productguid);
		string GetSpecImageBySpecId(string strProductGuId, string strSpecId);
		DataTable GetDetailByDGuid(string strGuids);
		string SearchName(string strId);
	}
}
