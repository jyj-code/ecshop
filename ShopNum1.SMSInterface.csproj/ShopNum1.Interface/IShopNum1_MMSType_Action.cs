using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_MMSType_Action
	{
		int Add(ShopNum1_MMSType emailtype);
		int Delete(string guids);
		DataTable Search(string typename, int isDeleted);
		DataTable GetEditInfo(string guid, int isDeleted);
		int Update(string guid, ShopNum1_MMSType emailtype);
	}
}
