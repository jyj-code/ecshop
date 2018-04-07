using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SpecificationProductImage_Action
	{
		bool SpecificationImageInsert(ShopNum1_SpecificationProductImage pImage);
		bool Update(ShopNum1_SpecificationProductImage pImage);
		DataTable GetProuctSImage(string productGuid, string specificationValue, string memloginid);
		bool AddSpecificationImages(List<ShopNum1_SpecificationProductImage> pImages);
		bool DelImgsBySpecificationValue(string specificationvalue, string memloginid);
	}
}
