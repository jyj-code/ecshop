using System;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopLocalization
{
	public class LocalizationUtil
	{
		public static void AddButtonText(Button button)
		{
			button.Text = buttonText.ResourceManager.GetString(button.ID);
		}
		public static void AddButtonText(string pageName, Button button)
		{
			button.Text = pageButtonText.ResourceManager.GetString(pageName + "_" + button.ID);
		}
		public static void AddLabelText(Label label)
		{
			label.Text = labelText.ResourceManager.GetString(label.ID);
		}
		public static void AddLabelText(string pageName, Label label)
		{
			label.Text = pageLabelText.ResourceManager.GetString(pageName + "_" + label.ID);
		}
		public static string AddGridViewText(string pageName, string columnName)
		{
			return pageGridView.ResourceManager.GetString(pageName + "_" + columnName);
		}
		public static void AddCheckboxText(CheckBox checkBox)
		{
			checkBox.Text = pageLabelText.ResourceManager.GetString(checkBox.ID);
		}
		public static void AddCheckboxText(string pageName, CheckBox checkBox)
		{
			checkBox.Text = pageLabelText.ResourceManager.GetString(pageName + "_" + checkBox.ID);
		}
		public static void AddHyperLinkText(HyperLink hyperLink)
		{
			hyperLink.Text = pageLabelText.ResourceManager.GetString(hyperLink.ID);
		}
		public static void AddHyperLinkText(string pageName, HyperLink hyperLink)
		{
			hyperLink.Text = pageLabelText.ResourceManager.GetString(pageName + "_" + hyperLink.ID);
		}
		public static void AddLinkButtonText(LinkButton linkButton)
		{
			linkButton.Text = pageLabelText.ResourceManager.GetString(linkButton.ID);
		}
		public static void AddLinkButtonText(string pageName, LinkButton linkButton)
		{
			linkButton.Text = pageLabelText.ResourceManager.GetString(pageName + "_" + linkButton.ID);
		}
		public static void AddPanelText(Panel panel)
		{
			panel.GroupingText = pageLabelText.ResourceManager.GetString(panel.ID);
		}
		public static void AddPanelText(string pageName, Panel panel)
		{
			panel.GroupingText = pageLabelText.ResourceManager.GetString(pageName + "_" + panel.ID);
		}
		public static void AddRequiredFieldValidatorErrorMessageText(string pageName, RequiredFieldValidator requiredFieldValidator)
		{
			if (pageName != string.Empty)
			{
				requiredFieldValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(pageName + "_" + requiredFieldValidator.ID);
			}
			else
			{
				requiredFieldValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(requiredFieldValidator.ID);
			}
		}
		public static void AddCompareValidatorErrorMessageText(string pageName, CompareValidator compareValidator)
		{
			if (pageName != string.Empty)
			{
				compareValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(pageName + "_" + compareValidator.ID);
			}
			else
			{
				compareValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(compareValidator.ID);
			}
		}
		public static void AddRegularExpressionValidatorErrorMessageText(string pageName, RegularExpressionValidator regularExpressionValidator)
		{
			if (pageName != string.Empty)
			{
				regularExpressionValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(pageName + "_" + regularExpressionValidator.ID);
			}
			else
			{
				regularExpressionValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(regularExpressionValidator.ID);
			}
		}
		public static void AddRangeValidatorErrorMessageText(string pageName, RangeValidator rangeValidator)
		{
			if (pageName != string.Empty)
			{
				rangeValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(pageName + "_" + rangeValidator.ID);
			}
			else
			{
				rangeValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(rangeValidator.ID);
			}
		}
		public static void AddCustomValidatorErrorMessageText(string pageName, CustomValidator customValidator)
		{
			if (pageName != string.Empty)
			{
				customValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(pageName + "_" + customValidator.ID);
			}
			else
			{
				customValidator.ErrorMessage = pageVlidatorErrorMessage.ResourceManager.GetString(customValidator.ID);
			}
		}
		public static string AddInputValue(string inputID)
		{
			return inputValue.ResourceManager.GetString(inputID);
		}
		public static string GetChangeMessage(string pageName, string filed, string filedValue)
		{
			string @string;
			if (pageName != string.Empty)
			{
				@string = changeFiled.ResourceManager.GetString(string.Concat(new string[]
				{
					pageName,
					"_",
					filed,
					"_",
					filedValue
				}));
			}
			else
			{
				@string = changeFiled.ResourceManager.GetString(filed);
			}
			return @string;
		}
		public static string GetCommonMessage(string key)
		{
			return common.ResourceManager.GetString(key);
		}
		public static string GegMessageShow(string operateType)
		{
			return messageShow.ResourceManager.GetString(operateType);
		}
	}
}
