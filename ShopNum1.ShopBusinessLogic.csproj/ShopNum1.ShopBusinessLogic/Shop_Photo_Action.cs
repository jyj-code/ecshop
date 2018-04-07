using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Photo_Action : IShop_Photo_Action
	{
		public int AddPhoto(ShopNum1_Shop_Photo photo)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@name";
			array2[0] = photo.Name;
			array[1] = "@photopath";
			array2[1] = photo.PhotoPath;
			array[2] = "@remark";
			array2[2] = photo.AlbumsGuid;
			array[3] = "@albumsguid";
			array2[3] = photo.AlbumsGuid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddPhoto", array, array2);
		}
		public DataTable EditPhoto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_EditPhoto", array, array2);
		}
		public int UpdatePhoto(ShopNum1_Shop_Photo photo)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = photo.Guid.ToString();
			array[1] = "@name";
			array2[1] = photo.Name;
			array[2] = "@photopath";
			array2[2] = photo.PhotoPath;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdatePhoto", array, array2);
		}
		public DataTable SearchPhotoList(string albumsguid, string showcount)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@albumsguid";
			array2[0] = albumsguid;
			array[1] = "@showcount";
			array2[1] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchPhotoList", array, array2);
		}
		public int DeletePhoto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeletePhoto", array, array2);
		}
	}
}
