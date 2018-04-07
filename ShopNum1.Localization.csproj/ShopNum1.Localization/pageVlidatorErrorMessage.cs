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
	internal class pageVlidatorErrorMessage
	{
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(pageVlidatorErrorMessage.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ShopNum1.Localization.pageVlidatorErrorMessage", typeof(pageVlidatorErrorMessage).Assembly);
					pageVlidatorErrorMessage.resourceMan = resourceManager;
				}
				return pageVlidatorErrorMessage.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return pageVlidatorErrorMessage.resourceCulture;
			}
			set
			{
				pageVlidatorErrorMessage.resourceCulture = value;
			}
		}
		internal static string User_List_CompareValidatorDept
		{
			get
			{
				return pageVlidatorErrorMessage.ResourceManager.GetString("User_List_CompareValidatorDept", pageVlidatorErrorMessage.resourceCulture);
			}
		}
		internal static string User_List_RequiredFieldValidatorEmail
		{
			get
			{
				return pageVlidatorErrorMessage.ResourceManager.GetString("User_List_RequiredFieldValidatorEmail", pageVlidatorErrorMessage.resourceCulture);
			}
		}
		internal static string User_List_RequiredFieldValidatorLoginID
		{
			get
			{
				return pageVlidatorErrorMessage.ResourceManager.GetString("User_List_RequiredFieldValidatorLoginID", pageVlidatorErrorMessage.resourceCulture);
			}
		}
		internal static string User_List_RequiredFieldValidatorRealName
		{
			get
			{
				return pageVlidatorErrorMessage.ResourceManager.GetString("User_List_RequiredFieldValidatorRealName", pageVlidatorErrorMessage.resourceCulture);
			}
		}
		internal pageVlidatorErrorMessage()
		{
		}
	}
}
