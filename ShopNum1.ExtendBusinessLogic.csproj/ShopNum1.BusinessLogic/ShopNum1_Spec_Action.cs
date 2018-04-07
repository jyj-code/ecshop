using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Spec_Action : IShopNum1_Spec_Action
	{
		public DataTable Search(string name)
		{
			string strSql = string.Empty;
			if (!string.IsNullOrEmpty(name))
			{
				strSql = "Select *,dbo.fun_Specstr(id)as detailSpec From ShopNum1_Spec Where SpecName='" + name.Trim().ToString() + "'";
			}
			else
			{
				strSql = "Select *,dbo.fun_Specstr(id)as detailSpec From ShopNum1_Spec";
			}
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search_Type_Spec(string strId)
		{
			string strSql = string.Empty;
			strSql = "Select ID,SpecName,dbo.fun_Specstr(id)as detailSpec,(select specid from ShopNum1_TypeSpec where typeid='" + strId + "' and TypeID!=0 and specid=t.id)ischeck From ShopNum1_Spec as t";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Delete(string strguid)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "Delete From ShopNum1_Spec Where ID in (" + strguid + ")";
			list.Add(item);
			item = "Delete From ShopNum1_SpecValue Where SpecID in (" + strguid + ")";
			list.Add(item);
			item = "Delete From ShopNum1_SpecProudctDetails where SpecId in(" + strguid + ")";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Add(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue)
		{
			string strSql = string.Empty;
			List<string> list = new List<string>();
			strSql = string.Concat(new object[]
			{
				"Insert Into ShopNum1_Spec(SpecName,Memo,ShowType,OrderID,tbProp)Values('",
				shopNum1_Spec.SpecName,
				"','",
				shopNum1_Spec.Memo,
				"',",
				shopNum1_Spec.ShowType,
				",",
				shopNum1_Spec.OrderID,
				",'",
				shopNum1_Spec.tbProp,
				"');select @@IDENTITY"
			});
			string text = DatabaseExcetue.ReturnString(strSql);
			if (listSpecValue != null && listSpecValue.Count > 0)
			{
				for (int i = 0; i < listSpecValue.Count; i++)
				{
					string item = string.Concat(new object[]
					{
						"Insert Into ShopNum1_SpecValue(Specid,Name,Imagepath,orderid,tbPropValue)Values('",
						text,
						"','",
						listSpecValue[i].Name,
						"','",
						listSpecValue[i].Imagepath,
						"','",
						listSpecValue[i].OrderId,
						"','",
						listSpecValue[i].tbPropValue,
						"')"
					});
					list.Add(item);
				}
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int DeleteValue(string dguid)
		{
			string text = string.Empty;
			text = "delete from  ShopNum1_SpecValue  where id={0}";
			text = string.Format(text, dguid);
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int Update(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			List<string> list = new List<string>();
			text = "update ShopNum1_Spec set SpecName='{0}',Memo='{1}',ShowType={2},OrderID={3} where id={4}";
			text = string.Format(text, new object[]
			{
				shopNum1_Spec.SpecName,
				shopNum1_Spec.Memo,
				shopNum1_Spec.ShowType,
				shopNum1_Spec.OrderID,
				shopNum1_Spec.ID.ToString()
			});
			list.Add(text);
			if (listSpecValue != null && listSpecValue.Count > 0)
			{
				for (int i = 0; i < listSpecValue.Count; i++)
				{
					if (listSpecValue[i].ID == 0)
					{
						text2 = "insert into ShopNum1_SpecValue(Specid,Name,Imagepath,tbPropValue,orderid) values({0},'{1}','{2}','{3}','{4}')";
						text2 = string.Format(text2, new object[]
						{
							listSpecValue[i].SpecID,
							listSpecValue[i].Name,
							listSpecValue[i].Imagepath,
							listSpecValue[i].tbPropValue,
							listSpecValue[i].OrderId
						});
					}
					else
					{
						text2 = "update ShopNum1_Specvalue set orderid='{0}', Name='{1}',Imagepath='{2}' where id={3}";
						text2 = string.Format(text2, new object[]
						{
							listSpecValue[i].OrderId,
							listSpecValue[i].Name,
							listSpecValue[i].Imagepath,
							listSpecValue[i].ID
						});
					}
					list.Add(text2);
				}
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable SearchByGuid(string guid)
		{
			string text = string.Empty;
			text = "Select a.id,a.SpecName,a.Memo,a.OrderID,a.ShowType,b.Name,b.orderid oid,b.Imagepath,b.id as DGuid,cast(a.id as varchar(50))+':'+cast(b.id as varchar(50))  as 'DetailGuid' From ShopNum1_Spec as a,ShopNum1_Specvalue as b Where a.id=b.Specid And a.id={0} order by b.orderid asc";
			text = string.Format(text, guid);
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchName(string guids)
		{
			string strSql = string.Empty;
			strSql = "Select id,SpecName,ShowType,OrderID,Memo From ShopNum1_Spec Where id In(" + guids + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int GetMaxGuid()
		{
			string strSql = "select max(ID) as MaxId  from ShopNum1_Spec";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				result = 1;
			}
			else if (dataTable.Rows[0]["MaxId"] == DBNull.Value)
			{
				result = 1;
			}
			else
			{
				result = Convert.ToInt32(dataTable.Rows[0]["MaxId"]) + 1;
			}
			return result;
		}
		public bool CheckSpecValueBySguid(string sguid)
		{
			string text = "SELECT COUNT(*) AS Num FROM ShopNum1_SpecValue WHERE Specid in(" + sguid + ")";
			text = string.Format(text, sguid);
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
			return Convert.ToInt32(dataTable.Rows[0]["Num"]) > 0;
		}
		public DataTable dt_GetSp(string strId)
		{
			string strSql = "SELECT id,SpecName,showType FROM dbo.ShopNum1_Spec where id in (select specid from ShopNum1_TypeSpec where typeid='" + strId + "') ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable dt_SubSpec(string strSid, string strPid)
		{
			DataTable result;
			try
			{
				strPid = ((strPid == "" || strPid == "0" || strPid.Length != 36) ? "null" : ("'" + strPid + "'"));
				string strSql = string.Concat(new string[]
				{
					"SELECT Id,Name,ImagePath,(SELECT TOP 1 specvalueid FROM dbo.ShopNum1_SpecProudctDetails WHERE SpecValueId=t.id and ProductGuid=",
					strPid,
					")tc,(SELECT TOP 1 SpecValueName FROM ShopNum1_SpecProudctDetails WHERE SpecValueId=t.id and ProductGuid=",
					strPid,
					")tv,(SELECT TOP 1 productimage FROM ShopNum1_SpecProudctDetails WHERE SpecValueId=t.id and ProductGuid=",
					strPid,
					")tm FROM shopnum1_specvalue t WHERE SpecID='",
					strSid,
					"' ORDER BY OrderId ASC"
				});
				result = DatabaseExcetue.ReturnDataTable(strSql);
			}
			catch
			{
				string strSql = "SELECT Id,Name,ImagePath,''tc,''tv,''tm FROM dbo.ShopNum1_SpecValue t WHERE SpecID='" + strSid + "' ORDER BY OrderId ASC";
				result = DatabaseExcetue.ReturnDataTable(strSql);
			}
			return result;
		}
		public DataTable SpecDetailsGetByTbPropValue(string tbpropvalue)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@tbpropvalue";
			array2[0] = tbpropvalue;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecificationDetailsGetByTbPropValue", array, array2);
		}
		public DataTable SearchNameByGuid(string strGuid)
		{
			string strSql = "select specname from ShopNum1_Spec where id in(select specid from ShopNum1_SpecProudctDetails where productguid='" + strGuid + "') order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetTbCid(string string_0)
		{
			string strSql = string.Empty;
			strSql = "Select Count(*) as CidCount from  ShopNum1_TbCat where cid='" + string_0 + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int AddByCid(ShopNum1_Spec sepc, List<ShopNum1_SpecValue> listSpecValue)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				string.Concat(new object[]
				{
					"Insert Into ShopNum1_Spec(SpecName,Memo,ShowType,OrderID,tbProp)Values('",
					sepc.SpecName,
					"','",
					sepc.Memo,
					"',",
					sepc.ShowType,
					",",
					sepc.OrderID,
					",'",
					sepc.tbProp,
					"')"
				})
			});
			list.Add(item);
			if (listSpecValue != null && listSpecValue.Count > 0)
			{
				for (int i = 0; i < listSpecValue.Count; i++)
				{
					string item2 = string.Concat(new object[]
					{
						string.Concat(new string[]
						{
							"Insert Into ShopNum1_SpecValue(Name,imagepath,tbPropValue)Values('",
							listSpecValue[i].Name,
							"','",
							listSpecValue[i].Imagepath,
							"','",
							listSpecValue[i].tbPropValue,
							"')"
						})
					});
					list.Add(item2);
				}
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int AddTbCat(string string_0, string name, string CreateTime)
		{
			string strSql = string.Concat(new string[]
			{
				"Insert into ShopNum1_TbCat (cid,name,CreateTime)values(",
				string_0,
				",'",
				name,
				"','",
				CreateTime,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SpecificationDetailsGetByTbPropValue(string tbpropvalue)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@tbpropvalue";
			array2[0] = tbpropvalue;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecificationDetailsGetByTbPropValue", array, array2);
		}
	}
}
