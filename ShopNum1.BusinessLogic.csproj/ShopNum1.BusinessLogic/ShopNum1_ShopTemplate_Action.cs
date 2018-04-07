using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopTemplate_Action : IShopNum1_ShopTemplate_Action
	{
		public int Add(ShopNum1_Shop_Template shopNum1_Shop_Template)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Shop_Template( \tName\t, \tPath\t, \tMeto\t, \tMoney\t, \tValidDay\t, \tIsDefault\t, \tIsForbid\t, \tTemplateImg\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted\t  ) VALUES (  '",
				Operator.FilterString(shopNum1_Shop_Template.Name),
				"',  '",
				shopNum1_Shop_Template.Path,
				"',  '",
				Operator.FilterString(shopNum1_Shop_Template.Meto),
				"',  '",
				Operator.FilterString(shopNum1_Shop_Template.Money),
				"',  ",
				Operator.FilterString(shopNum1_Shop_Template.ValidDay),
				",  ",
				Operator.FilterString(shopNum1_Shop_Template.IsDefault),
				",  ",
				shopNum1_Shop_Template.IsForbid,
				", '",
				shopNum1_Shop_Template.TemplateImg,
				"', '",
				shopNum1_Shop_Template.CreateUser,
				"', '",
				shopNum1_Shop_Template.CreateTime,
				"',  '",
				shopNum1_Shop_Template.ModifyUser,
				"' , '",
				shopNum1_Shop_Template.ModifyTime,
				"',  ",
				shopNum1_Shop_Template.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_Shop_Template shopNum1_Shop_Template)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Shop_Template SET  Name='",
				Operator.FilterString(shopNum1_Shop_Template.Name),
				"', Meto='",
				Operator.FilterString(shopNum1_Shop_Template.Meto),
				"', Money='",
				Operator.FilterString(shopNum1_Shop_Template.Money),
				"', ValidDay=",
				Operator.FilterString(shopNum1_Shop_Template.ValidDay),
				", IsDefault=",
				Operator.FilterString(shopNum1_Shop_Template.IsDefault),
				", IsForbid=",
				shopNum1_Shop_Template.IsForbid,
				", TemplateImg='",
				shopNum1_Shop_Template.TemplateImg,
				"', ModifyUser='",
				shopNum1_Shop_Template.ModifyUser,
				"', ModifyTime='",
				shopNum1_Shop_Template.ModifyTime,
				"'WHERE ID='",
				shopNum1_Shop_Template.ID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Edit(string guid)
		{
			string strSql = string.Empty;
			strSql = "select Name,Meto,Money,ValidDay,IsDefault,IsForbid,Path,TemplateImg from ShopNum1_Shop_Template WHERE ID=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Delete(string guid)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_Template WHERE ID = " + guid;
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete1(string string_0)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_Template WHERE ID in ( " + string_0 + " )";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search()
		{
			string strSql = string.Empty;
			strSql = "SELECT ID,Name,Money,Path,ValidDay,IsDefault,Meto,TemplateImg,IsForbid FROM ShopNum1_Shop_Template";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetTemplateType()
		{
			string strSql = string.Empty;
			strSql = "SELECT ID,Name,Path FROM ShopNum1_Shop_Template WHERE IsForbid=" + 0;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int CheckTemplateName(string name)
		{
			string strSql = string.Empty;
			strSql = "SELECT COUNT(name) AS CountName FROM ShopNum1_Shop_Template WHERE Name='" + name + "'";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable.Rows[0]["CountName"].ToString() == "0")
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}
		public DataTable GetTemplatePathAndImg(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT path,TemplateImg FROM ShopNum1_Shop_Template WHERE ID=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetTemplatePathAndImg1(string string_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT path,TemplateImg FROM ShopNum1_Shop_Template WHERE ID in (" + string_0 + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public bool UpdateIsDefault()
		{
			string strSql = string.Empty;
			strSql = "SELECT ID FROM ShopNum1_Shop_Template WHERE IsDefault=" + 0;
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			bool result;
			if (dataTable.Rows.Count > 0)
			{
				string text = string.Empty;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					text = text + ",'" + dataTable.Rows[0]["ID"].ToString() + "'";
				}
				strSql = string.Concat(new object[]
				{
					"UPDATE ShopNum1_Shop_Template SET IsDefault=",
					1,
					"WHERE ID=",
					text.Substring(1)
				});
				int num = DatabaseExcetue.RunNonQuery(strSql);
				result = (num > 0);
			}
			else
			{
				result = true;
			}
			return result;
		}
		public DataTable GetTemplateByID(string string_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT TemplateImg,Name FROM ShopNum1_Shop_Template WHERE ID IN (" + string_0 + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
