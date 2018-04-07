using ShopNum1.Control;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
internal class Form0 : WindowsFormsComponentEditor
{
	public override bool EditComponent(ITypeDescriptorContext context, object component, IWin32Window owner)
	{
		ShopNum1.Control.TabControl tabControl = (ShopNum1.Control.TabControl)component;
		IServiceProvider site = tabControl.Site;
		IComponentChangeService componentChangeService = null;
		DesignerTransaction designerTransaction = null;
		bool flag = false;
		bool result;
		try
		{
			if (site != null)
			{
				IDesignerHost designerHost = (IDesignerHost)site.GetService(typeof(IDesignerHost));
				designerTransaction = designerHost.CreateTransaction("BuildTabStrip");
				componentChangeService = (IComponentChangeService)site.GetService(typeof(IComponentChangeService));
				if (componentChangeService != null)
				{
					try
					{
						componentChangeService.OnComponentChanging(component, null);
					}
					catch (CheckoutException ex)
					{
						if (ex != CheckoutException.Canceled)
						{
							throw ex;
						}
						result = false;
						return result;
					}
				}
			}
			try
			{
				TabEditorForm tabEditorForm = new TabEditorForm(tabControl);
				if (tabEditorForm.ShowDialog(owner) == DialogResult.OK)
				{
					flag = true;
				}
			}
			finally
			{
				if (flag && componentChangeService != null)
				{
					componentChangeService.OnComponentChanged(tabControl, null, null, null);
				}
			}
		}
		finally
		{
			if (designerTransaction != null)
			{
				if (flag)
				{
					designerTransaction.Commit();
				}
				else
				{
					designerTransaction.Cancel();
				}
			}
		}
		result = flag;
		return result;
	}
}
