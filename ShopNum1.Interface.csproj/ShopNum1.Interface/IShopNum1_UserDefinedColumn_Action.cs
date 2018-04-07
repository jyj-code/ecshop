using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_UserDefinedColumn_Action
	{
		DataTable Search(string Name);
		DataTable GetEditInfo(string guid);
		int Delete(string guid);
		int Insert(ShopNum1_UserDefinedColumn shopNum1_AgentUserDefinedColumn);
		int Update(ShopNum1_UserDefinedColumn shopNum1_AgentUserDefinedColumn);
		DataTable SearchMiddleNavigation(string showCount, int type, string SubstationID);
		DataTable SearchMiddleNavigation(string showCount);
		DataTable SearchMiddleNavigation(string showCount, int cout);
		DataTable GetButtomNavigation(string showCount);
		DataTable GetTopNavigation(string showCount);
	}
}
