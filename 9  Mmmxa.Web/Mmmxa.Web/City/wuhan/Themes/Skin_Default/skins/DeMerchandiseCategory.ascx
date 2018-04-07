<%@ Control Language="C#" %>
<div style="width: 109px; float: left; text-align: center;">
    <div class="tab4_1">
        <a href="" id="AProductCategory" runat="server"></a>
    </div>
    <asp:Repeater ID="RepeaterMerchandiseName" runat="server">
        <ItemTemplate>
            <div class="tab4_2">
                <a href="/category-33.aspx">
                    <%#Eval("") %></a></div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="tab4_2">
    </div>
    <div class="tab4_content" id="test3_0">
        <div style="float: left; width: 456px;">
            <asp:Repeater ID="RepeaterMerchandisePicture" runat="server">
                <ItemTemplate>
                    <div style="padding-bottom: 10px; padding-left: 10px; width: 94px; padding-right: 10px;
                        float: left; padding-top: 10px">
                        <div>
                            <a href="/product-355.aspx">
                                <img border="0" src="Themes/Skin_Default/Images/a20090716094125.jpg" width='87' height='87'></a></div>
                        <div>
                            <a href="/product-355.aspx">纽曼X1 M..</a></div>
                        <div class="zhi_jvhong">
                            ￥200.00</div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="float: left; text-align: left; width: 142px; padding-top: 10px;">
            <ul>
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <li><a href="/product-276.aspx">淘宝现货机型－戴尔DEL..</a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
