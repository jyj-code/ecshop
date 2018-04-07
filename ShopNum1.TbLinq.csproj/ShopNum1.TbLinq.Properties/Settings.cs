using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace ShopNum1.TbLinq.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("Data Source=FC;Initial Catalog=ShopNum1_MultiV7.2;User ID=sa"), SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode]
		public string ShopNum1_MultiV7_2ConnectionString
		{
			get
			{
				return (string)this["ShopNum1_MultiV7_2ConnectionString"];
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("Data Source=FC;Initial Catalog=ShopNum1_MultiV7.2;User ID=sa;Password=sa"), SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode]
		public string ShopNum1_MultiV7_2ConnectionString1
		{
			get
			{
				return (string)this["ShopNum1_MultiV7_2ConnectionString1"];
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("Data Source=.;Initial Catalog=ShopNum1_MultiV7.2;Persist Security Info=True;User ID=sa;Password=123456"), SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode]
		public string ShopNum1_MultiV7_2ConnectionString2
		{
			get
			{
				return (string)this["ShopNum1_MultiV7_2ConnectionString2"];
			}
		}
	}
}
