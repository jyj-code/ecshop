<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>

<div class="latest_shop" style="border: 1px solid #b3b3b3;">
    <div class="all_top">
        <span style="padding-left: 10px;">
            <asp:Label ID="LabelCategory" runat="server" Text=""></asp:Label></span>
    </div>
    <!-- 隔开 -->
    <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
        font-size: 8px;">
    </div>
    <div class="brand_list_detail">
        <div class="brand_list_detail_list">
            <ul>
                <asp:Repeater ID="RepeaterBrand" runat="server">
                    <ItemTemplate>
                        <li><a href='BrandDetail.aspx?BrandGuid=<%# ((DataRowView)Container.DataItem).Row["Guid"] %>'
                            target="_blank">
                            <asp:Image ID="ImageBrand" Width="150" Height="51" runat="server" ImageUrl='<%# Globals.ImagePath+((DataRowView)Container.DataItem).Row["Logo"] %>' />
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!-- 隔开 -->
    </div>
    <!-- 隔开 -->
    <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
        font-size: 8px;">
    </div>
    <!-- 分页 -->
    <!-- 隔开 -->
    <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
        font-size: 8px;">
    </div>
    <!-- 分页 -->
    <div class="page" style="margin-left: 0; margin-right: 0; border:none;">
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
