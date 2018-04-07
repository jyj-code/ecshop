<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<script type="text/javascript">
    $(function() {
        $('ul.contsh:last').css('border-bottom', 'none');
    })    
</script>
<link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
<div class="ks_panel">
    <div class="storn_hd">
        <h3><asp:Label ID="LabelShopType" Text = ""  runat="server"></asp:Label></h3>
        <p class="gd_more">
           </p>
    </div>
    <div class="ktlist">
        <div id="b0" style="display: block">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <ul class="contsh">
                        <li class="sel_rank">
                            <div class="prdt_img">
                                <a href='<%#ShopUrlOperate.GetShopUrlNew(Eval("ShopID").ToString())%>' target="_blank"
                                    title='<%# Eval("Name")%>'>
                                    <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%# Eval("banner")+"_60x60.jpg"%>'
                                        onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" CssClass="mar_img" />
                                </a>
                            </div>
                        </li>
                        <li class="sel_info">
                            <p>
                             <a href="<%#ShopUrlOperate.GetShopUrlNew(Eval("ShopID").ToString()) %>">
                             <%#Eval("ShopName")%></a></p>
                            <p>
                                主营宝贝：<%# Eval("maingoods")%>
                            </p>
                            <p class="sale_out">
                                店主：<span><%# Eval("name").ToString().Length>6?Eval("name").ToString().Substring(0,6)+"..":Eval("name").ToString()%></span></p>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
