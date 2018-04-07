<%@ Control Language="C#"%>
<!--左边导航nav-->
<div id="left">
    <div id="left_top">
    </div>
    <div class="sdmenu">
        <div id="ti01" onclick="te_show(1,this)">
            <span class="fh1 fh">个人资料</span></div>
        <div id="te01" style="display: block;" class="lmf_submenu">
            <a target="win" href="A_MemInfo.aspx" onclick="subItem(this)" class="lmf_act">会员个人信息</a>
            <a target="win" href="A_PwdSer.aspx" onclick="subItem(this)" class="lmf_act">账户安全设置</a>
        </div>
        <div id="ti02" onclick="te_show(2,this)">
            <span class="fh2 fh">收货地址</span></div>
        <div id="te02" style="display: block;" class="lmf_submenu">
            <a target="win" href="A_ShipAddress.aspx" onclick="subItem(this)" class="lmf_act">收货地址</a>
        </div>
        <div id="ti03" onclick="te_show(3,this)">
            <span class="fh3 fh">我的账户</span></div>
        <div id="te03" style="display: block;" class="lmf_submenu">
            <a target="win" href="A_Welcome.aspx" onclick="subItem(this)" class="lmf_act">我的账户</a>
            <a target="win" href="A_AdPayDecrease.aspx" onclick="subItem(this)" class="lmf_act">预存款提现</a>
            <a target="win" href="A_AdPayRecharge.aspx" onclick="subItem(this)" class="lmf_act">预存款充值</a>
            <a target="win" href="A_AdPayTransfer.aspx" onclick="subItem(this)" class="lmf_act">预存款转账</a>
            <a target="win" href="A_AdPayDetailList.aspx" onclick="subItem(this)" class="lmf_act">预存款明细</a>
        </div>
    </div>
    <div id="left_bot">
    </div>
    
</div>