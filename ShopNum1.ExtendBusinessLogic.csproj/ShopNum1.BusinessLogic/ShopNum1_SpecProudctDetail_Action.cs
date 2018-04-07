using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SpecProudctDetail_Action : IShopNum1_SpecProudctDetail_Action
	{
		public int AddListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials)
		{
			List<string> list = new List<string>();
			if (SpecDetials != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < SpecDetials.Count; i++)
				{
					if (SpecDetials[i].SpecId != 0)
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"   INSERT INTO dbo.ShopNum1_SpecProudctDetails \r\n        ( ProductGuid ,\r\n          typeid ,\r\n          specid ,\r\n          specvalueid,\r\n          specvaluename ,\r\n          ProductImage \r\n        ) Values('",
							SpecDetials[i].ProductGuid,
							"','",
							SpecDetials[i].TypeId,
							"','",
							SpecDetials[i].SpecId,
							"','",
							SpecDetials[i].SpecValueId,
							"','",
							SpecDetials[i].SpecValueName,
							"','",
							SpecDetials[i].ProductImage,
							"')"
						}));
						list.Add(stringBuilder.ToString());
					}
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
		public int UpdateListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials, string strDelSpecId, string strNewSpec)
		{
			List<string> list = new List<string>();
			if (strDelSpecId.ToString() != "")
			{
				string[] array = (strDelSpecId + ",0").Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					list.Add("delete from ShopNum1_SpecProudct where ProductGuId='" + SpecDetials[0].ProductGuid + "';");
					list.Add(string.Concat(new object[]
					{
						"delete from ShopNum1_SpecProudctDetails where specvalueid='",
						array[i],
						"' and productguid='",
						SpecDetials[0].ProductGuid,
						"';"
					}));
				}
			}
			if (SpecDetials != null && SpecDetials.Count != 1)
			{
				for (int j = 0; j < SpecDetials.Count; j++)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("declare @id varchar(20)\r\n");
					if (strNewSpec.ToString() != "")
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"delete from ShopNum1_SpecProudctDetails where SpecId not in(",
							strNewSpec,
							") and ProductGuId='",
							SpecDetials[j].ProductGuid,
							"';"
						}));
					}
					stringBuilder.Append("set @id=''\r\n");
					stringBuilder.Append(string.Concat(new object[]
					{
						"select @id=max(id) from ShopNum1_SpecProudctDetails where typeid='",
						SpecDetials[j].TypeId,
						"' and specid='",
						SpecDetials[j].SpecId,
						"' and specvalueid='",
						SpecDetials[j].SpecValueId,
						"' and productguid='",
						SpecDetials[j].ProductGuid,
						"'"
					}));
					stringBuilder.Append("\r\nbegin\r\n");
					stringBuilder.Append("if(isnull(@id,'')='')\r\n");
					if (SpecDetials[j].SpecId != 0)
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"   INSERT INTO dbo.ShopNum1_SpecProudctDetails \r\n        ( ProductGuid ,\r\n          typeid ,\r\n          specid ,\r\n          specvalueid,\r\n          specvaluename ,\r\n          ProductImage \r\n        ) Values('",
							SpecDetials[j].ProductGuid,
							"','",
							SpecDetials[j].TypeId,
							"','",
							SpecDetials[j].SpecId,
							"','",
							SpecDetials[j].SpecValueId,
							"','",
							SpecDetials[j].SpecValueName,
							"','",
							SpecDetials[j].ProductImage,
							"')\r\n"
						}));
						stringBuilder.Append("\r\nelse\r\n");
					}
					stringBuilder.Append(string.Format("  update ShopNum1_SpecProudctDetails set typeid='{0}',specvaluename='{3}',ProductImage='{4}' where ProductGuid='{5}' and specid='{1}' and specvalueid='{2}'", new object[]
					{
						SpecDetials[j].TypeId,
						SpecDetials[j].SpecId,
						SpecDetials[j].SpecValueId,
						SpecDetials[j].SpecValueName,
						SpecDetials[j].ProductImage,
						SpecDetials[j].ProductGuid
					}));
					stringBuilder.Append("\r\nend\r\n");
					list.Add(stringBuilder.ToString());
				}
			}
			else
			{
				list.Add("Delete from ShopNum1_SpecProudctDetails where ProductGuId='" + SpecDetials[0].ProductGuid + "'");
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
		public string SearchName(string strId)
		{
			string strSql = "select specvaluename from ShopNum1_SpecProudctDetails where id='" + strId + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable GetDetailByDGuid(string guids, string productguid)
		{
			string strSql = string.Empty;
			strSql = "select distinct CAST(c.specname AS VARCHAR(50))+':'+replace(specvaluename,'*','x') AS SpecDetailName,CAST(a.specvalueid AS VARCHAR(50))+':'+CAST(specvalueid AS VARCHAR(5)) AS SpecDetail ,CAST(replace(specvaluename,'*','x') AS VARCHAR(50))+':'+CAST(specvalueid AS VARCHAR(5)) AS SpecDetailv,replace(specvaluename,'*','x') as specvaluename,b.imagepath,a.ProductImage,B.orderid from ShopNum1_SpecProudctDetails A left join ShopNum1_SpecValue B ON B.id=A.specvalueid left join ShopNum1_Spec C on C.id=b.specid where productguid=@productguid and [specvalueid] in (" + guids + ") order by B.orderid asc";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productguid";
			array2[0] = productguid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable GetDetailByDGuid(string strGuids)
		{
			string strSql = string.Format("select * from ShopNum1_SpecProudctDetails where [ID] in ({0}) order by id asc", strGuids);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetSpecImageBySpecId(string strProductGuId, string strSpecId)
		{
			string strSql = string.Concat(new string[]
			{
				"select top 1 productimage from ShopNum1_SpecProudctDetails where productguid='",
				strProductGuId,
				"' and specvaluename='",
				strSpecId.Split(new char[]
				{
					':'
				})[0],
				"' and specvalueid='",
				strSpecId.Split(new char[]
				{
					':'
				})[1],
				"' and productimage!=''"
			});
			return DatabaseExcetue.ReturnString(strSql);
		}
	}
}
