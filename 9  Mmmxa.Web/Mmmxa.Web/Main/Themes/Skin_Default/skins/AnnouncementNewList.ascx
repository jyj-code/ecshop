<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div  class="marquee" style="width:193px;overflow:hidden; position:relative;">
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <dl style=" display:block;width:180px; height:22px; overflow:hidden;">
            <dd>
                <a href='<%# ShopUrlOperate.RetUrl("AnnouncementDetail",((DataRowView)Container.DataItem).Row["guid"]) %> '
                    target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>
                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),26,"")%></a>
            </dd>
        </dl>
    </ItemTemplate>
</asp:Repeater>
</div>
