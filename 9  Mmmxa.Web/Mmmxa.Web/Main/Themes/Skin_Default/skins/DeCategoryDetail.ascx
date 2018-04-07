<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<ul>
    <asp:Repeater ID="RepeaterCategory" runat="server">
        <ItemTemplate>
            <li>· <a href='<%#ShopUrlOperate.RetUrl("CategoryInfoDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>
                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),30,"")%>
            </a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
