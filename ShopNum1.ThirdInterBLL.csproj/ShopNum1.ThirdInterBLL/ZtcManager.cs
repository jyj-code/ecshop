using ShopNum1.ThirdInterDAL;
using System;
namespace ShopNum1.ThirdInterBLL
{
	public class ZtcManager
	{
		private ZtcService ztcService
		{
			get
			{
				return new ZtcService();
			}
		}
		public bool TimeNessMoney()
		{
			return this.ztcService.TimeNessMoney();
		}
	}
}
