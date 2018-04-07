<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="news_article" style="display: none;">
    <h3><asp:Literal ID="LiteralTitle" runat="server" Visible="false"></asp:Literal></h3>
</div>
<div  class="marquee" style="width:193px;overflow:hidden; position:relative;">
<asp:Repeater ID="DataListAriticleNew" runat="server">
    <ItemTemplate>
        <dl style=" display:block;width:180px; height:22px; overflow:hidden;">
            <dd>
                <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'
                    target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),27,"")%></a></li>
            </dd>
        </dl>
    </ItemTemplate>
</asp:Repeater>
</div>
