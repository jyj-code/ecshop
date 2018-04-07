<%@ Control Language="C#" AutoEventWireup="true" %>
<asp:HiddenField ID="Hflash" runat="server" />
<div id="right">
    <div class="rhigth">
        <div class="rl">
        </div>
        <div class="rcon">
            <h3>打印预览</h3>
        </div>
        <div class="rr">
        </div>
    </div>
    <div class="welcon clearfix">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td align="center">
                    <div id="dly_printer" style="width: 907px; height: 560px">
                        <object id="dly_printer_flash" height="100%" width="100%" type="application/x-shockwave-flash"
                            data="swf/printermode.swf">
                            <param value="high" name="quality" />
                            <param value="swf/printermode.swf" name="movie" />
                            <param value="always" name="allowScriptAccess" />
                            <param value="true" name="swLiveConnect" />
                            <param value="opaque" name="wMode" />
                            <param value="<%=Hflash.Value %>" name="flashVars" />
                        </object>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
