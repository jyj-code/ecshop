<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<h2 class="penis">店内搜索</h2>
<div class="ks_panel">
    
    <div class="search_form">
        <ul>
            <li class="keyword">
                <label>关键字：</label>
                <span><asp:TextBox ID="TextBoxKeywordsSearch" MaxLength="18" runat="server"></asp:TextBox></span>
            </li>
            <li class="price">
                <label>价&nbsp;&nbsp;格：</label>
                <span>
                    <asp:TextBox ID="TextBoxPriceStartSearch" MaxLength="4" runat="server"></asp:TextBox>                    
                    到
                    <asp:TextBox ID="TextBoxPriceEndSearch" MaxLength="4" runat="server"></asp:TextBox>                    
                </span>
                <p>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriceStart" runat="server"
                        ControlToValidate="TextBoxPriceStartSearch" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPriceEndSearch"
                        ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                </p>
            </li>
            <li class="submit">
                <asp:Button ID="ButtonSearch" runat="server" Text="" CssClass="button" />
            </li>
        </ul>
    </div>
</div>
