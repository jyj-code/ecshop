using System;
namespace ShopNum1.WeiXinCommon
{
	public class ReplyInfoModel
	{
		private int int_0 = 0;
		private string string_0 = string.Empty;
		private int int_1 = 0;
		private string string_1 = string.Empty;
		private bool bool_0 = false;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		private string string_7 = string.Empty;
		private DateTime dateTime_0 = Convert.ToDateTime("1901-01-01 00:00:00");
		private bool bool_1 = false;
		public int RecId
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public string KeyWord
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public int RepMsgType
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		public string RepMsgContent
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public bool IsSinglePicRep
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public string Title
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public string Description
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string ImgSrc
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string Url
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string Music_Url
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		public string HQ_Music_Url
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public DateTime ModifyDate
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				this.dateTime_0 = value;
			}
		}
		public bool IsDelete
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}
	}
}
