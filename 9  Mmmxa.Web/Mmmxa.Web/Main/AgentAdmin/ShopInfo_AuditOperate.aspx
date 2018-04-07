<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_ShopInfo_AuditOperate, ShopNum1.Deploy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="GroupFly" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺审核操作</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />

    <script type='text/javascript' src='js/resolution-test.js'></script>

    <script src="js/tanchuDIV2.js" type="text/javascript"></script>

    <script src="js/dragbox/Shopnum1.Dialog.min.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="js/dragbox/Shopnum1.DragBox.min.css" />

    <script src="js/CommonJS.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function funCheck()
        {
            var leg=$("#CheckGuid").val().indexOf(",");
            
            if($("#CheckGuid").val()!="0" && leg==-1)
            {
          
                ECF.dialog.open('ShopAuditFailedReason.aspx?width=700&height=400&guid='+$("#CheckGuid").val(),{width:700,height:400,title:"店铺审核失败"});
                
                return false;
            }
            else
            {
                alert("每次只能选中一项！");
            }
            return false;
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
                    <span id="Span1">
                        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="店铺详细"></asp:Label></span></h3>
            </div>
            <div class="rr">   
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="1" border="0">
                    <tr>
                        <th align="right">
                            店主名称：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxName" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            店铺名称：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopName" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            店铺类别：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopType" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            店铺分类：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopCategory" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            主营商品：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxMainGoods" ReadOnly="true" CssClass="allinput3 tinput" runat="server"
                                TextMode="MultiLine" Width="300" Height="60"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right" width="20%">
                            销售范围：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxSalesRange" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
            <th align="right">
                电子邮件：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxEmail" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <tr>
                        <th align="right">
                            座机号码：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxTel" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            手机号码：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPhone" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            邮政编码：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPostalCode" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            身份证编号：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxIdentityCard" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
            <th align="right">
                注册号：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxRegistrationNum" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                企业名称：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxCompanName" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                法人代表：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxLegalPerson" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                注册资本：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxRegisteredCapital" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>

万元
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                营业期限：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxBusinessTerm" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                营业范围：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxBusinessScope" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <tr style="display: none">
                        <th align="right">
                            联系地址：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddress" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            所在地区：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddressValue" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            详细地址：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddressDeteil" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            身份证（正反）：
                        </th>
                        <td align="left">
                            <a runat="server" target="_blank" id="aCardImage1">
                                <asp:Image ID="ImageCardImage1" runat="server" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                    Height="187px" Width="191px" class="fanh" /></a>
                        </td>
                    </tr>
                    <%--<tr>
            <th align="right">
                证件图片（反）：
            </th>
            <td align="left">
                <a runat="server" target="_blank" id="aCardImage2">
                    <asp:Image ID="ImageCardImage2" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                        runat="server" Height="178px" Width="190px" /></a>
            </td>
        </tr>--%>
                    <asp:Panel ID="PanelShowBusinessLicense" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                营业执照：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aBusinessLicense">
                                    <asp:Image ID="ImageBusinessLicense" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
                <div class="tablebtn">
                    <asp:Button ID="ButtonOperate" runat="server" Text="审核通过" CssClass="fanh" OnClick="ButtonOperate_Click" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonOperate1" runat="server" Text="审核未通过" CssClass="fanh" OnClientClick="return funCheck()" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonBank" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonBank_Click" />&nbsp;
                    <asp:Label runat="server" ID="lbTest"></asp:Label>
                    <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
