using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Image_Action : IShopNum1_Image_Action
	{
		public DataTable Search(string imageType, string name, int isDeleted, string imageCategoryID)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, ImageType, ImagePath, Description, UseTimes, CreateUser, CreateTime,ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Image WHERE 0=0";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name Like '%" + Operator.FilterString(name) + "%'";
			}
			if (Operator.FormatToEmpty(imageType) != string.Empty && imageType != "-1")
			{
				text = text + " AND ImageType='" + imageType + "' ";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			if (imageCategoryID != "0")
			{
				text = text + " AND ImageCategoryID=" + imageCategoryID + " ";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid,ImagePath,ImageType,Name,ImageCategoryID,Description FROM ShopNum1_Image WHERE 0=0 AND Guid IN (" + guid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_Image shopnum1_image, string imageCategoryID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert ShopNum1_Image(  Guid, Name, ImageType, ImagePath, Description, UseTimes, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted, ImageCategoryID, IsDownload ) VALUES (  '",
				shopnum1_image.Guid,
				"',  '",
				Operator.FilterString(shopnum1_image.Name),
				"',  '",
				shopnum1_image.ImageType,
				"',  '",
				shopnum1_image.ImagePath,
				"',  '",
				Operator.FilterString(shopnum1_image.Description),
				"',  ",
				shopnum1_image.UseTimes,
				",  '",
				shopnum1_image.CreateUser,
				"',   '",
				shopnum1_image.CreateTime,
				"',   '",
				shopnum1_image.ModifyUser,
				"',   '",
				shopnum1_image.ModifyTime,
				"',   ",
				shopnum1_image.IsDeleted,
				", ",
				imageCategoryID,
				", ",
				0,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Image WHERE Guid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchImageByType(string imageType, string name, int isDeleted, string imageCategoryID, string pagesize, string current_page, string isReturCount)
		{
			string text = "";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name Like '%" + Operator.FilterString(name) + "%'";
			}
			if (Operator.FormatToEmpty(imageType) != string.Empty && imageType != "-1")
			{
				text = text + " AND ImageType='" + imageType + "' ";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			if (imageCategoryID != "0")
			{
				text = text + " AND ImageCategoryID=" + imageCategoryID + " ";
			}
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@perPageNum";
			array2[0] = pagesize;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " Guid, Name, ImageType, ImagePath, Description, CreateTime,IsDeleted";
			array[3] = "@searchName";
			array2[3] = text;
			array[4] = "@isReturCount";
			array2[4] = isReturCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchImageByType", array, array2);
		}
		public int Update(ShopNum1_Image shopnum1_image)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Image  SET  [Name] = '",
				shopnum1_image.Name,
				"' ,[ImageType] = '",
				shopnum1_image.ImageType,
				"' ,[ImagePath] = '",
				shopnum1_image.ImagePath,
				"' ,[Description] ='",
				shopnum1_image.Description,
				"' ,[ModifyUser] = '",
				shopnum1_image.ModifyUser,
				"' ,[ModifyTime] = '",
				shopnum1_image.ModifyTime,
				"' ,[ImageCategoryID] = '",
				shopnum1_image.ImageCategoryID,
				"' WHERE guid='",
				shopnum1_image.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateName(string strGuid, string strNewName)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Image SET Name='",
				strNewName,
				"' WHERE Guid='",
				strGuid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
