<%@ Control Language="C#" %>
<!-- 电子优惠券 -->

<script language="javascript" type="text/javascript">
    function Ispost() {
            var value = document.getElementById("<%= TextBoxPageNum.ClientID %>").value;
            if(!isNaN(value)) {
                var index = document.getElementById("<%= LabelPageIndex.ClientID %>").innerHTML;
                var count = document.getElementById("<%= LabelPageCount.ClientID %>").innerHTML;
                if(value != index && parseInt(value) <= parseInt(count) && parseInt(value) > 0) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
</script>

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <div class="elec_cou">
            <div class="yhhd_top">
                <span class="fl pol">
                    <img src="Themes/Skin_Default/Images/pic_title_left.gif" /></span> <span style="float: left;
                        padding-left: 8px; padding-top: 5px;">
                        <img src="Themes/Skin_Default/Images/title_ecoupon.gif" /></span> <span style="position: relative;
                            padding-right: 20px; float:right; padding-top:2px;">
                            <asp:DropDownList ID="DropDownListCouponCategory" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </span><span class="fr por">
                            <img src="Themes/Skin_Default/Images/pic_title_right.gif" /></span>
            </div>
            <div class="elec_cou_detail">
                <asp:Repeater ID="RepeaterData" runat="server">
                    <ItemTemplate>
                        <div class="fl ecd_img">
                            <a href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>'
                                target="_blank">
                                <img id="imgCoupon" width="220" height="122" style="border: 1px solid #ccc;" runat="server"
                                    src="" /></a><br />
                            <a href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>'
                                target="_blank">
                                <asp:Literal ID="Literal1" Text='<%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("CouponName").ToString(),30,"...")%>'
                                    runat="server"></asp:Literal></a><br />
                            <img class="yd_top" src="Themes/Skin_Default/Images/icon_coupon.gif" />
                            人气：<%# Eval("BrowserCount")%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="width: 100%; height: 1px; overflow: hidden; clear: both;">
                </div>
                <!--分页-->
                <div class="page">
                    <asp:LinkButton ID="LinkButtonFirst" runat="server">首页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonLast" runat="server">上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNext" runat="server">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonEnd" runat="server">尾页</asp:LinkButton>
                    <asp:Label ID="LabelPageIndex" runat="server" Text="1"></asp:Label>/
                    <asp:Label ID="LabelPageCount" runat="server" Text="0"></asp:Label>
                    <asp:TextBox ID="TextBoxPageNum" runat="server" onfocus="this.select();" Height="15px"
                        Width="30px"></asp:TextBox>
                    <asp:Button ID="ButtonGo" runat="server" Text="Go" OnClientClick="return Ispost()" />
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
