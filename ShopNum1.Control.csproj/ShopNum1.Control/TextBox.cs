using ShopNum1.Common;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[DefaultProperty("Text"), Designer("System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxData("<{0}:TextBox runat=server></{0}:TextBox>")]
	public class TextBox : System.Web.UI.WebControls.TextBox, IWebControl
	{
		protected RequiredFieldValidator CanBeNullRFV = new RequiredFieldValidator();
		protected RegularExpressionValidator RequiredFieldTypeREV = new RegularExpressionValidator();
		protected RangeValidator NumberRV = new RangeValidator();
		protected Label lablShow = new Label();
		private int int_0 = 30;
		private string string_0 = null;
		private string string_1 = null;
		private string string_2 = "";
		private string string_3 = "";
		private int int_1 = 0;
		private int int_2 = 0;
		private string string_4 = "up";
		private int int_3 = 50;
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string SetFocusButtonID
		{
			get
			{
				object obj = this.ViewState[this.ClientID + "_SetFocusButtonID"];
				return (obj == null) ? "" : obj.ToString();
			}
			set
			{
				this.ViewState[this.ClientID + "_SetFocusButtonID"] = value;
				if (value != "")
				{
					base.Attributes.Add("onkeydown", "if(event.keyCode==13){document.getElementById('" + value + "').focus();}");
				}
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public override int MaxLength
		{
			get
			{
				object obj = this.ViewState["TextBox_MaxLength"];
				int result;
				if (obj != null)
				{
					int num = Utils.StrToInt(obj.ToString(), 4);
					this.AddAttributes("maxlength", num.ToString());
					result = num;
				}
				else
				{
					result = -1;
				}
				return result;
			}
			set
			{
				this.ViewState["TextBox_MaxLength"] = value;
				this.AddAttributes("maxlength", value.ToString());
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public override string ValidationGroup
		{
			get
			{
				object obj = this.ViewState["ValidationGroup"];
				string result;
				if (obj != null)
				{
					this.AddAttributes("ValidationGroup", obj.ToString());
					result = obj.ToString();
				}
				else
				{
					result = "";
				}
				return result;
			}
			set
			{
				this.ViewState["ValidationGroup"] = value;
				this.AddAttributes("ValidationGroup", this.ValidationGroup);
			}
		}
		[Bindable(false), Category("Behavior"), DefaultValue(TextBoxMode.SingleLine), Description("要滚动的对象。")]
		public override TextBoxMode TextMode
		{
			get
			{
				return base.TextMode;
			}
			set
			{
				if (value == TextBoxMode.MultiLine)
				{
					base.Attributes.Add("onkeyup", "return isMaxLen(this)");
				}
				base.TextMode = value;
			}
		}
		[Bindable(false), Category("Behavior"), DefaultValue(""), Description("要滚动的对象。"), TypeConverter(typeof(RequiredFieldTypeControlsConverter))]
		public string RequiredFieldType
		{
			get
			{
				object obj = this.ViewState["RequiredFieldType"];
				return (obj == null) ? "" : obj.ToString();
			}
			set
			{
				this.ViewState["RequiredFieldType"] = value;
			}
		}
		[Bindable(false), Category("Behavior"), DefaultValue("可为空"), Description("要滚动的对象。"), TypeConverter(typeof(CanBeNullControlsConverter))]
		public string CanBeNull
		{
			get
			{
				object obj = this.ViewState["CanBeNull"];
				return (obj == null) ? "" : obj.ToString();
			}
			set
			{
				this.ViewState["CanBeNull"] = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public bool IsReplaceInvertedComma
		{
			get
			{
				object obj = this.ViewState["IsReplaceInvertedComma"];
				return obj == null || obj.ToString().Trim() == "" || obj.ToString().ToLower() == "true";
			}
			set
			{
				this.ViewState["IsReplaceInvertedComma"] = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string ValidationExpression
		{
			get
			{
				object obj = this.ViewState["ValidationExpression"];
				string result;
				if (obj == null || obj.ToString().Trim() == "")
				{
					result = null;
				}
				else
				{
					result = obj.ToString().ToLower();
				}
				return result;
			}
			set
			{
				this.ViewState["ValidationExpression"] = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public override string Text
		{
			get
			{
				string result;
				if (this.RequiredFieldType == "日期")
				{
					try
					{
						result = DateTime.Parse(base.Text).ToString("yyyy-MM-dd");
						return result;
					}
					catch
					{
						result = "";
						return result;
					}
				}
				if (this.RequiredFieldType == "日期时间")
				{
					try
					{
						result = DateTime.Parse(base.Text).ToString("yyyy-MM-dd HH:mm:ss");
						return result;
					}
					catch
					{
						result = "";
						return result;
					}
				}
				result = (this.IsReplaceInvertedComma ? base.Text.Replace("'", "''").Trim() : base.Text);
				return result;
			}
			set
			{
				if (this.RequiredFieldType.IndexOf("日期") >= 0)
				{
					try
					{
						base.Text = DateTime.Parse(value).ToString("yyyy-MM-dd");
					}
					catch
					{
						base.Text = "";
					}
				}
				if (this.RequiredFieldType.IndexOf("日期时间") >= 0)
				{
					try
					{
						base.Text = DateTime.Parse(value).ToString("yyyy-MM-dd HH:mm:ss");
						return;
					}
					catch
					{
						base.Text = "";
						return;
					}
				}
				base.Text = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(30)]
		public int Cols
		{
			get
			{
				return base.Columns;
			}
			set
			{
				base.Columns = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(30)]
		public int Size
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
		[Bindable(true), Category("Appearance"), DefaultValue(null)]
		public string MaximumValue
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
		[Bindable(true), Category("Appearance"), DefaultValue(null)]
		public string MinimumValue
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
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string HintTitle
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
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string HintInfo
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
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintLeftOffSet
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
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintTopOffSet
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
		[Bindable(true), Category("Appearance"), DefaultValue("up")]
		public string HintShowType
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
		[Bindable(true), Category("Appearance"), DefaultValue(130)]
		public int HintHeight
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}
		public void AddAttributes(string string_5, string valuestr)
		{
			base.Attributes.Add(string_5, valuestr);
		}
		protected override void CreateChildControls()
		{
			string text;
			if (this.RequiredFieldType != null && this.RequiredFieldType != "" && this.RequiredFieldType != "暂无校验")
			{
				if (this.ValidationGroup != "")
				{
					this.RequiredFieldTypeREV.ValidationGroup = this.ValidationGroup;
				}
				this.RequiredFieldTypeREV.Display = ValidatorDisplay.Dynamic;
				this.RequiredFieldTypeREV.ControlToValidate = this.ID;
				text = this.RequiredFieldType;
				switch (text)
				{
				case "数据校验":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^[-]?\\d+[.]?\\d*$");
					this.RequiredFieldTypeREV.ErrorMessage = "数字的格式不正确";
					break;
				case "整数验证":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^\\d{1,9}$");
					this.RequiredFieldTypeREV.ErrorMessage = "格式不正确";
					break;
				case "电子邮箱":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
					this.RequiredFieldTypeREV.ErrorMessage = "邮箱的格式不正确";
					break;
				case "邮政编码":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^[0-9 ]{3,12}$");
					this.RequiredFieldTypeREV.ErrorMessage = "邮政编码格式不正确";
					break;
				case "移动手机":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(1[3|5|8][0-9])\\d{8}$");
					this.RequiredFieldTypeREV.ErrorMessage = "手机格式不对!";
					break;
				case "家用电话":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{8}|((\\(\\d{3}\\) ?)|(\\d{4}-))?\\d{4}-\\d{7}");
					this.RequiredFieldTypeREV.ErrorMessage = "电话号码格式为XXX-XXXXXXXX或XXXX-XXXXXXX！";
					break;
				case "身份证号码":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^\\d{15}$|^\\d{17}[\\d|X]$");
					this.RequiredFieldTypeREV.ErrorMessage = "身份证号位15或18位!";
					break;
				case "网页地址":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(http|https)\\://([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&%\\$\\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\\:[0-9]+)*(/($|[a-zA-Z0-9\\.\\,\\?\\'\\\\\\+&%\\$#\\=~_\\-]+))*$");
					this.RequiredFieldTypeREV.ErrorMessage = "格式为https://xxx.xx或http://xxxx.xx";
					break;
				case "日期":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-9]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
					this.RequiredFieldTypeREV.ErrorMessage = "日期格式为2006-1-1";
					break;
				case "日期时间":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-9]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\\d):[0-5]?\\d:[0-5]?\\d$");
					this.RequiredFieldTypeREV.ErrorMessage = "时间格式为2006-1-1 23:59:59";
					break;
				case "金额":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(([0-9]{1,9})|([0-9]{1,9}\\.[0-9]{0,2}))$");
					this.RequiredFieldTypeREV.ErrorMessage = "请输入正确的金额";
					break;
				case "IP地址":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
					this.RequiredFieldTypeREV.ErrorMessage = "请输入正确的IP地址";
					break;
				case "IP地址带端口":
					this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9]):\\d{1,5}?$");
					this.RequiredFieldTypeREV.ErrorMessage = "请输入正确的带端口的IP地址";
					break;
				}
				this.Controls.AddAt(0, this.RequiredFieldTypeREV);
				if (this.MaximumValue != null || this.MinimumValue != null)
				{
					this.NumberRV.ControlToValidate = this.ID;
					this.NumberRV.Type = ValidationDataType.Double;
					this.NumberRV.Display = ValidatorDisplay.Dynamic;
					if (this.MaximumValue != null && this.MinimumValue != null)
					{
						this.NumberRV.MaximumValue = this.MaximumValue;
						this.NumberRV.MinimumValue = this.MinimumValue;
						this.NumberRV.ErrorMessage = string.Concat(new string[]
						{
							"输入数据应在",
							this.MinimumValue,
							"和",
							this.MaximumValue,
							"之间!"
						});
					}
					else
					{
						if (this.MaximumValue != null)
						{
							this.NumberRV.MaximumValue = this.MaximumValue;
							RangeValidator arg_53A_0 = this.NumberRV;
							int num = -2147483648;
							arg_53A_0.MinimumValue = num.ToString();
							this.NumberRV.ErrorMessage = "输入允许最大值为" + this.MaximumValue;
						}
						if (this.MinimumValue != null)
						{
							this.NumberRV.MinimumValue = this.MinimumValue;
							RangeValidator arg_589_0 = this.NumberRV;
							int num = 2147483647;
							arg_589_0.MaximumValue = num.ToString();
							this.NumberRV.ErrorMessage = "输入允许最小值为" + this.MinimumValue;
						}
					}
					this.Controls.AddAt(0, this.NumberRV);
				}
			}
			text = this.CanBeNull;
			if (text != null && !(text == "可为空") && text == "必填")
			{
				this.lablShow.Style.Add(HtmlTextWriterStyle.Color, "red");
				this.lablShow.Text = "*";
				this.CanBeNullRFV.Display = ValidatorDisplay.Dynamic;
				this.CanBeNullRFV.ControlToValidate = this.ID;
				this.CanBeNullRFV.ErrorMessage = "不能为空!";
				this.Controls.AddAt(0, this.lablShow);
				this.Controls.AddAt(1, this.CanBeNullRFV);
			}
		}
		protected override void Render(HtmlTextWriter output)
		{
			if (this.TextMode == TextBoxMode.MultiLine)
			{
				output.WriteLine("<script type=\"text/javascript\">");
				output.WriteLine("function isMaxLen(o){");
				output.WriteLine("var nMaxLen=o.getAttribute? parseInt(o.getAttribute(\"maxlength\")):\"\";");
				output.WriteLine(" if(o.getAttribute && o.value.length>nMaxLen){");
				output.WriteLine(" o.value=o.value.substring(0,nMaxLen)");
				output.WriteLine("}}</script>");
				this.AddAttributes("rows", this.Rows.ToString());
				this.AddAttributes("cols", this.Cols.ToString());
				base.Attributes.Add("onfocus", "this.className='FormFocus';");
				base.Attributes.Add("onblur", "this.className='FormBase';");
				base.Attributes.Add("class", "FormBase");
			}
			else if (this.TextMode == TextBoxMode.Password)
			{
				this.AddAttributes("value", this.Text);
			}
			if (this.HintInfo != "")
			{
				this.AddAttributes("onmouseover", string.Concat(new object[]
				{
					"showhintinfo(this,",
					this.HintLeftOffSet,
					",",
					this.HintTopOffSet,
					",'",
					this.HintTitle,
					"','",
					this.HintInfo,
					"','",
					this.HintHeight,
					"','",
					this.HintShowType,
					"')"
				}));
				this.AddAttributes("onmouseout", "hidehintinfo()");
			}
			base.Render(output);
			this.RenderChildren(output);
		}
	}
}
