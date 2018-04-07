<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="pro_hot clearfix">
    <span class="hotspan"></span>
    <h3>
        <span class="fl"><asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></span>
        <span class="fr"><a href="/ProductListPromotion.html?code=-1&brandguid=-1&Pvalue=-1&sort=desc&ordername=salenumber&style=grid&minprice=&maxprice=&addcode=-1&IsshopNew= 0&IsshopHot=1&IsShopGood=0&IsshopRecommend=0">更多</a></span>
    </h3>
    <div class="hot_lists">
        <ul class="clearfix">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="hotimgs">
                            <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                <asp:Image ID="Image1" ImageUrl='<%#Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())+"_100x100.jpg"%>'
                                    runat="server" onerror="javascript:this.src='../ImgUpload/noimg.jpg_100x100.jpg'" />
                            </a>
                        </div>
                        <div class="hot_name">
                            <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>' title="<%# ((DataRowView)Container.DataItem).Row["Name"].ToString()%>">
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),28,"")%></a>
                            <p>特价：<b><%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></b></p>
                            <div class="btnqiang">
                                <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                    <input type="button"  name="btn" value="立即抢购" class="qiangguo" />
                                </a>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
