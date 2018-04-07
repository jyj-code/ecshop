using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Photo_Action
	{
		int AddPhoto(ShopNum1_Shop_Photo photo);
		DataTable EditPhoto(string guid);
		int UpdatePhoto(ShopNum1_Shop_Photo photo);
		DataTable SearchPhotoList(string albumsguid, string showcount);
		int DeletePhoto(string guid);
	}
}
