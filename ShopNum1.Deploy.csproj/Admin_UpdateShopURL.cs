using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_UpdateShopURL : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	private string string_12 = string.Empty;
	protected Label LabelPageTitle;
	protected TextBox TextBoxShopURL;
	protected Literal LiteralURL;
	protected Label Label3;
	protected Label Labelerr;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Button ButtonUpdata;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldShopURL;
	protected HtmlForm form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			string str = string.Empty;
			try
			{
				str = Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND   Guid='" + base.Request.QueryString["guid"].ToString().Replace("'", "") + "'   ");
			}
			catch (Exception)
			{
			}
			this.LiteralURL.Text = "." + str + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			this.CheckGuid.Value = ((base.Request.QueryString["guid"] == null) ? "-1" : base.Request.QueryString["guid"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.CheckGuid.Value);
			if (allShopInfoByGuid != null && allShopInfoByGuid.Rows.Count > 0)
			{
				this.HiddenFieldShopURL.Value = (this.TextBoxShopURL.Text = allShopInfoByGuid.Rows[0]["ShopUrl"].ToString());
			}
		}
		this.string_5 = ((base.Request.QueryString["type"] == null) ? "-1" : base.Request.QueryString["type"].ToString());
	}
	private void method_5()
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid("'" + this.CheckGuid.Value.Replace("'", "") + "'");
		if (allShopInfoByGuid.Rows.Count > 0)
		{
			Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
			Cache cache = HttpRuntime.Cache;
			foreach (DataRow dataRow in allShopInfoByGuid.Rows)
			{
				if (cache["shopnum1_shopinfoIdCache"] != null)
				{
					string key = dataRow["ShopID"].ToString();
					dictionary = (cache["shopnum1_shopinfoIdCache"] as Dictionary<string, DataTable>);
					dictionary.Remove(key);
					DataTable dataTable = allShopInfoByGuid.Clone();
					DataRow dataRow2 = dataTable.NewRow();
					dataRow2["ShopID"] = dataRow["ShopID"];
					dataRow2["ShopUrl"] = dataRow["ShopUrl"];
					dataRow2["OpenTime"] = dataRow["OpenTime"];
					dataRow2["IsExpires"] = dataRow["IsExpires"];
					dataRow2["IsClose"] = dataRow["IsClose"];
					dataTable.Rows.Add(dataRow2);
					dictionary.Add(key, dataTable);
					cache.Add("shopnum1_shopinfoIdCache", dictionary, null, DateTime.Now.AddHours(12.0), TimeSpan.Zero, CacheItemPriority.High, null);
				}
				if (cache["GetDefaultShopMessgae"] != null)
				{
					string key = dataRow["ShopUrl"].ToString();
					dictionary = (cache["GetDefaultShopMessgae"] as Dictionary<string, DataTable>);
					dictionary.Remove(key);
					DataTable dataTable = allShopInfoByGuid.Clone();
					DataRow dataRow2 = dataTable.NewRow();
					dataRow2["ShopID"] = dataRow["ShopID"];
					dataRow2["ShopUrl"] = dataRow["ShopUrl"];
					dataRow2["OpenTime"] = dataRow["OpenTime"];
					dataRow2["IsExpires"] = dataRow["IsExpires"];
					dataRow2["IsClose"] = dataRow["IsClose"];
					dataTable.Rows.Add(dataRow2);
					dictionary.Add(key, dataTable);
					cache.Add("GetDefaultShopMessgae", dictionary, null, DateTime.Now.AddHours(12.0), TimeSpan.Zero, CacheItemPriority.High, null);
				}
				if (cache["GetShopInfoMessgae"] != null)
				{
					string key = dataRow["MemLoginID"].ToString();
					dictionary = (cache["GetShopInfoMessgae"] as Dictionary<string, DataTable>);
					dictionary.Remove(key);
					DataTable dataTable = allShopInfoByGuid.Clone();
					DataRow dataRow2 = dataTable.NewRow();
					dataRow2["ShopID"] = dataRow["ShopID"];
					dataRow2["ShopUrl"] = dataRow["ShopUrl"];
					dataRow2["OpenTime"] = dataRow["OpenTime"];
					dataRow2["ShopName"] = dataRow["ShopName"];
					dataRow2["MemLoginID"] = dataRow["MemLoginID"];
					dataTable.Rows.Add(dataRow2);
					dictionary.Add(key, dataTable);
					cache.Add("GetShopInfoMessgae", dictionary, null, DateTime.Now.AddHours(12.0), TimeSpan.Zero, CacheItemPriority.High, null);
				}
			}
		}
	}
	protected void ButtonUpdata_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (this.string_5 == "List")
		{
			if (!this.method_7())
			{
				MessageBox.Show("店铺URL已经存在！");
				this.TextBoxShopURL.Focus();
			}
			else if (shopNum1_ShopInfoList_Action.UpdataShopURLByGuid(this.CheckGuid.Value.Replace("'", ""), this.TextBoxShopURL.Text.Trim()) > 0)
			{
				this.method_5();
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "修改店铺URL成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "UpdateShopURL.aspx",
					Date = DateTime.Now
				});
				base.Response.Redirect("ShopInfoList_Manage.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("Audit2No");
				this.MessageShow.Visible = true;
			}
		}
		else if (this.string_5 == "Audit" || this.string_5 == "openshop")
		{
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsAudit", "1") > 0 && shopNum1_ShopInfoList_Action.UpdateMemberType(this.CheckGuid.Value, 2) > 0 && shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsExpires", "0") > 0 && shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsClose", "0") > 0)
			{
				try
				{
					shopNum1_ShopInfoList_Action.UpdateDate(this.CheckGuid.Value, DateTime.Now.ToString());
					shopNum1_ShopInfoList_Action.UpdataShopURLByGuid(this.CheckGuid.Value.Replace("'", ""), this.TextBoxShopURL.Text.Trim());
					DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.CheckGuid.Value);
					string text = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
					string s = allShopInfoByGuid.Rows[0]["ShopID"].ToString();
					string string_ = allShopInfoByGuid.Rows[0]["TemplateType"].ToString();
					shopNum1_ShopInfoList_Action.InsertShopNav(text);
					this.method_6(text, int.Parse(s), string_);
					if (this.string_5 == "Audit")
					{
						if (ShopSettings.GetValue("AuditOpenShopIsEmail") == "1")
						{
							this.IsEmail();
						}
						if (ShopSettings.GetValue("AuditOpenShopIsMMS") == "1")
						{
							this.IsMMS();
						}
						this.method_5();
						base.Response.Redirect("ShopInfoList_Audit.aspx");
					}
					else if (this.string_5 == "openshop")
					{
						base.Response.Redirect("Member_List.aspx");
					}
					goto IL_347;
				}
				catch (Exception ex)
				{
					base.Response.Write(ex.Message);
					goto IL_347;
				}
			}
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
			IL_347:
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员审核店铺通过",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "UpdateShopURL.aspx",
				Date = DateTime.Now
			});
		}
	}
	protected void GetEmailSetting()
	{
		ShopSettings shopSettings = new ShopSettings();
		this.string_6 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailServer"));
		this.string_7 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
		this.string_9 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ServerPort"));
		this.string_8 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailAccount"));
		this.string_10 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailPassword"));
		this.string_11 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "RestoreEmail"));
		this.string_12 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailCode"));
	}
	protected ShopNum1_EmailGroupSend Add(string memLoginID, string strTitle, string email, int state, string scont)
	{
		return new ShopNum1_EmailGroupSend
		{
			Guid = Guid.NewGuid(),
			EmailTitle = strTitle,
			CreateTime = DateTime.Now,
			EmailGuid = new Guid("60c1bef2-33e4-4510-944c-afca43d09f0c"),
			SendObjectEmail = scont,
			SendObject = memLoginID + "-" + email,
			State = state
		};
	}
	protected void IsMMS()
	{
		try
		{
			string value = ShopSettings.GetValue("Name");
			string mMsTitle = string.Empty;
			string text = string.Empty;
			string mobile = string.Empty;
			string text2 = "60c1bef2-33e4-4510-944c-afca43d09f0c";
			string text3 = string.Empty;
			IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
			DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text2 + "'", 0);
			Guid.NewGuid().ToString();
			if (editInfo.Rows.Count > 0)
			{
				text3 = editInfo.Rows[0]["Remark"].ToString();
				mMsTitle = editInfo.Rows[0]["Title"].ToString();
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberInfoByGuID = shopNum1_Member_Action.GetMemberInfoByGuID(this.CheckGuid.Value.Replace("'", ""));
			if (memberInfoByGuID.Rows.Count > 0)
			{
				text = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
				if (memberInfoByGuID.Rows[0]["Phone"].ToString() != "")
				{
					mobile = memberInfoByGuID.Rows[0]["Phone"].ToString();
				}
				else
				{
					mobile = memberInfoByGuID.Rows[0]["Tel"].ToString();
				}
			}
			text3 = text3.Replace("{$Name}", text);
			text3 = text3.Replace("{$ShopName}", value);
			text3 = text3.Replace("{$SysSendTime} ", DateTime.Now.ToString("yyyy-MM-dd"));
			SMS sMS = new SMS();
			string text4 = "";
			sMS.Send(mobile, text3, out text4);
			if (text4.IndexOf("发送成功") != -1)
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(text, mobile, mMsTitle, 2, text2, text3);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
			else
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(text, mobile, mMsTitle, 0, text2, text3);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
		}
		catch (Exception)
		{
		}
	}
	protected void IsEmail()
	{
		try
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberInfoByGuID = shopNum1_Member_Action.GetMemberInfoByGuID(this.CheckGuid.Value.Replace("'", ""));
			if (!(memberInfoByGuID.Rows[0]["Email"].ToString() == ""))
			{
				string value = ShopSettings.GetValue("Name");
				OpenShop openShop = new OpenShop();
				this.GetEmailSetting();
				NetMail netMail = new NetMail();
				netMail.RecipientEmail = memberInfoByGuID.Rows[0]["Email"].ToString();
				openShop.Name = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
				openShop.ShopID = ShopSettings.GetValue("PersonShopUrl") + memberInfoByGuID.Rows[0]["ShopID"].ToString();
				openShop.ShopStatus = "审核通过";
				openShop.SysSendTime = DateTime.Now.ToString();
				openShop.ShopName = value;
				string text = string.Empty;
				string text2 = string.Empty;
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'60c1bef2-33e4-4510-944c-afca43d09f0c'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					text2 = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", memberInfoByGuID.Rows[0]["MemLoginID"].ToString());
				text = text.Replace("{$ShopName}", openShop.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				netMail.Subject = text2;
				netMail.Body = openShop.ChangeOpenShop(this.Page.Server.HtmlDecode(text));
				if (!netMail.Send())
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), text2, memberInfoByGuID.Rows[0]["Email"].ToString(), 0, netMail.Body);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
				}
				else
				{
					ShopNum1_EmailGroupSend emailGroupSend = this.Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), text2, memberInfoByGuID.Rows[0]["Email"].ToString(), 2, netMail.Body);
					shopNum1_Email_Action.AddEmailGroupSend(emailGroupSend);
				}
			}
		}
		catch (Exception)
		{
		}
	}
	protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid, string emailBody)
	{
		return new ShopNum1_MMSGroupSend
		{
			Guid = Guid.NewGuid(),
			MMSTitle = MMsTitle,
			CreateTime = DateTime.Now,
			MMSGuid = new Guid(mmsGuid),
			SendObjectMMS = emailBody,
			SendObject = memLoginID + "-" + mobile,
			State = state
		};
	}
	private void method_6(string string_13, int int_0, string string_14)
	{
		string path = "~/Template/Shop/" + string_14;
		if (!File.Exists(this.Page.Server.MapPath("~/Template/Shop/" + string_14)))
		{
			path = "~/Template/Shop/Skin_Default.zipzz";
		}
		string text = "";
		text = "~/ImgUpload/";
		string text2 = "~/Shop/Shop/";
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		string openTime = shopNum1_ShopInfoList_Action.GetOpenTime(string_13);
		object obj = text2;
		text2 = string.Concat(new object[]
		{
			obj,
			Convert.ToDateTime(openTime).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			int_0,
			"/"
		});
		obj = text;
		text = string.Concat(new object[]
		{
			obj,
			Convert.ToDateTime(openTime).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			int_0,
			"/"
		});
		if (!Directory.Exists(this.Page.Server.MapPath(text2)))
		{
			try
			{
				Directory.CreateDirectory(this.Page.Server.MapPath(text2));
				string path2 = text2 + Path.GetFileName(this.Page.Server.MapPath(path));
				File.Copy(this.Page.Server.MapPath(path), this.Page.Server.MapPath(path2));
				ShopNum1UnZipClass.UnZip(this.Page.Server.MapPath(path2), this.Page.Server.MapPath(text2), null);
				File.Delete(this.Page.Server.MapPath(path2));
				goto IL_295;
			}
			catch
			{
				goto IL_295;
			}
		}
		try
		{
			if (!Directory.Exists(this.Page.Server.MapPath(path)))
			{
				string path2 = text2 + Path.GetFileName(this.Page.Server.MapPath(path));
				File.Copy(this.Page.Server.MapPath(path), this.Page.Server.MapPath(path2));
				ShopNum1UnZipClass.UnZip(this.Page.Server.MapPath(path2), this.Page.Server.MapPath(text2), null);
				File.Delete(this.Page.Server.MapPath(path2));
			}
		}
		catch
		{
		}
		IL_295:
		if (!Directory.Exists(this.Page.Server.MapPath(text)))
		{
			Directory.CreateDirectory(this.Page.Server.MapPath(text));
		}
	}
	protected void TextBoxShopURL_TextChanged(object sender, EventArgs e)
	{
		if (!this.method_7())
		{
			MessageBox.Show("店铺URL已经存在！");
			this.TextBoxShopURL.Focus();
		}
	}
	private bool method_7()
	{
		bool result;
		if (this.HiddenFieldShopURL.Value == this.TextBoxShopURL.Text.Trim())
		{
			result = false;
		}
		else
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable dataTable = shopNum1_ShopInfoList_Action.CheckShopURLIsRepeat(this.TextBoxShopURL.Text.Trim());
			result = (dataTable.Rows[0]["ShopUrl"].ToString() == "0");
		}
		return result;
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.string_5 == "Audit")
		{
			base.Response.Redirect("ShopInfoList_Audit.aspx");
		}
		else if (this.string_5 == "List")
		{
			base.Response.Redirect("ShopInfoList_Manage.aspx");
		}
		else if (this.string_5 == "openshop")
		{
			base.Response.Redirect("Member_List.aspx");
		}
	}
}
