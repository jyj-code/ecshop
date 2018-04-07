using ShopNum1.ThirdInterDAL;
using System;
namespace ShopNum1.ThirdInterBLL
{
	public class MemberManager
	{
		private MemberService memberService
		{
			get
			{
				return new MemberService();
			}
		}
		public int CheckMember(string memLoginId, string password)
		{
			return this.memberService.CheckMember(memLoginId, password);
		}
	}
}
