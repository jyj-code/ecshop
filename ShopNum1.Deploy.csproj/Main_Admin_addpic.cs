using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_addpic : PageBase, IRequiresSessionState
{
	protected DropDownList DropDownListImageType;
	protected TextBox textBoxName;
	protected DropDownList DropDownListImgCategory2;
	protected FileUpload FileUploadImage;
	protected Image Image1;
	protected CheckBoxList CheckBoxListImageSpec;
	protected TextBox textBoxDescription;
	protected Button btnConfirm;
	protected MessageShow MessageShow;
	protected HtmlForm form1;
	protected string strSapce = "\u3000\u3000";
	[CompilerGenerated]
	private string string_5;
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
	public string ImageSpec
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.BindImageType();
			this.BindImageCategory();
			this.BindCheckBoxListImageSpec("Product");
			this.method_5();
		}
	}
	private void method_5()
	{
		if (base.Request.QueryString["id"] != null)
		{
			ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
			DataTable dataTable = shopNum1_Image_Action.Search("'" + base.Request.QueryString["id"] + "'");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.DropDownListImageType.SelectedValue = dataTable.Rows[0]["ImageType"].ToString();
				this.textBoxName.Text = dataTable.Rows[0]["Name"].ToString();
				this.DropDownListImgCategory2.SelectedValue = dataTable.Rows[0]["ImageCategoryID"].ToString();
				this.textBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
				this.Image1.Visible = true;
				this.Image1.ImageUrl = dataTable.Rows[0]["ImagePath"].ToString();
			}
		}
	}
	protected void BindImageCategory()
	{
		this.DropDownListImgCategory2.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "请选择";
		listItem.Value = "0";
		this.DropDownListImgCategory2.Items.Add(listItem);
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		DataView defaultView = shopNum1_ImageCategory_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListImgCategory2.Items.Add(listItem2);
			DataTable dataTable = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	private void method_6(DataTable dt)
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		foreach (DataRow dataRow in dt.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += dataRow["Name"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListImgCategory2.Items.Add(listItem);
			DataTable dataTable = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	protected void BindCheckBoxListImageSpec(string strType)
	{
		this.CheckBoxListImageSpec.Items.Clear();
		this.CheckBoxListImageSpec.Visible = true;
		string str = "Skin_Default";
		string imageSpec = "Themes/" + str + "/ImageSpec.xml";
		this.ImageSpec = imageSpec;
		string xmlPath = base.Server.MapPath("../" + this.ImageSpec);
		DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "ImageSpec");
		foreach (DataRow dataRow in xmlData.Tables[0].Rows)
		{
			ListItem listItem = new ListItem();
			if (strType == "Product")
			{
				if (!(dataRow["name"].ToString().Trim() == "Product"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "Brand")
			{
				if (!(dataRow["name"].ToString().Trim() == "Brand"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "GuidBuy")
			{
				if (!(dataRow["name"].ToString().Trim() == "GuidBuy"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "Pack")
			{
				if (!(dataRow["name"].ToString().Trim() == "Pack"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "BlessCard")
			{
				if (!(dataRow["name"].ToString().Trim() == "BlessCard"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "Logo")
			{
				if (!(dataRow["name"].ToString().Trim() == "Logo"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "Article")
			{
				if (!(dataRow["name"].ToString().Trim() == "Article"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "Control")
			{
				if (!(dataRow["name"].ToString().Trim() == "Control"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else if (strType == "Video")
			{
				if (!(dataRow["name"].ToString().Trim() == "Video"))
				{
					continue;
				}
				listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
				this.CheckBoxListImageSpec.Items.Add(listItem);
			}
			else
			{
				if ((!(strType == "Advertisement") && !(strType == "Icon")) || (!(dataRow["name"].ToString().Trim() == "Icon") && !(dataRow["name"].ToString().Trim() == "Advertisement")))
				{
					continue;
				}
				this.CheckBoxListImageSpec.Visible = false;
			}
			break;
		}
		if (this.CheckBoxListImageSpec.Items.Count > 0)
		{
			this.CheckBoxListImageSpec.Items[0].Selected = true;
		}
	}
	protected void DropDownListImageType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>loadwindow2(800,600);</script>", false);
		string a = this.DropDownListImageType.SelectedItem.Text.ToString();
		if (a == "商品图片")
		{
			this.BindCheckBoxListImageSpec("Product");
		}
		else if (a == "品牌图片")
		{
			this.BindCheckBoxListImageSpec("Brand");
		}
		else if (a == "导购图片")
		{
			this.BindCheckBoxListImageSpec("GuidBuy");
		}
		else if (a == "包装图片")
		{
			this.BindCheckBoxListImageSpec("Pack");
		}
		else if (a == "贺卡图片")
		{
			this.BindCheckBoxListImageSpec("BlessCard");
		}
		else if (a == "Logo图片")
		{
			this.BindCheckBoxListImageSpec("Logo");
		}
		else if (a == "资讯图片")
		{
			this.BindCheckBoxListImageSpec("Article");
		}
		else if (a == "控件图片")
		{
			this.BindCheckBoxListImageSpec("Control");
		}
		else if (a == "视频图片")
		{
			this.BindCheckBoxListImageSpec("Video");
		}
		else if (a == "广告图片")
		{
			this.BindCheckBoxListImageSpec("Advertisement");
		}
		else if (a == "小图标")
		{
			this.BindCheckBoxListImageSpec("Icon");
		}
	}
	protected void BindImageType()
	{
		this.DropDownListImageType.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListImageType.Items.Add(new ListItem("商品图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4941"));
		this.DropDownListImageType.Items.Add(new ListItem("品牌图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4942"));
		this.DropDownListImageType.Items.Add(new ListItem("导购图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4943"));
		this.DropDownListImageType.Items.Add(new ListItem("包装图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4944"));
		this.DropDownListImageType.Items.Add(new ListItem("贺卡图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4945"));
		this.DropDownListImageType.Items.Add(new ListItem("Logo图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4947"));
		this.DropDownListImageType.Items.Add(new ListItem("资讯图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4948"));
		this.DropDownListImageType.Items.Add(new ListItem("控件图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4950"));
		this.DropDownListImageType.Items.Add(new ListItem("视频图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4951"));
		this.DropDownListImageType.Items.Add(new ListItem("广告图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4952"));
		this.DropDownListImageType.Items.Add(new ListItem("小图标", "b0f6e545-cd10-4e83-8c96-2c1e143e4953"));
	}
	protected void btnConfirm_Click(object sender, EventArgs e)
	{
		if (base.Request.QueryString["id"] == null)
		{
			if (this.FileUploadImage.HasFile)
			{
				string contentType = this.FileUploadImage.PostedFile.ContentType;
				if (contentType == "image/bmp" || contentType == "image/png" || contentType == "image/gif" || contentType == "image/pjpeg" || contentType == "image/x-png" || contentType == "image/pjpeg" || contentType == "image/jpeg")
				{
					string fileName = Operator.FilterString(this.FileUploadImage.PostedFile.FileName);
					Random random = new Random();
					string str = (10 + random.Next(70)).ToString();
					Thread.Sleep(20);
					string text = DateTime.Now.ToString("yyyyMMddHHmmss") + str;
					FileInfo fileInfo = new FileInfo(fileName);
					string str2 = text + fileInfo.Extension;
					string text2 = base.Server.MapPath("~/ImgUpload/" + str2);
					string fileName2 = "~/ImgUpload/" + str2;
					if (!File.Exists(text2))
					{
						try
						{
							string a = ShopSettings.GetValue("IfSetWaterMark");
							if (this.DropDownListImageType.SelectedValue == "b0f6e545-cd10-4e83-8c96-2c1e143e4947")
							{
								a = "0";
							}
							if (a == "0")
							{
								this.FileUploadImage.SaveAs(text2);
							}
							else if (a == "1")
							{
								string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
								this.FileUploadImage.SaveAs(text3);
								string value = ShopSettings.GetValue("WaterMarkWords");
								string value2 = ShopSettings.GetValue("WordsWaterMarkPosition");
								string value3 = ShopSettings.GetValue("WaterMarkWordsFont");
								float fontSize = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
								string value4 = ShopSettings.GetValue("WaterMarkWordsColor");
								ImageOperator.CreateWater(text3, text2, value, value2, value3, fontSize, value4);
								File.Delete(text3);
							}
							else if (a == "2")
							{
								string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
								this.FileUploadImage.SaveAs(text3);
								string text4 = ShopSettings.GetValue("WaterMarkOriginalImge");
								text4 = base.Server.MapPath(text4);
								string value2 = ShopSettings.GetValue("WaterMarkImagePosition");
								ImageOperator.CreateWaterPic(text3, text2, text4, value2);
								File.Delete(text3);
							}
							this.Add(fileName2);
							string str3 = "s_" + text + fileInfo.Extension;
							string text5 = base.Server.MapPath("~/ImgUpload/" + str3);
							for (int i = 0; i < this.CheckBoxListImageSpec.Items.Count; i++)
							{
								if (!this.CheckBoxListImageSpec.Items[i].Selected)
								{
									File.Copy(text2, text5);
									IL_372:
									return;
								}
								string[] array = this.CheckBoxListImageSpec.Items[i].Value.Split(new char[]
								{
									'*'
								});
								int width = Convert.ToInt32(array[0]);
								int height = Convert.ToInt32(array[1]);
								ImageOperator.CreateThumbnailAuto(text2, text5, width, height);
							}
                            //goto IL_372;
						}
						catch (Exception)
						{
							this.MessageShow.Visible = true;
							this.MessageShow.ShowMessage("UpdateNo1");
							return;
						}
					}
					this.MessageShow.Visible = true;
					this.MessageShow.ShowMessage("UpdateNo2");
				}
				else
				{
					this.MessageShow.Visible = true;
					this.MessageShow.ShowMessage("UpdateNo3");
				}
			}
			else
			{
				MessageBox.Show("请上传图片！");
			}
		}
		else
		{
			string fileName2 = string.Empty;
			if (this.FileUploadImage.HasFile)
			{
				string contentType = this.FileUploadImage.PostedFile.ContentType;
				if (contentType == "image/bmp" || contentType == "image/png" || contentType == "image/gif" || contentType == "image/pjpeg" || contentType == "image/x-png" || contentType == "image/pjpeg" || contentType == "image/jpeg")
				{
					string fileName = Operator.FilterString(this.FileUploadImage.PostedFile.FileName);
					Random random = new Random();
					string str = (10 + random.Next(70)).ToString();
					Thread.Sleep(20);
					string text = DateTime.Now.ToString("yyyyMMddHHmmss") + str;
					FileInfo fileInfo = new FileInfo(fileName);
					string str2 = text + fileInfo.Extension;
					string text2 = base.Server.MapPath("~/ImgUpload/" + str2);
					fileName2 = "~/ImgUpload/" + str2;
					if (!File.Exists(text2))
					{
						try
						{
							string a = ShopSettings.GetValue("IfSetWaterMark");
							if (this.DropDownListImageType.SelectedValue == "b0f6e545-cd10-4e83-8c96-2c1e143e4947")
							{
								a = "0";
							}
							if (a == "0")
							{
								this.FileUploadImage.SaveAs(text2);
							}
							else if (a == "1")
							{
								string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
								this.FileUploadImage.SaveAs(text3);
								string value = ShopSettings.GetValue("WaterMarkWords");
								string value2 = ShopSettings.GetValue("WordsWaterMarkPosition");
								string value3 = ShopSettings.GetValue("WaterMarkWordsFont");
								float fontSize = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
								string value4 = ShopSettings.GetValue("WaterMarkWordsColor");
								ImageOperator.CreateWater(text3, text2, value, value2, value3, fontSize, value4);
								File.Delete(text3);
							}
							else if (a == "2")
							{
								string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
								this.FileUploadImage.SaveAs(text3);
								string text4 = ShopSettings.GetValue("WaterMarkOriginalImge");
								text4 = base.Server.MapPath("~/ImgUpload/" + text4);
								string value2 = ShopSettings.GetValue("WaterMarkImagePosition");
								ImageOperator.CreateWaterPic(text3, text2, text4, value2);
								File.Delete(text3);
							}
							string str3 = "s_" + text + fileInfo.Extension;
							string text5 = base.Server.MapPath("~/ImgUpload/" + str3);
							for (int i = 0; i < this.CheckBoxListImageSpec.Items.Count; i++)
							{
								if (!this.CheckBoxListImageSpec.Items[i].Selected)
								{
									File.Copy(text2, text5);
                                    //IL_745:
									goto IL_7FE;
								}
								string[] array = this.CheckBoxListImageSpec.Items[i].Value.Split(new char[]
								{
									'*'
								});
								int width = Convert.ToInt32(array[0]);
								int height = Convert.ToInt32(array[1]);
								ImageOperator.CreateThumbnailAuto(text2, text5, width, height);
							}
                            //goto IL_745;
						}
						catch (Exception)
						{
							this.MessageShow.Visible = true;
							this.MessageShow.ShowMessage("UpdateNo1");
							goto IL_7FE;
						}
					}
					this.MessageShow.Visible = true;
					this.MessageShow.ShowMessage("UpdateNo2");
				}
				else
				{
					this.MessageShow.Visible = true;
					this.MessageShow.ShowMessage("UpdateNo3");
				}
			}
			else
			{
				ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
				DataTable dataTable = shopNum1_Image_Action.Search("'" + base.Request.QueryString["id"] + "'");
				fileName2 = dataTable.Rows[0]["ImagePath"].ToString();
			}
			IL_7FE:
			this.Update(base.Request.QueryString["id"], fileName2);
		}
	}
	protected void Add(string fileName)
	{
		ShopNum1_Image shopNum1_Image = new ShopNum1_Image();
		shopNum1_Image.Guid = Guid.NewGuid();
		shopNum1_Image.Name = this.textBoxName.Text.Trim();
		shopNum1_Image.ImageType = this.DropDownListImageType.SelectedValue;
		shopNum1_Image.ImagePath = fileName;
		shopNum1_Image.Description = this.textBoxDescription.Text.Trim();
		shopNum1_Image.UseTimes = 0;
		shopNum1_Image.CreateUser = "admin";
		shopNum1_Image.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		shopNum1_Image.ModifyUser = "admin";
		shopNum1_Image.ModifyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		shopNum1_Image.IsDeleted = 0;
		ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
		int num = shopNum1_Image_Action.Add(shopNum1_Image, this.DropDownListImgCategory2.SelectedValue);
		if (num > 0)
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("AddYes");
			this.ClearContorl();
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	protected void Update(string guid, string fileName)
	{
		ShopNum1_Image shopNum1_Image = new ShopNum1_Image();
		shopNum1_Image.Guid = new Guid(guid);
		shopNum1_Image.Name = this.textBoxName.Text.Trim();
		shopNum1_Image.ImageType = this.DropDownListImageType.SelectedValue;
		shopNum1_Image.ImagePath = fileName;
		shopNum1_Image.Description = this.textBoxDescription.Text.Trim();
		shopNum1_Image.UseTimes = 0;
		shopNum1_Image.CreateUser = "admin";
		shopNum1_Image.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		shopNum1_Image.ModifyUser = "admin";
		shopNum1_Image.ModifyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		shopNum1_Image.IsDeleted = 0;
		shopNum1_Image.ImageCategoryID = Convert.ToInt32(this.DropDownListImgCategory2.SelectedValue);
		ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
		int num = shopNum1_Image_Action.Update(shopNum1_Image);
		if (num > 0)
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("EditYes");
			this.ClearContorl();
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	protected void ClearContorl()
	{
		this.textBoxName.Text = "";
		this.textBoxDescription.Text = "";
	}
}
