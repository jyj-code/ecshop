﻿<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<ul>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <li><a href='<%# ShopUrlOperate.RetUrl("AnnouncementDetail",((DataRowView)Container.DataItem).Row["guid"]) %> '
                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>·<%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%></a>
                <li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
