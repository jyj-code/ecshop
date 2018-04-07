using ShopNum1.Ucenter.Request;
using System;
using System.Text;
using System.Web;
namespace ShopNum1.Ucenter.UCAPI
{
	public abstract class UCAPIBase : IHttpHandler
	{
		protected bool API_DELETEUSER = true;
		protected bool API_GETCREDIT = true;
		protected bool API_GETCREDITSETTINGS = true;
		protected bool API_GETTAG = true;
		protected bool API_RENAMEUSER = true;
		protected string API_RETURN_FAILED = "-1";
		protected string API_RETURN_FORBIDDEN = "-2";
		protected bool API_SYNLOGIN = true;
		protected bool API_SYNLOGOUT = true;
		protected bool API_UPDATEAPPS = true;
		protected bool API_UPDATEBADWORDS = true;
		protected bool API_UPDATECLIENT = true;
		protected bool API_UPDATECREDIT = true;
		protected bool API_UPDATECREDITSETTINGS = true;
		protected bool API_UPDATEHOSTS = true;
		protected bool API_UPDATEPW = true;
		private bool bool_0 = false;
		private Class1 class1_0 = null;
		private string string_0 = "1";
		public string API_RETURN_SUCCEED
		{
			get
			{
				if (UCConfig.IsIntergrationUCenter == "1")
				{
					this.string_0 = "1";
				}
				else
				{
					this.string_0 = "0";
				}
				return this.string_0;
			}
		}
		public virtual string EncryptKeyNameInRequest
		{
			get
			{
				return "code";
			}
		}
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		protected virtual string Parameter_AMOUNT
		{
			get
			{
				return this.GetRequestParameter("amount");
			}
		}
		protected virtual string Parameter_CREDIT
		{
			get
			{
				return this.GetRequestParameter("credit");
			}
		}
		protected virtual string Parameter_IDS
		{
			get
			{
				return this.GetRequestParameter("ids");
			}
		}
		protected virtual string Parameter_NEWUSERNAME
		{
			get
			{
				return this.GetRequestParameter("newusername");
			}
		}
		protected virtual string Parameter_OLDUSERNAME
		{
			get
			{
				return this.GetRequestParameter("oldusername");
			}
		}
		protected virtual string Parameter_PASSWORD
		{
			get
			{
				return this.GetRequestParameter("password");
			}
		}
		protected virtual string Parameter_UID
		{
			get
			{
				return this.GetRequestParameter("uid");
			}
		}
		protected virtual string Parameter_USERNAME
		{
			get
			{
				return this.GetRequestParameter("username");
			}
		}
		public virtual Encoding UCRequestEncoding
		{
			get
			{
				return Encoding.GetEncoding("utf-8");
			}
		}
		public virtual bool UrlDecodeEncryptValue
		{
			get
			{
				return false;
			}
		}
		private string method_0()
		{
			string result;
			if (!this.API_DELETEUSER)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				if (Utils.IsIntArray(this.Parameter_IDS))
				{
					string[] string_ = this.Parameter_IDS.Split(new char[]
					{
						','
					});
					if (this.DeleteUser(string_))
					{
						result = this.API_RETURN_SUCCEED;
						return result;
					}
				}
				result = this.API_RETURN_FAILED;
			}
			return result;
		}
		private string method_1()
		{
			string result;
			if (!this.API_GETCREDIT)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				int num = Utils.StringToInt(this.Parameter_UID);
				int creditId = Utils.StringToInt(this.Parameter_CREDIT);
				if (num <= 0)
				{
					result = "0";
				}
				else
				{
					result = this.GetCredit(num, creditId).ToString();
				}
			}
			return result;
		}
		private string method_2()
		{
			string result;
			if (!this.API_GETCREDITSETTINGS)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				result = this.GetCreditSettings();
			}
			return result;
		}
		private string method_3()
		{
			return "";
		}
		private string method_4()
		{
			string result;
			if (!this.API_RENAMEUSER)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				int num = Utils.StringToInt(this.Parameter_UID);
				string parameter_OLDUSERNAME = this.Parameter_OLDUSERNAME;
				string parameter_NEWUSERNAME = this.Parameter_NEWUSERNAME;
				if ((num > 0 || !string.IsNullOrEmpty(parameter_NEWUSERNAME)) && this.RenameUser(num, parameter_OLDUSERNAME, parameter_NEWUSERNAME))
				{
					result = this.API_RETURN_SUCCEED;
				}
				else
				{
					result = this.API_RETURN_FAILED;
				}
			}
			return result;
		}
		private string method_5()
		{
			string result;
			if (!this.API_SYNLOGIN)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				int num = Utils.StringToInt(this.Parameter_UID);
				if (num > 0 && this.Synlogin(num))
				{
					result = this.API_RETURN_SUCCEED;
				}
				else
				{
					result = this.API_RETURN_FAILED;
				}
			}
			return result;
		}
		private void method_6()
		{
			if (this.API_SYNLOGOUT)
			{
				this.Synlogout();
			}
		}
		private string method_7()
		{
			string result;
			if (!this.API_UPDATEAPPS || !this.bool_0)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				this.UpdateApps();
				result = this.API_RETURN_SUCCEED;
			}
			return result;
		}
		private string method_8()
		{
			string result;
			if (!this.API_UPDATEBADWORDS || !this.bool_0)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				this.UpdateBadwords();
				result = this.API_RETURN_SUCCEED;
			}
			return result;
		}
		private string method_9()
		{
			string result;
			if (!this.API_UPDATECLIENT || !this.bool_0)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				this.UpdateClient();
				result = this.API_RETURN_SUCCEED;
			}
			return result;
		}
		private string method_10()
		{
			string result;
			if (!this.API_UPDATECREDIT)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				int creditId = Utils.StringToInt(this.Parameter_CREDIT);
				int amount = Utils.StringToInt(this.Parameter_AMOUNT);
				int int_ = Utils.StringToInt(this.Parameter_UID);
				if (this.UpdateCredit(int_, creditId, amount))
				{
					result = this.API_RETURN_SUCCEED;
				}
				else
				{
					result = this.API_RETURN_FAILED;
				}
			}
			return result;
		}
		private string method_11()
		{
			string result;
			if (!this.API_UPDATECREDITSETTINGS)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				this.UpdateCreditSettings(this.Parameter_CREDIT);
				result = this.API_RETURN_SUCCEED;
			}
			return result;
		}
		private string method_12()
		{
			string result;
			if (!this.API_UPDATEHOSTS || !this.bool_0)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				this.UpdateHosts();
				result = this.API_RETURN_SUCCEED;
			}
			return result;
		}
		private string method_13()
		{
			string result;
			if (!this.API_UPDATEPW)
			{
				result = this.API_RETURN_FORBIDDEN;
			}
			else
			{
				string parameter_USERNAME = this.Parameter_USERNAME;
				string parameter_PASSWORD = this.Parameter_PASSWORD;
				if (!string.IsNullOrEmpty(parameter_USERNAME) && !string.IsNullOrEmpty(parameter_PASSWORD) && this.UpdatePW(parameter_USERNAME, Utils.MD5(parameter_PASSWORD)))
				{
					result = this.API_RETURN_SUCCEED;
				}
				else
				{
					result = this.API_RETURN_FAILED;
				}
			}
			return result;
		}
		public abstract bool DeleteUser(string[] string_1);
		public abstract int GetCredit(int int_0, int creditId);
		public abstract string GetCreditSettings();
		public string GetRequestParameter(string keyName)
		{
			string result;
			if (this.class1_0 == null)
			{
				result = "";
			}
			else
			{
				result = this.class1_0.method_4()[keyName].Trim();
			}
			return result;
		}
		public void ProcessRequest(HttpContext context)
		{
			this.class1_0 = new Class1(context.Request, this.EncryptKeyNameInRequest, UCConfig.UC_KEY, this.UrlDecodeEncryptValue, this.UCRequestEncoding);
			this.bool_0 = (context.Request.HttpMethod == "POST");
			if (this.class1_0.method_2() || this.class1_0.method_3())
			{
				context.Response.Write("Invalid Request");
				context.Response.End();
			}
			if (this.class1_0.method_1())
			{
				context.Response.Write("Authracation has expiried");
				context.Response.End();
			}
			context.Response.Clear();
			string text = this.class1_0.method_0();
			switch (text)
			{
			case "test":
				context.Response.Write(this.API_RETURN_SUCCEED);
				context.Response.End();
				break;
			case "addfeed":
				context.Response.Write(this.API_RETURN_SUCCEED);
				context.Response.End();
				break;
			case "deleteuser":
				context.Response.Write(this.method_0());
				context.Response.End();
				break;
			case "getcreditsettings":
				context.Response.Write(this.method_2());
				context.Response.End();
				break;
			case "gettag":
				context.Response.Write(this.method_3());
				context.Response.End();
				break;
			case "renameuser":
				context.Response.Write(this.method_4());
				context.Response.End();
				break;
			case "synlogin":
				context.Response.Write(this.method_5());
				context.Response.End();
				break;
			case "synlogout":
				this.method_6();
				context.Response.End();
				break;
			case "updateapps":
				context.Response.Write(this.method_7());
				context.Response.End();
				break;
			case "updatebadwords":
				context.Response.Write(this.method_8());
				context.Response.End();
				break;
			case "updateclient":
				context.Response.Write(this.method_9());
				context.Response.End();
				break;
			case "updatecredit":
				context.Response.Write(this.method_10());
				context.Response.End();
				break;
			case "updatecreditsettings":
				context.Response.Write(this.method_11());
				context.Response.End();
				break;
			case "updatehosts":
				context.Response.Write(this.method_12());
				context.Response.End();
				break;
			case "updatepw":
				context.Response.Write(this.method_13());
				context.Response.End();
				break;
			}
		}
		public abstract bool RenameUser(int int_0, string oldname, string newname);
		public abstract bool Synlogin(int int_0);
		public abstract void Synlogout();
		public abstract void UpdateApps();
		public abstract void UpdateBadwords();
		public abstract void UpdateClient();
		public abstract bool UpdateCredit(int int_0, int creditId, int amount);
		public abstract void UpdateCreditSettings(string creditSettings);
		public abstract void UpdateHosts();
		public abstract bool UpdatePW(string uname, string string_1);
	}
}
