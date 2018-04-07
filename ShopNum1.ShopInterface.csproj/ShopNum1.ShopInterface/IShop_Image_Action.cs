using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Image_Action
	{
		int Insert(ShopNum1_Shop_Image shopNum1_Shop_Image);
		DataTable Select_List(int PageSize, int CurrentPage, int ResultNum, string strName, string strOrderType, string strTypeId, string strCreateUser);
		DataTable dt_Album_Page(string PageSize, string currentpage, string condition, string resultnum);
		DataSet MangeShopImg(string pagesize, string currentpage, string condition, string resultnum);
		int DeleteShopImg(string strID);
		int DeleteSelectImg(List<ShopNum1_Shop_Image> shopImg);
		DataTable Shop_ImgUser();
		int UpdateImgName(string strName, string strId, string strMemloginId);
	}
}
