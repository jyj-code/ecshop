using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using ShopNum1_Second;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SecondUserBind : BaseWebControl, ICallbackEventHandler
	{
		[CompilerGenerated]
		private sealed class Class1
		{
			public string string_0;
			public SecondUserBind secondUserBind_0;
			public bool method_0(string string_1)
			{
				if (this.string_0 == "BtnBind")
				{
					this.secondUserBind_0.method_2();
				}
				else if (this.string_0 == "BtnCreate")
				{
					this.secondUserBind_0.method_1();
				}
				return true;
			}
		}
		private string string_0 = "SecondUserBind.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private ShopNum1_SecondUserBussiness shopNum1_SecondUserBussiness_0 = new ShopNum1_SecondUserBussiness();
		private ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness_0 = new ShopNum1_SecondTypeBussiness();
		private string string_1;
		public SecondUserBind()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralUserName");
			this.literal_1 = (Literal)skin.FindControl("LiteralAccountType");
			this.literal_2 = (Literal)skin.FindControl("LiteralAccount");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("Divcontent1");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("Divcontent2");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButton1");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButton2");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			if (!this.Page.IsPostBack && this.Page.Request.QueryString["type"] != null)
			{
				string text = this.Page.Request.QueryString["type"];
				this.ViewState["type"] = text;
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "1"))
					{
						if (!(text2 == "2"))
						{
							if (!(text2 == "3"))
							{
								if (!(text2 == "4"))
								{
									if (text2 == "5")
									{
										this.literal_1.Text = "淘宝";
										this.literal_2.Text = "淘宝";
										string text3 = this.Page.Request.QueryString["user_id"];
										if (text3 != "")
										{
											this.ViewState["user_id"] = text3;
											string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(text3, "5");
											if (this.method_0(memLogid))
											{
												this.Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
												return;
											}
										}
									}
								}
								else
								{
									this.literal_1.Text = "淘宝支付宝";
									this.literal_2.Text = "支付宝";
									string text3 = this.Page.Request.QueryString["user_id"];
									if (text3 != "")
									{
										this.ViewState["user_id"] = text3;
										string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(text3, "4");
										if (this.method_0(memLogid))
										{
											this.Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
											return;
										}
									}
								}
							}
							else
							{
								this.literal_1.Text = "新浪微博";
								this.literal_2.Text = "新浪";
								string text3 = this.Page.Request.QueryString["uid"];
								string text4 = this.Page.Request.QueryString["access_token"];
								if (text3 != "")
								{
									this.literal_0.Text = "";
									this.ViewState["user"] = text3;
									string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(text3, "3");
									if (this.method_0(memLogid))
									{
										this.Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
										return;
									}
								}
							}
						}
						else
						{
							this.literal_1.Text = "百度账户";
							this.literal_2.Text = "百度";
							string text4 = this.Page.Request.QueryString["access_token"];
							ShopNum1_BaiduCommonClient shopNum1_BaiduCommonClient = new ShopNum1_BaiduCommonClient();
							ShopNum1_BaiduUserResponse baiduUser = shopNum1_BaiduCommonClient.GetBaiduUser(text4, "xml");
							string text3 = baiduUser.uid;
							if (text3 != "")
							{
								this.literal_0.Text = baiduUser.uname;
								this.ViewState["user"] = baiduUser;
								string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(baiduUser.uid, "2");
								if (this.method_0(memLogid))
								{
									this.Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
									return;
								}
							}
						}
					}
					else
					{
						this.literal_1.Text = "QQ账户";
						this.literal_2.Text = "QQ";
						string text4 = this.Page.Request.QueryString["access_token"];
						ShopNum1_QzoneCommonClient shopNum1_QzoneCommonClient = new ShopNum1_QzoneCommonClient();
						ShopNum1_QzoneCommonResponse shopNum1_QzoneCommonResponse = new ShopNum1_QzoneCommonResponse();
						shopNum1_QzoneCommonClient.access_token = text4;
						string qzoneOpenID = shopNum1_QzoneCommonClient.GetQzoneOpenID();
						if (qzoneOpenID != "")
						{
							shopNum1_QzoneCommonClient.openid = qzoneOpenID;
							shopNum1_QzoneCommonClient.access_token = text4;
							shopNum1_QzoneCommonClient.AppId = "100226141";
							DataTable model = this.shopNum1_SecondTypeBussiness_0.GetModel(1);
							if (model != null && model.Rows.Count > 0)
							{
								shopNum1_QzoneCommonClient.AppId = model.Rows[0]["AppID"].ToString();
							}
							string text5 = shopNum1_QzoneCommonClient.QzoneGet("user", "get_user_info", "xml");
							this.literal_0.Text = shopNum1_QzoneCommonResponse.GetQQUserName(text5, "xml");
							this.ViewState["openID"] = qzoneOpenID;
							this.ViewState["userName"] = this.literal_0.Text;
							string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(qzoneOpenID, "1");
							if (this.method_0(memLogid))
							{
								this.Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
								return;
							}
						}
					}
				}
			}
			if (this.Page.IsPostBack && this.Page.Request.Form["secondUserEVENTTARGET"] != null && this.Page.Request.Form["secondUserEVENTTARGET"].ToString() != "")
			{
				this.RaisePostBackEvent();
			}
			string text6 = "function CheckMemLogin() {\n";
			text6 += "var inputcontrol = document.getElementById(\"seconduserBind_userName\");\n";
			text6 += "var context = document.getElementById(\"spanContent\");\n";
			text6 += "var pwd = document.getElementById(\"seconduserBind_password\").value; \n";
			text6 += "var arg2 = \"CheckLogin|\" + inputcontrol.value+\"|\"+pwd;\n";
			text6 += "var reg = /^[\\u4e00-\\u9fa5\\da-zA-Z\\-\\_]{2,12}$/";
			text6 += "\n if(inputcontrol.value != \"\") {\n";
			text6 += "if(reg.test(inputcontrol.value)) {context.innerHTML = \"正在验证..\"; ";
			text6 = text6 + this.Page.ClientScript.GetCallbackEventReference(this, "arg2", "ReceiveServerData", "context") + "; }\n";
			text6 += "else { context.innerHTML = \"用户名格式不正确\";}\n}\n";
			text6 += "else { context.innerHTML = \"用户名不能为空\";}\n}\n";
			string text7 = "function existemail(inputcontrol) {\n";
			text7 += "var context = document.getElementById(\"spanErrEmail\");\n";
			text7 += "var arg = \"ExistEmail|\" + inputcontrol.value;\n";
			text7 += "if(inputcontrol.value != \"\") {\n";
			text7 += "var reg = new RegExp(\"\\\\w+([-+.']\\\\w+)*@\\\\w+([-.]\\\\w+)*\\\\.\\\\w+([-.]\\\\w+)*\");\n";
			text7 += "if(reg.test(inputcontrol.value)) {\n";
			text7 += "context.innerHTML = \"数据查询中..\"; ";
			text7 = text7 + this.Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerEmailData", "context") + "; }\n";
			text7 += "else { context.innerHTML = \"电子邮箱格式不正确\"; }\n}\n";
			text7 += "else { context.innerHTML = \"电子邮箱不能为空\"; }\n}\n";
			this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CheckMemLogin", text6, true);
			this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CheckEmail", text7, true);
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.htmlGenericControl_0.Visible = false;
			this.htmlGenericControl_1.Visible = true;
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.htmlGenericControl_0.Visible = true;
			this.htmlGenericControl_1.Visible = false;
		}
		public string ExistEmail(string email)
		{
			IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
			int num = shopNum1_Member_Action.CheckmemEmail(email);
			string result;
			if (num > 0)
			{
				result = "1";
			}
			else
			{
				result = "0";
			}
			return result;
		}
		public void RaisePostBackEvent()
		{
			SecondUserBind.Class1 @class = new SecondUserBind.Class1();
			@class.secondUserBind_0 = this;
			@class.string_0 = this.Page.Request.Form["secondUserEVENTTARGET"];
			Func<string, bool> func = new Func<string, bool>(@class.method_0);
			func(@class.string_0);
		}
		private bool method_0(string string_2)
		{
			bool result;
			if (string.IsNullOrEmpty(string_2))
			{
				result = false;
			}
			else
			{
				IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
				DataTable memInfoByMemberloginId = shopNum1_Member_Action.GetMemInfoByMemberloginId(string_2);
				if (memInfoByMemberloginId != null && memInfoByMemberloginId.Rows.Count > 0)
				{
					if (memInfoByMemberloginId.Rows[0]["IsForbid"].ToString() == "1")
					{
						MessageBox.Show("对不起，您的账户已被禁用！");
						result = false;
					}
					else
					{
						HttpCookie httpCookie = new HttpCookie("MemberLoginCookie");
						httpCookie.Values.Add("MemLoginID", string_2);
						httpCookie.Values.Add("Name", memInfoByMemberloginId.Rows[0]["Name"].ToString());
						httpCookie.Values.Add("MemberType", memInfoByMemberloginId.Rows[0]["MemberType"].ToString());
						if (memInfoByMemberloginId.Rows[0]["MemberType"].ToString() == "2")
						{
							ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
							DataTable shopRankByMemLoginID = shopNum1_ShopInfoList_Action.GetShopRankByMemLoginID(string_2);
							if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
							{
								httpCookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
							}
						}
						HttpCookie httpCookie2 = HttpSecureCookie.Encode(httpCookie);
						httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie2);
						result = true;
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}
		private void method_1()
		{
			ShopNum1_SecondUser shopNum1_SecondUser = new ShopNum1_SecondUser();
			string text = DateTime.Now.ToString("MMddmmss");
			lock (text)
			{
				Thread.Sleep(20);
			}
			string memlogID = this.Page.Request.Form["seconduserBind_userName_c"].ToString();
			string text2 = this.ViewState["type"].ToString();
			string text3 = text2;
			if (text3 != null)
			{
				if (!(text3 == "1"))
				{
					if (!(text3 == "2"))
					{
						if (!(text3 == "3"))
						{
							if (!(text3 == "4"))
							{
								if (text3 == "5")
								{
									shopNum1_SecondUser.MemlogID = memlogID;
									shopNum1_SecondUser.SecondID = this.ViewState["user_id"].ToString();
								}
							}
							else
							{
								shopNum1_SecondUser.MemlogID = memlogID;
								shopNum1_SecondUser.SecondID = this.ViewState["user_id"].ToString();
							}
						}
						else
						{
							shopNum1_SecondUser.MemlogID = memlogID;
							shopNum1_SecondUser.SecondID = this.ViewState["user"].ToString();
						}
					}
					else
					{
						ShopNum1_BaiduUserResponse shopNum1_BaiduUserResponse = (ShopNum1_BaiduUserResponse)this.ViewState["user"];
						shopNum1_SecondUser.MemlogID = memlogID;
						shopNum1_SecondUser.SecondID = shopNum1_BaiduUserResponse.uid;
					}
				}
				else
				{
					shopNum1_SecondUser.MemlogID = memlogID;
					shopNum1_SecondUser.SecondID = this.ViewState["openID"].ToString();
				}
			}
			shopNum1_SecondUser.Secondtype = text2;
			shopNum1_SecondUser.isAvailable = 1;
			if (this.shopNum1_SecondUserBussiness_0.Add(shopNum1_SecondUser))
			{
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
				shopNum1_Member.MemLoginID = shopNum1_SecondUser.MemlogID;
				shopNum1_Member.MemberType = new int?(1);
				text3 = text2;
				if (text3 != null)
				{
					if (!(text3 == "1"))
					{
						if (!(text3 == "2"))
						{
							if (!(text3 == "3"))
							{
								if (!(text3 == "4"))
								{
									if (text3 == "5")
									{
										shopNum1_Member.Name = "";
										shopNum1_Member.Photo = "";
									}
								}
								else
								{
									shopNum1_Member.Name = "";
									shopNum1_Member.Photo = "";
								}
							}
							else
							{
								shopNum1_Member.Name = "";
								shopNum1_Member.Photo = "";
							}
						}
						else
						{
							ShopNum1_BaiduUserResponse shopNum1_BaiduUserResponse = (ShopNum1_BaiduUserResponse)this.ViewState["user"];
							shopNum1_Member.Name = shopNum1_BaiduUserResponse.uname;
							UrlImgOperate urlImgOperate = new UrlImgOperate();
							string string_ = string.Format("http://himg.bdimg.com/sys/portraitn/item/{0}.jpg", shopNum1_BaiduUserResponse.portrait);
							shopNum1_Member.Photo = urlImgOperate.GetUrlFileName(string_);
						}
					}
					else
					{
						shopNum1_Member.Name = this.ViewState["userName"].ToString();
						shopNum1_Member.Photo = "";
					}
				}
				shopNum1_Member.Pwd = Encryption.GetMd5Hash(this.Page.Request.Form["seconduserBind_Newpassword"].ToString());
				shopNum1_Member.IsForbid = new int?(0);
				shopNum1_Member.Email = this.Page.Request.Form["seconduserBind_email"].ToString();
				shopNum1_Member.Guid = Guid.NewGuid();
				shopNum1_Member.Tel = "";
				shopNum1_Member.AdvancePayment = new decimal?(0m);
				shopNum1_Member.AddressValue = "";
				shopNum1_Member.AddressCode = "";
				shopNum1_Member.RegeDate = new DateTime?(DateTime.Now);
				shopNum1_Member.LoginDate = new DateTime?(DateTime.Now);
				shopNum1_Member.IsMailActivation = new int?(0);
				shopNum1_Member.IsMobileActivation = 0;
				string value = ShopSettings.GetValue("RegPresentRankScore");
				if (value == "" || value == null)
				{
					shopNum1_Member.MemberRank = new int?(0);
				}
				else
				{
					shopNum1_Member.MemberRank = new int?(int.Parse(value));
				}
				string value2 = ShopSettings.GetValue("RegPresentScore");
				if (value2 == "" || value2 == null)
				{
					shopNum1_Member.Score = 0;
				}
				else
				{
					shopNum1_Member.Score = int.Parse(value2);
				}
				shopNum1_Member.LastLoginIP = null;
				shopNum1_Member.LoginTime = new int?(0);
				shopNum1_Member.AdvancePayment = new decimal?(0m);
				shopNum1_Member.LockAdvancePayment = new decimal?(0m);
				shopNum1_Member.LockSocre = new int?(0);
				shopNum1_Member.CostMoney = new decimal?(0m);
				shopNum1_Member.PayPwd = Encryption.GetMd5SecondHash(shopNum1_SecondUser.MemlogID);
				shopNum1_Member.PromotionMemLoginID = "";
				if (shopNum1_Member_Action.Add(shopNum1_Member) == 1)
				{
					HttpCookie httpCookie = HttpSecureCookie.Encode(new HttpCookie("MemberLoginCookie")
					{
						Values = 
						{

							{
								"MemLoginID",
								shopNum1_Member.MemLoginID
							},

							{
								"MemberType",
								"1"
							},

							{
								"uid",
								"-1"
							}
						}
					});
					httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					this.Page.Response.AppendCookie(httpCookie);
					string value3 = ShopSettings.GetValue("RegIsEmail");
					ShopSettings.GetValue("RegIsMMS");
					ShopSettings.GetValue("Name");
					if (!(value3 == "1"))
					{
					}
					this.Page.Response.Redirect("http://" + ShopSettings.siteDomain);
				}
				else
				{
					MessageBox.Show("会员绑定失败!请重新绑定");
				}
			}
		}
		private void method_2()
		{
			string text = this.Page.Request.Form["seconduserBind_userName"].ToString();
			string input = this.Page.Request.Form["seconduserBind_password"].ToString();
			ShopNum1_SecondUser shopNum1_SecondUser = new ShopNum1_SecondUser();
			shopNum1_SecondUser.MemlogID = text;
			string text2 = this.ViewState["type"].ToString();
			string text3 = text2;
			if (text3 != null)
			{
				if (!(text3 == "1"))
				{
					if (!(text3 == "2"))
					{
						if (!(text3 == "3"))
						{
							if (!(text3 == "4"))
							{
								if (text3 == "5")
								{
									shopNum1_SecondUser.SecondID = this.ViewState["user_id"].ToString();
								}
							}
							else
							{
								shopNum1_SecondUser.SecondID = this.ViewState["user_id"].ToString();
							}
						}
						else
						{
							ShopNum1_XinlanUserResponse shopNum1_XinlanUserResponse = (ShopNum1_XinlanUserResponse)this.ViewState["user"];
							shopNum1_SecondUser.SecondID = shopNum1_XinlanUserResponse.Id.ToString();
						}
					}
					else
					{
						ShopNum1_BaiduUserResponse shopNum1_BaiduUserResponse = (ShopNum1_BaiduUserResponse)this.ViewState["user"];
						shopNum1_SecondUser.SecondID = shopNum1_BaiduUserResponse.uid;
					}
				}
				else
				{
					shopNum1_SecondUser.SecondID = this.ViewState["openID"].ToString();
				}
			}
			shopNum1_SecondUser.Secondtype = text2;
			shopNum1_SecondUser.isAvailable = 1;
			if (this.shopNum1_SecondUserBussiness_0.Add(shopNum1_SecondUser))
			{
				IShopNum1_Member_Action shopNum1_Member_Action = LogicFactory.CreateShopNum1_Member_Action();
				DataTable memberPassWord = shopNum1_Member_Action.GetMemberPassWord(text, Encryption.GetMd5Hash(input));
				if (memberPassWord != null && memberPassWord.Rows.Count > 0)
				{
					if (memberPassWord.Rows[0]["IsForbid"].ToString() != "1")
					{
						HttpCookie httpCookie = new HttpCookie("MemberLoginCookie");
						httpCookie.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
						httpCookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
						httpCookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
						if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
						{
							ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
							DataTable shopRankByMemLoginID = shopNum1_ShopInfoList_Action.GetShopRankByMemLoginID(memberPassWord.Rows[0]["MemLoginID"].ToString());
							if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
							{
								httpCookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
							}
						}
						httpCookie.Values.Add("uid", "-1");
						HttpCookie httpCookie2 = HttpSecureCookie.Encode(httpCookie);
						httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie2);
						shopNum1_Member_Action.UpdateLoginTime(text, this.Page.Request.UserHostAddress);
						this.Page.Response.Redirect("http://" + ShopSettings.siteDomain);
					}
					else
					{
						MessageBox.Show("您不能绑定该账户，该账户已经被禁用了!");
					}
				}
				else
				{
					MessageBox.Show("输入的账户或者密码不正确!");
				}
			}
		}
		public string CheckLogin(string memlogid, string string_2)
		{
			return "1";
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (this.Page.Request.QueryString["type"] != null)
			{
				base.Render(writer);
			}
		}
		public string GetCallbackResult()
		{
			string[] array = this.string_1.Split(new char[]
			{
				'|'
			});
			string result;
			if (array.Length == 2)
			{
				result = (string)base.GetType().GetMethod(array[0]).Invoke(this, new object[]
				{
					array[1]
				});
			}
			else
			{
				result = (string)base.GetType().GetMethod(array[0]).Invoke(this, new object[]
				{
					array[1],
					array[2]
				});
			}
			return result;
		}
		public void RaiseCallbackEvent(string eventArgument)
		{
			this.string_1 = eventArgument;
		}
	}
}
