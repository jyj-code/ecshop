using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopInterface;
using ShopNum1_Second;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ThreeLogin : BaseWebControl, ICallbackEventHandler
	{
		[CompilerGenerated]
		private sealed class Class0
		{
			public string string_0;
			public ThreeLogin threeLogin_0;
			public bool method_0(string string_1)
			{
				if (this.string_0 == "BtnBind")
				{
					this.threeLogin_0.method_2();
				}
				else if (this.string_0 == "BtnCreate")
				{
					this.threeLogin_0.method_1();
				}
				return true;
			}
		}
		private string string_0 = "ThreeLogin.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		private ShopNum1_SecondUserBussiness shopNum1_SecondUserBussiness_0 = new ShopNum1_SecondUserBussiness();
		private ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness_0 = new ShopNum1_SecondTypeBussiness();
		private string string_1;
		[CompilerGenerated]
		private static Func<string, string> func_0;
		public ThreeLogin()
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
			if (this.Page.Request.QueryString["type"] != null)
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
												if (this.Page.Request.Cookies["ProductDetail"] != null)
												{
													string url = this.Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/").Replace(".aspx%3Fguid%3D", "/");
													this.Page.Response.Redirect(url);
													return;
												}
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
											if (this.Page.Request.Cookies["ProductDetail"] != null)
											{
												string url = this.Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/").Replace(".aspx%3Fguid%3D", "/");
												this.Page.Response.Redirect(url);
												return;
											}
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
								ShopNum1_XinlanCommonClient shopNum1_XinlanCommonClient = new ShopNum1_XinlanCommonClient();
								shopNum1_XinlanCommonClient.GetXinlanUser(text3, text4);
								if (text3 != "")
								{
									this.literal_0.Text = "";
									this.ViewState["user"] = text3;
									string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(text3, "3");
									if (this.method_0(memLogid))
									{
										if (this.Page.Request.Cookies["ProductDetail"] != null)
										{
											string url = this.Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/").Replace(".aspx%3Fguid%3D", "/");
											this.Page.Response.Redirect(url);
											return;
										}
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
							ShopNum1_BaiduUserResponse baiduUser = shopNum1_BaiduCommonClient.GetBaiduUser(text4, "json");
							string text3 = baiduUser.uid;
							if (text3 != "")
							{
								this.literal_0.Text = baiduUser.uname;
								this.ViewState["user"] = baiduUser;
								string memLogid = this.shopNum1_SecondUserBussiness_0.GetMemLogid(baiduUser.uid, "2");
								if (this.method_0(memLogid))
								{
									if (this.Page.Request.Cookies["ProductDetail"] != null)
									{
										string url = this.Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/").Replace(".aspx%3Fguid%3D", "/");
										this.Page.Response.Redirect(url);
										return;
									}
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
								if (this.Page.Request.Cookies["ProductDetail"] != null)
								{
									string url = this.Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/").Replace(".aspx%3Fguid%3D", "/");
									this.Page.Response.Redirect(url);
									return;
								}
								this.Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
								return;
							}
							else
							{
								this.method_3();
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
		public string ExistEmail(string email)
		{
			IShopNum1_Member_Action shopNum1_Member_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
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
			ThreeLogin.Class0 @class = new ThreeLogin.Class0();
			@class.threeLogin_0 = this;
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
				IShopNum1_Member_Action shopNum1_Member_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
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
						if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
						{
							try
							{
								string oldUser = string.Empty;
								HttpCookie httpCookie = this.Page.Request.Cookies["Visitor_LoginCookie"];
								HttpCookie httpCookie2 = HttpSecureCookie.Decode(httpCookie);
								oldUser = httpCookie2.Values["MemLoginID"].ToString();
								Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
								shop_Product_Action.ChangeCarByCook(oldUser, string_2);
								httpCookie.Values.Clear();
							}
							catch (Exception)
							{
							}
						}
						HttpCookie httpCookie3 = new HttpCookie("MemberLoginCookie");
						httpCookie3.Values.Add("MemLoginID", string_2);
						httpCookie3.Values.Add("Name", memInfoByMemberloginId.Rows[0]["Name"].ToString());
						httpCookie3.Values.Add("MemberType", memInfoByMemberloginId.Rows[0]["MemberType"].ToString());
						if (memInfoByMemberloginId.Rows[0]["MemberType"].ToString() == "2")
						{
							IShop_ShopInfo_Action shop_ShopInfo_Action = ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
							DataTable shopRankByMemLoginID = shop_ShopInfo_Action.GetShopRankByMemLoginID(string_2);
							if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
							{
								httpCookie3.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
							}
						}
						HttpCookie httpCookie4 = HttpSecureCookie.Encode(httpCookie3);
						httpCookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie4);
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
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
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
									}
								}
								else
								{
									shopNum1_Member.Name = "";
								}
							}
							else
							{
								shopNum1_Member.Name = "";
							}
						}
						else
						{
							ShopNum1_BaiduUserResponse shopNum1_BaiduUserResponse = (ShopNum1_BaiduUserResponse)this.ViewState["user"];
							shopNum1_Member.Name = shopNum1_BaiduUserResponse.uname;
							new UrlImgOperate();
							string.Format("http://himg.bdimg.com/sys/portraitn/item/{0}.jpg", shopNum1_BaiduUserResponse.portrait);
						}
					}
					else
					{
						shopNum1_Member.Name = this.ViewState["userName"].ToString();
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
				shopNum1_Member.IsMailActivation = new int?(1);
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
				if (shopNum1_Member_Action.Add(shopNum1_Member) == 1)
				{
					if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
					{
						try
						{
							string oldUser = string.Empty;
							HttpCookie httpCookie = this.Page.Request.Cookies["Visitor_LoginCookie"];
							HttpCookie httpCookie2 = HttpSecureCookie.Decode(httpCookie);
							oldUser = httpCookie2.Values["MemLoginID"].ToString();
							Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
							shop_Product_Action.ChangeCarByCook(oldUser, shopNum1_SecondUser.MemlogID);
							httpCookie.Values.Clear();
						}
						catch (Exception)
						{
						}
					}
					HttpCookie httpCookie3 = HttpSecureCookie.Encode(new HttpCookie("MemberLoginCookie")
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
					httpCookie3.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					this.Page.Response.AppendCookie(httpCookie3);
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
							if (text3 == "4")
							{
								shopNum1_SecondUser.SecondID = this.ViewState["user_id"].ToString();
								goto IL_157;
							}
							if (text3 == "5")
							{
								shopNum1_SecondUser.SecondID = this.ViewState["user_id"].ToString();
								goto IL_157;
							}
							goto IL_157;
						}
						else
						{
							try
							{
								shopNum1_SecondUser.SecondID = this.ViewState["user"].ToString();
								goto IL_157;
							}
							catch
							{
								goto IL_157;
							}
						}
					}
					ShopNum1_BaiduUserResponse shopNum1_BaiduUserResponse = (ShopNum1_BaiduUserResponse)this.ViewState["user"];
					shopNum1_SecondUser.SecondID = shopNum1_BaiduUserResponse.uid;
				}
				else
				{
					shopNum1_SecondUser.SecondID = this.ViewState["openID"].ToString();
				}
			}
			IL_157:
			shopNum1_SecondUser.Secondtype = text2;
			shopNum1_SecondUser.isAvailable = 1;
			if (this.shopNum1_SecondUserBussiness_0.Add(shopNum1_SecondUser))
			{
				IShopNum1_Member_Action shopNum1_Member_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
				DataTable memberPassWord = shopNum1_Member_Action.GetMemberPassWord(text, Encryption.GetMd5Hash(input));
				if (memberPassWord != null && memberPassWord.Rows.Count > 0)
				{
					if (memberPassWord.Rows[0]["IsForbid"].ToString() != "1")
					{
						HttpCookie httpCookie = new HttpCookie("MemberLoginCookie");
						httpCookie.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
						if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
						{
							try
							{
								string oldUser = string.Empty;
								HttpCookie httpCookie2 = this.Page.Request.Cookies["Visitor_LoginCookie"];
								HttpCookie httpCookie3 = HttpSecureCookie.Decode(httpCookie2);
								oldUser = httpCookie3.Values["MemLoginID"].ToString();
								Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
								shop_Product_Action.ChangeCarByCook(oldUser, memberPassWord.Rows[0]["MemLoginID"].ToString());
								httpCookie2.Values.Clear();
							}
							catch (Exception)
							{
							}
						}
						httpCookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
						httpCookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
						if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
						{
							IShop_ShopInfo_Action shop_ShopInfo_Action = ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
							DataTable shopRankByMemLoginID = shop_ShopInfo_Action.GetShopRankByMemLoginID(memberPassWord.Rows[0]["MemLoginID"].ToString());
							if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
							{
								httpCookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
							}
						}
						httpCookie.Values.Add("uid", "-1");
						HttpCookie httpCookie4 = HttpSecureCookie.Encode(httpCookie);
						httpCookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
						this.Page.Response.AppendCookie(httpCookie4);
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
		private void method_3()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			string text = this.ViewState["userName"].ToString().Replace("(", "").Replace(")", "") + "_" + this.method_5();
			text = this.method_4(text);
			ShopNum1_SecondUser shopNum1_SecondUser = new ShopNum1_SecondUser();
			string text2 = DateTime.Now.ToString("MMddmmss");
			lock (text2)
			{
				Thread.Sleep(20);
			}
			this.ViewState["userName"].ToString();
			shopNum1_SecondUser.MemlogID = text;
			shopNum1_SecondUser.SecondID = this.ViewState["openID"].ToString();
			shopNum1_SecondUser.Secondtype = "1";
			shopNum1_SecondUser.isAvailable = 1;
			if (this.shopNum1_SecondUserBussiness_0.Add(shopNum1_SecondUser))
			{
				ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
				shopNum1_Member.MemLoginID = text;
				shopNum1_Member.MemberType = new int?(1);
				shopNum1_Member.Name = this.ViewState["userName"].ToString();
				shopNum1_Member.Pwd = Encryption.GetMd5Hash("123456");
				shopNum1_Member.IsForbid = new int?(0);
				shopNum1_Member.Email = "";
				shopNum1_Member.Guid = Guid.NewGuid();
				shopNum1_Member.Tel = "";
				shopNum1_Member.AdvancePayment = new decimal?(0m);
				shopNum1_Member.AddressValue = "";
				shopNum1_Member.AddressCode = "";
				shopNum1_Member.RegeDate = new DateTime?(DateTime.Now);
				shopNum1_Member.LoginDate = new DateTime?(DateTime.Now);
				shopNum1_Member.IsMailActivation = new int?(1);
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
				ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberRank_Action();
				DataTable defaultMemberRank = shopNum1_MemberRank_Action.GetDefaultMemberRank();
				Guid memberRankGuid = Guid.NewGuid();
				try
				{
					if (defaultMemberRank != null && defaultMemberRank.Rows.Count > 0)
					{
						memberRankGuid = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
					}
					else
					{
						memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
					}
				}
				catch (Exception)
				{
					memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
				}
				shopNum1_Member.MemberRankGuid = memberRankGuid;
				if (shopNum1_Member_Action.Add(shopNum1_Member) == 1)
				{
					HttpCookie httpCookie = new HttpCookie("MemberLoginCookie");
					httpCookie.Values.Add("MemLoginID", shopNum1_Member.MemLoginID);
					if (this.Page.Request.Cookies["Visitor_LoginCookie"] != null)
					{
						try
						{
							string oldUser = string.Empty;
							HttpCookie httpCookie2 = this.Page.Request.Cookies["Visitor_LoginCookie"];
							HttpCookie httpCookie3 = HttpSecureCookie.Decode(httpCookie2);
							oldUser = httpCookie3.Values["MemLoginID"].ToString();
							Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
							shop_Product_Action.ChangeCarByCook(oldUser, shopNum1_Member.MemLoginID);
							httpCookie2.Values.Clear();
						}
						catch (Exception)
						{
						}
					}
					httpCookie.Values.Add("MemberType", "1");
					httpCookie.Values.Add("uid", "-1");
					HttpCookie httpCookie4 = HttpSecureCookie.Encode(httpCookie);
					httpCookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					this.Page.Response.AppendCookie(httpCookie4);
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
		private string method_4(string string_2)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			int num = shopNum1_Member_Action.CheckmemLoginID(string_2);
			string result;
			if (num > 0)
			{
				string_2 = this.ViewState["userName"].ToString().Replace("(", "").Replace(")", "") + "_" + this.method_5();
				this.method_4(string_2);
				result = string_2;
			}
			else
			{
				result = string_2;
			}
			return result;
		}
		private string method_5()
		{
			if (ThreeLogin.func_0 == null)
			{
				ThreeLogin.func_0 = new Func<string, string>(ThreeLogin.smethod_0);
			}
			Func<string, string> func = ThreeLogin.func_0;
			string text = string.Empty;
			Random random = new Random();
			for (int i = 0; i < 4; i++)
			{
				int num = random.Next();
				char c;
				if (num % 2 == 0)
				{
					c = (char)(48 + (ushort)(num % 10));
				}
				else
				{
					c = (char)(65 + (ushort)(num % 26));
				}
				text += c.ToString();
			}
			return func(text);
		}
		[CompilerGenerated]
		private static string smethod_0(string string_2)
		{
			HttpContext.Current.Session["code"] = string_2;
			return string_2;
		}
	}
}
