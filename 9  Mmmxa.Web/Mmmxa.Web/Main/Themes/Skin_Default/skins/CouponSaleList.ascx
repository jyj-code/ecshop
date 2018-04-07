<%@ Control Language="C#" %>
<!-- 优惠活动 -->
<div class="yhhd">
    <div class="yhhd_top">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span class="fl pol">
                    <img src="Themes/Skin_Default/Images/pic_title_left.gif" /></span> <span style="float: left; padding-left: 8px;
                        padding-top: 5px;">
                        <img src="Themes/Skin_Default/Images/title_preferential_event.gif" /></span> <span style="position: relative;
                            padding-right: 20px; float:right;">
                            <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode3" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </span><span class="fr por porku">
                            <img src="Themes/Skin_Default/Images/pic_title_right.gif" /></span>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="yhhd_detail">
        <div class="yhhd_de_left">
            <img width="375" height="103" src="Themes/Skin_Default/Images/adv001.jpg" />&nbsp;<img alt="" width="375"
                height="103" src="Themes/Skin_Default/Images/adv001.jpg" />
            <div class="yhhd_de_left_detail">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <ul>
                            <asp:Repeater ID="RepeaterData" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src="Themes/Skin_Default/Images/icon_preferential.gif" />
                                        <a href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>' target="_blank">
                                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("SaleTitle").ToString(),48,"")%>
                                        </a>
                                        <img src="Themes/Skin_Default/Images/icon_hot.gif" /></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" />
</div>
