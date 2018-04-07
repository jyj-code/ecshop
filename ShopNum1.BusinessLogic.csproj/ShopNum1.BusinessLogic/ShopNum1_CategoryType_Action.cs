using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_CategoryType_Action : IShopNum1_CategoryType_Action
	{
		public DataTable SelectCategoryType_List(int pagesize, int currentpage, string strcondition, int resultnum)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "pagesize";
			array2[0] = pagesize.ToString();
			array[1] = "currentpage";
			array2[1] = currentpage.ToString();
			array[2] = "columns";
			array2[2] = "name,id,orderid";
			array[3] = "tablename";
			array2[3] = "ShopNum1_CategoryType";
			array[4] = "condition";
			array2[4] = " and isdeleted=0";
			array[5] = "ordercolumn";
			array2[5] = "orderid";
			array[6] = "resultnum";
			array2[6] = resultnum.ToString();
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int Add_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType)
		{
			List<string> list = new List<string>();
			string text = "insert into ShopNum1_CategoryType(name,description,orderid,createuser,modifyuser,isshow,spec_ids,pro_ids)values";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"('",
				shopNum1_CategoryType.Name,
				"','",
				shopNum1_CategoryType.Description,
				"','",
				shopNum1_CategoryType.OrderID,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"'",
				shopNum1_CategoryType.CreateUser,
				"','",
				shopNum1_CategoryType.ModifyUser,
				"','",
				shopNum1_CategoryType.IsShow,
				"',"
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"'",
				shopNum1_CategoryType.Spec_Ids,
				"','",
				shopNum1_CategoryType.Pro_Ids,
				"');SELECT @@IDENTITY AS returnName"
			});
			string text3 = DatabaseExcetue.ReturnString(text);
			if (shopNum1_CategoryType.Pro_Ids != "")
			{
				string[] array = (shopNum1_CategoryType.Pro_Ids.Replace("L", "") + ",").Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						list.Add(string.Concat(new string[]
						{
							"INSERT INTO ShopNum1_TypeProp(TypeId,PropId)Values('",
							text3,
							"','",
							array[i],
							"');"
						}));
					}
				}
			}
			if (shopNum1_CategoryType.Spec_Ids != "")
			{
				string[] array = (shopNum1_CategoryType.Spec_Ids.Replace("J", "") + ",").Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						list.Add(string.Concat(new string[]
						{
							"INSERT INTO ShopNum1_TypeSpec(TypeId,SpecId)Values('",
							text3,
							"','",
							array[i],
							"');"
						}));
					}
				}
			}
			DatabaseExcetue.RunTransactionSql(list);
			return 1;
		}
		public int Update_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType)
		{
			List<string> list = new List<string>();
			string text = string.Concat(new string[]
			{
				"update ShopNum1_CategoryType set name='",
				shopNum1_CategoryType.Name,
				"',description='",
				shopNum1_CategoryType.Description,
				"'"
			});
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				",orderid='",
				shopNum1_CategoryType.OrderID,
				"',modifyuser='",
				shopNum1_CategoryType.ModifyUser,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"isshow='",
				shopNum1_CategoryType.IsShow,
				"',spec_ids='",
				shopNum1_CategoryType.Spec_Ids,
				"',pro_ids='",
				shopNum1_CategoryType.Pro_Ids,
				"'"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" where id='",
				shopNum1_CategoryType.ID,
				"';"
			});
			list.Add(text);
			list.Add("delete from ShopNum1_TypeProp where typeId='" + shopNum1_CategoryType.ID + "';");
			if (shopNum1_CategoryType.Pro_Ids != "")
			{
				string[] array = (shopNum1_CategoryType.Pro_Ids.Replace("L", "") + ",").Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						list.Add(string.Concat(new object[]
						{
							"INSERT INTO ShopNum1_TypeProp(TypeId,PropId)Values('",
							shopNum1_CategoryType.ID,
							"','",
							array[i],
							"');"
						}));
					}
				}
			}
			list.Add("delete from ShopNum1_TypeSpec where typeId='" + shopNum1_CategoryType.ID + "';");
			if (shopNum1_CategoryType.Spec_Ids != "")
			{
				string[] array = (shopNum1_CategoryType.Spec_Ids.Replace("J", "") + ",").Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						list.Add(string.Concat(new object[]
						{
							"INSERT INTO ShopNum1_TypeSpec(TypeId,SpecId)Values('",
							shopNum1_CategoryType.ID,
							"','",
							array[i],
							"');"
						}));
					}
				}
			}
			DatabaseExcetue.RunTransactionSql(list);
			return 1;
		}
		public ShopNum1_CategoryType Select_CategoryType(string strID)
		{
			ShopNum1_CategoryType shopNum1_CategoryType = new ShopNum1_CategoryType();
			string strSql = "select name,description,orderid,spec_ids,pro_ids,isshow from ShopNum1_CategoryType where id='" + strID + "'";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			if (dataTable.Rows.Count > 0)
			{
				shopNum1_CategoryType.Name = dataTable.Rows[0]["name"].ToString();
				shopNum1_CategoryType.IsShow = new int?(Convert.ToInt32(dataTable.Rows[0]["isshow"]));
				shopNum1_CategoryType.Description = dataTable.Rows[0]["description"].ToString();
				shopNum1_CategoryType.OrderID = new int?(Convert.ToInt32(dataTable.Rows[0]["orderid"].ToString()));
				shopNum1_CategoryType.Spec_Ids = dataTable.Rows[0]["spec_ids"].ToString();
				shopNum1_CategoryType.Pro_Ids = dataTable.Rows[0]["pro_ids"].ToString();
			}
			return shopNum1_CategoryType;
		}
		public int Get_TypeMaxId()
		{
			string strSql = "select max(id)+1 from ShopNum1_CategoryType";
			return Convert.ToInt32(DatabaseExcetue.ReturnString(strSql));
		}
		public int update_CategoryType_Order(string strorderid, string strId)
		{
			string strSql = string.Concat(new string[]
			{
				"update ShopNum1_CategoryType set orderid='",
				strorderid,
				"' where id='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteBatch_CategoryType(string strId)
		{
			string strSql = "delete from ShopNum1_CategoryType where id in(" + strId + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Select_ProductCategoryType()
		{
			string strSql = "select id as code,id,name from ShopNum1_CategoryType where isdeleted=0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add_CategoryTypeInto(ShopNum1_CategoryType shopNum1_CategoryType)
		{
			List<string> sqlList = new List<string>();
			string text = "insert into ShopNum1_CategoryType(name,description,orderid,createuser,modifyuser,isshow,spec_ids,pro_ids)values";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"('",
				shopNum1_CategoryType.Name,
				"','",
				shopNum1_CategoryType.Description,
				"','",
				shopNum1_CategoryType.OrderID,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"'",
				shopNum1_CategoryType.CreateUser,
				"','",
				shopNum1_CategoryType.ModifyUser,
				"','",
				shopNum1_CategoryType.IsShow,
				"',"
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"'",
				shopNum1_CategoryType.Spec_Ids,
				"','",
				shopNum1_CategoryType.Pro_Ids,
				"');SELECT @@IDENTITY AS returnName"
			});
			string value = DatabaseExcetue.ReturnString(text);
			DatabaseExcetue.RunTransactionSql(sqlList);
			return Convert.ToInt32(value);
		}
		public string Get_SpValue(string strId)
		{
			string strSql = "select (spec_ids+'|'+pro_ids)spvalue from ShopNum1_CategoryType where id='" + strId + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
	}
}
