<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterBrand" runat="server">
    <ItemTemplate>
        <a href='<%# ShopUrlOperate.RetUrl("BrandDetail",((DataRowView)Container.DataItem).Row["Guid"].ToString(),"brandguid")%>'
            target="_blank">
            <asp:Image ID="ImageBrand" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'" Width="100px" Height="50px" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Logo"] %>' />
        </a>
    </ItemTemplate>
</asp:Repeater>
