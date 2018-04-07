using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace ShopNum1.Localization
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class inputValue
	{
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(inputValue.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ShopNum1.Localization.inputValue", typeof(inputValue).Assembly);
					inputValue.resourceMan = resourceManager;
				}
				return inputValue.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return inputValue.resourceCulture;
			}
			set
			{
				inputValue.resourceCulture = value;
			}
		}
		internal static string inputReset
		{
			get
			{
				return inputValue.ResourceManager.GetString("inputReset", inputValue.resourceCulture);
			}
		}
		internal inputValue()
		{
		}
	}
}
