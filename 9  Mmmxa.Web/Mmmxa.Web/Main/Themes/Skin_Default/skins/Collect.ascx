<%@ Control Language="C#"  %>
<%@ Import Namespace="ShopNum1.Common"%>
<%@ Import Namespace="System.Data" %>
<div class="MemberAll">
<div class="MemberTitle">我的收藏</div>
<table cellpadding="0" cellspacing="1" width="100%" border="0">
  <tr class="MemberTr">
    <td width="30"><asp:CheckBox ID="CheckAll" AutoPostBack="true" runat="server"  /></td>
    <td width="33%">商品名称</td>
    <td width="33%">店铺名称</td>
    <td width="33%">本店售价</td>
    <td width="33%">收藏时间</td>
  </tr>
           <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
					<ItemTemplate>

      <tr>
        <td align="center">   
		<asp:checkbox id="checkboxAll" runat="server" /><span runat="server" visible="false" id="guid"><%# ((DataRowView)Container.DataItem).Row["Guid"]%></span></td>
        <td ><a href='ProductDetail.aspx?guid=<%# ((DataRowView)Container.DataItem).Row["ProductGuid"] %>'   target="_self"><%# ((DataRowView)Container.DataItem).Row["ProductName"]%><asp:HiddenField ID="HiddenFieldProductGuid" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ProductGuid"] %>' /></a></td>
                <td align="center"  ><%# ((DataRowView)Container.DataItem).Row["ShopName"]%></td>
        <td  align="center"><%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></td>
        <td align="center"  ><%# ((DataRowView)Container.DataItem).Row["CollectTime"]%></td>
         </tr>
						<!-- ********* ItemTemplate.End ************* //-->
					</ItemTemplate>
					<FooterTemplate>
						<!-- ********* FooterTemplate.Start ************* //-->
					
						<!-- ********* FooterTemplate.End ************* //-->
					</FooterTemplate>
				</asp:Repeater>

      
</table>
</div>
        <!-- 分页部分-->
    <div class="pager" >
<asp:Label ID="LabelPageMessage" runat="server"></asp:Label>

&nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
<asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
<asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
<asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
&nbsp;<span class="fpager">转到 <asp:Literal ID="lnkTo" runat="server" /> 页</span>

</div>  

                      <asp:Button ID="ButtonAddOrder" runat="server" 
    Text="加入购物车"  CssClass="Button2" />
        &nbsp;<asp:Button runat="server" id="ButtonDelete"  Text="删除"  CssClass="Button1" />
        
