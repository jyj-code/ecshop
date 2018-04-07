<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_ShopCategoryAply_SearchDetail, ShopNum1.Deploy" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺申请分类查看详细</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="店铺申请分类查看详细"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>     
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeName" runat="server" Text="店铺名称："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localizereplacement" runat="server" Text="申请店铺会员："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemberLoginID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="申请前店铺分类："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldShopCategory" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="申请前店铺品牌："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldShopBrand" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="申请店铺分类："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopApplyCategory" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="申请店铺品牌："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopApplyBrand" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize6" runat="server" Text="申请时间："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxApplyTime" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="备注："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxComment" TextMode="MultiLine" Height="100px" Width="500px"
                                CssClass="tinput txtarea" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonOperate" runat="server" Text="审核通过" OnClick="ButtonOperate_Click" CssClass="fanh"></asp:Button>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonOperate1" runat="server" Text="审核未通过" CssClass="fanh" OnClick="ButtonOperate1_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="返回列表" OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
