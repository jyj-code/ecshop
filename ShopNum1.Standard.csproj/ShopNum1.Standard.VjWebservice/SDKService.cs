using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Schema;
using System.Xml.Serialization;
namespace ShopNum1.Standard.VjWebservice
{
	[GeneratedCode("System.Web.Services", "2.0.50727.1433"), DesignerCategory("code"), DebuggerStepThrough, WebServiceBinding(Name = "SDKServiceBinding", Namespace = "http://sdkhttp.eucp.b2m.cn/")]
	public class SDKService : SoapHttpClientProtocol
	{
		private SendOrPostCallback sendOrPostCallback_0;
		private SendOrPostCallback sendOrPostCallback_1;
		private SendOrPostCallback sendOrPostCallback_2;
		private SendOrPostCallback sendOrPostCallback_3;
		private SendOrPostCallback sendOrPostCallback_4;
		private SendOrPostCallback sendOrPostCallback_5;
		private SendOrPostCallback sendOrPostCallback_6;
		private SendOrPostCallback sendOrPostCallback_7;
		private SendOrPostCallback sendOrPostCallback_8;
		private SendOrPostCallback sendOrPostCallback_9;
		private SendOrPostCallback sendOrPostCallback_10;
		private SendOrPostCallback sendOrPostCallback_11;
		private SendOrPostCallback sendOrPostCallback_12;
		private SendOrPostCallback sendOrPostCallback_13;
		private bool bool_0;
		private getVersionCompletedEventHandler getVersionCompletedEventHandler_0;
		private getReportCompletedEventHandler getReportCompletedEventHandler_0;
		private cancelMOForwardCompletedEventHandler cancelMOForwardCompletedEventHandler_0;
		private chargeUpCompletedEventHandler chargeUpCompletedEventHandler_0;
		private getBalanceCompletedEventHandler getBalanceCompletedEventHandler_0;
		private getEachFeeCompletedEventHandler getEachFeeCompletedEventHandler_0;
		private getMOCompletedEventHandler getMOCompletedEventHandler_0;
		private logoutCompletedEventHandler logoutCompletedEventHandler_0;
		private registDetailInfoCompletedEventHandler registDetailInfoCompletedEventHandler_0;
		private registExCompletedEventHandler registExCompletedEventHandler_0;
		private sendSMSCompletedEventHandler sendSMSCompletedEventHandler_0;
		private serialPwdUpdCompletedEventHandler serialPwdUpdCompletedEventHandler_0;
		private setMOForwardCompletedEventHandler setMOForwardCompletedEventHandler_0;
		private setMOForwardExCompletedEventHandler setMOForwardExCompletedEventHandler_0;
		public event getVersionCompletedEventHandler getVersionCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.getVersionCompletedEventHandler_0 = (getVersionCompletedEventHandler)Delegate.Combine(this.getVersionCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.getVersionCompletedEventHandler_0 = (getVersionCompletedEventHandler)Delegate.Remove(this.getVersionCompletedEventHandler_0, value);
			}
		}
		public event getReportCompletedEventHandler getReportCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.getReportCompletedEventHandler_0 = (getReportCompletedEventHandler)Delegate.Combine(this.getReportCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.getReportCompletedEventHandler_0 = (getReportCompletedEventHandler)Delegate.Remove(this.getReportCompletedEventHandler_0, value);
			}
		}
		public event cancelMOForwardCompletedEventHandler cancelMOForwardCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.cancelMOForwardCompletedEventHandler_0 = (cancelMOForwardCompletedEventHandler)Delegate.Combine(this.cancelMOForwardCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.cancelMOForwardCompletedEventHandler_0 = (cancelMOForwardCompletedEventHandler)Delegate.Remove(this.cancelMOForwardCompletedEventHandler_0, value);
			}
		}
		public event chargeUpCompletedEventHandler chargeUpCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.chargeUpCompletedEventHandler_0 = (chargeUpCompletedEventHandler)Delegate.Combine(this.chargeUpCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.chargeUpCompletedEventHandler_0 = (chargeUpCompletedEventHandler)Delegate.Remove(this.chargeUpCompletedEventHandler_0, value);
			}
		}
		public event getBalanceCompletedEventHandler getBalanceCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.getBalanceCompletedEventHandler_0 = (getBalanceCompletedEventHandler)Delegate.Combine(this.getBalanceCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.getBalanceCompletedEventHandler_0 = (getBalanceCompletedEventHandler)Delegate.Remove(this.getBalanceCompletedEventHandler_0, value);
			}
		}
		public event getEachFeeCompletedEventHandler getEachFeeCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.getEachFeeCompletedEventHandler_0 = (getEachFeeCompletedEventHandler)Delegate.Combine(this.getEachFeeCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.getEachFeeCompletedEventHandler_0 = (getEachFeeCompletedEventHandler)Delegate.Remove(this.getEachFeeCompletedEventHandler_0, value);
			}
		}
		public event getMOCompletedEventHandler getMOCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.getMOCompletedEventHandler_0 = (getMOCompletedEventHandler)Delegate.Combine(this.getMOCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.getMOCompletedEventHandler_0 = (getMOCompletedEventHandler)Delegate.Remove(this.getMOCompletedEventHandler_0, value);
			}
		}
		public event logoutCompletedEventHandler logoutCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.logoutCompletedEventHandler_0 = (logoutCompletedEventHandler)Delegate.Combine(this.logoutCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.logoutCompletedEventHandler_0 = (logoutCompletedEventHandler)Delegate.Remove(this.logoutCompletedEventHandler_0, value);
			}
		}
		public event registDetailInfoCompletedEventHandler registDetailInfoCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.registDetailInfoCompletedEventHandler_0 = (registDetailInfoCompletedEventHandler)Delegate.Combine(this.registDetailInfoCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.registDetailInfoCompletedEventHandler_0 = (registDetailInfoCompletedEventHandler)Delegate.Remove(this.registDetailInfoCompletedEventHandler_0, value);
			}
		}
		public event registExCompletedEventHandler registExCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.registExCompletedEventHandler_0 = (registExCompletedEventHandler)Delegate.Combine(this.registExCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.registExCompletedEventHandler_0 = (registExCompletedEventHandler)Delegate.Remove(this.registExCompletedEventHandler_0, value);
			}
		}
		public event sendSMSCompletedEventHandler sendSMSCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.sendSMSCompletedEventHandler_0 = (sendSMSCompletedEventHandler)Delegate.Combine(this.sendSMSCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.sendSMSCompletedEventHandler_0 = (sendSMSCompletedEventHandler)Delegate.Remove(this.sendSMSCompletedEventHandler_0, value);
			}
		}
		public event serialPwdUpdCompletedEventHandler serialPwdUpdCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.serialPwdUpdCompletedEventHandler_0 = (serialPwdUpdCompletedEventHandler)Delegate.Combine(this.serialPwdUpdCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.serialPwdUpdCompletedEventHandler_0 = (serialPwdUpdCompletedEventHandler)Delegate.Remove(this.serialPwdUpdCompletedEventHandler_0, value);
			}
		}
		public event setMOForwardCompletedEventHandler setMOForwardCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.setMOForwardCompletedEventHandler_0 = (setMOForwardCompletedEventHandler)Delegate.Combine(this.setMOForwardCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.setMOForwardCompletedEventHandler_0 = (setMOForwardCompletedEventHandler)Delegate.Remove(this.setMOForwardCompletedEventHandler_0, value);
			}
		}
		public event setMOForwardExCompletedEventHandler setMOForwardExCompleted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.setMOForwardExCompletedEventHandler_0 = (setMOForwardExCompletedEventHandler)Delegate.Combine(this.setMOForwardExCompletedEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.setMOForwardExCompletedEventHandler_0 = (setMOForwardExCompletedEventHandler)Delegate.Remove(this.setMOForwardExCompletedEventHandler_0, value);
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
				if (this.method_14(base.Url) && !this.bool_0 && !this.method_14(value))
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
		public SDKService()
		{
			this.Url = Class0.smethod_0().method_1();
			if (this.method_14(this.Url))
			{
				this.UseDefaultCredentials = true;
				this.bool_0 = false;
			}
			else
			{
				this.bool_0 = true;
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public string getVersion()
		{
			object[] array = base.Invoke("getVersion", new object[0]);
			return (string)array[0];
		}
		public void getVersionAsync()
		{
			this.getVersionAsync(null);
		}
		public void getVersionAsync(object userState)
		{
			if (this.sendOrPostCallback_0 == null)
			{
				this.sendOrPostCallback_0 = new SendOrPostCallback(this.method_0);
			}
			base.InvokeAsync("getVersion", new object[0], this.sendOrPostCallback_0, userState);
		}
		private void method_0(object object_0)
		{
			if (this.getVersionCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.getVersionCompletedEventHandler_0(this, new getVersionCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public statusReport[] getReport([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
		{
			object[] array = base.Invoke("getReport", new object[]
			{
				arg0,
				arg1
			});
			return (statusReport[])array[0];
		}
		public void getReportAsync(string arg0, string arg1)
		{
			this.getReportAsync(arg0, arg1, null);
		}
		public void getReportAsync(string arg0, string arg1, object userState)
		{
			if (this.sendOrPostCallback_1 == null)
			{
				this.sendOrPostCallback_1 = new SendOrPostCallback(this.method_1);
			}
			base.InvokeAsync("getReport", new object[]
			{
				arg0,
				arg1
			}, this.sendOrPostCallback_1, userState);
		}
		private void method_1(object object_0)
		{
			if (this.getReportCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.getReportCompletedEventHandler_0(this, new getReportCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int cancelMOForward([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
		{
			object[] array = base.Invoke("cancelMOForward", new object[]
			{
				arg0,
				arg1
			});
			return (int)array[0];
		}
		public void cancelMOForwardAsync(string arg0, string arg1)
		{
			this.cancelMOForwardAsync(arg0, arg1, null);
		}
		public void cancelMOForwardAsync(string arg0, string arg1, object userState)
		{
			if (this.sendOrPostCallback_2 == null)
			{
				this.sendOrPostCallback_2 = new SendOrPostCallback(this.method_2);
			}
			base.InvokeAsync("cancelMOForward", new object[]
			{
				arg0,
				arg1
			}, this.sendOrPostCallback_2, userState);
		}
		private void method_2(object object_0)
		{
			if (this.cancelMOForwardCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.cancelMOForwardCompletedEventHandler_0(this, new cancelMOForwardCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int chargeUp([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg3)
		{
			object[] array = base.Invoke("chargeUp", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3
			});
			return (int)array[0];
		}
		public void chargeUpAsync(string arg0, string arg1, string arg2, string arg3)
		{
			this.chargeUpAsync(arg0, arg1, arg2, arg3, null);
		}
		public void chargeUpAsync(string arg0, string arg1, string arg2, string arg3, object userState)
		{
			if (this.sendOrPostCallback_3 == null)
			{
				this.sendOrPostCallback_3 = new SendOrPostCallback(this.method_3);
			}
			base.InvokeAsync("chargeUp", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3
			}, this.sendOrPostCallback_3, userState);
		}
		private void method_3(object object_0)
		{
			if (this.chargeUpCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.chargeUpCompletedEventHandler_0(this, new chargeUpCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public double getBalance([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
		{
			object[] array = base.Invoke("getBalance", new object[]
			{
				arg0,
				arg1
			});
			return (double)array[0];
		}
		public void getBalanceAsync(string arg0, string arg1)
		{
			this.getBalanceAsync(arg0, arg1, null);
		}
		public void getBalanceAsync(string arg0, string arg1, object userState)
		{
			if (this.sendOrPostCallback_4 == null)
			{
				this.sendOrPostCallback_4 = new SendOrPostCallback(this.method_4);
			}
			base.InvokeAsync("getBalance", new object[]
			{
				arg0,
				arg1
			}, this.sendOrPostCallback_4, userState);
		}
		private void method_4(object object_0)
		{
			if (this.getBalanceCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.getBalanceCompletedEventHandler_0(this, new getBalanceCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public double getEachFee([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
		{
			object[] array = base.Invoke("getEachFee", new object[]
			{
				arg0,
				arg1
			});
			return (double)array[0];
		}
		public void getEachFeeAsync(string arg0, string arg1)
		{
			this.getEachFeeAsync(arg0, arg1, null);
		}
		public void getEachFeeAsync(string arg0, string arg1, object userState)
		{
			if (this.sendOrPostCallback_5 == null)
			{
				this.sendOrPostCallback_5 = new SendOrPostCallback(this.method_5);
			}
			base.InvokeAsync("getEachFee", new object[]
			{
				arg0,
				arg1
			}, this.sendOrPostCallback_5, userState);
		}
		private void method_5(object object_0)
		{
			if (this.getEachFeeCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.getEachFeeCompletedEventHandler_0(this, new getEachFeeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public GClass0[] getMO([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
		{
			object[] array = base.Invoke("getMO", new object[]
			{
				arg0,
				arg1
			});
			return (GClass0[])array[0];
		}
		public void getMOAsync(string arg0, string arg1)
		{
			this.getMOAsync(arg0, arg1, null);
		}
		public void getMOAsync(string arg0, string arg1, object userState)
		{
			if (this.sendOrPostCallback_6 == null)
			{
				this.sendOrPostCallback_6 = new SendOrPostCallback(this.method_6);
			}
			base.InvokeAsync("getMO", new object[]
			{
				arg0,
				arg1
			}, this.sendOrPostCallback_6, userState);
		}
		private void method_6(object object_0)
		{
			if (this.getMOCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.getMOCompletedEventHandler_0(this, new getMOCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int logout([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
		{
			object[] array = base.Invoke("logout", new object[]
			{
				arg0,
				arg1
			});
			return (int)array[0];
		}
		public void logoutAsync(string arg0, string arg1)
		{
			this.logoutAsync(arg0, arg1, null);
		}
		public void logoutAsync(string arg0, string arg1, object userState)
		{
			if (this.sendOrPostCallback_7 == null)
			{
				this.sendOrPostCallback_7 = new SendOrPostCallback(this.method_7);
			}
			base.InvokeAsync("logout", new object[]
			{
				arg0,
				arg1
			}, this.sendOrPostCallback_7, userState);
		}
		private void method_7(object object_0)
		{
			if (this.logoutCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.logoutCompletedEventHandler_0(this, new logoutCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int registDetailInfo([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg3, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg4, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg5, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg6, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg7, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg8, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg9)
		{
			object[] array = base.Invoke("registDetailInfo", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3,
				arg4,
				arg5,
				arg6,
				arg7,
				arg8,
				arg9
			});
			return (int)array[0];
		}
		public void registDetailInfoAsync(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5, string arg6, string arg7, string arg8, string arg9)
		{
			this.registDetailInfoAsync(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, null);
		}
		public void registDetailInfoAsync(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5, string arg6, string arg7, string arg8, string arg9, object userState)
		{
			if (this.sendOrPostCallback_8 == null)
			{
				this.sendOrPostCallback_8 = new SendOrPostCallback(this.method_8);
			}
			base.InvokeAsync("registDetailInfo", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3,
				arg4,
				arg5,
				arg6,
				arg7,
				arg8,
				arg9
			}, this.sendOrPostCallback_8, userState);
		}
		private void method_8(object object_0)
		{
			if (this.registDetailInfoCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.registDetailInfoCompletedEventHandler_0(this, new registDetailInfoCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int registEx([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2)
		{
			object[] array = base.Invoke("registEx", new object[]
			{
				arg0,
				arg1,
				arg2
			});
			return (int)array[0];
		}
		public void registExAsync(string arg0, string arg1, string arg2)
		{
			this.registExAsync(arg0, arg1, arg2, null);
		}
		public void registExAsync(string arg0, string arg1, string arg2, object userState)
		{
			if (this.sendOrPostCallback_9 == null)
			{
				this.sendOrPostCallback_9 = new SendOrPostCallback(this.method_9);
			}
			base.InvokeAsync("registEx", new object[]
			{
				arg0,
				arg1,
				arg2
			}, this.sendOrPostCallback_9, userState);
		}
		private void method_9(object object_0)
		{
			if (this.registExCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.registExCompletedEventHandler_0(this, new registExCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int sendSMS([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2, [XmlElement("arg3", Form = XmlSchemaForm.Unqualified, IsNullable = true)] string[] arg3, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg4, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg5, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg6, [XmlElement(Form = XmlSchemaForm.Unqualified)] int arg7, [XmlElement(Form = XmlSchemaForm.Unqualified)] long arg8)
		{
			object[] array = base.Invoke("sendSMS", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3,
				arg4,
				arg5,
				arg6,
				arg7,
				arg8
			});
			return (int)array[0];
		}
		public void sendSMSAsync(string arg0, string arg1, string arg2, string[] arg3, string arg4, string arg5, string arg6, int arg7, long arg8)
		{
			this.sendSMSAsync(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, null);
		}
		public void sendSMSAsync(string arg0, string arg1, string arg2, string[] arg3, string arg4, string arg5, string arg6, int arg7, long arg8, object userState)
		{
			if (this.sendOrPostCallback_10 == null)
			{
				this.sendOrPostCallback_10 = new SendOrPostCallback(this.method_10);
			}
			base.InvokeAsync("sendSMS", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3,
				arg4,
				arg5,
				arg6,
				arg7,
				arg8
			}, this.sendOrPostCallback_10, userState);
		}
		private void method_10(object object_0)
		{
			if (this.sendSMSCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.sendSMSCompletedEventHandler_0(this, new sendSMSCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int serialPwdUpd([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg3)
		{
			object[] array = base.Invoke("serialPwdUpd", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3
			});
			return (int)array[0];
		}
		public void serialPwdUpdAsync(string arg0, string arg1, string arg2, string arg3)
		{
			this.serialPwdUpdAsync(arg0, arg1, arg2, arg3, null);
		}
		public void serialPwdUpdAsync(string arg0, string arg1, string arg2, string arg3, object userState)
		{
			if (this.sendOrPostCallback_11 == null)
			{
				this.sendOrPostCallback_11 = new SendOrPostCallback(this.method_11);
			}
			base.InvokeAsync("serialPwdUpd", new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3
			}, this.sendOrPostCallback_11, userState);
		}
		private void method_11(object object_0)
		{
			if (this.serialPwdUpdCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.serialPwdUpdCompletedEventHandler_0(this, new serialPwdUpdCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int setMOForward([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2)
		{
			object[] array = base.Invoke("setMOForward", new object[]
			{
				arg0,
				arg1,
				arg2
			});
			return (int)array[0];
		}
		public void setMOForwardAsync(string arg0, string arg1, string arg2)
		{
			this.setMOForwardAsync(arg0, arg1, arg2, null);
		}
		public void setMOForwardAsync(string arg0, string arg1, string arg2, object userState)
		{
			if (this.sendOrPostCallback_12 == null)
			{
				this.sendOrPostCallback_12 = new SendOrPostCallback(this.method_12);
			}
			base.InvokeAsync("setMOForward", new object[]
			{
				arg0,
				arg1,
				arg2
			}, this.sendOrPostCallback_12, userState);
		}
		private void method_12(object object_0)
		{
			if (this.setMOForwardCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.setMOForwardCompletedEventHandler_0(this, new setMOForwardCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		[SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/", ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
		public int setMOForwardEx([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0, [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1, [XmlElement("arg2", Form = XmlSchemaForm.Unqualified, IsNullable = true)] string[] arg2)
		{
			object[] array = base.Invoke("setMOForwardEx", new object[]
			{
				arg0,
				arg1,
				arg2
			});
			return (int)array[0];
		}
		public void setMOForwardExAsync(string arg0, string arg1, string[] arg2)
		{
			this.setMOForwardExAsync(arg0, arg1, arg2, null);
		}
		public void setMOForwardExAsync(string arg0, string arg1, string[] arg2, object userState)
		{
			if (this.sendOrPostCallback_13 == null)
			{
				this.sendOrPostCallback_13 = new SendOrPostCallback(this.method_13);
			}
			base.InvokeAsync("setMOForwardEx", new object[]
			{
				arg0,
				arg1,
				arg2
			}, this.sendOrPostCallback_13, userState);
		}
		private void method_13(object object_0)
		{
			if (this.setMOForwardExCompletedEventHandler_0 != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)object_0;
				this.setMOForwardExCompletedEventHandler_0(this, new setMOForwardExCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}
		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}
		private bool method_14(string string_0)
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
