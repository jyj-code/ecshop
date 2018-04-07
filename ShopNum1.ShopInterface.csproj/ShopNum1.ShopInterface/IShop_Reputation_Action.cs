using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Reputation_Action
	{
		DataTable Search(int isDeleted);
		DataTable Search(string type);
		DataTable ShopReputationSearch(string reputation, string isdeleted, string type);
		DataTable Search(string guid, int isDeleted);
		int Add(ShopNum1_ShopReputation ShopReputation);
		int Update(ShopNum1_ShopReputation ShopReputation);
		int Delete(string guids);
	}
}
