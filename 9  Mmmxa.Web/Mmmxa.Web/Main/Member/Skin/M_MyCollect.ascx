<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>

<script type="text/javascript" language="javascript">
         //跳转到制定的页码
         function ontoPage(txtId)
         {
               location.href='?isread=<%= Common.ReqStr("type") %>&pageid='+$("input[name='searchpage']").val();
         }
         $(function(){
            //批量删除操作
            $(".shanchu").click(function(){
                var ArrayGuid=new Array();
                var flat=false;
                $("input[name='checksub']").each(function(){
                if($(this).is(":checked")){flat=true;
                ArrayGuid.push("'"+$(this).val()+"'");}
                });
                if(flat==false)
                {
                    alert("请选择一项！");
                }
                else
                {
                    IsDelete(ArrayGuid.join(",")); 
                }
            });
         });
         
         $(function(){
            $("input[name='checktop']").click(function(){
                $("input[name='checksub']").attr("checked",$(this).is(":checked"));
           });
        })
</script>

<div id="list_main" class="ordmain1">
    <ul id="sidebar">
        <li class='<%=Common.ReqStr("type")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=0&pageid=1">商品收藏</a></li>
        <li class='<%=Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=1&pageid=1">店铺收藏</a></li>
    </ul>
    <div id="content">
        <asp:Panel ID="PanelMemberProductCollect" runat="server">
            <ShopNum1:M_MemberProductCollect ID="M_MemberProductCollect" runat="server" SkinFilename="Skin/M_MemberProductCollect.ascx"
                PageSize="10" />
        </asp:Panel>
        <asp:Panel ID="PanelShopCollect" runat="server">
            <ShopNum1:M_ShopCollect ID="M_ShopCollect" runat="server" SkinFilename="Skin/M_ShopCollect.ascx"
                PageSize="10" />
        </asp:Panel>
    </div>
</div>
