using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Image_Action
	{
		DataTable Search(string imageType, string name, int isDeleted, string imageCategoryID);
		DataTable Search(string guid);
		int Add(ShopNum1_Image shopNum1_Image, string imageCategoryID);
		int Delete(string guids);
		DataTable SearchImageByType(string imageType, string name, int isDeleted, string imageCategoryID, string pagesize, string current_page, string isReturCount);
		int Update(ShopNum1_Image shopnum1_image);
		int UpdateName(string strGuid, string strNewName);
	}
}
