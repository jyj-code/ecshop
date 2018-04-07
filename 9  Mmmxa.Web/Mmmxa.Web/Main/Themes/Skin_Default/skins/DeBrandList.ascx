<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterBrand" runat="server">
    <ItemTemplate>
        <div class="announ_list">
            <a href='<%# ShopUrlOperate.RetUrl("BrandDetail",((DataRowView)Container.DataItem).Row["Guid"].ToString(),"brandguid")%>'
                target="_blank">
                <asp:Image ID="ImageBrand" onerror="javascript:this.src='../ImgUpload/noImage.gif'" Width="182px" Height="62px" runat="server" ImageUrl='<%# Globals.ImagePath+((DataRowView)Container.DataItem).Row["Logo"] %>' />
            </a>
        </div>
    </ItemTemplate>
</asp:Repeater>
