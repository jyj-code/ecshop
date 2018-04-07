<%@ Control Language="C#"  %>
<div style="text-align:center; margin:0 auto; width:980px;">
    <asp:HyperLink ID="HyperLinkUrl" runat="server" Target="_blank">
        <asp:Label ID="labelBazs" runat="server" />
    </asp:HyperLink>
</div>
<asp:HiddenField ID="HiddenFieldXmlPath" runat="server" Value="0" />