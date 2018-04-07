<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="latest_shop" style="border: 1px solid #b3b3b3;">
    <div class="all_top" style="line-height: normal;">
        <img src="Themes/Skin_Default/Images/brandtop.jpg" />
    </div>
    <!-- 隔开 -->
    <div class="cle">
    </div>
    <div class="brand_list_detail">
        <asp:Repeater ID="RepeaterBrandCategory" runat="server">
            <ItemTemplate>
                <div class="brand_list_detail_title">
                    <asp:Label ID="LabelBrandCategory" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["Name"] %>'></asp:Label>
                </div>
                <asp:Literal ID="LiteralCode" Visible="false" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["Code"] %>'></asp:Literal>
                <div class="brand_list_detail_list">
                    <ul>
                        <asp:Repeater ID="RepeaterBrandImg" runat="server">
                            <ItemTemplate>
                                <li>
                                    <asp:Image ID="ImageBrand" runat="server" Height="51px" Width="150" ImageUrl='<%#"~/Main/images/"+((DataRowView)Container.DataItem).Row["Logo"] %>' />
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
