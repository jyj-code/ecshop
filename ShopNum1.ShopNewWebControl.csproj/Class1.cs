using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
internal class Class1
{
	private static ResourceManager resourceManager_0;
	private static CultureInfo cultureInfo_0;
	internal Class1()
	{
	}
	internal static ResourceManager smethod_0()
	{
		if (object.ReferenceEquals(Class1.resourceManager_0, null))
		{
			ResourceManager resourceManager = new ResourceManager("ShopNum1.ShopNewWebControl.Properties.Resources", typeof(Class1).Assembly);
			Class1.resourceManager_0 = resourceManager;
		}
		return Class1.resourceManager_0;
	}
	internal static CultureInfo smethod_1()
	{
		return Class1.cultureInfo_0;
	}
	internal static void smethod_2(CultureInfo cultureInfo_1)
	{
		Class1.cultureInfo_0 = cultureInfo_1;
	}
}
