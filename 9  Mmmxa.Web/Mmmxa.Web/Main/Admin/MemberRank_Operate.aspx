<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_MemberRank_Operate"   CodeBehind="MemberRank_Operate.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增会员等级</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

    <script type="text/javascript">
        var has_showModalDialog = !!window.showModalDialog;//定义一个全局变量判定是否有原生showModalDialog方法  
        if (!has_showModalDialog && !!(window.opener)) {
            window.onbeforeunload = function () {
                window.opener.hasOpenWindow = false;        //弹窗关闭时告诉opener：它子窗口已经关闭  
            }
        }
        //定义window.showModalDialog如果它不存在  
        if (window.showModalDialog == undefined) {
            window.showModalDialog = function (url, mixedVar, features) {
                if (window.hasOpenWindow) {
                    alert("您已经打开了一个窗口！请先处理它");//避免多次点击会弹出多个窗口  
                    window.myNewWindow.focus();
                }
                window.hasOpenWindow = true;
                if (mixedVar) var mixedVar = mixedVar;
                //因window.showmodaldialog 与 window.open 参数不一样，所以封装的时候用正则去格式化一下参数  
                if (features) var features = features.replace(/(dialog)|(px)/ig, "").replace(/;/g, ',').replace(/\:/g, "=");
                //window.open("Sample.htm",null,"height=200,width=400,status=yes,toolbar=no,menubar=no");  
                //window.showModalDialog("modal.htm",obj,"dialogWidth=200px;dialogHeight=100px");   
                var left = (window.screen.width - parseInt(features.match(/width[\s]*=[\s]*([\d]+)/i)[1])) / 2;
                var top = (window.screen.height - parseInt(features.match(/height[\s]*=[\s]*([\d]+)/i)[1])) / 2;
                window.myNewWindow = window.open(url, "_blank", features);
            }
        }
       //选择单图
   function openLogoSingleChild()
    { 
        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if (k == undefined) {k = window.returnValue; }
        if(k != null) 
        {
           var imgvalue = new Array();
            imgvalue = k.split(",");
          document.getElementById("TextBoxpath").value = imgvalue[0];
          document.getElementById("ImageOriginalImge").src=imgvalue[1];
        }
    } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增会员等级"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="会员等级名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="会员等级名称最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMinScore" runat="server" Text="最小积分满足点："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMinScore" MaxLength="9" CssClass="tinput" ReadOnly="false"
                                runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMinScore"
                                runat="server" ControlToValidate="TextBoxMinScore" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMinScore" runat="server"
                                ControlToValidate="TextBoxMinScore" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxScore" runat="server" Text="最大积分满足点："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxScore" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxMaxScore"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMaxScore" runat="server"
                                ControlToValidate="TextBoxMaxScore" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareDataTime" runat="server" ControlToValidate="TextBoxMinScore"
                                Display="Dynamic" ErrorMessage="最大积分满足点不能小于最小积分满足点" Operator="LessThan" Type="Double"
                                ControlToCompare="TextBoxMaxScore"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPic" runat="server" Text="等级图片："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxpath" CssClass="tinput" runat="server"></asp:TextBox>
                            <input id="ButtonSelectSingleImage" runat="server" type="button" value="插入图片" onclick="openLogoSingleChild()"
                                class="selpic" style="position: relative; top: 1px; top: 0px\9; *top: -1px; _top: -1px;" />
                                 <img runat="server" src="/ImgUpload/2011090809095523x.png" id="ImageOriginalImge" onerror="javascript:this,src='/ImgUpload/noImage.gif'"/>友情提示：图片高度控制在20px内
                        </td>
                    </tr>
                    <tr style=" display:none">
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="是否默认："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsDefault" runat="server" /><span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMemo" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemo" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/MemberRank_List.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
