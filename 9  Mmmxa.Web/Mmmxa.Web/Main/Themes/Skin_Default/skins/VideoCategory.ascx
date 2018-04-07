<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div id="article_categroy" class="VideoCategoryBox">
    <asp:Repeater ID="RepeaterCategory" runat="server">
        <ItemTemplate>
            <ul>
                <li class="f2">
                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                    <a href='<%# ShopUrlOperate.RetUrl("VideoSearchList",((DataRowView)Container.DataItem).Row["ID"],"VideoCategoryID") %>'
                        target="_blank">
                        <%#((DataRowView)Container.DataItem).Row["Name"] %>
                        </a>
                </li>
                <asp:Repeater ID="RepeaterSubCategory" runat="server">
                    <ItemTemplate>
                        <li>
                       <a href='<%# ShopUrlOperate.RetUrl("VideoSearchList",((DataRowView)Container.DataItem).Row["ID"],"VideoCategoryID") %>'
                            target="_blank">
                            <%#((DataRowView)Container.DataItem).Row["Name"]  %>
                            </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
</div>
