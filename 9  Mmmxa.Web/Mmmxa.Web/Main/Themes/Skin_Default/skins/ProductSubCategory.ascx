<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="recommend_keyword fr">
    <asp:Repeater ID="RepeaterDataWenzi" runat="server">
        <ItemTemplate>
            <%#RepeaterDataWenzi.Items.Count == 0 ? "" : "|"%>
            <a href='/Search_productlist.html?code=<%#((DataRowView)Container.DataItem).Row["Code"] %>'
                target="_blank">
                <%# ((DataRowView)Container.DataItem).Row["Name"]%>
            </a>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Literal ID="moreView_1" runat="server" Text="更多" Visible="false"></asp:Literal>
</div>


