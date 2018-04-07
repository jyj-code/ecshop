using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
namespace ShopNum1.ThirdInterDAL
{
	public sealed class EvalData<T> where T : class, new()
	{
		public static List<T> GetData(DataTable dataTable_0)
		{
			List<T> list = new List<T>();
			T t = default(T);
			if (dataTable_0 != null && dataTable_0.Rows.Count > 0)
			{
				foreach (DataRow dataRow in dataTable_0.Rows)
				{
					t = Activator.CreateInstance<T>();
					PropertyInfo[] properties = t.GetType().GetProperties();
					foreach (DataColumn dataColumn in dataTable_0.Columns)
					{
						PropertyInfo[] array = properties;
						for (int i = 0; i < array.Length; i++)
						{
							PropertyInfo propertyInfo = array[i];
							if (propertyInfo.Name.ToLower() == dataColumn.ColumnName.ToLower())
							{
								propertyInfo.SetValue(t, dataRow[dataColumn.ColumnName], null);
							}
						}
					}
					list.Add(t);
				}
			}
			return list;
		}
	}
}
