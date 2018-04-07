using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
namespace ShopNum1.Standard.WebReference
{
	[GeneratedCode("System.Web.Services", "2.0.50727.3053"), DesignerCategory("code"), DebuggerStepThrough]
	public class reportCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] object_0;
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.object_0[0];
			}
		}
		internal reportCompletedEventArgs(object[] object_1, Exception exception_0, bool bool_0, object object_2) : base(exception_0, bool_0, object_2)
		{
			this.object_0 = object_1;
		}
	}
}
