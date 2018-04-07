using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_MMSGroupSend_Action : IShopNum1_MMSGroupSend_Action
	{
		public int Add(ShopNum1_MMSGroupSend MMSGroupSend)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MMSGroupSend( Guid, SendObject, SendObjectMMS, MMSTitle, State, CreateTime, IsTime, TimeSendTime, MMSGuid  ) VALUES (  '",
				MMSGroupSend.Guid,
				"',  '",
				Operator.FilterString(MMSGroupSend.SendObject),
				"',  '",
				Operator.FilterString(MMSGroupSend.SendObjectMMS),
				"',  '",
				Operator.FilterString(MMSGroupSend.MMSTitle),
				"',  '",
				Operator.FilterString(MMSGroupSend.State),
				"',  '",
				MMSGroupSend.CreateTime,
				"', '",
				MMSGroupSend.IsTime,
				"',  '",
				MMSGroupSend.TimeSendTime,
				"' , '",
				MMSGroupSend.MMSGuid,
				"' )"
			});
			list.Add(item);
			string text = Guid.NewGuid().ToString();
			item = string.Concat(new string[]
			{
				"INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,MemLoginID,Content,sendtime,OperateUser,IsDeleted  ) VALUES (  '",
				text,
				"',  '",
				Operator.FilterString(MMSGroupSend.MMSTitle),
				"',  '1',  '",
				MMSGroupSend.SendObject.Split(new char[]
				{
					'-'
				})[0],
				"',  '",
				Operator.FilterString(MMSGroupSend.SendObjectMMS),
				"',  '",
				DateTime.Now.ToString(),
				"' , 'admin' , '0')"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_UserMessage(  Guid ,  ReceiveID ,  SendID,  IsRead, SendTime,  IsDeleted,  MessageInfoGuid,  SendIsDeleted,  ReceiveIsDeleted  ) VALUES (  '",
				Guid.NewGuid(),
				"',  '",
				MMSGroupSend.SendObject.Split(new char[]
				{
					'-'
				})[0],
				"',  'admin',  ",
				0,
				",  '",
				DateTime.Now.ToString(),
				"',  ",
				0,
				",  '",
				text,
				"',  ",
				0,
				",  ",
				0,
				" )"
			});
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
	}
}
