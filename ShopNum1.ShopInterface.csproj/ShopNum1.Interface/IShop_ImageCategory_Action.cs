using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShop_ImageCategory_Action
	{
		int Delete(string string_0);
		int Insert(string CreateUser, string name, string description, string sort);
		int Update(string strid, string name, string description, string sort);
		DataTable Select(string strType, string strMemloginId);
		DataTable Select_AllType(string strMemloginId);
		string Get_TypeName(string strId);
		DataTable dt_Album_Import(string strMemloginId);
		int UpdateAlbumImg(string strTypeId, string strImgPath);
	}
}
