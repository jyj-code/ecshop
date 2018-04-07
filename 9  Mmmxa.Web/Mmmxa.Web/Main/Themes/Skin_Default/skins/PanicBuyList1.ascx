﻿<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data " %>
<div class="panic_se">
    <div class="panic_se_left_top">
        <div class="psl_left">美容、珠宝专场</div>
        <div class="psl_right">
            共<b class="totle"><asp:Label ID="LabelCount" runat="server"></asp:Label></b>个商品 
            <b>
                <span style="color: #ff6400;"><asp:Label ID="LabelIndex" runat="server"></asp:Label></span>/
                <asp:Label ID="LabelPageCount" runat="server"></asp:Label>
            </b>
            <asp:LinkButton ID="LinkButtonLast" runat="server" class="page_up_true">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNext" runat="server" class="page_down_true">下一页</asp:LinkButton>
        </div>
    </div>
    <div class="panic_cont">
        <div class="panic_se_right">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage16" runat="server" AdImgId="16" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <div class="panic_se_left">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <div class="psld_de">
                        <div class="panic_img">
                            <a href='<%#ShopUrlOperate.shopDetailHrefByShopIDNew(Eval("Guid").ToString(),Eval("ShopID").ToString(),"ProductIsPanic_Detail") %>'
                            target="_blank">
                            <img alt="" src='<%# Page.ResolveUrl(Eval("ThumbImage").ToString())+"_160x160.jpg" %>'
                                onerror="javascript:this.src='../ImgUpload/noimg.jpg_160x160.jpg'" /></a>
                        </div>                        
                        <div class="panic_name">
                            <a href='<%#ShopUrlOperate.shopDetailHrefByShopIDNew(Eval("Guid").ToString(),Eval("ShopID").ToString(),"ProductIsPanic_Detail") %>'
                                target="_blank">
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),19,"") %></a>
                        </div>
                       <%-- <div class="panic_time" id='<%# "PanicBuy" + (PanicBuyList.i).ToString() %>'>
                            剩余时间：<span class="time"><script>show_date_time(('<%# PanicBuyList.IsBegin(Eval("PanicStartTime"),Eval("PanicBuyEndTime")).Replace("-","/") %>'),'<%# "PanicBuy" + (PanicBuyList.i++).ToString() %>')</script></span>
                        </div>--%>
                        <div class="panic_price">
                          <span class="fl">抢购价：<span class="qgjia">￥<%#Eval("ShopPrice")%></span></span><del>￥<%#Eval("MarketPrice")%></del>
                            <a href='<%#ShopUrlOperate.shopDetailHrefByShopIDNew(Eval("Guid").ToString(),Eval("ShopID").ToString(),"ProductIsPanic_Detail") %>'
                                target="_blank" style="display: none;"></a>
                            <div class="clear"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
    </div>
</div>
