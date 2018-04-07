<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<h2 class="penis"><i></i>资讯分类</h2>
<div class="ks_panel">
    
    <div class="NewClassify">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table1 tc">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="50%">
                            <a href='<%# GetPageName.RetUrl("NewsListBestNew",Eval("guid"))%>'>
                                <%# Eval("Name")%></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</div>
