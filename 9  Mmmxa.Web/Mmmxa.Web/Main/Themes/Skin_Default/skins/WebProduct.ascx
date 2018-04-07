<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="lmf_qianggou">
        <table cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                
    <asp:Repeater ID="RepeaterShopByType" runat="server">
    <ItemTemplate>
        <td valign="top" align="left" class="lmf_padding">
                        <div class="lmf_qg_img">
                            <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                
                                <asp:Image ID="ImageShop" Width="160" Height="160" runat="server" ImageUrl='<%#Eval("OriginalImage") %>' onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"/>
                            </a>
                        </div>
                        <div class="lmf_qg_title">
                            <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                               <%#Eval("Name")%></a>
                        </div>
                        <div class="lmf_qg_price">
                            <span class="lmf_price_fh">售价：</span>
                            <span class="lmf_price"> <%#Eval("ShopPrice")%>
                            </span>
                        </div>
                    </td>
    </ItemTemplate>
    </asp:Repeater>
                </tr>
            </tbody>
        </table>
    </div>