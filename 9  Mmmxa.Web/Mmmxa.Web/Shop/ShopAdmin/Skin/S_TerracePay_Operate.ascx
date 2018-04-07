<%@ Control Language="C#" %>
<script type="text/javascript" language="javascript" src="../js/CommonJS.js"></script>
<div class="biaogenr">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
    <tr>
        <th colspan="2">
            发布平台付费广告
        </th>
    </tr>
        <tr>
        <td class="bordleft">
            广告位：
        </td>
        <td align="left">
            <asp:DropDownList ID="DropDownListArea" runat="server" AutoPostBack="true" CssClass="op_select">
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label><br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListArea"
                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
        </td>
    </tr>
    <asp:Panel ID="PanelShowMsg" runat="server" Visible="false">
    <tr>
        <td class="bordleft"></td>
        <td>
            <asp:Label ID="LabelShow" runat="server" Text=""></asp:Label>
            <asp:Label ID="LabelOrderID" runat="server" Text="" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    </asp:Panel>
    <asp:Panel ID="PanelShowAd" runat="server" Visible="true" Width="100%">
    <tr>
        <td class="bordleft">
              广告名称：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxName" runat="server" CssClass="op_text"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="值不能为空"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
              广告图片：
        </td>
        <td align="left">
            <asp:Panel ID="PanelComputer" runat="server" Visible="true">
            <asp:FileUpload ID="FileUploadImage" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
              链接地址：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxLinkAdress" runat="server" CssClass ="op_text" Text="http://"></asp:TextBox>
            (链接地址请以"http://"开头)
        </td>
    </tr>
    <tr>
        <td class="bordleft">
              功能说明：
        </td>
        <td align="left" style="  color:Silver; line-height:26px;">
             一、发布广告的图片必须对应相应的分类，如果不符合要求，平台有权撤销相关广告。
             <br />二、本广告发布到全国站的前台首页楼层。<br />三、请保证预存款充足。
             <br />四、购买成功后，预存款就已经扣除。
        </td>
    </tr>
    </asp:Panel>
    <asp:Panel ID="PanelShowMoreAd" runat="server"  Width="100%" Visible="false">
    <tr>
        <td style=" text-align:right;">
              广告名称1：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxName1" runat="server" CssClass ="input1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style=" text-align:right;">
              链接地址1：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxLinkAdress1" runat="server" CssClass ="input1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style=" text-align:right;">
              广告图片1：
        </td>
        <td align="left">
            <asp:FileUpload ID="FileUploadAD1" runat="server" />
        </td>
    </tr>
    
    
    <tr>
        <td style=" text-align:right;">
              广告名称2：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxName2" runat="server" CssClass ="input1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style=" text-align:right;">
              链接地址2：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxLinkAdress2" runat="server" CssClass ="input1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style=" text-align:right;">
              广告图片2：
        </td>
        <td align="left">
            <asp:FileUpload ID="FileUploadAD2" runat="server" />
        </td>
    </tr>
    
    
    <tr>
        <td style=" text-align:right;">
              广告名称3：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxName3" runat="server" CssClass ="input1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style=" text-align:right;">
              链接地址3：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBoxLinkAdress3" runat="server" CssClass ="input1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style=" text-align:right;">
              广告图片3：
        </td>
        <td align="left">
            <asp:FileUpload ID="FileUploadAD3" runat="server" />
        </td>
    </tr>
    
    </asp:Panel>
    <tr style=" display:none">
        <td style=" text-align:right;">
              位置图片预览：
        </td>
        <td align="left">
            <asp:Image ID="ImageMap" runat="server"  Width="710" Height="400" ImageUrl="~/ImgUpload/noImage.gif"/>
        </td>
    </tr>
    <tr>
        <td>
         &nbsp;
        </td>
        <td align="left">
            <asp:Button ID="ButtonBuy" runat="server" Text="购买" CssClass="baocbtn"/>
            <asp:Button ID="ButtonBuyGo" runat="server" Text="预定" CssClass="baocbtn" Visible="false"/>
            <input id="Reset1" type="reset" value="重置" class="baocbtn"/>
            <asp:Button ID="ButtonGoBack" runat="server" Text="返回列表" CssClass="baocbtn" CausesValidation="false" Visible="false" />
        </td>
    </tr>
</table>
</div>
<asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldADCount" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldADGuid" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldType" runat="server" Value="-1" />
<asp:HiddenField ID="HiddenFieldshowDay" runat="server" Value="0" />
