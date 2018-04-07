<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">
            <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增发货信息"></asp:Label></span>
    </p>
    <div class="content">
        <table border="0" cellpadding="0" cellspacing="1">
            <tr>
                <th align="right" width="180px;">
                    <asp:Label ID="LabelName" runat="server" Text="发货点名称："></asp:Label>
                </th>
                <td valign="middle">
                    <asp:TextBox ID="TextBoxShipperName" runat="server" CssClass="tinput_op">
                    </asp:TextBox>
                    <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*" CssClass="star"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxShipperName"
                        Display="Dynamic" ErrorMessage="该值不能为空">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                        ControlToValidate="TextBoxShipperName" Display="Dynamic" ErrorMessage="标题最多200个字符"
                        ValidationExpression="^[\s\S]{0,200}$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="LabelScore" runat="server" Text="发货人："></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="TextBoxSendName" runat="server" CssClass="tinput_op">
                    </asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*" CssClass="star"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxSendName"
                        Display="Dynamic" ErrorMessage="该值不能为空">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxSendName"
                        Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="LabelSendAddress" runat="server" Text="发货地址："></asp:Label>
                </th>
                <td>
                    <asp:HiddenField ID="HiddenFieldSelectDispatch" Value="0" runat="server" />
                    <asp:DropDownList ID="DropDownListDispatchRegionCode1" runat="server" AutoPostBack="true"
                        CssClass="tselect_op1">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListDispatchRegionCode2" runat="server" AutoPostBack="true"
                        CssClass="tselect_op1" Style="margin-left: 5px;">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListDispatchRegionCode3" runat="server" AutoPostBack="true"
                        CssClass="tselect_op1" Style="margin-left: 5px;">
                    </asp:DropDownList>
                    <span style="color: Red" cssclass="star">*</span>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="Label5" runat="server" Text="详细地址："></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="tinput_op">
                    </asp:TextBox>
                    <asp:Label ID="Label6" runat="server" ForeColor="#FF0066" Text="*" CssClass="star"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAddress"
                        Display="Dynamic" ErrorMessage="该值不能为空">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxAddress"
                        Display="Dynamic" ErrorMessage="标题最多200个字符" ValidationExpression="^[\s\S]{0,200}$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="LabelPayoutMoney" runat="server" Text="手机号码："></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="TextBoxMobile" runat="server" CssClass="tinput_op">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMobile" runat="server"
                        ControlToValidate="TextBoxMobile" Display="Dynamic" ErrorMessage="请填写正确的手机号"
                        ValidationExpression="^(1[3|5|8][0-9])\d{8}$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="LabelDiscount" runat="server" Text="电话号码："></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="TextBoxPhone" runat="server" CssClass="tinput_op">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxPhone" runat="server"
                        ControlToValidate="TextBoxPhone" Display="Dynamic" ErrorMessage="请填写正确的电话号码"
                        ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="Label2" runat="server" Text="邮编："></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="TextBoxPostalCode" MaxLength="9" runat="server" CssClass="tinput_op">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="LabelIsDefault" runat="server" Text="是否默认发货人："></asp:Label>
                </th>
                <td>
                    <asp:CheckBox ID="CheckBoxIsDefault" runat="server" Text="是" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    <asp:Label ID="LabelMemo" runat="server" Text="备注："></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="TextBoxRemark" runat="server" TextMode="MultiLine" CssClass="tinput_op1">
                    </asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="tablebtn">
        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="Submit" CssClass="fanh"
            Style="background: url(images/baocbtn.jpg) no-repeat;" />
        <%--<input id="inputReset" runat="server" type="reset" value="重置" class="fanh" />--%>
        <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="../S_OrderShipper_List.aspx"
            CausesValidation="false" Style="background: url(images/baocbtn.jpg) no-repeat;" />
    </div>
</div>
<asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
