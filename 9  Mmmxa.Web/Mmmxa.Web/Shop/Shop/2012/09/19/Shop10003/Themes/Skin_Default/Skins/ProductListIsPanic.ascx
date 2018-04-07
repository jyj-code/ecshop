<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="bBox">
    <h2>
        抢购商品</h2>
    <div>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                    <asp:Image ID="ImageProduct" runat="server" Height="160px" ImageUrl='<%# Eval("OriginalImage") %>'
                        onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" Width="160px" /></a>
                <br />
                <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                    <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a>
                <br />
                本店价格：<font class="Price"><%# Eval("ShopPrice")%>
                </font>结束时间：<%# Eval("PanicBuyEndTime")%>
               <%-- 还剩数量:<%# ProductListIsPanic.GetCount((Eval("PanicBuyCount")), (Eval("SaledNum")))%><br />--%>
                <%--<asp:Literal ID="LiteralLastBuyInfo" runat="server" Text='<%# ProductListIsPanic.SetLastBuyTime(Eval("MemberLoginID"),Eval("LastTime"))%>'></asp:Literal>--%>
            </ItemTemplate> 
        </asp:Repeater>
    </div>
</div>
