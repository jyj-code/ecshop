<%@ WebHandler Language="C#" Class="S_OpenShop" %>

using System;
using System.Web;
using System.Web;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using System.IO;
using ShopNum1MultiEntity;
using System.Text;

public class S_OpenShop : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string strFileName = string.Empty;
        HttpFileCollection _upfile = context.Request.Files;
        for (int i = 0; i < _upfile.Count; i++)
        {
            if (_upfile[i].FileName != ""&&context.Request.QueryString["type"].ToString()=="1")
            {
                context.Response.Write(fileSaveAs(_upfile[0])); break;
            }
            else if (_upfile[i].FileName != "" && context.Request.QueryString["type"].ToString() == "2")
            {
                context.Response.Write(fileSaveAs(_upfile[1])); break;
            }
        }
    }

    ///<summary>
    /// 文件上传方法
    /// </summary>
    public string fileSaveAs(HttpPostedFile _postedFile)
    {
        
        try
        {
            string fileName = _postedFile.FileName;
            string _fileExt = _postedFile.FileName.Substring(fileName.LastIndexOf(".") + 1).Trim().ToLower();
            //验证合法的文件
            string[] strArray = { "jpg", "png", "jpge", "gif" };
            if (!Common.CheckImgType(strArray, _fileExt))
            {
                return "{msg: 0, imagepath: \"不允许上传" + _fileExt + "类型的文件！\"}";
            }
            if (_postedFile.ContentLength > 1024 * 1024)
            {
                return "{msg: 0, imagepath: \"文件1M超过限制的大小啦！\"}";
            }
            if (fileName.IndexOf(' ') > -1)
            {
                fileName = fileName.Substring(fileName.LastIndexOf(' ') + 1);
            }
            else if (fileName.IndexOf('/') > -1)
            {
                fileName = fileName.Substring(fileName.LastIndexOf('/') + 1);
            }
            string uploadDir = "/ImgUpload/ShopCertification/";

            //检查是否有该路径没有就创建
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(uploadDir)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadDir));
            }
            Random r = new Random();
            string strNewFileName = System.DateTime.Now.ToString("yyyyMMddhhmmss") + r.Next(1, 9);
            string uploadPath = uploadDir + strNewFileName + fileName.Substring(fileName.LastIndexOf("."));
            //string strSmallImage = uploadDir + "s_" + strNewFileName + fileName.Substring(fileName.LastIndexOf("."));
            //string strMediumImage = uploadDir + "m_" + strNewFileName + fileName.Substring(fileName.LastIndexOf("."));
            _postedFile.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));
            //System.Drawing.Image image = System.Drawing.Image.FromStream(_postedFile.InputStream);
            //float w = image.Width;
            //float h = image.Height;
            //string fileType = Path.GetExtension(fileName).ToLower();
            //ShopNum1_Shop_Image shopNum1_Shop_Image = new ShopNum1_Shop_Image();
            //Shop_Image_Action shop_Image_Action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
            //shopNum1_Shop_Image.Name = fileName.Replace(fileType, "");
            //shopNum1_Shop_Image.ImageType = fileType;
            //shopNum1_Shop_Image.ImagePath = uploadPath;
            //shopNum1_Shop_Image.CreateUser = GetMemLoginId();
            //shopNum1_Shop_Image.ImageCategoryID = 2;
            //shopNum1_Shop_Image.ImageSize = (double)_postedFile.ContentLength;
            //shopNum1_Shop_Image.DisplaySize = w + "×" + h;
            //shop_Image_Action.Insert(shopNum1_Shop_Image);
            return "{msg: 1, imagepath: \"" + uploadPath.Replace("~/", "/") + "\"}";
        }
        catch (Exception ex)
        {
            return "{msg: 0, imagepath: \"上传过程中发生意外错误！+" + ex.Message + "\"}";
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}