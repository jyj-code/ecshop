<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main">
    <ul class="sidebar">
        <li id="0" class='<%=Common.ReqStr("type")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=0&pageid=1">供求评论</a></li>
        <li id="1" class='<%=Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=1&pageid=1">店铺视频评论</a></li>
        <li id="2" class='<%=Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=2&pageid=1">平台视频评论</a></li>
        <li id="3" class='<%=Common.ReqStr("type")=="3"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=3&pageid=1">平台资讯评论</a></li>
        <li id="4" class='<%=Common.ReqStr("type")=="4"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=4&pageid=1">店铺资讯评论</a></li>
    </ul>
    <div id="content" class="ordmain">
        <%--供求评论--%>
        <asp:Panel ID="PanelComment1" runat="server" Visible="false">
            <ShopNum1:M_SupplyDemandComment ID="M_SupplyDemandComment" runat="server" SkinFilename="Skin/M_SupplyDemandComment.ascx"
                PageSize="10" />
        </asp:Panel>
        <%--店铺视频评论--%>
        <asp:Panel ID="PanelComment2" runat="server" Visible="false">
            <ShopNum1:M_ShopVideoComment ID="M_ShopVideoComment" runat="server" SkinFilename="Skin/M_ShopVideoComment.ascx"
                PageSize="10" />
        </asp:Panel>
        <%--平台视频评论--%>
        <asp:Panel ID="PanelComment3" runat="server" Visible="false">
            <ShopNum1:M_VideoComment ID="M_VideoComment" runat="server" SkinFilename="Skin/M_VideoComment.ascx"
                PageSize="10" />
        </asp:Panel>
        <%--平台资讯评论--%>
        <asp:Panel ID="PanelComment4" runat="server" Visible="false">
            <ShopNum1:M_ArticleComment ID="M_ArticleComment" runat="server" SkinFilename="Skin/M_ArticleComment.ascx"
                PageSize="10" />
        </asp:Panel>
        <%--店铺资讯评论--%>
        <asp:Panel ID="PanelComment5" runat="server" Visible="false">
            <ShopNum1:M_ShopNewsComment ID="M_ShopNewsComment" runat="server" SkinFilename="Skin/M_ShopNewsComment.ascx"
                PageSize="10" />
        </asp:Panel>

        <script type="text/javascript" language="javascript">
         //跳转到制定的页码
         function ontoPage(txtId)
         {
               location.href='?isread=<%= Common.ReqStr("type") %>&pageid='+$("#txtIndex").val();
         }
         
         $(function(){
            $("input[name='checktop']").click(function(){
                $("input[name='checksub']").attr("checked",$(this).is(":checked"));
           });
        })
         
         $(function(){
            //批量删除操作
            $(".shanchu").click(function(){
                var ArrayGuid=new Array();
                var flat=false;
                $("input[name='checksub']").each(function(){
                        if($(this).is(":checked")){flat=true;
                        ArrayGuid.push("'"+$(this).val()+"'");}
                });
                if(flat)
                {
                    IsDelete(ArrayGuid.join(","));
                }
                else
                {
                    alert("请选择一项数据！");
                } 
                
            });
         });
        </script>

    </div>
</div>
