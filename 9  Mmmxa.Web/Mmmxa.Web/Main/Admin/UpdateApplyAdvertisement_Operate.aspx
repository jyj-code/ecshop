<%@ page language="C#" autoeventwireup="true" inherits="Admin_UpdateApplyAdvertisement_Operate"   CodeBehind="UpdateApplyAdvertisement_Operate.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片广告</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

    <script type="text/javascript">
    function openSingleChild()
    {
        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if (k == undefined) {k = window.returnValue; }
        if(k != null) 
        {
            var imgvalue = new Array();
            imgvalue = k.split(",");
            document.getElementById("TextBoxNewImage").value = imgvalue[0];
            document.getElementById("ImageOriginalImge").src = imgvalue[1];
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="启用撤销广告"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>


        <div class="welcon clearfix">
            <div class="inner_page_list">

             <table border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <th align="right" width="150px">
                        
                            会员：
                       
                    </th>
                    <td valign="middle">
                        <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                            广告位：
                    </th>
                    <td>
                        <asp:Label ID="LabelAdId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <asp:Panel ID="PanelShow1" runat="server" Visible="false">
                <tr>
                    <th align="right">
                            广告名称：
                    </th>
                    <td>
                        <asp:Label ID="LabelRemarks" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                            剩余显示时间：
                    </th>
                    <td>
                        <asp:Label ID="LabelResidueDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right" >
                        广告链接地址：
                    </th>
                    <td>
                      <asp:Label ID="LabelHref" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="TextBoxHref" runat="server" Width="300"></asp:TextBox><span>(此处可更改)</span>
                    </td>
                </tr>
                </asp:Panel>
                <tr id="adheight" runat="server">
                    <th align="right">
                         广告图片预览：
                    </th>
                    <td>
                        <asp:Panel ID="PanelShow2" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="1">
                            <tr>
                                <td>旧图预览</td><td>新图预览</td>
                            </tr>
                            <tr>
                                <td><asp:Image ID="ImageAd" runat="server"  Width="300" Height="300"/></td>
                                <td><img id="ImageOriginalImge" alt="" height="300" width="300" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="TextBoxNewImage" runat="server" CssClass="tinput"></asp:TextBox>
                                    <input id="ButtonSelectSingleImage" class="selpic" type="button" value="选择图片" onclick="openSingleChild()" /><asp:RegularExpressionValidator
                                ID="RegularExpressionValidatorLogo" runat="server" ControlToValidate="TextBoxNewImage"
                                Display="Dynamic" ErrorMessage="新图最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            
                                </td>
                            </tr>
                        </table>
                       
                        </asp:Panel>
                        <asp:Panel ID="PanelShow3" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelName1" runat="server" Text="Label"></asp:Label></td>
                                <td>
                                    <asp:Label ID="LabelName2" runat="server" Text="Label"></asp:Label></td>
                                <td>
                                    <asp:Label ID="LabelName3" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                    <td>
                                    <asp:Image ID="ImageAd1" runat="server" />
                                    </td>
                                    <td>
                                    <asp:Image ID="ImageAd2" runat="server" />
                                    </td>
                                    <td>
                                    <asp:Image ID="ImageAd3" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelWeb1" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="LabelWeb2" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="LabelWeb3" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                        付费金额：
                    </th>
                    <td>
                        <asp:Label ID="LabelMoney" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <th align="right">
                        申请日期：
                    </th>
                    <td>
                        <asp:Label ID="LabelCreateTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        审核状态：
                    </th>
                    <td>
                        <asp:Label ID="LabelIsExamine" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        申请状态：
                    </th>
                    <td>
                        <asp:Label ID="LabelApplyState" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        是否撤销：
                    </th>
                    <td>
                         <asp:Label ID="LabelIsCancel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="adwidth" runat="server">
                    <th align="right">
                        开始日期：
                    </th>
                    <td>
                      <asp:Label ID="LabelBeginDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <th align="right">
                        结束日期：
                    </th>
                    <td>
                      <asp:Label ID="LabelEndDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="Tr1" runat="server" style=" display:none;">
                    <th align="right">
                        
                        广告位位置图片：
                        
                    </th>
                    <td>
                        <asp:Image ID="ImageMap" runat="server"  Width="300" Height="300"/>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <th align="right">
                        显示期限：
                    </th>
                    <td>
                        <asp:Label ID="LabelShowDay" runat="server" Text=""></asp:Label>天
                    </td>
                </tr>
            </table>
                </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="启用" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <input type="button" value="返回列表" class="fanh" onclick="window.location.href='ApplyAdvertisement_List.aspx';" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCityCode" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldSubstationID" runat="server"  />
    <asp:HiddenField ID="HiddenFieldImage" runat="server"  />
    </form>
</body>
</html>
