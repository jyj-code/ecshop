<%@ Control Language="C#" %>
<div class="store_category_view renqi">
    <h3>积分兑换排行榜</h3>
    <div class="news_pics">
        <asp:Repeater ID="RepeaterShow" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href='<%#ShopUrlOperate.shopDetailHrefNew(Eval("Guid").ToString(),Eval("MemLoginID").ToString(),"ProductIntegral")%>' class="newsimg">
                <asp:Image ID="ImageProduct" runat="server" Width="60" Height="60"   ImageUrl='<%#Eval("OriginalImge") %>' onerror="javascript:this.src='/ImgUpload/noImage.gif'"/>
                </a>
                <div class="news_name">
                    <a href='<%#ShopUrlOperate.shopDetailHrefNew(Eval("Guid").ToString(),Eval("MemLoginID").ToString(),"ProductIntegral")%>' class="hname">
                    <%#Eval("Name").ToString().Length > 10 ? Eval("Name").ToString().Substring(0, 10) : Eval("Name").ToString()%></a>
                    <p class="del">
                        <span>市场价：</span><del>￥<%#Eval("MarketPrice")%></del>
                    </p>
                    <p class="renqinum">
                        <span>积分：</span><%#Eval("Score")%></p>
                        <span class="renqinum">
                        <span>件数：</span><%#Eval("repertorycount")%></span>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
        </asp:Repeater>
    </div>
</div>