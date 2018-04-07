<div class="dpsc_mian" style="width: 998px; padding-bottom: 60px;">
    <div class="maijtitle3">
    </div>
    <div class="dianpsh" id="showCss" runat="server">
        <div class="no_data1" style="float: none; font-size: 18px; color: #ff6600; font-weight: bold;">
            <asp:Label ID="LabelShow" runat="server" Text="店铺申请成功，请等待审核！"></asp:Label></div>
        <div style="text-align: right; line-height: 23px; margin-top: 10px; text-align: center;"
            runat="server" id="OpenLink">
            <a href="S_ShopOpenStep2.aspx?OptMsg=edit" style="color: #ff6600; text-align: center;
                font-size: 12px; color:#005ea7;">(如需修改提交信息，请点击此处！)</a>
        </div>
        <div style="font-size: 12px;" id="showFailedReason" runat="server" visible="false">
            <div style="text-align:left; color: #666666; background:#ffffcc; width:500px; padding:10px; margin:10px auto; border:1px solid #ffcc99;">
                <strong>失败原因：</strong><asp:Label ID="LabelAuditFailedReason" runat="server" Text=""></asp:Label></div>
            <div style="text-align: right; line-height: 23px; margin-top: 10px; text-align: center;">
                <a href="S_ShopOpenStep2.aspx?OptMsg=reopen" style="color: #ff6600; text-align: center;
                    font-size: 12px; color:#005ea7;">(点击修改店铺信息，可继续申请店铺，请保证预存款充足！) </a>
            </div>
        </div>
    </div>
</div>
<table cellpadding="0" cellspacing="0" width="500" border="1" style="margin-left: 150px;
    display: none">
    <tr>
        <td width="100" style="text-align: right;">
            审核人：
        </td>
        <td width="400" style="text-align: left;">
            <asp:Label ID="LabelOperateUser" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            审核时间：
        </td>
        <td style="text-align: left;">
            <asp:Label ID="LabelAuditTime" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            失败原因：
        </td>
        <td style="text-align: left;">
        </td>
    </tr>
</table>
