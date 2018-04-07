<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
        $(function(){
                $("input[name='hidPwd']").each(function(){
                        if($(this).val()=="1")
                        {
                            $(this).next().attr("href","javascript:void(0)");
                        }
                });
                 $("input[name='hidPwdv']").each(function(){
                        if($(this).val()=="1")
                        {
                            $(this).parent().show();
                        }
                });
                $("input[name='btnSearch']").click(function(){
                        var id=$(this).attr("lang");
                        var pwd=$(this).prev().val();
                        $.get("/Api/Shop/ShopImgAblum.ashx?pwd="+pwd+"&ablumId="+id+"",null,function(data){
                                if(data=="ok")
                                {
                                   window.location.href="http://<%=Request.Url.Host %>/ImgList.aspx?imgCategoryId="+id+"&pwd="+pwd+"";
                                }
                                else
                                {
                                  alert("相册查看密码不正确!");return false;
                                }
                        });
                });
        });
</script>
<div class="bBox bBoxnt">
    <h2>
        <span class="fl">相册展示</span><span class="fr">
            <table width="300" border="0" cellpadding="0" cellspacing="0" style="display:none">
                <tr>
                    <td style="color: #4D4D4D; font-size: 12px;">
                        排序方式：
                    </td>
                    <td width="140">
                        <select id="Select1" name="sort">
                            <option value="0">按排序从大到小</option>
                            <option value="1">按排序从小到大</option>
                            <option value="2">按创建时间从晚到早</option>
                            <option value="3">按创建时间从早到晚</option>
                            <option value="4">按相册名降序</option>
                            <option value="5">按相册名升序</option>
                        </select>
                    </td>
                </tr>
            </table>
        </span>
    </h2>
    
    <div class="content despis">
        <div class="middle clearfix">
            <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
                <p class="nofind">
                    没有找到符合条件的相册！
                </p>
            </asp:Panel>
            
            <asp:Repeater ID="RepeaterImgCate" runat="server">
                <ItemTemplate>
                    <asp:Literal ID="LiteralImgCateID" runat="server" Text='<%# Eval("ID")%>' Visible="false"></asp:Literal>
                    <div class="scratch">
                        <div class="pruct_zs">
                            <div class="pdt_img">
                                <p class="ncs_img">
                                 <input type="hidden" name="hidPwd" value='<%# Eval("ispublic")%>' />
                                 <a href="http://<%=HttpContext.Current.Request.Url.Host%>/ImgList.aspx?imgCategoryId=<%# Eval("ID")%>&pwd=<%# Eval("ImgPwd")%>">
                                        <asp:Image ID="ImageCateFace" runat="server" ImageUrl='<%# Eval("Face")+"_160x160.jpg"%>'
                                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" /></a>
                                    
                                </p>
                            </div>
                           
                            <p class="pdt_name">
                                    <asp:Literal ID="LiteralName" runat="server"  Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                            </p>    
                            <p class="pdt_name" style="display:none;">
                            <input type="hidden" name="hidPwdv" value='<%# Eval("ispublic")%>' />
                            输入密码:<input type="text" id="txtPwd" style="border: 1px solid #D6D6D6; color: #333333;height: 10px;width:60px; padding: 2px 0 1px 3px;" /> 
                            <input type="button" name="btnSearch" value="查看" lang='<%# Eval("ID")%>' />
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





