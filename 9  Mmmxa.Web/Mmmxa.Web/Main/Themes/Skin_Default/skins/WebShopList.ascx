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
                            <a href='<%#ShopUrlOperate.GetShopUrlNew(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'>
                            <asp:Image ID="ImageShop" runat="server" Width="160" Height="160" ImageUrl='<%#Eval("Banner") %>' onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"/>
                            </a>
                        </div>
                        <div class="lmf_qg_title">
                            <a href='<%#ShopUrlOperate.GetShopUrlNew(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'>
                               <%#Eval("ShopName")%></a>
                        </div>
                        <div class="lmf_qg_price">
                            <span class="lmf_price_fh">店长：</span>
                            <span class="lmf_price"> <%#Eval("MemLoginID")%>
                            </span>
                        </div>
                    </td>
                    </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </tbody>
        </table>
    </div>