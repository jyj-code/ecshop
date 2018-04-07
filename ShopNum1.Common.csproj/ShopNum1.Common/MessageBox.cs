using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.UI;
namespace ShopNum1.Common
{
	public static class MessageBox
	{
		private static Hashtable hashtable_0 = new Hashtable();
		public static void Show(string sMessage)
		{
			if (!MessageBox.hashtable_0.Contains(HttpContext.Current.Handler))
			{
				Page page = HttpContext.Current.Handler as Page;
				if (page != null)
				{
					Queue queue = new Queue();
					queue.Enqueue(sMessage);
					MessageBox.hashtable_0.Add(HttpContext.Current.Handler, queue);
					page.Unload += new EventHandler(MessageBox.smethod_0);
				}
			}
			else
			{
				Queue queue2 = (Queue)MessageBox.hashtable_0[HttpContext.Current.Handler];
				queue2.Enqueue(sMessage);
			}
		}
		private static void smethod_0(object sender, EventArgs e)
		{
			Queue queue = (Queue)MessageBox.hashtable_0[HttpContext.Current.Handler];
			if (queue != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int count = queue.Count;
				stringBuilder.Append("<script language='javascript'>");
				while (count-- > 0)
				{
					string text = (string)queue.Dequeue();
					text = text.Replace("\n", "\\n");
					text = text.Replace("\"", "'");
					stringBuilder.Append("alert( \"" + text + "\" );");
				}
				stringBuilder.Append("</script>");
				MessageBox.hashtable_0.Remove(HttpContext.Current.Handler);
				HttpContext.Current.Response.Write(stringBuilder.ToString());
			}
		}
	}
}
