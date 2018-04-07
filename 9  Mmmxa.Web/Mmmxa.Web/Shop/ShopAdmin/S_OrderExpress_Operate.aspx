<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="S_OrderExpress_Operate" Codebehind="S_OrderExpress_Operate.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <link href="style/style.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" for="dly_printer_editor_flash"
        event="onclick">
<!--
    return dly_printer_editor_flash_onclick()
    // -->
    </script>

    <script type="text/javascript">  
        function checkInsert()
        {
            //var ins=document.getElementById("selectPrintObj");
            //if(ins.options[ins.options.selectedIndex].value=="0")
            //{
            // alert("请选择要插入的打印项");
            // return false;
            // }
            return true;
 
        }
 
        function CheckAdd()
        {
            if(document.getElementById("drTextBoxExpressName").value=="")
            {
                alert("快递单模板名不能为空!")
                return false;
            }
            else
            {
                document.getElementById("ButtonAdd").disabled=false;
                return true;
            }
        }
        function checkFileUploadImage()
        {
            var FileUploadImage=document.getElementById("FileUploadImage");
            if(FileUploadImage.value=="")
            {
                alert("模板背景图不能为空");
                return false;
            }
            var extentsion=FileUploadImage.value.substring(FileUploadImage.value.lastIndexOf(".")+1,FileUploadImage.value.length).toUpperCase();
            if(extentsion=="JPG" || extentsion=="BMP" || extentsion=="GIF"|| extentsion=="JPEG" || extentsion=="PNG")
            {
                return true;
            }
            else
            {
                alert("模板的背景图格式不对，应为图片");
                return false;
            }
        }
        function insertitem(){
            if($("#selectPrintObj").val()!="0")
            {
                window.location.href=document.getElementById('selectPrintObj').options[document.getElementById('selectPrintObj').options.selectedIndex].value;
                return false;
            }
            else{
                alert("请选择要插入的项!");
            }
        }

        function saveData(){
            var obj = document.getElementById('dly_printer_editor_flash');
           $("<%=paraTemppara.ClientID%>").val(unescape(obj.getData()));
            $("#<%=hTempData.ClientID%>").val(unescape(obj.getData()));
            return true;
        }
        function checkinput(){
            if(CheckAdd())
            {
                saveData();
                return true;
            }
            return false;
        }
    </script>

