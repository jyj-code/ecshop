using System;
using System.Text;
using System.Web;
namespace ShopNum1.DiscuzToolkit
{
	public class DiscuzParam : IComparable
	{
		private string string_0;
		private object object_0;
		public string Name
		{
			get
			{
				return this.string_0;
			}
		}
		public string Value
		{
			get
			{
				string result;
				if (this.object_0 is Array)
				{
					result = DiscuzParam.smethod_0(this.object_0 as Array);
				}
				else
				{
					result = this.object_0.ToString();
				}
				return result;
			}
		}
		public string EncodedValue
		{
			get
			{
				string result;
				if (this.object_0 is Array)
				{
					result = HttpUtility.UrlEncode(DiscuzParam.smethod_0(this.object_0 as Array));
				}
				else
				{
					result = HttpUtility.UrlEncode(this.object_0.ToString());
				}
				return result;
			}
		}
		protected DiscuzParam(string name, object value)
		{
			this.string_0 = name;
			this.object_0 = value;
		}
		public override string ToString()
		{
			return string.Format("{0}={1}", this.Name, this.Value);
		}
		public string ToEncodedString()
		{
			return string.Format("{0}={1}", this.Name, this.EncodedValue);
		}
		public static DiscuzParam Create(string name, object value)
		{
			return new DiscuzParam(name, value);
		}
		public int CompareTo(object target)
		{
			int result;
			if (!(target is DiscuzParam))
			{
				result = -1;
			}
			else
			{
				result = this.string_0.CompareTo((target as DiscuzParam).string_0);
			}
			return result;
		}
		private static string smethod_0(Array array_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array_0.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(array_0.GetValue(i).ToString());
			}
			return stringBuilder.ToString();
		}
	}
}
