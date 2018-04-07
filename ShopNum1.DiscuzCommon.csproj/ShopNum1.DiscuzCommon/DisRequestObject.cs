using System;
using System.Web;
namespace ShopNum1.DiscuzCommon
{
	public class DisRequestObject
	{
		private string string_0 = string.Empty;
		private bool bool_0 = true;
		private bool bool_1 = true;
		private int int_0 = 0;
		private int int_1 = 0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		public string Action
		{
			get
			{
				return this.string_0;
			}
		}
		public bool IsAuthracationExpiried
		{
			get
			{
				return this.bool_0;
			}
		}
		public bool IsInvalidAction
		{
			get
			{
				return !DisRequestActions.IsValidAction(this.string_0);
			}
		}
		public bool IsInvalidRequest
		{
			get
			{
				return this.bool_1;
			}
		}
		public int Timestamp
		{
			get
			{
				return this.int_0;
			}
		}
		public string Sig
		{
			get
			{
				return this.string_2;
			}
		}
		public int Int32_0
		{
			get
			{
				return this.int_1;
			}
		}
		public string user_name
		{
			get
			{
				return this.string_1;
			}
		}
		public DisRequestObject(HttpRequest dis_request)
		{
			this.string_0 = string.Empty;
			this.int_0 = 0;
			this.bool_1 = false;
			this.bool_0 = false;
			if (dis_request.QueryString.Count == 0)
			{
				this.bool_1 = true;
				this.bool_0 = true;
			}
			else
			{
				if (dis_request["action"] != null)
				{
					this.bool_1 = false;
					this.string_0 = dis_request["action"].Trim().ToLower();
				}
				if (dis_request["time"] != null)
				{
					this.int_0 = DisRequestActions.StringToInt(dis_request["time"].Trim().ToLower());
				}
				if (dis_request["user_name"] != null)
				{
					this.string_1 = dis_request["user_name"].ToString();
				}
				if (dis_request["uid"] != null)
				{
					this.int_1 = DisRequestActions.StringToInt(dis_request["uid"].Trim().ToUpper());
				}
				if (dis_request["sig"] != null)
				{
					this.string_2 = dis_request["sig"].ToString();
				}
				if (DisRequestActions.UnixTimestamp() - this.int_0 > 3600)
				{
					this.bool_0 = false;
				}
			}
		}
	}
}