</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">
                <asp:Label ID="LabelPageTitle" runat="server" Text="编辑快递单模板"></asp:Label></span></p>
        <div class="content">
            <div style="margin-left: 10px; margin-top: 6px;">
                <div style="margin-top: 10px; margin-left: 6px;">
                    <select id="selectPrintObj" class="tselect">
                        <option value="0">请选择要插入的打印项</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_name','收件人-姓名');">
                            收件人-姓名</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_addr','收件人-地址')">
                            收件人-地址</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_tel','收件人-电话')">
                            收件人-电话</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_mobile','收件人-手机')">
                            收件人-手机</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_zip','收件人-邮编')">
                            收件人-邮编</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_name','发件人-姓名')">
                            发件人-姓名</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_address','发件人-地址')">
                            发件人-地址</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_tel','发件人-电话')">
                            发件人-电话</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_mobile','发件人-手机')">
                            发件人-手机</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_zip','发件人-邮编')">
                            发件人-邮编</option>
                        <%--                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_id','订单-订单号')">
                            订单-订单号</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_price','订单总金额')">
                            订单总金额</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_weight','订单物品总重量')">
                            订单物品总重量</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_count','订单-物品数量')">
                            订单-物品数量</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_memo','订单-备注')">
                            订单-备注</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_time','订单-送件时间')">
                            订单-送件时间</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('shop_name','网店名称')">
                            网店名称</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('tick','对号 - √')">
                            对号 - √</option>
                        <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('text','自定义内容')">
                            自定义内容</option>--%>
                    </select>
                    <input type="button" value="插入" class="dele" style="margin: 0px;" onclick="insertitem()" />
                    <input type="button" value="删除" class="dele" onclick="dly_printer_editor_flash.delItem()"
                        style="margin: 0px;" />
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="r1" Text="是"
                        Visible="false" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="r1" Text="否" Visible="false" />
                </div>
                <div style="margin-top: 10px; margin-left: 6px;">
                    <asp:Label ID="Label1" runat="server" Text="快递单模板名称"></asp:Label>
                    &nbsp;
                    <%-- <asp:TextBox ID="TextBoxExpressName" runat="server" onchange='if(this.value!="") document.getElementById("ButtonAdd").disabled=false ' CssClass="tinput"></asp:TextBox>--%>
                    <asp:DropDownList ID="drTextBoxExpressName" runat="server" Width="180px">
                    </asp:DropDownList>
                    <asp:FileUpload ID="FileUploadImage" runat="server" />
                    <asp:Button ID="ButtonChangeBg" OnClick="ButtonChangeBg_Click" CssClass="dele" OnClientClick="return checkFileUploadImage();"
                        runat="server" Text="设为背景" />
                </div>
                <div style="margin-top: 12px; margin-left: 6px;">
                    <select id="jianju2" style="width: 80px;" onchange="if(this.value!='--')document.getElementById('dly_printer_editor_flash').setFontSize(this.value);"
                        class="tselect" width="60" name="font">
                        <option value="--">大小</option>
                        <option value="10">10</option>
                        <option value="12">12</option>
                        <option value="14">14</option>
                        <option value="18">18</option>
                        <option value="20">20</option>
                        <option value="24">24</option>
                        <option value="27">27</option>
                        <option value="30">30</option>
                        <option value="36">36</option>
                    </select>
                    <select onchange="if(this.value!='--')document.getElementById('dly_printer_editor_flash').setFont(this.value);"
                        class="tselect" style="width: 100px;">
                        <option value="--">字体</option>
                        <option value="宋体">宋体</option>
                        <option value="黑体">黑体</option>
                        <option value="Arial">Arial</option>
                        <option value="Verdana">Verdana</option>
                        <option value="Serif">Serif</option>
                        <option value="Cursive">Cursive</option>
                        <option value="Fantasy">Fantasy</option>
                        <option value="Sans-Serif">Sans-Serif</option>
                    </select>
                    <select id="jianju" style="width: 80px;" onchange="if(this.value!='--')document.getElementById('dly_printer_editor_flash').setFontSpace(this.value); "
                        class="tselect" name="jianju">
                        <option value="--">间距</option>
                        <option value="-4">-4</option>
                        <option value="-2">-2</option>
                        <option value="0">0</option>
                        <option value="2">2</option>
                        <option value="4">4</option>
                        <option value="6">6</option>
                        <option value="8">8</option>
                        <option value="10">10</option>
                        <option value="12">12</option>
                        <option value="14">14</option>
                        <option value="16">16</option>
                        <option value="18">18</option>
                        <option value="20">20</option>
                        <option value="22">22</option>
                        <option value="24">24</option>
                        <option value="26">26</option>
                        <option value="28">28</option>
                        <option value="30">30</option>
                    </select>
                    <input type="button" value="B" class="dele" onclick="document.getElementById('dly_printer_editor_flash').setBorder()"
                        style="margin: 0px;" />
                    <input type="button" value="I" class="dele" onclick="document.getElementById('dly_printer_editor_flash').setItalic()"
                        style="margin: 0px;" />
                    <input type="button" value="居左" class="dele" onclick="document.getElementById('dly_printer_editor_flash').setAlign('left')"
                        style="margin: 0px;" />
                    <input type="button" value="居中" class="dele" onclick="document.getElementById('dly_printer_editor_flash').setAlign('center')"
                        style="margin: 0px;" />
                    <input type="button" value="居右" class="dele" onclick="document.getElementById('dly_printer_editor_flash').setAlign('right')"
                        style="margin: 0px;" />
                    <input id="flashData" name="flashData" type="hidden" runat="server" style="margin: 0px;"
                        class="dele" />
                    <asp:Button ID="Button1Submit" runat="server" Text="保存快递" CssClass="dele" OnClick="Button1Submit_Click"
                        OnClientClick="return saveData();" />
                    <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick="return checkinput();"
                        Text="添加" Visible="true" CssClass="dele" Style="margin: 5px 0px 0px 5px;" />
                    <input type="button" class="dele" value="返回列表" onclick="window.location.href='S_OrderExpress_List.aspx'" />
                </div>
            </div>
            <div id="dly_printer_editor" style="border-right: #999 1px solid; border-top: #999 1px solid;
                border-left: #999 1px solid; width: 762px; border-bottom: #999 1px solid; height: 615px;
                margin-top: 10px; border-solid: 1px 1px 0 0; margin-left: 16px;">
                <object id="dly_printer_editor_flash" type="application/x-shockwave-flash" data="swf/printer.swf?1338626378"
                    width="100%" height="100%">
                    <param value="high" name="quality" />
                    <param name="movie" value="swf/printer.swf">
                    <param value="always" name="allowScriptAccess" />
                    <param value="opaque" name="wMode" />
                    <param value="true" name="swLiveConnect" />
                    <param name="flashVars" runat="server" id="paraTemppara" />
                    <asp:HiddenField runat="server" ID="hTempData" />
                </object>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
