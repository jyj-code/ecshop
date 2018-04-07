<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>

<div class="latest_shop">
    <div class="all_top">
        <div class="latest_shop1 fl" style="border:none;">
            <asp:Label ID="LabelBrandName" runat="server" Text="时尚品牌"></asp:Label></div>
        <div class="fr xsfs">
            显示方式：
            <asp:ImageButton ID="ImageButtonList" runat="server" ImageUrl='/Main/Themes/Skin_Default/images/productDisplayList.gif' />&nbsp;<asp:ImageButton
                ID="ImageButtonGrid" runat="server" ImageUrl='/Main/Themes/Skin_Default/Images/productDisplayGrid.gif' />&nbsp;<asp:ImageButton
                    ID="ImageButtontext" runat="server" ImageUrl='/Main/Themes/Skin_Default/Images/productDisplayListText.gif' />
            <label>
                <asp:DropDownList ID="DropDownListSort1" AutoPostBack="true" runat="server" Style="position: relative;
                    top: -3px; top: -7px\9; *top: -3px; _top: -2px;">
                    <asp:ListItem Value="CreateTime">按上架时间排序</asp:ListItem>
                    <asp:ListItem Value="ShopPrice">按价格排序</asp:ListItem>
                </asp:DropDownList>
            </label>
            <label>
                <asp:DropDownList ID="DropDownListSort2" AutoPostBack="true" runat="server" Style="position: relative;
                    top: -3px; top: -7px\9; *top: -3px; _top: -2px;">
                    <asp:ListItem Value="DESC">倒序</asp:ListItem>
                    <asp:ListItem Value="ASC">正序</asp:ListItem>
                </asp:DropDownList>
            </label>
        </div>
    </div>
    <div class="article_list" style="float: left; padding-right: 8px; width: 692px; overflow: hidden;">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="pro_de">
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                        <img width="150" height="150" runat="server" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                            src='<%#((DataRowView)Container.DataItem).Row["OriginalImage"] %>' /></a><br />
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                        <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),24,"") %>
                    </a>
                    <br />
                    <span class="line_throw">
                        <%# Globals.MoneySymbol%><%#((DataRowView)Container.DataItem).Row["MarketPrice"]%></span>
                    <span class="yellow">
                        <%# Globals.MoneySymbol%><%#((DataRowView)Container.DataItem).Row["ShopPrice"]%></span><br />
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                        <img src="Themes/Skin_Default/Images/Buy.gif" /></a> <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                            <img src="Themes/Skin_Default/Images/shouchang.gif" /></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="clear: both;">
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                <img width="50" style="border: 1px solid #dedede;" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                    runat="server" height="50" src='<%#((DataRowView)Container.DataItem).Row["ThumbImage"] %>' /></a>
                        </td>
                        <td>
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),20,"")%>
                            </a>
                        </td>
                        <td>
                            市场价格：<span class="line_throw"><%# Globals.MoneySymbol%><%#((DataRowView)Container.DataItem).Row["MarketPrice"]%></span>
                        </td>
                        <td>
                            本店售价： <span class="yellow">
                                <%# Globals.MoneySymbol%><%#((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
                        </td>
                        <td>
                            <div align="right">
                                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                    <img src="Themes/Skin_Default/Images/buy.png" /></a> <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                        <img src="Themes/Skin_Default/Images/coll.png" /></a></div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="clear: both;">
            <asp:Repeater ID="Repeater3" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),20,"")%>
                            </a>
                        </td>
                        <td>
                            市场价格：<span class="line_throw"><%# Globals.MoneySymbol%><%#((DataRowView)Container.DataItem).Row["MarketPrice"]%></span>
                        </td>
                        <td>
                            本店售价： <span class="yellow">
                                <%# Globals.MoneySymbol%><%#((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
                        </td>
                        <td>
                            <div align="right">
                                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                    <img src="Themes/Skin_Default/Images/buy.png" /></a> <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString().ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                        <img src="Themes/Skin_Default/Images/coll.png" /></a></div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <!-- 隔开 -->
    <div class="cle" style=" height: 8px; line-height: 8px; overflow: hidden;font-size: 8px;"></div>
    <div style="clear:both;"></div>
    <!-- 分页 -->
    <div class="page" style="margin:5px; border:0px;">
        <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
        &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
        &nbsp;<span class="fpager">转到
            <asp:Literal ID="lnkTo" runat="server" />
            页</span>
    </div>
</div>
