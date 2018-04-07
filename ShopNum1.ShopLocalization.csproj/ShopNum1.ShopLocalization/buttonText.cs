using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace ShopNum1.ShopLocalization
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class buttonText
	{
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(buttonText.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ShopNum1.ShopLocalization.buttonText", typeof(buttonText).Assembly);
					buttonText.resourceMan = resourceManager;
				}
				return buttonText.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return buttonText.resourceCulture;
			}
			set
			{
				buttonText.resourceCulture = value;
			}
		}
		internal static string ButtonAdd
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonAdd", buttonText.resourceCulture);
			}
		}
		internal static string ButtonAddPage
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonAddPage", buttonText.resourceCulture);
			}
		}
		internal static string ButtonAddUser
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonAddUser", buttonText.resourceCulture);
			}
		}
		internal static string ButtonConfirm
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonConfirm", buttonText.resourceCulture);
			}
		}
		internal static string ButtonDelete
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonDelete", buttonText.resourceCulture);
			}
		}
		internal static string ButtonDeletePage
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonDeletePage", buttonText.resourceCulture);
			}
		}
		internal static string ButtonDeleteUser
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonDeleteUser", buttonText.resourceCulture);
			}
		}
		internal static string ButtonEdit
		{
			get
			{
				return buttonText.ResourceManager.GetString("ButtonEdit", buttonText.resourceCulture);
			}
		}
		internal buttonText()
		{
		}
	}
}
