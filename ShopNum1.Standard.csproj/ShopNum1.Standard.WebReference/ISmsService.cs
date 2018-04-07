using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
namespace ShopNum1.Standard.WebReference
{
	[GeneratedCode("System.Web.Services", "2.0.50727.3053"), DesignerCategory("code"), DebuggerStepThrough, WebServiceBinding(Name = "ISmsServiceHttpBinding", Namespace = "http://service.ewing.com")]
	public class ISmsService : SoapHttpClientProtocol
	{
		private SendOrPostCallback sendOrPostCallback_0;
		private SendOrPostCallback sendOrPostCallback_1;
		private SendOrPostCallback sendOrPostCallback_2;
		private SendOrPostCallback sendOrPostCallback_3;
		private SendOrPostCallback sendOrPostCallback_4;
		private SendOrPostCallback sendOrPostCallback_5;
		private SendOrPostCallback sendOrPostCallback_6;
		private bool bool_0;
		private sendLSActionCompletedEventHandler sendLSActionCompletedEventHandler_0;
		private smsSendCompletedEventHandler smsSendCompletedEventHandler_0;
		private moCompletedEventHandler moCompletedEventHandler_0;
		private updatePasswordCompletedEventHandler updatePasswordCompletedEventHandler_0;
		private reportCompletedEventHandler reportCompletedEventHandler_0;
		private accountCompletedEventHandler accountCompletedEventHandler_0;
		private excelSendCompletedEventHandler excelSendCompletedEventHandler_0;
		public event sendLSActionCompletedEventHandler sendLSActionCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.sendLSActionCompletedEventHandler_0 = (sendLSActionCompletedEventHandler)Delegate.Combine(this.sendLSActionCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.sendLSActionCompletedEventHandler_0 = (sendLSActionCompletedEventHandler)Delegate.Remove(this.sendLSActionCompletedEventHandler_0, value);
			}
		}
		public event smsSendCompletedEventHandler smsSendCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.smsSendCompletedEventHandler_0 = (smsSendCompletedEventHandler)Delegate.Combine(this.smsSendCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.smsSendCompletedEventHandler_0 = (smsSendCompletedEventHandler)Delegate.Remove(this.smsSendCompletedEventHandler_0, value);
			}
		}
		public event moCompletedEventHandler moCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.moCompletedEventHandler_0 = (moCompletedEventHandler)Delegate.Combine(this.moCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.moCompletedEventHandler_0 = (moCompletedEventHandler)Delegate.Remove(this.moCompletedEventHandler_0, value);
			}
		}
		public event updatePasswordCompletedEventHandler updatePasswordCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.updatePasswordCompletedEventHandler_0 = (updatePasswordCompletedEventHandler)Delegate.Combine(this.updatePasswordCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.updatePasswordCompletedEventHandler_0 = (updatePasswordCompletedEventHandler)Delegate.Remove(this.updatePasswordCompletedEventHandler_0, value);
			}
		}
		public event reportCompletedEventHandler reportCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.reportCompletedEventHandler_0 = (reportCompletedEventHandler)Delegate.Combine(this.reportCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.reportCompletedEventHandler_0 = (reportCompletedEventHandler)Delegate.Remove(this.reportCompletedEventHandler_0, value);
			}
		}
		public event accountCompletedEventHandler accountCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.accountCompletedEventHandler_0 = (accountCompletedEventHandler)Delegate.Combine(this.accountCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.accountCompletedEventHandler_0 = (accountCompletedEventHandler)Delegate.Remove(this.accountCompletedEventHandler_0, value);
			}
		}
		public event excelSendCompletedEventHandler excelSendCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.excelSendCompletedEventHandler_0 = (excelSendCompletedEventHandler)Delegate.Combine(this.excelSendCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.excelSendCompletedEventHandler_0 = (excelSendCompletedEventHandler)Delegate.Remove(this.excelSendCompletedEventHandler_0, value);
			}
		}
		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				if (this.method_8(base.Url) && !this.bool_0 && !this.method_8(value))
				{
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}
		public new bool UseDefaultCredentials
		{
			get
			{
				return base.UseDefaultCredentials;
			}
			set
			{
				base.UseDefaultCredentials = value;
				this.bool_0 = true;
			}
		}
		public ISmsService()
		{
			this.Url = Class0.smethod_0().method_0();
			if (this.method_8(this.Url))
			{
				this.UseDefaultCredentials = true;
				this.bool_0 = false;
			}
			else
			{
				this.bool_0 = true;
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string sendLSAction([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1)
		{
			object[] array = base.Invoke("sendLSAction", new object[]
			{
				string_0,
				string_1
			});
			return (string)array[0];
		}
		public void sendLSActionAsync(string string_0, string string_1)
		{
			this.sendLSActionAsync(string_0, string_1, null);
		}
		public void sendLSActionAsync(string string_0, string string_1, object userState)
		{
			if (this.sendOrPostCallback_0 == null)
			{
				this.sendOrPostCallback_0 = new SendOrPostCallback(this.method_0);
			}
			base.InvokeAsync("sendLSAction", new object[]
			{
				string_0,
				string_1
			}, this.sendOrPostCallback_0, userState);
		}
		private void method_0(object object_0)
		{
			if (this.sendLSActionCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.sendLSActionCompletedEventHandler_0(this, new sendLSActionCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string smsSend([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1, [XmlElement(IsNullable = true)] string string_2, [XmlElement(IsNullable = true)] string string_3, [XmlElement(IsNullable = true)] string string_4, [XmlElement(IsNullable = true)] string string_5, [XmlElement(IsNullable = true)] string string_6, [XmlElement(IsNullable = true)] string string_7, [XmlElement(IsNullable = true)] string string_8)
		{
			object[] array = base.Invoke("smsSend", new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
				string_7,
				string_8
			});
			return (string)array[0];
		}
		public void smsSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8)
		{
			this.smsSendAsync(string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7, string_8, null);
		}
		public void smsSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8, object userState)
		{
			if (this.sendOrPostCallback_1 == null)
			{
				this.sendOrPostCallback_1 = new SendOrPostCallback(this.method_1);
			}
			base.InvokeAsync("smsSend", new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
				string_7,
				string_8
			}, this.sendOrPostCallback_1, userState);
		}
		private void method_1(object object_0)
		{
			if (this.smsSendCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.smsSendCompletedEventHandler_0(this, new smsSendCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string method_2([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1, [XmlElement(IsNullable = true)] string string_2)
		{
			object[] array = base.Invoke("mo", new object[]
			{
				string_0,
				string_1,
				string_2
			});
			return (string)array[0];
		}
		public void moAsync(string string_0, string string_1, string string_2)
		{
			this.moAsync(string_0, string_1, string_2, null);
		}
		public void moAsync(string string_0, string string_1, string string_2, object userState)
		{
			if (this.sendOrPostCallback_2 == null)
			{
				this.sendOrPostCallback_2 = new SendOrPostCallback(this.method_3);
			}
			base.InvokeAsync("mo", new object[]
			{
				string_0,
				string_1,
				string_2
			}, this.sendOrPostCallback_2, userState);
		}
		private void method_3(object object_0)
		{
			if (this.moCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.moCompletedEventHandler_0(this, new moCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string updatePassword([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1, [XmlElement(IsNullable = true)] string string_2, [XmlElement(IsNullable = true)] string string_3)
		{
			object[] array = base.Invoke("updatePassword", new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3
			});
			return (string)array[0];
		}
		public void updatePasswordAsync(string string_0, string string_1, string string_2, string string_3)
		{
			this.updatePasswordAsync(string_0, string_1, string_2, string_3, null);
		}
		public void updatePasswordAsync(string string_0, string string_1, string string_2, string string_3, object userState)
		{
			if (this.sendOrPostCallback_3 == null)
			{
				this.sendOrPostCallback_3 = new SendOrPostCallback(this.method_4);
			}
			base.InvokeAsync("updatePassword", new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3
			}, this.sendOrPostCallback_3, userState);
		}
		private void method_4(object object_0)
		{
			if (this.updatePasswordCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.updatePasswordCompletedEventHandler_0(this, new updatePasswordCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string report([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1, [XmlElement(IsNullable = true)] string string_2)
		{
			object[] array = base.Invoke("report", new object[]
			{
				string_0,
				string_1,
				string_2
			});
			return (string)array[0];
		}
		public void reportAsync(string string_0, string string_1, string string_2)
		{
			this.reportAsync(string_0, string_1, string_2, null);
		}
		public void reportAsync(string string_0, string string_1, string string_2, object userState)
		{
			if (this.sendOrPostCallback_4 == null)
			{
				this.sendOrPostCallback_4 = new SendOrPostCallback(this.method_5);
			}
			base.InvokeAsync("report", new object[]
			{
				string_0,
				string_1,
				string_2
			}, this.sendOrPostCallback_4, userState);
		}
		private void method_5(object object_0)
		{
			if (this.reportCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.reportCompletedEventHandler_0(this, new reportCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string account([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1, [XmlElement(IsNullable = true)] string string_2)
		{
			object[] array = base.Invoke("account", new object[]
			{
				string_0,
				string_1,
				string_2
			});
			return (string)array[0];
		}
		public void accountAsync(string string_0, string string_1, string string_2)
		{
			this.accountAsync(string_0, string_1, string_2, null);
		}
		public void accountAsync(string string_0, string string_1, string string_2, object userState)
		{
			if (this.sendOrPostCallback_5 == null)
			{
				this.sendOrPostCallback_5 = new SendOrPostCallback(this.method_6);
			}
			base.InvokeAsync("account", new object[]
			{
				string_0,
				string_1,
				string_2
			}, this.sendOrPostCallback_5, userState);
		}
		private void method_6(object object_0)
		{
			if (this.accountCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.accountCompletedEventHandler_0(this, new accountCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com", ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("out", IsNullable = true)]
		public string excelSend([XmlElement(IsNullable = true)] string string_0, [XmlElement(IsNullable = true)] string string_1, [XmlElement(IsNullable = true)] string string_2, [XmlElement(IsNullable = true)] string string_3, [XmlElement(IsNullable = true)] string string_4, [XmlElement(IsNullable = true)] string string_5, [XmlElement(IsNullable = true)] string string_6, [XmlElement(IsNullable = true)] string string_7, [XmlElement(IsNullable = true)] string string_8)
		{
			object[] array = base.Invoke("excelSend", new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
				string_7,
				string_8
			});
			return (string)array[0];
		}
		public void excelSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8)
		{
			this.excelSendAsync(string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7, string_8, null);
		}
		public void excelSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8, object userState)
		{
			if (this.sendOrPostCallback_6 == null)
			{
				this.sendOrPostCallback_6 = new SendOrPostCallback(this.method_7);
			}
			base.InvokeAsync("excelSend", new object[]
			{
				string_0,
				string_1,
				string_2,
				string_3,
				string_4,
				string_5,
				string_6,
				string_7,
				string_8
			}, this.sendOrPostCallback_6, userState);
		}
		private void method_7(object object_0)
		{
			if (this.excelSendCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.excelSendCompletedEventHandler_0(this, new excelSendCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}
		private bool method_8(string string_0)
		{
			bool result;
			if (string_0 == null || string_0 == string.Empty)
			{
				result = false;
			}
			else
			{
				Uri uri = new Uri(string_0);
				result = (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0);
			}
			return result;
		}
	}
}
