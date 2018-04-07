<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>

<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">
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
                    alert("请选择一项！");
                }
            });
         });
     function IsDelete(val){
     if(confirm("是否删除勾选项？"))
     {
        $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=AdvertPay&delid="+val,null,function(data){
                    if(data=="ok"){alert("删除成功！");location.reload();window.location.href="S_TerracePayList.aspx"; return false;}
                    else{Alert("删除失败！");return false;}
               });
        }
     }
     
     $(function(){
            $("#checktop").click(function(){
                $("input[name='checksub']").attr("checked",$(this).is(":checked"));
           });
        })
</script>

<div id="content" class="ordmain1">
    <div class="btntable_tbg">
        <div class="shanc">
            <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
        </div>
        <div class="shanc">
            <a href="S_TerracePay_Operate.aspx" class="tianjiafl lmf_btn">添加广告</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
      
            <tr>
                <th class="th_le" width="6%">
                    <input name="checktop" type="checkbox" title="全选" id="checktop" />
                </th>
                <th width="15%">
                    广告位
                </th>
                <th width="15%">
                    名称
                </th>
                <th width="10%">
                    申请时间
                </th>
                <th width="10%">
                    开始时间
                </th>
                <th width="10%">
                    结束时间
                </th>
                <th width="9%">
                    撤销
                </th>
                <th width="9%">
                    审核
                </th>
            </tr>
   
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le">
                            <input name="checksub" type="checkbox" class="vcheck" value='<%#Eval("Guid")%>' />
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.GetAdId(Eval("AdId").ToString(),"all")%>
                        </td>
                        <td>
                            <%#Utils.GetUnicodeSubString(Eval("Remarks").ToString(), 13, "")%>
                        </td>
                        <td>
                            <%#Eval("CreateTime")%>
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.BeginDate(Eval("BeginDate").ToString())%>
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.EndDate(Eval("EndDate").ToString())%>
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.IsCancel(Eval("IsCancel").ToString())%>
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_TerracePayList.IsAudit(Eval("IsExamine").ToString())%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
     
        <%if (RepeaterShow.Items.Count == 0)
          { %>
     
            <tr>
                <td colspan="8" class="th_le th_ri">
                    <div class="no_datas">
                    <div class="no_data">
                        暂无数据</div></div>
                </td>
            </tr>
      
        <% }%>
    </table>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
