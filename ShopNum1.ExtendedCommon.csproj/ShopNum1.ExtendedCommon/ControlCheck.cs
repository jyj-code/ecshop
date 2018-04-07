using System;
using System.IO;
using System.Text;
using System.Web;
namespace ShopNum1.ExtendedCommon
{
	public class ControlCheck
	{
		public string EncodeDomainSecond(string strDomain)
		{
			return ControlE.GetSHA1SecondHash("6a7d031e03726081beb08f826c11d4ff" + strDomain + "e9ed51*(&(*(*%$#$_>KJHNGB?<<MMNBBBV_)DD") + "4D822420F5C3994323F3E858618ADB419A22185E";
		}
		public int CheckCertificationModificate(string domain)
		{
			string path = HttpContext.Current.Server.MapPath("~/CertificationB.cer");
			if (!File.Exists(path))
			{
				return 0;
			}
			string[] array = File.ReadAllLines(path);
			if (array.Length != 1001)
			{
				return 1;
			}
			string a = this.EncodeDomainSecond(domain);
			if (a == array[26])
			{
				return 2;
			}
			return 3;
		}
		public int CheckCopyright(string domain)
		{
			string path = HttpContext.Current.Server.MapPath("~/ShopNum1Copyright.cer");
			if (!File.Exists(path))
			{
				return 0;
			}
			string b = File.ReadAllText(path);
			string a = this.method_3(domain);
			if (a == b)
			{
				return 2;
			}
			return 3;
		}
		public int CheckCetificationA(out string contMd5, out string contDes)
		{
			string path = HttpContext.Current.Server.MapPath("~/CertificationA.cer");
			if (!File.Exists(path))
			{
				contMd5 = string.Empty;
				contDes = string.Empty;
				return 0;
			}
			string text = File.ReadAllText(path, Encoding.Default);
			if (text.Length != 132)
			{
				contMd5 = string.Empty;
				contDes = string.Empty;
				return 1;
			}
			contMd5 = text.Substring(0, 64) + text.Substring(100, 32);
			contDes = text.Substring(64, 36).ToLower();
			return 2;
		}
		public bool CheckFirstMd5(string content, string domain, string string_0)
		{
			string a = this.method_0(domain) + this.method_1("2099/12/30") + this.method_2(string_0);
			return a == content;
		}
		public bool CheckSecondDes(string content)
		{
			string a = ControlD.Encrypt(content);
			string path = HttpContext.Current.Server.MapPath("~/CertificationB.cer");
			if (File.Exists(path))
			{
				string[] array = File.ReadAllLines(path);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string b = array2[i];
					if (a == b)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		private string method_0(string string_0)
		{
			return ControlE.GetMd5SecondHash(string_0 + "23432414321412rqwerewa6bcfb260fb");
		}
		private string method_1(string string_0)
		{
			return ControlE.GetMd5SecondHash("642378324ioewrkkwlfdsakfdsalfk33" + string_0);
		}
		private string method_2(string string_0)
		{
			return ControlE.GetMd5SecondHash(string_0 + "bbcae16367f5263761b3aeb0964ed83bfenxiao");
		}
		private string method_3(string string_0)
		{
			string empty = string.Empty;
			string str = string.Empty;
			str = this.method_0(string_0);
			string str2 = string.Empty;
			str2 = this.method_1("2099/12/30");
			string text = string.Empty;
			text = "*(UDSF#@$%#))_$##CX<>XCGRJTUHRVXC AAA@!@!@**____";
			string str3 = string.Empty;
			str3 = this.method_2(text);
			return str + str2 + text.ToUpper() + str3;
		}
	}
}
