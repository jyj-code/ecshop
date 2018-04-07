using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Image_Type_Action
	{
		DataTable Search(string name, int isDeleted);
		DataTable GetEditInfo(string guid);
		int Add(ShopNum1_Image_Type shopnum1_image_type);
		int Update(string guid, ShopNum1_Image_Type shopnum1_image_type);
		int Delete(string guids);
	}
}
