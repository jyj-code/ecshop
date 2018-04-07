using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
internal sealed class Class0 : ApplicationSettingsBase
{
	private static Class0 class0_0 = (Class0)SettingsBase.Synchronized(new Class0());
	public static Class0 smethod_0()
	{
		return Class0.class0_0;
	}
	public string method_0()
	{
		return (string)this["SendSMS_WebReference_ISmsService"];
	}
	public string method_1()
	{
		return (string)this["ShopNum1_Standard_VjWebservice_SDKService"];
	}
}
