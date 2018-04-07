using System;
using System.Data;
using System.Text;
namespace ShopNum1.Common
{
	public class Json
	{
		public static string GetJson(DataTable dataTable_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (dataTable_0.Rows.Count > 0)
			{
				stringBuilder.Append("[");
				for (int i = 0; i < dataTable_0.Rows.Count; i++)
				{
					stringBuilder.Append("{");
					for (int j = 0; j < dataTable_0.Columns.Count; j++)
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"\"",
							dataTable_0.Columns[j].ColumnName.ToLower(),
							"\":\"",
							dataTable_0.Rows[i][j].ToString().Replace("~/", "/"),
							"\","
						}));
					}
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
					stringBuilder.Append("},");
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("]");
			}
			return stringBuilder.ToString();
		}
	}
}
