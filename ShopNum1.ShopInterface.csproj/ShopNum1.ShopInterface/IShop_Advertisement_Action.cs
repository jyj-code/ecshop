using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Advertisement_Action
	{
		string GetPath();
		void LoadXml();
		DataTable Search(string pagename, string fileName);
		DataTable SelectByID(string guid);
		int Add(Advertisement advertisement);
		int Update(Advertisement advertisement);
		int Delete(string guids);
		string GetNewDivID(string filename);
		DataTable ShowAD(string filename);
		DataTable ShowADByDivID(string divID);
	}
}
