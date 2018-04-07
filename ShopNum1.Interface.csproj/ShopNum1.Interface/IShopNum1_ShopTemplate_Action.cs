using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopTemplate_Action
	{
		int Add(ShopNum1_Shop_Template shopNum1_Shop_Template);
		int Updata(ShopNum1_Shop_Template shopNum1_Shop_Template);
		DataTable Edit(string guid);
		int Delete(string guid);
		DataTable Search();
		DataTable GetTemplateType();
		int CheckTemplateName(string name);
		DataTable GetTemplatePathAndImg(string guid);
		bool UpdateIsDefault();
		DataTable GetTemplateByID(string string_0);
	}
}
