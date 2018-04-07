<%@ page language="C#" autoeventwireup="true" inherits="Admin_PayAdvertisementImg_Operate"   CodeBehind="PayAdvertisementImg_Operate.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>付费广告操作</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />

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
      var lock=0;
    //选择单图
    function openSingleChild()
    {
        if(lock==0)
        {
        lock=1
        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if (k == undefined) {k = window.returnValue; }
        if(k != null) 
        {
            var imgvalue = new Array();
            imgvalue = k.split(",");
            document.getElementById("TextBoxDefaultImage").value = imgvalue[0];
            document.getElementById("ImageDefaultImage").src = imgvalue[1];
        }
         lock=0
        }
    }
    function test()
    {alert("fdsaf");}
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="添加付费广告位"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>


        <div class="welcon clearfix">
            <div class="inner_page_list">

             <table border="0" cellpadding="0" cellspacing="1">
             <tr>
                    <th align="right" width="150px">
                        
                            当前操作城市平台：
                       
                    </th>
                    <td valign="middle">
                      
                            <asp:TextBox ID="TextBoxSubstationIdOnline" CssClass="tinput" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox><span> （此处显示的城市平台表示管理员所操作的平台）</span>
                        
                    </td>
                </tr>
                <tr>
                    <th align="right" width="150px">
                        
                            广告位ID：
                       
                    </th>
                    <td valign="middle">
                      
                            <asp:TextBox ID="TextBoxID" CssClass="tinput" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox><span> 广告位ID</span>
                        
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        
                            广告类型：
                      
                    </th>
                    <td>
                        <asp:DropDownList ID="DropDownListAdType" runat="server">
                        <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">单图</asp:ListItem>
                        <%--<asp:ListItem Value="2">幻灯片</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            位置说明：
                    </th>
                    <td>
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span><span>如 前台首页 一楼广告1</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFileName" runat="server" Display="Dynamic"
                                ControlToValidate="TextBoxName" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                      
                    </td>
                </tr>
                <tr>
                    <th align="right" >
                       
                            默认链接地址：
                       
                    </th>
                    <td>
                      
                            <asp:TextBox ID="TextBoxHref" CssClass="tinput" runat="server" Text="http://"></asp:TextBox><span> 输入链接地址，请以http://开头。</span>
                       
                    </td>
                </tr>
                                <tr>
                    <th align="right">
                       
                            默认图片：
                      
                    </th>
                    <td>
                        
                            <asp:TextBox ID="TextBoxDefaultImage" runat="server" CssClass="tinput"></asp:TextBox>
                            <input id="Button1" type="button" value="添加图片" onclick="openSingleChild()"
                                class="selpic" style="position: relative; top: 1px; top: 0px\9; *top: -1px; _top: -1px;" />
                        
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            默认图片预览：
                      
                    </th>
                    <td>
                        <asp:Image ID="ImageDefaultImage" runat="server" Width="300" Height="200" />
                    </td>
                </tr>
                <tr style="display:none">
                    <th align="right">
                       
                            广告位置图片：
                      
                    </th>
                    <td>
                        
                            <asp:TextBox ID="TextBoxpath" runat="server" CssClass="tinput"></asp:TextBox>
                            <input id="ButtonSelectSingleImage" type="button" value="添加图片" 
                                class="selpic" style="position: relative; top: 1px; top: 0px\9; *top: -1px; _top: -1px;" />
                        
                    </td>
                </tr>
                <tr style="display:none">
                    <th align="right">
                       
                            广告位置图片预览：
                      
                    </th>
                    <td>
                        <asp:Image ID="ImageMaps" runat="server" Width="500" Height="300" />
                    </td>
                </tr>
                <tr id="adwidth" runat="server">
                    <th align="right">
                     
                            宽度：
                     
                    </th>
                    <td>
                      
                            <asp:TextBox ID="TextBoxWidth" runat="server" CssClass="tinput" Width="100" MaxLength="6"></asp:TextBox>px
                             <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RegularExpressionValidatorWidth" runat="server" ControlToValidate="TextBoxWidth"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RequiredFieldValidatorWidth" runat="server" ControlToValidate="TextBoxWidth"
                                Display="Dynamic" ErrorMessage="输入的格式不正确或者输入的宽度太大" ValidationExpression="^[0-9]{0,6}$"></asp:RegularExpressionValidator>
                     
                    </td>
                </tr>
                <tr id="adheight" runat="server">
                    <th align="right">
                        
                            高度：
                        
                    </th>
                    <td>
                      
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" runat="server" Width="100" MaxLength="6"></asp:TextBox>px
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorHeight" runat="server" Display="Dynamic"
                                ControlToValidate="TextBoxHeight" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorHeight" runat="server"
                                ControlToValidate="TextBoxHeight" Display="Dynamic" ErrorMessage="输入的格式不正确或高度太高"
                                ValidationExpression="^[0-9]{0,6}$"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                <tr id="Tr1" runat="server">
                    <th align="right">
                        
                        付费金额：
                        
                    </th>
                    <td>
                        
                            <asp:TextBox ID="TextBoxMoney" CssClass="tinput" runat="server" Width="100" MaxLength="6"></asp:TextBox>￥
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="TextBoxMoney" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <th align="right">
                        显示期限：
                    </th>
                    <td>
                            <asp:TextBox ID="TextBoxDate" CssClass="tinput" runat="server" Width="100" MaxLength="6"></asp:TextBox>天
                             <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="TextBoxDate" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <th align="right">
                        是否启用：
                    </th>
                    <td>
                        <asp:CheckBox ID="CheckBoxIsRun" runat="server"  Checked="true"/>
                    </td>
                </tr>
            </table>
                </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <input type="button" value="返回列表" class="fanh" onclick="window.location.href='PayAdvertisementImg_List.aspx';" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
