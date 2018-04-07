using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System.IO;
using System.Text;  
using ShopNum1.Factory;
public partial class S_OrderExpress_Operate : PageBase
{
    string guid = string.Empty;
    public string TempData;
    ShopNum1_OrderExpress_Action orderExpress = new ShopNum1_OrderExpress_Action();
    protected void Page_Load(object sender, EventArgs e)
    {
        guid = Request["guid"];
        if (!IsPostBack)
        {
            BindDrp();
            if (guid == null)
            {
                ButtonAdd.Visible = true;
                Button1Submit.Visible = false;
                paraTemppara.Attributes["value"] = "data=" + BaseData + "&copyright=shopex";
            }
            else
            {
                ButtonAdd.Visible = false;
                Button1Submit.Visible = true;
                this.BindData();
            }
        }
    }
    void BindDrp()
    {
        ShopNum1_Logistic_Action shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
        DataTable dt = shopNum1_Logistic_Action.Search(1);
        drTextBoxExpressName.DataSource = dt;
        drTextBoxExpressName.DataTextField = "Name";
        drTextBoxExpressName.DataValueField = "ValueCode";
        drTextBoxExpressName.DataBind();
    }
    protected void Button1Submit_Click(object sender, EventArgs e)
    {
        try
        {
            orderExpress.Delete(guid);
            ButtonAdd_Click(null, null);
        }
        catch (Exception e1)
        {
            MessageBox.Show("修改失败!" + e1.ToString());
        }
    }
    protected void BindData()
    {
        DataTable dataTable = orderExpress.Search(guid.Replace("'", ""));
        if (dataTable != null)
        {
            drTextBoxExpressName.SelectedValue = dataTable.Rows[0]["LogisticsID"].ToString();
            RadioButton1.Checked = dataTable.Rows[0]["IsDefault"].ToString() == "1";
            RadioButton2.Checked = !RadioButton1.Checked;
            hTempData.Value = dataTable.Rows[0]["hidden"].ToString();
            ViewState["imgsrc"] = dataTable.Rows[0]["imgPath"].ToString();
            paraTemppara.Attributes["value"] = "data=" + hTempData.Value + "&bg=" + dataTable.Rows[0]["imgPath"].ToString() + "&copyright=shopex";
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string imgPath = string.Empty;
            int IsDefault = 0;
            if (RadioButton1.Checked)
            {
                IsDefault = 1;
            }
            if (ViewState["imgsrc"] != null)
                imgPath = ViewState["imgsrc"] as string;
            orderExpress.Add(Guid.NewGuid().ToString(), this.drTextBoxExpressName.SelectedItem.Text, IsDefault, hTempData.Value, imgPath, drTextBoxExpressName.SelectedItem.Value);
            Response.Redirect("S_OrderExpress_List.aspx");
        }
        catch (Exception e1)
        {
            MessageBox.Show("保存失败!" + e1.ToString());
        }
    }
    protected void ButtonChangeBg_Click(object sender, EventArgs e)
    {
        if (FileUploadImage.FileName != "")
        {
            try
            {
                string type = Path.GetExtension(FileUploadImage.FileName.ToString());
                string ImagePath = "images/Pic" + Guid.NewGuid().ToString().Substring(0, 4) + type;
                if (type == ".jpg" || type == ".bmp" || type == ".gif" || type == ".jpeg" || type == ".png")
                {
                    if (File.Exists(Server.MapPath("images/" + FileUploadImage.FileName)))
                    {
                        File.Delete(Server.MapPath("images/" + FileUploadImage.FileName));
                    }
                    FileUploadImage.PostedFile.SaveAs(Server.MapPath(ImagePath));
                    ViewState["imgsrc"] = ImagePath;
                }
                else
                {
                    MessageBox.Show("请选择图片文件！");
                }
                string tempData = paraTemppara.Attributes["value"].Contains("&bg=") ? paraTemppara.Attributes["value"].Substring(0, paraTemppara.Attributes["value"].IndexOf("&bg")) : paraTemppara.Attributes["value"];
                paraTemppara.Attributes["value"] = tempData + "&bg=" + ImagePath + "&copyright=shopex";
            }
            catch
            {
                MessageBox.Show("图片上传错误!");
            }
        }
    }
    #region 基础数据
    public string BaseData = @"<printer picposition=""0:0""></printer>";
    #endregion
}
