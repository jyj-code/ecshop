﻿<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
    $(function() {
    $('ul.LatestNews li:last a').css('border-bottom', 'none');
    })    
</script>

<h2 class="penis"><i></i>最新资讯</h2>
<div class="ks_panel">
    
    <div class="content">
        <ul class="LatestNews">
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <li>
                        <a href='<%# GetPageName.RetUrl("NewsDetail",Eval("guid"))%>'>·<%# Eval("Title")%></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>