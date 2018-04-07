using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	public class WebControl : System.Web.UI.WebControls.WebControl, IWebControl
	{
		private string string_0 = "";
		private string string_1 = "";
		private int int_0 = 0;
		private int int_1 = 0;
		private string string_2 = "up";
		private int int_2 = 50;
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string HintTitle
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
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string HintInfo
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
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintLeftOffSet
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
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintTopOffSet
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
		[Bindable(true), Category("Appearance"), DefaultValue("up")]
		public string HintShowType
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
		[Bindable(true), Category("Appearance"), DefaultValue(50)]
		public int HintHeight
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
	}
}
