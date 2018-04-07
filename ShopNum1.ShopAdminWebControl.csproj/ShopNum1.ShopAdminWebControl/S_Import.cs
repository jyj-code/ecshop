using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Import : BaseShopWebControl, IPostBackEventHandler
	{
		private string string_0 = "S_Import.ascx";
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private HtmlInputHidden htmlInputHidden_5;
		private HtmlInputHidden htmlInputHidden_6;
		private HtmlInputHidden htmlInputHidden_7;
		private HtmlInputHidden htmlInputHidden_8;
		private DataTable dataTable_0 = new DataTable();
		private string string_1 = string.Empty;
		private Label label_0;
		private HtmlInputHidden htmlInputHidden_9;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private Shop_ShopInfo_Action shop_ShopInfo_Action_0 = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
		private Shop_Common_Action shop_Common_Action_0 = (Shop_Common_Action)LogicFactory.CreateShop_Common_Action();
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private static MatchEvaluator matchEvaluator_0;
		private string ShopRank
		{
			get;
			set;
		}
		private string imgUploadPath
		{
			get;
			set;
		}
		private string Temppath
		{
			get;
			set;
		}
		private string ShopImgUpload
		{
			get;
			set;
		}
		public S_Import()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidProdtype");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidctype");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidptype");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidstype");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidbtype");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidatype");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidsell");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidpath");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidLoginId");
			this.label_0 = (Label)skin.FindControl("lblMsg");
			this.htmlInputHidden_8.Value = this.MemLoginID;
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidfee");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtPost_fee");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtExpress_fee");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txtEms_fee");
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.ShopRank = httpCookie.Values["ShopRank"].ToString();
			}
			this.Page.RegisterRequiresRaiseEvent(this);
		}
		public void RaisePostBackEvent(string eventArgument)
		{
			Func<string, bool> func = null;
			try
			{
				string arg = this.Page.Request.Form["__EVENTTARGET"];
				if (func == null)
				{
					func = new Func<string, bool>(this.method_2);
				}
				Func<string, bool> func2 = func;
				func2(arg);
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(ex.Message);
			}
		}
		protected bool ImportCSV(string strPath)
		{
			bool result;
			try
			{
				ShopNum1UnZipClass.UnZip(strPath, strPath.Replace(".zip", "") + "\\", null);
				Thread.Sleep(20);
				File.Delete(strPath);
				string[] files = Directory.GetFiles(strPath.Replace(".zip", ""));
				string[] directories = Directory.GetDirectories(strPath.Replace(".zip", ""));
				if (directories.Length == 1 && files.Length == 0)
				{
					string[] directories2 = Directory.GetDirectories(directories[0].ToString());
					string[] files2 = Directory.GetFiles(directories[0].ToString());
					string filepath = files2[0];
					this.imgUploadPath = directories2[0];
					this.dataTable_0 = S_Import.read_csv(filepath);
					if (this.dataTable_0 != null && this.dataTable_0.Rows.Count > 0)
					{
						result = true;
					}
					else
					{
						this.label_0.Text = "没有导入任何数据!";
						result = false;
					}
				}
				else if (directories.Length == 1 && files.Length == 1)
				{
					string filepath = files[0];
					this.imgUploadPath = directories[0];
					this.dataTable_0 = S_Import.read_csv(filepath);
					if (this.dataTable_0 != null && this.dataTable_0.Rows.Count > 0)
					{
						result = true;
					}
					else
					{
						this.label_0.Text = "没有导入任何数据!";
						result = false;
					}
				}
				else
				{
					this.label_0.Text = "导入数据包格式不正确!";
					result = false;
				}
			}
			catch (Exception)
			{
				this.label_0.Text = "导入的文件的格式不对!请上传正确的ZIP压缩文件!";
				result = false;
			}
			finally
			{
				try
				{
					File.Delete(strPath);
				}
				catch
				{
				}
			}
			return result;
		}
		protected string GetShopName()
		{
			DataTable memLoginInfo = this.shop_ShopInfo_Action_0.GetMemLoginInfo(this.MemLoginID);
			return memLoginInfo.Rows[0]["ShopName"].ToString();
		}
		protected bool OpImport()
		{
			bool result;
			try
			{
				int num = 0;
				string strPath = this.Page.Server.MapPath(this.htmlInputHidden_7.Value);
				if (this.ImportCSV(strPath))
				{
					DataTable memLoginInfo = this.shop_ShopInfo_Action_0.GetMemLoginInfo(this.MemLoginID);
					this.string_1 = memLoginInfo.Rows[0]["ShopID"].ToString();
					DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("MM_dd");
					this.ShopImgUpload = string.Concat(new string[]
					{
						"/ImgUpload/shopImage/",
						DateTime.Now.ToString("yyyy"),
						"/shop",
						this.string_1,
						"/"
					});
					Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
					Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
					string value = shop_ShopInfo_Action.IsAllowToAddProduct(this.MemLoginID, this.ShopRank, "1");
					int num2 = Convert.ToInt32(value);
					if (Convert.ToInt32(value) < this.dataTable_0.Rows.Count)
					{
						num2 = 0;
						this.label_0.Text = "添加的商品已超过权限最大值!";
						result = false;
					}
					else
					{
						ShopNum1_Shop_Product shopNum1_Shop_Product = new ShopNum1_Shop_Product();
						shopNum1_Shop_Product.Score = new int?(0);
						shopNum1_Shop_Product.IsReal = 1;
						shopNum1_Shop_Product.IsSell = Convert.ToInt32(this.htmlInputHidden_6.Value);
						shopNum1_Shop_Product.UnitName = "";
						shopNum1_Shop_Product.CreateTime = new DateTime?(DateTime.Now);
						shopNum1_Shop_Product.IsNew = new int?(0);
						shopNum1_Shop_Product.IsHot = new int?(0);
						shopNum1_Shop_Product.IsPromotion = new int?(0);
						if (this.htmlInputHidden_0.Value.IndexOf("isshopnew") != -1)
						{
							shopNum1_Shop_Product.IsShopNew = 1;
						}
						if (this.htmlInputHidden_0.Value.IndexOf("isshophot") != -1)
						{
							shopNum1_Shop_Product.IsShopHot = 1;
						}
						if (this.htmlInputHidden_0.Value.IndexOf("isshoppromotion") != -1)
						{
							shopNum1_Shop_Product.IsShopPromotion = 1;
						}
						if (this.htmlInputHidden_0.Value.IndexOf("isshoprecommend") != -1)
						{
							shopNum1_Shop_Product.IsShopRecommend = 1;
						}
						string value2 = ShopSettings.GetValue("AddProductIsAudit");
						if (value2 == "0")
						{
							shopNum1_Shop_Product.IsAudit = 1;
						}
						else
						{
							shopNum1_Shop_Product.IsAudit = 0;
						}
						shopNum1_Shop_Product.MemLoginID = this.MemLoginID;
						shopNum1_Shop_Product.ShopName = this.GetShopName();
						shopNum1_Shop_Product.ProductCategoryCode = this.htmlInputHidden_2.Value.Split(new char[]
						{
							'|'
						})[0];
						shopNum1_Shop_Product.ProductCategoryName = this.htmlInputHidden_2.Value.Split(new char[]
						{
							'|'
						})[1];
						shopNum1_Shop_Product.ProductSeriesCode = this.htmlInputHidden_3.Value.Split(new char[]
						{
							'|'
						})[0];
						shopNum1_Shop_Product.ProductSeriesName = this.htmlInputHidden_3.Value.Split(new char[]
						{
							'|'
						})[1];
						if (this.htmlInputHidden_4.Value.Split(new char[]
						{
							'|'
						})[0].Length > 30)
						{
							shopNum1_Shop_Product.BrandGuid = new Guid(this.htmlInputHidden_4.Value.Split(new char[]
							{
								'|'
							})[0]);
							shopNum1_Shop_Product.BrandName = this.htmlInputHidden_4.Value.Split(new char[]
							{
								'|'
							})[1];
						}
						else
						{
							shopNum1_Shop_Product.BrandGuid = new Guid("00000000-0000-0000-0000-000000000000");
							shopNum1_Shop_Product.BrandName = "其它";
						}
						int num3 = 0;
						while (num3 < this.dataTable_0.Rows.Count && num2 > 0)
						{
							try
							{
								shopNum1_Shop_Product.Guid = Guid.NewGuid();
								shopNum1_Shop_Product.Name = this.dataTable_0.Rows[num3]["宝贝名称"].ToString();
								if (this.dataTable_0.Rows[num3]["省"].ToString() != "")
								{
									shopNum1_Shop_Product.AddressCode = "00";
									shopNum1_Shop_Product.AddressValue = this.dataTable_0.Rows[num3]["省"].ToString();
									if (this.dataTable_0.Rows[num3]["城市"].ToString() != "")
									{
										shopNum1_Shop_Product.AddressCode = "00,00";
										shopNum1_Shop_Product.AddressValue = this.dataTable_0.Rows[num3]["省"].ToString() + "," + this.dataTable_0.Rows[num3]["城市"].ToString();
									}
								}
								shopNum1_Shop_Product.Name = this.dataTable_0.Rows[num3]["宝贝名称"].ToString();
								shopNum1_Shop_Product.ProductNum = this.dataTable_0.Rows[num3]["商家编码"].ToString();
								shopNum1_Shop_Product.OrderID = new int?(this.shop_Common_Action_0.ReturnMaxID("OrderID", "ShopNum1_Shop_Product") + 1);
								shopNum1_Shop_Product.ShopPrice = Convert.ToDecimal(this.dataTable_0.Rows[num3]["宝贝价格"].ToString().Trim());
								shopNum1_Shop_Product.MarketPrice = new decimal?(Convert.ToDecimal(this.dataTable_0.Rows[num3]["宝贝价格"].ToString().Trim()));
								shopNum1_Shop_Product.RepertoryCount = Convert.ToInt32(this.dataTable_0.Rows[num3]["宝贝数量"].ToString());
								if (this.htmlInputHidden_9.Value == "1")
								{
									shopNum1_Shop_Product.FeeType = 1;
									shopNum1_Shop_Product.Post_fee = Convert.ToDecimal("0.00");
									shopNum1_Shop_Product.Express_fee = Convert.ToDecimal("0.00");
									shopNum1_Shop_Product.Ems_fee = Convert.ToDecimal("0.00");
								}
								else
								{
									shopNum1_Shop_Product.FeeType = 0;
									try
									{
										shopNum1_Shop_Product.Post_fee = Convert.ToDecimal(this.htmlInputText_0.Value);
										shopNum1_Shop_Product.Express_fee = Convert.ToDecimal(this.htmlInputText_1.Value);
										shopNum1_Shop_Product.Ems_fee = Convert.ToDecimal(this.htmlInputText_2.Value);
									}
									catch
									{
										shopNum1_Shop_Product.Post_fee = Convert.ToDecimal("0.00");
										shopNum1_Shop_Product.Express_fee = Convert.ToDecimal("0.00");
										shopNum1_Shop_Product.Ems_fee = Convert.ToDecimal("0.00");
									}
								}
								ShopNum1_Shop_Product arg_76C_0 = shopNum1_Shop_Product;
								string arg_767_0 = HttpUtility.HtmlDecode(this.dataTable_0.Rows[num3]["宝贝描述"].ToString());
								string arg_767_1 = "=\"\"[\\w](.*?)\"\"";
								if (S_Import.matchEvaluator_0 == null)
								{
									S_Import.matchEvaluator_0 = new MatchEvaluator(S_Import.smethod_0);
								}
								arg_76C_0.Detail = Regex.Replace(arg_767_0, arg_767_1, S_Import.matchEvaluator_0);
								shopNum1_Shop_Product.Instruction = this.dataTable_0.Rows[num3]["宝贝名称"].ToString();
								string text = "";
								if (this.dataTable_0.Rows[num3]["新图片"].ToString() != string.Empty)
								{
									try
									{
										string[] array = new string[]
										{
											":0:0:|;"
										};
										string[] array2 = this.dataTable_0.Rows[num3]["新图片"].ToString().Split(new char[]
										{
											':'
										});
										FileInfo fileInfo = new FileInfo(this.imgUploadPath + "\\" + array2[0].ToString() + ".tbi");
										string text2 = DateTime.Now.ToString("yyyyMMddHHmmss");
										lock (text2)
										{
											Thread.Sleep(1);
										}
										string str = text2 + new Random().Next(1000);
										text = this.ShopImgUpload + str + ".jpg";
										if (!Directory.Exists(this.Page.Server.MapPath(this.ShopImgUpload)))
										{
											Directory.CreateDirectory(this.Page.Server.MapPath(this.ShopImgUpload));
										}
										fileInfo.CopyTo(this.Page.Server.MapPath(text));
										string path = text + "_25x25.jpg";
										string path2 = text + "_60x60.jpg";
										string path3 = text + "_100x100.jpg";
										string path4 = text + "_160x160.jpg";
										string path5 = text + "_300x300.jpg";
										ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(path), 25, 25);
										ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(path2), 60, 60);
										ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(path3), 100, 100);
										ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(path4), 160, 160);
										ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(path5), 300, 300);
										shopNum1_Shop_Product.OriginalImage = text;
										this.AddImageSizeToXML(text);
										this.AddImageToDataBase(text);
									}
									catch (Exception ex)
									{
									}
								}
								shopNum1_Shop_Product.AddressValue = this.dataTable_0.Rows[num3]["省"].ToString();
								shopNum1_Shop_Product.MultiImages = text;
								shopNum1_Shop_Product.OriginalImage = text;
								shopNum1_Shop_Product.ThumbImage = text;
								shopNum1_Shop_Product.SmallImage = text;
								shopNum1_Shop_Product.Ctype = new int?(Convert.ToInt32(this.htmlInputHidden_1.Value.Split(new char[]
								{
									'|'
								})[0]));
								shopNum1_Shop_Product.ModifyTime = new DateTime?(DateTime.Now);
								shopNum1_Shop_Product.CreateTime = new DateTime?(DateTime.Now);
								shopNum1_Shop_Product.StartTime = new DateTime?(DateTime.Now);
								shopNum1_Shop_Product.SaleTime = new DateTime?(DateTime.Now);
								shopNum1_Shop_Product.DeSaleTime = new DateTime?(DateTime.Now);
								shopNum1_Shop_Product.EndTime = new DateTime?(DateTime.Now);
								shopNum1_Shop_Product.Description = this.dataTable_0.Rows[num3]["宝贝名称"].ToString();
								shopNum1_Shop_Product.Keywords = this.dataTable_0.Rows[num3]["宝贝名称"].ToString();
								shopNum1_Shop_Product.Wap_desc = "";
								shopNum1_Shop_Product.ProductState = new int?(0);
								int num4 = shop_Product_Action.AddShopProduct(shopNum1_Shop_Product);
								if (num4 > 0)
								{
									num++;
									num2--;
								}
							}
							catch (Exception ex)
							{
							}
							num3++;
						}
						this.method_0();
						if (num > 0)
						{
							this.label_0.Text = string.Format("您成功导入了{0}条商品数据!", num);
							this.label_0.ForeColor = Color.Green;
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(string.Concat(new string[]
				{
					ex.Message,
					"|",
					ex.Source,
					"|",
					ex.StackTrace
				}));
				result = false;
			}
			return result;
		}
		private void method_0()
		{
			Themes.DeleteFolder(this.Temppath);
		}
		private string method_1(string string_6, string string_7)
		{
			string[] array = string_6.Split(new char[]
			{
				';'
			});
			string text = string_7;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				if (text2 != array[0].ToString())
				{
					string[] array3 = text2.Split(new char[]
					{
						':'
					});
					if (array3.Length != 4 && array3.Length == 5)
					{
						try
						{
							FileInfo fileInfo = new FileInfo(this.imgUploadPath + "\\" + array3[0] + ".tbi");
							string text3 = DateTime.Now.ToString("yyyyMMddHHmmss");
							lock (text3)
							{
								Thread.Sleep(1);
							}
							string text4 = text3 + new Random().Next(1000);
							fileInfo.CopyTo(this.Page.Server.MapPath(this.ShopImgUpload + text4 + ".jpg"));
							ImageOperator.CreateThumbnailAuto(this.Page.Server.MapPath(this.ShopImgUpload + text4 + ".jpg"), this.Page.Server.MapPath(this.ShopImgUpload + "s_" + text4 + ".jpg"), 300, 300);
							this.AddImageSizeToXML(this.ShopImgUpload + text4 + ".jpg");
							this.AddImageToDataBase(this.ShopImgUpload + text4 + ".jpg");
							if (text != string.Empty)
							{
								text = string.Concat(new string[]
								{
									text,
									",",
									this.ShopImgUpload,
									"s_",
									text4,
									".jpg"
								});
							}
							else
							{
								text = string.Concat(new string[]
								{
									string_7,
									",",
									this.ShopImgUpload,
									"s_",
									text4,
									".jpg"
								});
							}
						}
						catch
						{
						}
					}
				}
			}
			return text;
		}
		public static DataTable read_csv(string filepath)
		{
			string text = File.ReadAllText(filepath, Encoding.GetEncoding("gbk")).Replace("\t", ",");
			DataTable result;
			if (text != null)
			{
				List<string[]> list = new List<string[]>();
				List<string> list2 = new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				bool flag = false;
				bool flag2 = true;
				for (int i = 0; i < text.Length; i++)
				{
					char c = text[i];
					if (flag)
					{
						if (c == '"')
						{
							if (i < text.Length - 1 && text[i + 1] == '"')
							{
								stringBuilder.Append('"');
								i++;
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					else
					{
						char c2 = c;
						if (c2 <= '\r')
						{
							if (c2 == '\n')
							{
								if (stringBuilder.Length > 0 || flag2)
								{
									list2.Add(stringBuilder.ToString());
									stringBuilder.Remove(0, stringBuilder.Length);
								}
								list.Add(list2.ToArray());
								list2.Clear();
								flag2 = true;
								goto IL_1F8;
							}
							if (c2 == '\r')
							{
								if (stringBuilder.Length > 0 || flag2)
								{
									list2.Add(stringBuilder.ToString());
									stringBuilder.Remove(0, stringBuilder.Length);
								}
								list.Add(list2.ToArray());
								list2.Clear();
								flag2 = true;
								if (i < text.Length - 1 && text[i + 1] == '\n')
								{
									i++;
									goto IL_1F8;
								}
								goto IL_1F8;
							}
						}
						else if (c2 != '"')
						{
							if (c2 == ',')
							{
								list2.Add(stringBuilder.ToString());
								stringBuilder.Remove(0, stringBuilder.Length);
								flag2 = true;
								goto IL_1F8;
							}
						}
						else
						{
							if (flag2)
							{
								flag = true;
								goto IL_1F8;
							}
							stringBuilder.Append(c);
							goto IL_1F8;
						}
						flag2 = false;
						stringBuilder.Append(c);
					}
					IL_1F8:;
				}
				if (stringBuilder.Length > 10 || flag2)
				{
					list2.Add(stringBuilder.ToString());
				}
				if (list2.Count > 0)
				{
					list.Add(list2.ToArray());
				}
				bool flag3 = false;
				DataTable dataTable = new DataTable();
				for (int i = 0; i < list.Count; i++)
				{
					if (list[0].Length < 20)
					{
						list.Remove(list[0]);
						list.Remove(list[0]);
						IL_2A2:
						for (i = 0; i < list.Count; i++)
						{
							if (list[i].Length > 10)
							{
								if (i == 0)
								{
									for (int j = 0; j < list[0].Length; j++)
									{
										if (!string.IsNullOrEmpty(list[0][j]))
										{
											DataColumn dataColumn = new DataColumn();
											dataColumn.ColumnName = list[0][j];
											dataTable.Columns.Add(dataColumn);
										}
									}
								}
								else
								{
									DataRow dataRow = dataTable.NewRow();
									for (int j = 0; j < list[i].Length; j++)
									{
										try
										{
											if (!string.IsNullOrEmpty(list[0][j]))
											{
												dataRow[j] = list[i][j];
											}
											goto IL_392;
										}
										catch
										{
											goto IL_392;
										}
										break;
										IL_392:;
									}
									if (flag3)
									{
										flag3 = false;
										break;
									}
									dataTable.Rows.Add(dataRow);
								}
							}
						}
						result = dataTable;
						return result;
					}
				}
                //goto IL_2A2;
			}
			result = null;
			return result;
		}
		public void AddImageSizeToXML(string filepath)
		{
			string str = filepath.Substring(filepath.LastIndexOf('/') + 1);
			string str2 = filepath.Substring(0, filepath.LastIndexOf('/') + 1);
			string str3 = "s_" + str;
			string path = str2 + str3;
			string text = this.Page.Server.MapPath(filepath);
			string text2 = this.Page.Server.MapPath(path);
			if (File.Exists(text) && File.Exists(text2))
			{
				FileInfo fileInfo = new FileInfo(text);
				FileInfo fileInfo2 = new FileInfo(text2);
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
				string text3 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
				new XmlDataSource();
				string path2 = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text3.Replace("-", "/"),
					"/shop",
					this.string_1,
					"/Site_Settings.xml"
				});
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(path2));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				dataRow["UserImageSpace"] = (Convert.ToInt64(dataRow["UserImageSpace"]) + fileInfo.Length + fileInfo2.Length).ToString();
				dataSet.AcceptChanges();
				dataSet.WriteXml(this.Page.Server.MapPath(path2));
			}
		}
		public void AddImageToDataBase(string imagePath)
		{
			ShopNum1_Shop_Image shopNum1_Shop_Image = new ShopNum1_Shop_Image();
			Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
			shopNum1_Shop_Image.CreateTime = DateTime.Now;
			shopNum1_Shop_Image.CreateUser = this.MemLoginID;
			shopNum1_Shop_Image.ImageCategoryID = Convert.ToInt32(this.htmlInputHidden_5.Value.Split(new char[]
			{
				'|'
			})[0]);
			shopNum1_Shop_Image.ImagePath = imagePath;
			shopNum1_Shop_Image.ImageType = ".jpg";
			shopNum1_Shop_Image.Name = string.Concat(new string[]
			{
				"tb_",
				DateTime.Now.Month.ToString(),
				DateTime.Now.Day.ToString(),
				DateTime.Now.Hour.ToString(),
				DateTime.Now.Minute.ToString(),
				DateTime.Now.Millisecond.ToString()
			});
			shopNum1_Shop_Image.UseTimes = 0;
			shop_Image_Action.Insert(shopNum1_Shop_Image);
		}
		[CompilerGenerated]
		private bool method_2(string string_6)
		{
			if (string_6 != null && string_6 == "btnOk")
			{
				this.OpImport();
			}
			return true;
		}
		[CompilerGenerated]
		private static string smethod_0(Match match_0)
		{
			return match_0.ToString().Replace("\"\"", "\"");
		}
	}
}
