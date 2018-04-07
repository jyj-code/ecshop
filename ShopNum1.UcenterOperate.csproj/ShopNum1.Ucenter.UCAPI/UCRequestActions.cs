using System;
using System.Collections.Specialized;
namespace ShopNum1.Ucenter.UCAPI
{
	public static class UCRequestActions
	{
		public const string UC_ACTION_ADDFEED = "addfeed";
		public const string UC_ACTION_DELETEUSER = "deleteuser";
		public const string UC_ACTION_GETCREDITSETTINGS = "getcreditsettings";
		public const string UC_ACTION_GETTAG = "gettag";
		public const string UC_ACTION_RENAMEUSER = "renameuser";
		public const string UC_ACTION_SYNLOGIN = "synlogin";
		public const string UC_ACTION_SYNLOGOUT = "synlogout";
		public const string UC_ACTION_TEST = "test";
		public const string UC_ACTION_UPDATEAPPS = "updateapps";
		public const string UC_ACTION_UPDATEBADWORDS = "updatebadwords";
		public const string UC_ACTION_UPDATECLIENT = "updateclient";
		public const string UC_ACTION_UPDATECREDIT = "updatecredit";
		public const string UC_ACTION_UPDATECREDITSETTINGS = "updatecreditsettings";
		public const string UC_ACTION_UPDATEHOSTS = "updatehosts";
		public const string UC_ACTION_UPDATEPW = "updatepw";
		private static StringCollection stringCollection_0;
		static UCRequestActions()
		{
			if (UCRequestActions.stringCollection_0 == null)
			{
				UCRequestActions.stringCollection_0 = new StringCollection();
				UCRequestActions.stringCollection_0.Add("test");
				UCRequestActions.stringCollection_0.Add("deleteuser");
				UCRequestActions.stringCollection_0.Add("renameuser");
				UCRequestActions.stringCollection_0.Add("gettag");
				UCRequestActions.stringCollection_0.Add("synlogin");
				UCRequestActions.stringCollection_0.Add("synlogout");
				UCRequestActions.stringCollection_0.Add("updatepw");
				UCRequestActions.stringCollection_0.Add("updatebadwords");
				UCRequestActions.stringCollection_0.Add("updatehosts");
				UCRequestActions.stringCollection_0.Add("updateapps");
				UCRequestActions.stringCollection_0.Add("updateclient");
				UCRequestActions.stringCollection_0.Add("updatecredit");
				UCRequestActions.stringCollection_0.Add("getcreditsettings");
				UCRequestActions.stringCollection_0.Add("updatecreditsettings");
				UCRequestActions.stringCollection_0.Add("addfeed");
			}
		}
		public static bool IsValidAction(string action)
		{
			return UCRequestActions.stringCollection_0.Contains(action.ToLower());
		}
	}
}
