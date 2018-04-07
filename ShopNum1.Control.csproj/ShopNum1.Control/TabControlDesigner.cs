using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
namespace ShopNum1.Control
{
	public class TabControlDesigner : ControlDesigner
	{
		private DesignerVerbCollection designerVerbCollection_0;
		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (this.designerVerbCollection_0 == null)
				{
					this.designerVerbCollection_0 = new DesignerVerbCollection(new DesignerVerb[]
					{
						new DesignerVerb("创建新的属性页...", new EventHandler(this.method_0))
					});
				}
				return this.designerVerbCollection_0;
			}
		}
		protected override string GetEmptyDesignTimeHtml()
		{
			return base.CreatePlaceHolderDesignTimeHtml("右击选择创建新的属性页");
		}
		private void method_0(object sender, EventArgs e)
		{
			Form0 form = new Form0();
			form.EditComponent(base.Component);
		}
		public override string GetDesignTimeHtml()
		{
			string result;
			try
			{
				TabControl tabControl = (TabControl)base.Component;
				if (tabControl.Items == null || tabControl.Items.Count == 0)
				{
					result = this.GetEmptyDesignTimeHtml();
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					StringWriter stringWriter = new StringWriter(stringBuilder);
					HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
					tabControl.method_0(htmlTextWriter);
					htmlTextWriter.Flush();
					stringWriter.Flush();
					result = stringBuilder.ToString();
				}
			}
			catch (Exception ex)
			{
				result = base.CreatePlaceHolderDesignTimeHtml("生成设计时代码错误:\n\n" + ex.ToString());
			}
			return result;
		}
	}
}
