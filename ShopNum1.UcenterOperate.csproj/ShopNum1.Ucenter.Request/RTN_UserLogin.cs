using System;
namespace ShopNum1.Ucenter.Request
{
	[Serializable]
	public class RTN_UserLogin
	{
		private int int_0;
		private string string_0;
		private string string_1;
		private string string_2;
		private bool bool_0;
		public int Uid
		{
			get
			{
				return this.int_0;
			}
		}
		public string UserName
		{
			get
			{
				return this.string_0;
			}
		}
		public string PassWord
		{
			get
			{
				return this.string_1;
			}
		}
		public string Email
		{
			get
			{
				return this.string_2;
			}
		}
		public bool UserNameUsed
		{
			get
			{
				return this.bool_0;
			}
		}
		public RTN_UserLogin()
		{
		}
		public RTN_UserLogin(int int_1, string uname, string string_3, string email, bool used)
		{
			this.int_0 = int_1;
			this.string_0 = uname;
			this.string_1 = string_3;
			this.string_2 = email;
			this.bool_0 = used;
		}
	}
}
