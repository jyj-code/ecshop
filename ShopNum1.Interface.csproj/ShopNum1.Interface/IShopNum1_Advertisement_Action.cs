using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Advertisement_Action
	{
		string GetPath();
		void LoadXml();
		DataTable Search(string pagename, string fileName);
		DataTable Search(string pagename, string fileName, string adID);
		DataTable SelectByID(string guid);
		int Add(Advertisement advertisement);
		int Update(Advertisement advertisement);
		int Delete(string guids);
		string GetNewDivID(string filename);
		DataTable ShowAD(string filename);
		DataTable ShowADByDivID(string divID);
		DataTable ShowADByDivID(string divID, string type);
		DataTable Search1(string pagename, string fileName);
	}
}
