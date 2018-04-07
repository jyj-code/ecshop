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
using ShopNum1.Localization;

public partial class MessageShowTb : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    public void ShowMessage(string cmd)
    {
        switch (cmd)
        {
            case "AddYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //添加成功
                 this.LabelShow.Text=LocalizationUtil.GegMessageShow("AddYes");
                
                break;
            case "AddNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //添加失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("AddNo");
                break;
            case "DelYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //删除成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("DelYes");
                break;
            case "DelNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //删除失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("DelNo");
                break;
            case "DelProductCategoryNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //删除失败
                this.LabelShow.Text = "此分类中含有相关商品,不能删除此分类!";
                break;
            case "DelImageCategoryNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //删除失败
                this.LabelShow.Text = "此分类中含有相关图片,不能删除此分类!";
                break;
            case "EditYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //编辑成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("EditYes");
                break;
            case "EditNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //编辑失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("EditNo");
                break;
            case "EditError":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //编辑失败
                this.LabelShow.Text = "父节点错误！";//LocalizationUtil.GegMessageShow("EditNo");
                break;
            case "UpdateYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //编辑成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("UpdateYes");
                break;
            case "UpdateNo1":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //文件上传失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("UpdateNo1");
                break;
            case "UpdateNo2":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //文件件已经存在提示
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("UpdateNo2");
                break;
            case "UpdateNo3":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //文件类型不符提示
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("UpdateNo3");
                break;
            case "OperateYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //操作成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("OperateYes");
                break;
            case "OperateNo":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //操作成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("OperateNo");
                break;
            case "Audit1Yes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //操作成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("Audit1Yes");
                break;
            case "Audit1No":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //操作成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("Audit1No");
                break;
            case "Audit2Yes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //操作成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("Audit2Yes");
                break;
            case "Audit2No":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //操作成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("Audit2No");
                break;
            case "RemoveCartYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //将商品移除购物车成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("RemoveCartYes");
                break;
            case "RemoveCartNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //将商品移除购物车失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("RemoveCartNo");
                break;
            case "UpdateCartYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //更新购物车成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("UpdateCartYes");
                break;
            case "UpdateCartNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //更新购物车失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("UpdateCartNo");
                break;
            case "EmailState1Success":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //同意订阅成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("EmailState1Success");
                break;
            case "EmailState1Fail":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //同意订阅失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("EmailState1Fail");
                break;
            case "EmailState2Success":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //拒绝订阅成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("EmailState2Success");
                break;
            case "EmailState2Fail":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //拒绝订阅失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("EmailState2Fail");
                break;
            case "SendYes":
                this.ImageShow.ImageUrl = "../images/success.gif";
                //拒绝订阅成功
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("SendYes");
                break;
            case "SendNo":
                this.ImageShow.ImageUrl = "../images/fail.gif";
                //拒绝订阅失败
                this.LabelShow.Text = LocalizationUtil.GegMessageShow("SendNo");
                break;
            default:
                break;
        }
    }

}
