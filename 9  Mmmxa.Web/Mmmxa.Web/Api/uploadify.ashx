﻿<%@ WebHandler Language="C#" Class="uploadify" %>

using System;
using System.Web;
using System.IO;
using ShopNum1MultiEntity;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using System.Security;
using System.Data;

public class uploadify : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
        context.Response.Expires = 0;
        context.Response.CacheControl = "no-cache";
        context.Request.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        context.Response.Charset = "UTF-8";
        try
        {
            if (Common.ReqStr("albumid") != "")
            {
                ShopNum1_Shop_Image shopNum1_Shop_Image = new ShopNum1_Shop_Image();
                //获取上传的文件数据
                HttpPostedFile file = context.Request.Files["Filedata"];

                System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream);//从上传文件流中实例化Image类 
                float w = image.Width;//获取上传文件的水平分辨率（以“像素/英寸”为单位）。 
                float h = image.Height;//获取上传文件的垂直分辨率（以“像素/英寸”为单位）。 

                string fileName = file.FileName;
                string fileType = Path.GetExtension(fileName).ToLower();
                string[] strArray = { ".jpg", ".png", ".jpeg", ".gif", ".bmp" };
                if (!Common.CheckImgType(strArray, fileType))
                {
                    context.Response.Write("不支持格式！"); return;
                }
                if (file.ContentLength > 1024 * 1024)
                {
                    context.Response.Write("error"); return;
                }
                //由于不同浏览器取出的FileName不同（有的是文件绝对路径，有的是只有文件名），故要进行处理
                if (fileName.IndexOf(' ') > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf(' ') + 1);
                }
                else if (fileName.IndexOf('/') > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf('/') + 1);
                }
                //上传的目录
                string strM = GetMemLoginId();
                string strMemloginId = Encryption.Decrypt(Common.ReqStr("albumid").Split('-')[0]);
                string strShopId = Common.GetNameById("ShopId", "shopnum1_shopinfo", " and memloginid='" + strMemloginId + "'");
                string strOpenTime = Common.GetNameById("OpenTime", "shopnum1_shopinfo", " and memloginid='" + strMemloginId + "'");
                string uploadDir = "/ImgUpload/shopImage/" + Convert.ToDateTime(strOpenTime).ToString("yyyy") + "/shop" + strShopId + "/";
                //上传的路径
                //生成年月文件夹及日文件夹
                if (Directory.Exists(context.Server.MapPath(uploadDir)) == false)
                {
                    Directory.CreateDirectory(context.Server.MapPath(uploadDir));
                }
                Random r = new Random();
                string strNewFileName = System.DateTime.Now.ToString("yyyyMMddhhmmss") + r.Next(1, 9);
                string strFileName = strNewFileName + fileType;
                string uploadPath = uploadDir + strNewFileName + fileType;
                //保存文件
                try
                {
                    if (strShopId != "")
                    {
                        string shopid = strShopId;
                        string openTime = DateTime.Parse(strOpenTime).ToString("yyyy-MM-dd");
                        System.Web.UI.WebControls.XmlDataSource XmlDataSourceData = new System.Web.UI.WebControls.XmlDataSource();
                        string imageSpec = "/Shop/Shop/" + openTime.Replace("-", "/") + "/shop" + shopid + "/Site_Settings.xml";
                        DataSet ds = new DataSet();
                        ds.ReadXml(HttpContext.Current.Server.MapPath(imageSpec));
                        DataRow dr = ds.Tables["Setting"].Rows[0];
                        string strCheck = dr["IfSetWaterMark"].ToString();
                        if (strCheck == "0")
                        {
                            file.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));
                        }
                        else if (strCheck == "1")           //生成文字水印
                        {
                            string o_webFilePath = HttpContext.Current.Server.MapPath(uploadDir + "txt_" + strFileName);
                            file.SaveAs(o_webFilePath);
                            //水印文字
                            string addText = dr["WaterMarkWords"].ToString();
                            //水印位置
                            int position = 5;
                            try
                            {
                                position = Convert.ToInt32(dr["WordsWaterMarkPosition"].ToString());
                            }
                            catch { }
                            //水印透明度
                            int FontMarkClarity = Convert.ToInt32(dr["ImageWaterMarkClarity"].ToString());
                            //字体
                            string fontType = dr["WaterMarkWordsFont"].ToString();
                            //字大小
                            float fontSize = Convert.ToSingle(dr["WaterMarkWordsFontSize"].ToString());
                            //字的颜色
                            string fontColor = dr["WaterMarkWordsColor"].ToString();
                            ImageOperator.AddImageSignText(o_webFilePath, addText, position, fontColor, fontType, fontSize, FontMarkClarity);
                            uploadPath = uploadDir + "txt_" + strFileName;
                        }
                        else if (strCheck == "2")           //生成图片水印
                        {
                            //添加图片水印
                            string o_webFilePath = HttpContext.Current.Server.MapPath(uploadDir + "/img_" + strFileName);
                            file.SaveAs(o_webFilePath);
                            //从ShopSettings.xml中读水印的图片地址
                            //水印图片地址
                            string waterSourcePath = dr["WaterMarkOriginalImge"].ToString();
                            waterSourcePath = HttpContext.Current.Server.MapPath(waterSourcePath); //水印的物理路径
                            //水印位置
                            int position = 5;
                            //水印透明度
                            int FontMarkClarity = Convert.ToInt32(dr["ImageWaterMarkClarity"].ToString());
                            try
                            {
                                position = Convert.ToInt32(dr["WaterMarkImagePosition"].ToString());
                            }
                            catch { }
                            ImageOperator.AddImageSignPic(o_webFilePath, waterSourcePath, position, 100, FontMarkClarity);
                            uploadPath = uploadDir + "/img_" + strFileName;
                        }
                    }
                }
                catch { file.SaveAs(HttpContext.Current.Server.MapPath(uploadPath)); }

                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                Shop_Image_Action shop_Image_Action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
                shopNum1_Shop_Image.Name = fileName.Replace(fileType, "");
                shopNum1_Shop_Image.ImageType = fileType;
                shopNum1_Shop_Image.ImagePath = uploadPath;
                shopNum1_Shop_Image.CreateUser = strMemloginId;
                string strId =HttpUtility.HtmlDecode(Common.ReqStr("albumid"));
                shopNum1_Shop_Image.ImageCategoryID = Convert.ToInt32(Common.ReqStr("albumid").Split('-')[1]);
                shopNum1_Shop_Image.ImageSize = (double)file.ContentLength;
                shopNum1_Shop_Image.DisplaySize = w + "×" + h;
                shop_Image_Action.Insert(shopNum1_Shop_Image);
                
                string strImg25 = uploadPath + "_25x25.jpg";
                string strImg60 = uploadPath + "_60x60.jpg";
                string strImg100 = uploadPath + "_100x100.jpg";
                string strImg160 = uploadPath + "_160x160.jpg";
                string strImg300 = uploadPath + "_300x300.jpg";
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath), HttpContext.Current.Server.MapPath(strImg25), 25, 25); // 25x25(规格小图专用)  商品上传单独处理
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath), HttpContext.Current.Server.MapPath(strImg60), 60, 60); //60x60    商品详细小图用
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath), HttpContext.Current.Server.MapPath(strImg100), 100, 100); //100x100(手机用)
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath), HttpContext.Current.Server.MapPath(strImg160), 160, 160); //商品列表
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath), HttpContext.Current.Server.MapPath(strImg300), 300, 300); //商品详细
                context.Response.Write(Common.ReqStr("albumid")); System.Threading.Thread.Sleep(500);
            }
        }
        catch(Exception ex)
        {
            context.Response.Write("0|" + Common.ReqStr("albumid"));
        }
    }
    //获取登录用户方法
    private string GetMemLoginId()
    {
        string name = "jely";
        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
            name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"].ToString();
        }
        return name;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}