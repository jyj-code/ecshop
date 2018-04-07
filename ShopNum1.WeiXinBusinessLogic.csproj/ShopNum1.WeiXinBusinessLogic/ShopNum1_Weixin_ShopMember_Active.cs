using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinCommon.model;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
namespace ShopNum1.WeiXinBusinessLogic
{
	public class ShopNum1_Weixin_ShopMember_Active : IShopNum1_Weixin_ShopMember_Active
	{
		public bool AddWeiXinMember(string ShopMemLoginID, string UsrWeiXinID, string ShopWeiXinId, UserModel usermdl)
		{
			string strSql = string.Format("if(select ShopWeiXinId from dbo.ShopNum1_Weixin_ShopWeiXinConfig where ShopMemLoginID = '{0}')=''\r\n                                            begin\r\n\t                                            update dbo.ShopNum1_Weixin_ShopWeiXinConfig set ShopWeiXinId ='{2}' where ShopMemLoginID = '{0}'\r\n                                            end\r\n                                            if\t(select count(1) from dbo.ShopNum1_Member where MemLoginID = '{1}')=0\r\n                                            begin\r\n                                                INSERT INTO dbo.ShopNum1_Member\r\n                                                        ( Guid ,\r\n                                                          Name ,\r\n                                                          MemLoginID ,\r\n                                                          Email ,\r\n                                                          Tel ,\r\n                                                          Pwd ,\r\n                                                          PayPwd ,\r\n                                                          IsForbid ,\r\n                                                          MemberType ,\r\n                                                          AddressCode ,\r\n                                                          AddressValue ,\r\n                                                          Score ,\r\n                                                          RegeDate ,\r\n                                                          LoginDate ,\r\n                                                          MemberRank ,\r\n                                                          LastLoginIP ,\r\n                                                          LoginTime ,\r\n                                                          AdvancePayment ,\r\n                                                          LockAdvancePayment ,\r\n                                                          LockSocre ,\r\n                                                          CostMoney ,\r\n                                                          IsDeleted ,\r\n                                                          LastLoginDate ,\r\n                                                          IdentityCard ,\r\n                                                          RealName ,\r\n                                                          AlipayNumber ,\r\n                                                          IdentityCardBackImg ,\r\n                                                          IdentityCardImg ,\r\n                                                          IdentificationIsAudit ,\r\n                                                          IdentificationTime ,\r\n                                                          AuditFailedReason ,\r\n                                                          IsMailActivation,\r\n                                                          MemberRankGuid\r\n                                                        )\r\n                                                VALUES  (\r\n                                                       \r\n                                                         NEWID() , -- Guid - uniqueidentifier\r\n                                                          N'' , -- Name - nvarchar(50)\r\n                                                          '{1}' , -- MemLoginID - nvarchar(50)\r\n                                                          N'', -- Email - nvarchar(100)\r\n                                                          N'' , -- Tel - nvarchar(25)\r\n                                                          '{12}', -- Pwd - nvarchar(250)\r\n                                                          '{13}' , -- PayPwd - nvarchar(250)\r\n                                                          0 , -- IsForbid - int\r\n                                                          1 , -- MemberType - int\r\n                                                          '' , -- AddressCode - varchar(9)\r\n                                                          N'' , -- AddressValue - nvarchar(50)\r\n                                                          10 , -- Score - int\r\n                                                          getdate() , -- RegeDate - datetime\r\n                                                          getdate() , -- LoginDate - datetime\r\n                                                          0 , -- MemberRank - int\r\n                                                          N'' , -- LastLoginIP - nvarchar(25)\r\n                                                          0 , -- LoginTime - int\r\n                                                          0 , -- AdvancePayment - decimal\r\n                                                          0 , -- LockAdvancePayment - decimal\r\n                                                          0 , -- LockSocre - int\r\n                                                          0 , -- CostMoney - decimal\r\n                                                          0 , -- IsDeleted - tinyint\r\n                                                          getdate() , -- LastLoginDate - datetime\r\n                                                          N'' , -- IdentityCard - nvarchar(50)\r\n                                                          N'' , -- RealName - nvarchar(50)\r\n                                                          N'' , -- AlipayNumber - nvarchar(100)\r\n                                                          N'' , -- IdentityCardBackImg - nvarchar(250)\r\n                                                          N'' , -- IdentityCardImg - nvarchar(250)\r\n                                                          0 , -- IdentificationIsAudit - int\r\n                                                          getdate() , -- IdentificationTime - datetime\r\n                                                          N'' , -- AuditFailedReason - nvarchar(500)\r\n                                                          0,  -- IsMailActivation - int\r\n                                                          'a6da75ad-e1ac-4df8-99ad-980294a16581'\r\n                                                        )\r\n                                            end\r\n                                            else\r\n                                            begin\r\n                                                update dbo.ShopNum1_Member set IsDeleted = 0 , IsForbid = 0 where MemLoginID = '{1}'\r\n                                            end\r\n                                            if (select count(1) from dbo.ShopNum1_Weixin_ShopMember where ShopMemLoginId='{0}' and MemLoginId = '{1}')=0\r\n                                            begin\r\n\t                                            insert dbo.ShopNum1_Weixin_ShopMember(ShopMemLoginId,MemLoginId,[Group],[nickname],[sex],[language],[city],[province],[country],[headimgurl],[subscribe_time])\r\n                                                values('{0}','{1}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')\r\n                                            end\r\n                                            else\r\n                                            begin\r\n\t                                            UPDATE [dbo].[ShopNum1_Weixin_ShopMember]\r\n                                                SET [Group] ='{3}',[nickname] = '{4}',[sex] = '{5}',[language] = '{6}',[city] = '{7}',[province] = '{8}',[country] = '{9}',[headimgurl] = '{10}',[subscribe_time] = '{11}'\r\n                                                WHERE [MemLoginId] ='{1}'\r\n                                            end", new object[]
			{
				ShopMemLoginID,
				UsrWeiXinID,
				ShopWeiXinId,
				0,
				usermdl.nickname,
				usermdl.sex,
				usermdl.language,
				usermdl.city,
				usermdl.province,
				usermdl.country,
				usermdl.headimgurl,
				usermdl.subscribe_time,
				Encryption.GetMd5Hash("123456"),
				Encryption.GetMd5SecondHash("123456")
			});
			return DatabaseExcetue.RunNonQuery(strSql) > 0;
		}
		public DataTable GetShopMemByShopOwner(string shopowner)
		{
			string strSql = string.Format("select ShopMemLoginId,MemLoginId,Group,[nickname],[sex],[language],[city],[province],[country],[headimgurl],[subscribe_time] from ShopNum1_Weixin_ShopMember where ShopMemLoginId = '{0}'", shopowner);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public bool ChangeVipGroup(string shopowner, string vips, int group)
		{
			string strSql = string.Format("update ShopNum1_Weixin_ShopMember set [group] = '{2}'  where ShopMemLoginId = '{0}' and MemLoginId in({1})", shopowner, vips, group);
			return DatabaseExcetue.RunNonQuery(strSql) > 0;
		}
		public DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Weixin_ShopMember";
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "id,[Group]";
			array[6] = "@sortvalue";
			array2[6] = "asc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
