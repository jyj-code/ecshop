<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>

<div class="bBox bBoxnt">
<h2><span class="fl"><asp:Label ID="lblAlbum" runat="server"></asp:Label>相册</span></h2>
    <div class="content despis">
        <div class="middle clearfix">
            <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
                <p class="nofind">
                    没有找到符合条件的图片！
                </p>
            </asp:Panel>
            
            <asp:Repeater ID="RepeaterImgList" runat="server">
                <ItemTemplate>
                    <asp:Literal ID="LiteralImgID" runat="server" Text='<%# Eval("Id")%>' Visible="false"></asp:Literal>
                    <div class="scratch">
                        <div class="pruct_zs">
                            <div class="pdt_img">
                                <p class="ncs_img">                                 
                                        <asp:Image ID="ImageCateFace" runat="server" ImageUrl='<%# Eval("ImagePath")+"_160x160.jpg"%>'
                                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" />
                                    
                                </p>
                            </div>
                            <p class="pdt_name">
                                    <asp:Literal ID="LiteralName" runat="server"  Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                                </a>
                            </p>                                                       
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>    
</div>



 <!--分页-->
<div class="fenye">
    <div class="lambert">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <span class="fenye1">共</span>
                </td>
                <td>
                    <span>
                        <asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span>
                </td>
                <td>
                    <span class="fenye2">页，到第</span>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input">
                    </asp:TextBox>
                </td>
                <td style="*width: 18px; width: 18px\9;">
                    <span class="fenye3">页</span>
                </td>
                <td style="*width: 42px; width: 42px\9; padding-left: 0px\9; *padding-left: 18px;">
                    <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" />
                </td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 " style="float: right; width: 210px; text-align: right;">
            <span class="disabled">< </span><span class="current">1</span> <a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>





