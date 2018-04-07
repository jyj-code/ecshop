using ShopNum1.DataAccess;
using System;
namespace ShopNum1.ThirdInterDAL
{
	public class MemberService
	{
		public int CheckMember(string memLoginId, string password)
		{
			int result = 0;
			try
			{
				string strSql = string.Format("SELECT count(*) FROM ShopNum1_Member WHERE MemberType=2 and MemLoginID='{0}' and Pwd='{1}'", memLoginId, password);
				int num = Convert.ToInt32(DatabaseExcetue.ReturnString(strSql));
				if (num > 0)
				{
					result = 1;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
	}
}
