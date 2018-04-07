<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>

<script type="text/javascript">
 function OperateCa(dobj,isout)
 {
 if(!isout)
 {
  $(dobj).next().attr("style","display:block;");
// $(dobj).next.show();
  }
  else
  {
   $(dobj).next().attr("style","display:none;");
// $(dobj).next.hide();
  }
 }
 
  function OperateCa1(dobj,isout)
 {
 if(!isout)
 {
  $(dobj).eq(1).attr("style","display:block;");
  }
  else
  {
   $(dobj).eq(1).attr("style","display:none;");
  }
 }
</script>

<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="store_category_view_list" onmouseover="OperateCa1(this,false)" onmouseout="OperateCa1(this,true)">
            <div class="store_category_title" onmouseover="OperateCa(this,false)" onmouseout="OperateCa(this,true)">
                <a href='<%# "AllBrandList.aspx?Code=" + ((DataRowView)Container.DataItem).Row["Code"]%>'>
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                    >></a></div>
            <div style="display: none" onmouseout="this.style.display='none';" onmousemove="this.style.display='block';">
                <asp:Repeater ID="RepeaterChild" runat="server">
                    <ItemTemplate>
                        <div class="store_category_detail store_category_detailon" onmouseover="OperateCa(this,false)"
                            onmouseout="OperateCa(this,true)" style="font-weight: bold; margin-left: 6px;">
                            <a href="<%# "AllBrandList.aspx?Code=" + ((DataRowView)Container.DataItem).Row["Code"]%>">
                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                        </div>
                        <div class="store_category_detail" onmouseout="this.style.display='none';" onmousemove="this.style.display='block';"
                            style="margin-left: 8px; background: none; display: none;">
                            <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                <ItemTemplate>
                                    <a href="<%# "AllBrandList.aspx?Code=" + ((DataRowView)Container.DataItem).Row["Code"]%>">
                                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                    <asp:Literal ID="LiteralLine" runat="server">|</asp:Literal>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
        </div>
    </ItemTemplate>
</asp:Repeater>
