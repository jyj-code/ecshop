using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Friends_Action
	{
		DataTable GetFriendList(string memloginid);
		int UpdateFriend(string memloginid, string memberfriends);
		int AddFriend(string memloginid, string memberfriends);
	}
}
