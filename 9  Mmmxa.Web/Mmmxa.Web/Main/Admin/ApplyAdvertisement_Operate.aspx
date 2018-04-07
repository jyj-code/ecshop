<%@ page language="C#" autoeventwireup="true" inherits="Admin_ApplyAdvertisement_Operate"   CodeBehind="ApplyAdvertisement_Operate.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片广告</title>
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
      //选择单图
   function openLogoSingleChild()
    { 
        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if(k != null) 
        {
          var strLen=k.length;
          var lastIndex=k.lastIndexOf('/');
          document.getElementById("TextBoxpath").value ="/ImgUpload/" + k.substring(lastIndex+1,strLen);
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="审核会员申请广告"></asp:Label></h3>
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
                    <th align="right" >
                        广告链接地址：
                    </th>
                    <td>
                      <asp:Label ID="LabelHref" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                </asp:Panel>
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
                <tr id="adheight" runat="server">
                    <th align="right">
                         广告图片预览：
                    </th>
                    <td>
                        <asp:Panel ID="PanelShow2" runat="server" Visible="false">
                        <asp:Image ID="ImageAd" runat="server"  Width="300" Height="300"/>
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
                <tr id="Tr1" runat="server" style="display:none">
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
                <asp:Button ID="ButtonConfirm" runat="server" Text="审核" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <input type="button" value="返回列表" class="fanh" onclick="window.location.href='ApplyAdvertisement_List.aspx';" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCityCode" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldSubstationID" runat="server"  />
    </form>
</body>
</html>
