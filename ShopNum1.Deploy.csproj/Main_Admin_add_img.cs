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
public class Main_Admin_add_img : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	protected MessageShow MessageShow;
	protected Label Label5;
	protected DropDownList DropDownListImageType;
	protected Label Label9;
	protected Label Label3;
	protected TextBox textBoxName;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected Label Label6;
	protected DropDownList DropDownListImgCategory2;
	protected Label Label10;
	protected RequiredFieldValidator RequiredFieldValidatorDropDownListImgCategory2;
	protected Label Label8;
	protected FileUpload FileUploadImage;
	protected RequiredFieldValidator RequiredFieldValidatorImage;
	protected Label Label11;
	protected TextBox textBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorTitle3;
	protected Label LabelSpec;
	protected CheckBoxList CheckBoxListImageSpec;
	protected Button btnConfirm;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	public string ImageSpec
	{
		get;
		set;
	}
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
			this.BindImageCategory();
			this.BindImageType();
			this.BindCheckBoxListImageSpec("Product");
		}
	}
	protected void DropDownListImageType_SelectedIndexChanged(object sender, EventArgs e)
	{
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
				if (dataRow["name"].ToString().Trim() == "Product")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "Brand")
			{
				if (dataRow["name"].ToString().Trim() == "Brand")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "GuidBuy")
			{
				if (dataRow["name"].ToString().Trim() == "GuidBuy")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "Pack")
			{
				if (dataRow["name"].ToString().Trim() == "Pack")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "BlessCard")
			{
				if (dataRow["name"].ToString().Trim() == "BlessCard")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "Logo")
			{
				if (dataRow["name"].ToString().Trim() == "Logo")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "Article")
			{
				if (dataRow["name"].ToString().Trim() == "Article")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "Control")
			{
				if (dataRow["name"].ToString().Trim() == "Control")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if (strType == "Video")
			{
				if (dataRow["name"].ToString().Trim() == "Video")
				{
					listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
					this.CheckBoxListImageSpec.Items.Add(listItem);
				}
			}
			else if ((strType == "Advertisement" || strType == "Icon") && (dataRow["name"].ToString().Trim() == "Icon" || dataRow["name"].ToString().Trim() == "Advertisement"))
			{
				this.CheckBoxListImageSpec.Visible = false;
				break;
			}
		}
		if (this.CheckBoxListImageSpec.Items.Count > 0)
		{
			this.CheckBoxListImageSpec.Items[0].Selected = true;
		}
	}
	protected void butExit_Click(object sender, EventArgs e)
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
						string value = ShopSettings.GetValue("IfSetWaterMark");
						if (value == "0")
						{
							this.FileUploadImage.SaveAs(text2);
						}
						else if (value == "1")
						{
							string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
							this.FileUploadImage.SaveAs(text3);
							string value2 = ShopSettings.GetValue("WaterMarkWords");
							string value3 = ShopSettings.GetValue("WordsWaterMarkPosition");
							string value4 = ShopSettings.GetValue("WaterMarkWordsFont");
							float fontSize = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
							string value5 = ShopSettings.GetValue("WaterMarkWordsColor");
							ImageOperator.CreateWater(text3, text2, value2, value3, value4, fontSize, value5);
							File.Delete(text3);
						}
						else if (value == "2")
						{
							string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
							this.FileUploadImage.SaveAs(text3);
							string text4 = ShopSettings.GetValue("WaterMarkOriginalImge");
							text4 = base.Server.MapPath("~/ImgUpload/" + text4);
							string value3 = ShopSettings.GetValue("WaterMarkImagePosition");
							ImageOperator.CreateWaterPic(text3, text2, text4, value3);
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
								IL_331:
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
                        //goto IL_331;
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
	protected void btnConfirm_Click(object sender, EventArgs e)
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
						string value = ShopSettings.GetValue("IfSetWaterMark");
						if (value == "0")
						{
							this.FileUploadImage.SaveAs(text2);
						}
						else if (value == "1")
						{
							string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
							this.FileUploadImage.SaveAs(text3);
							string value2 = ShopSettings.GetValue("WaterMarkWords");
							string value3 = ShopSettings.GetValue("WordsWaterMarkPosition");
							string value4 = ShopSettings.GetValue("WaterMarkWordsFont");
							float fontSize = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
							string value5 = ShopSettings.GetValue("WaterMarkWordsColor");
							ImageOperator.CreateWater(text3, text2, value2, value3, value4, fontSize, value5);
							File.Delete(text3);
						}
						else if (value == "2")
						{
							string text3 = base.Server.MapPath("~/ImgUpload/O_" + str2);
							this.FileUploadImage.SaveAs(text3);
							string text4 = ShopSettings.GetValue("WaterMarkOriginalImge");
							text4 = base.Server.MapPath("~/ImgUpload/" + text4);
							string value3 = ShopSettings.GetValue("WaterMarkImagePosition");
							ImageOperator.CreateWaterPic(text3, text2, text4, value3);
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
								IL_331:
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
                        //goto IL_331;
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
			this.Page.RegisterStartupScript("name", "<script>alert('添加成功');window.parent.location.reload();</script>");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	protected void BindImageType()
	{
		this.DropDownListImageType.Items.Clear();
		this.DropDownListImageType.Items.Add(new ListItem("商品图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4941"));
		this.DropDownListImageType.Items.Add(new ListItem("品牌图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4942"));
		this.DropDownListImageType.Items.Add(new ListItem("导购图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4943"));
		this.DropDownListImageType.Items.Add(new ListItem("包装图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4944"));
		this.DropDownListImageType.Items.Add(new ListItem("贺卡图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4945"));
		this.DropDownListImageType.Items.Add(new ListItem("Logo图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4947"));
		this.DropDownListImageType.Items.Add(new ListItem("资讯图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4948"));
		this.DropDownListImageType.Items.Add(new ListItem("控件图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4950"));
		this.DropDownListImageType.Items.Add(new ListItem("视频图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4951"));
	}
	protected void BindImageCategory()
	{
		this.DropDownListImgCategory2.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "选择分类";
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
				this.method_5(dataTable);
			}
		}
	}
	private void method_5(DataTable dt)
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
				this.method_5(dataTable);
			}
		}
	}
}
