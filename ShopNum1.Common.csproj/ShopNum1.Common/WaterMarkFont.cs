using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
namespace ShopNum1.Common
{
	public static class WaterMarkFont
	{
		public static ArrayList Font()
		{
			ArrayList arrayList = new ArrayList();
			InstalledFontCollection installedFontCollection = new InstalledFontCollection();
			FontFamily[] families = installedFontCollection.Families;
			for (int i = 0; i < families.Length; i++)
			{
				FontFamily fontFamily = families[i];
				arrayList.Add(fontFamily.Name);
			}
			return arrayList;
		}
	}
}
