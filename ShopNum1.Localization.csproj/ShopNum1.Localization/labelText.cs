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
	internal class labelText
	{
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(labelText.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ShopNum1.Localization.labelText", typeof(labelText).Assembly);
					labelText.resourceMan = resourceManager;
				}
				return labelText.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return labelText.resourceCulture;
			}
			set
			{
				labelText.resourceCulture = value;
			}
		}
		internal labelText()
		{
		}
	}
}
