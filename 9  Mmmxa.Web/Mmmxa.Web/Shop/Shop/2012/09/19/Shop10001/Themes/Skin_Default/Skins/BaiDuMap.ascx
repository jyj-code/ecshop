<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />

<div class="outlet">
    <div class="outlet-left">
        <%--<div class="outlet-filter">
            <table>
                <tbody>

                    <tr>
                        <th>
                            <em>|</em>
                            <h4>
                                <img src="http://static.qccr.com/upload/2015/09/beauty.png">店铺一级</h4>
                        </th>
                        <td>
                            <span class="item " di="30" cid="4">普通洗车
                                            <em class="list_tips"></em>
                            </span>
                            <span class="item " di="31" cid="6">精细洗车
                                            <em class="list_tips"></em>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <em>|</em>
                            <h4>
                                <img src="http://static.qccr.com/upload/2015/09/maintain.png">
                                店铺二级
                            </h4>
                        </th>
                        <td>
                            <span class="item " di="5" cid="12|12">小保养
                                            <em class="list_tips"></em>
                            </span>
                            <span class="item " di="6" cid="12|19|20">大保养
                                            <em class="list_tips"></em>
                            </span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>--%>
        <div class="condition">
            <div class="cond-bar clearfix">
                <div class="region_select" style="width: 361px; height: 31px; line-height: 31px;">
                    <ul class="areaSelect">
                        <li>
                            <span style="font-weight: 700">店铺分类</span>
                        </li>
                      <%--  <li>
                           <span>店铺二级</span>
                        </li>
                        <li>
                           <span>店铺三级</span>--%>
                    </ul>
                </div>
                <div class="region_select" style="width: 361px; height: 31px; line-height: 31px;">
                    <ul class="areaSelect">
                        <li>
                            <asp:DropDownList ID="ddlfirst" runat="server" CssClass="selectItem" onchange="bindCategory(this,1);GetShops();">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:DropDownList ID="ddlsecond" runat="server" CssClass="selectItem" onchange="bindCategory(this,2);GetShops();">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:DropDownList ID="ddlthird" runat="server" CssClass="selectItem" onchange="GetShops();">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                    </ul>
                </div>
                <div class="region_select" style="width: 361px; height: 31px; line-height: 31px;">
                    <ul class="areaSelect">
                        <li>
                            <span style="font-weight: 700">省</span><asp:DropDownList ID="ddlProvince" runat="server" CssClass="selectItem" onchange="document.getElementById('HiddenRegion1').value=this.options[this.selectedIndex].text;BindDropDownShopCategory2(this);GetShops();">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <select name="ddlProvince" class="selectItem">
                                <option value="-1">---请选择---</option>
                            </select>--%>
                        </li>
                        <li>
                            <span style="font-weight: 700">市</span><asp:DropDownList ID="dropdownlistCity" runat="server" CssClass="selectItem" onchange="document.getElementById('HiddenRegion2').value=this.options
[this.selectedIndex].text;BindDropDownShopCategory3(this);GetShops();">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>

                            <%-- <select name="ddlCity" class="selectItem">
                                <option value="-1">---请选择---</option>
                            </select>--%>
                        </li>
                        <li>
                            <span style="font-weight: 700">区</span><asp:DropDownList ID="dropdownlistArea" runat="server" CssClass="selectItem" onchange="document.getElementById('HiddenRegion3').value=this.options[this.selectedIndex].text;GetShops();">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <%--<select name="ddlArea" class="selectItem">
                                <option value="-1">---请选择---</option>
                            </select></li>--%>
                    </ul>
                </div>

                <div class="oyt-position clearfix">
                    <p class="row"><span id="size" style="text-algin: right; float: right; margin-top: 4px;"></span></p>
                </div>
            </div>
        </div>
        <div class="storelist">
            <ul id="shopinfo">
               <%-- <li class="clearfix">
                    <img src="http://static.qichechaoren.com/thumb/twl/contract/2016/10/9076ebc8eb5a6b8a,h_200,w_200.jpeg">
                    <div class="store-info">
                        <p class="name"><a href="/store/22981.jhtml" target="_blank">车爵士汽车养护服务(白渡路店)</a></p>
                        <p class="sco">
                            <span class="stroe-score10"></span>
                            5分
                        </p>
                        <p class="adrs">地址：上海市黄浦区白渡路291号</p>
                        <p class="tel">电话：021-63321120</p>
                    </div>
                </li>--%>
            </ul>
        </div>
    </div>
    <div class="warp outlet-right">
        <div class="MapSearch">
            <input type="text" class="text" id="txtAdress" />
            <input type="button" class="btn" value="" id="btnSearch" />
        </div>
        <div id="l-map" style="height: 600px;">
        </div>
        <div>
            <asp:HiddenField ID="hdShopName" runat="server" />
            <asp:HiddenField ID="hdShopAdress" runat="server" />
            <asp:HiddenField ID="hdMapValue" runat="server" />
            <input id="HiddenRegion1" name="HiddenRegion1" type="hidden" />
            <input id="HiddenRegion2" name="HiddenRegion2" type="hidden" />
            <input id="HiddenRegion3" name="HiddenRegion3" type="hidden" />
            <asp:HiddenField ID="hiddenCategory" runat="server" />
            <%--<input id="hiddenCategory" name="hiddenCategory" type="hidden">--%>
            <asp:HiddenField runat="server" ID="hiddenCategoryId"/>
            <asp:HiddenField runat="server" ID="HiddenDropdownAddress"/>
        </div>
    </div>
</div>


<script type="text/javascript">

    // function GetShops(obj, type)
    function GetShops() {
        var ddlfirst = ' ', ddlsecond = ' ', ddlthird = ' ', ddlprovince = ' ', ddlcity = ' ', ddlarea = ' ';
        //var ddlsecond
        //var ddlType = type;
        //var ddlCode = obj.options[obj.selectedIndex].value;
        var ddlfirstOption = $('#BaiDuMap_ctl00_ddlfirst').find("option:selected");
        if (ddlfirstOption.val() != '-1') {
            ddlfirst = ddlfirstOption.attr('Code');
        }
        var ddlsecondOption = $('#BaiDuMap_ctl00_ddlsecond').find("option:selected");
        if (ddlsecondOption.val() != '-1') {
            ddlsecond = ddlsecondOption.attr('Code');
        }
        var ddlthirdOption = $('#BaiDuMap_ctl00_ddlthird').find("option:selected");
        if (ddlthirdOption.val() != '-1') {
            ddlthird = ddlthirdOption.attr('Code');
        }
        var ddlprovinceOption = $('#BaiDuMap_ctl00_ddlProvince').find("option:selected");
        if (ddlprovinceOption.val() != '-1') {
            ddlprovince = ddlprovinceOption.text(); //attr('Code');
        }
        var ddlcityOption = $('#BaiDuMap_ctl00_dropdownlistCity').find("option:selected");
        if (ddlcityOption.val() != '-1') {
            ddlcity = ddlcityOption.text();//.attr('Code');
        }
        var ddlareaOption = $('#BaiDuMap_ctl00_dropdownlistArea').find("option:selected");
        if (ddlareaOption.val() != '-1') {
            ddlarea = ddlareaOption.text();//.attr('Code');
        }
       // console.log(ddlprovince);
        var params = { 'type': 'baidumap', 'ddlfirst': ddlfirst, 'ddlsecond': ddlsecond, 'ddlthird': ddlthird, 'ddlprovince': ddlprovince, 'ddlcity': ddlcity, 'ddlarea': ddlarea };
        $.getJSON('/Main/Api/Address.ashx', params, function (data) {
            $('#shopinfo').html('');
            // console.log(data);
            var shopcount = data.length;
            if (data.length > 0) {
                var infohtml = '';
                for (var i = 0; i < data.length; i++) {
                    infohtml += ' <li class="clearfix" lat=' + data[i].Lat + ' lon=' + data[i].Lon + ' address=' + data[i].Address + ' shopname=' + data[i].ShopName + ' onclick=directMap(this);> ';
                    infohtml += ' <img src=' + data[i].ShopPic + '> ';
                    infohtml += ' <div class="store-info"> ';
                    infohtml += ' <p class="name"><a href="javascript:;">'+data[i].ShopName+'</a></p> ';
                    infohtml += ' <p class="adrs">' + data[i].Address + '</p> ';
                    infohtml += ' <p class="tel">电话：' + data[i].Phone + '</p> ';
                    infohtml += ' </div></li> ';


                    var point = new BMap.Point(data[i].Lon, data[i].Lat);
                    //map.centerAndZoom(point, 15);
                    var marker = new BMap.Marker(point);  // 创建标注
                    map.addOverlay(marker);              // 将标注添加到地图中
                    marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画

                    //var opts = {
                    //    width: 200,     // 信息窗口宽度
                    //    height: 60,     // 信息窗口高度
                    //    title: data[i].ShopName, // 信息窗口标题
                    //    enableMessage: true,//设置允许信息窗发送短息
                    //    message: data[i].Address
                    //}
                    //var infoWindow = new BMap.InfoWindow(data[i].Address, opts);  // 创建信息窗口对象
                    //map.openInfoWindow(infoWindow, point); //开启信息窗口
                }
                $('#shopinfo').html(infohtml);
            }
            $('#size').html("共有"+shopcount+"家门店");
        });
        var local = new BMap.LocalSearch(map, {
            renderOptions: {
                map: map,
                autoViewport: true,
                selectFirstResult: true
            },
            pageCapacity: 1
        });
        local.search(ddlprovince+ddlcity+ddlarea);
    }

    function bindCategory(obj, currentIndex) {
        //console.log('2');
        //console.log(obj);
        //console.log(obj.selectedIndex);
        var ddlId = obj.options[obj.selectedIndex].value;
        //   console.log(ddlId);
        var params = { 'type': 'category', 'categoryId': ddlId };

        switch (currentIndex) {
            case 1:
                $("#BaiDuMap_ctl00_ddlsecond").html("");
                $("#BaiDuMap_ctl00_ddlsecond").append("<option value=\"-1\" selected='selected'>-请选择-</option>");
                $("#BaiDuMap_ctl00_ddlsecond").hide();
                $("#BaiDuMap_ctl00_ddlthird").hide();
                $.getJSON("/Main/Api/Address.ashx?type=category&categoryId=" + ddlId, function (json) {
                    if (json == null || json == "") {
                        return;
                    }

                    $("#BaiDuMap_ctl00_ddlsecond").show();
                    $.each(json, function (i) { $("#BaiDuMap_ctl00_ddlsecond").append("<option value='" + json[i].Id + "' Code='" + json[i].Code + "'>" + json[i].Name + "</option>"); });
                });
                break;
            case 2:
                $("#BaiDuMap_ctl00_ddlthird").html("");
                $("#BaiDuMap_ctl00_ddlthird").append("<option value=\"-1\" selected='selected'>-请选择-</option>");
                $("#BaiDuMap_ctl00_ddlthird").hide();
                $.getJSON("/Main/Api/Address.ashx?type=category&categoryId=" + ddlId, function (json) {
                    if (json == null || json == "") {
                        return;
                    }

                    $("#BaiDuMap_ctl00_ddlthird").show();
                    $.each(json, function (i) { $("#BaiDuMap_ctl00_ddlthird").append($("<option></option>").val(json[i].Value).html(json[i].Name)); });
                });
                break;
            case 3:
                break;
        }
    }

    function BindDropDownShopCategory2(dlist) {
        // console.log(dlist);
        var ccode = dlist.options[dlist.selectedIndex].value;
        params = { 'cityid': ccode };
        $("#BaiDuMap_ctl00_dropdownlistCity").html("");
        $("#BaiDuMap_ctl00_dropdownlistCity").append("<option value=\"-1\" selected='selected'>-请选择-</option>");
        $("#BaiDuMap_ctl00_dropdownlistCity").hide();
        $("#BaiDuMap_ctl00_dropdownlistArea").hide();

        $.getJSON("/Main/Api/AddressOpreateJson.aspx", params, function (json) {
            if (json == null || json == "") {
                return;
            }

            $("#BaiDuMap_ctl00_dropdownlistCity").show();
            $.each(json, function (i) { $("#BaiDuMap_ctl00_dropdownlistCity").append($("<option></option>").val(json[i].Value).html(json[i].Name)) });
        });

    }

    function BindDropDownShopCategory3(dlist) {

        var ccode = new String();

        var code = new Array();
        code = dlist.options[dlist.selectedIndex].value;
        ccode = code.split('/')[1];
        params = { 'cityid': ccode };
        $("#BaiDuMap_ctl00_dropdownlistArea").html("");
        $("#BaiDuMap_ctl00_dropdownlistArea").append("<option value=\"-1\" selected='selected'>-请选择-</option>");
        $("#BaiDuMap_ctl00_dropdownlistArea").hide();

        $.getJSON("/Main/Api/AddressOpreateJson.aspx", params, function (json) {
            if (json == null || json == "") {
                return;
            }
            $("#BaiDuMap_ctl00_dropdownlistArea").show();
            $.each(json, function (i) { $("#BaiDuMap_ctl00_dropdownlistArea").append($("<option></option>").val(json[i].Value).html(json[i].Name)); });
        });

    }
    // 百度地图API功能
    var result = $("#<%=hdMapValue.ClientID%>").val();


    var map = new BMap.Map("l-map");                        // 创建Map实例


    var point = new BMap.Point(result.split(',')[0], result.split(',')[1]);

    map.centerAndZoom(point, 15);     // 初始化地图,设置中心点坐标和地图级别

    var local = new BMap.LocalSearch(map, {
        renderOptions: { map: map, selectFirstResult: false, autoViewport: false }
    });
    local.searchInBounds("商场", map.getBounds());

    map.centerAndZoom(point, 15);     // 初始化地图,设置中心点坐标和地图级别

    var marker = new BMap.Marker(point);  // 创建标注
    map.addOverlay(marker);              // 将标注添加到地图中
    marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画


    map.addControl(new BMap.NavigationControl());               // 添加平移缩放控件
    map.addControl(new BMap.ScaleControl());                    // 添加比例尺控件
    map.addControl(new BMap.OverviewMapControl());              //添加缩略地图控件
    map.enableScrollWheelZoom();                            //启用滚轮放大缩小
    //map.setCurrentCity("武汉");          // 设置地图显示的城市 此项是必须设置的
    map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM }));  //右下角，仅包含缩放按钮

    var opts = {
        width: 200,     // 信息窗口宽度
        height: 60,     // 信息窗口高度
        title: $("#<%=hdShopName.ClientID%>").val(), // 信息窗口标题
        enableMessage: true,//设置允许信息窗发送短息
        message: $("#<%=hdShopAdress.ClientID%>").val()
    }
    var infoWindow = new BMap.InfoWindow($("#<%=hdShopAdress.ClientID%>").val(), opts);  // 创建信息窗口对象
    map.openInfoWindow(infoWindow, point); //开启信息窗口



    $(function () {
        var hiddenCagegoryId = $.trim($('#BaiDuMap_ctl00_hiddenCategoryId').val());
        var hiddenAddress = $.trim($('#BaiDuMap_ctl00_HiddenDropdownAddress').val()).split(',');
        switch (hiddenCagegoryId.length) {
            case 3:
                $('#BaiDuMap_ctl00_ddlfirst').find('option[Code=' + hiddenCagegoryId + ']').attr('selected', true);
                break;
            case 6:
                $('#BaiDuMap_ctl00_ddlfirst').find('option[Code=' + hiddenCagegoryId.substring(0, 3) + ']').attr('selected', true);
                $('#BaiDuMap_ctl00_ddlsecond').find('option[Code=' + hiddenCagegoryId.substring(3, 3) + ']').attr('selected', true);
                break;
            case 9:
                $('#BaiDuMap_ctl00_ddlfirst').find('option[Code=' + hiddenCagegoryId.substring(0, 3) + ']').attr('selected', true);
                $('#BaiDuMap_ctl00_ddlsecond').find('option[Code=' + hiddenCagegoryId.substring(3, 3) + ']').attr('selected', true);
                $('#BaiDuMap_ctl00_ddlthird').find('option[Code=' + hiddenCagegoryId.substring(6, 3) + ']').attr('selected', true);
                break;
        }

        switch (hiddenAddress.length) {
            case 1:
                $('#BaiDuMap_ctl00_ddlProvince').find('option[text='+hiddenAddress[0]+']').attr('selected', true);
                break;;
            case 2:
                $('#BaiDuMap_ctl00_ddlProvince').find('option[text='+ hiddenAddress[0]+']').attr('selected', true);
                $('#BaiDuMap_ctl00_dropdownlistCity').find('option[text='+hiddenAddress[1]+']').attr('selected', true);
                break;
            case 3:
                $('#BaiDuMap_ctl00_ddlProvince').find('option[text='+hiddenAddress[0]+']').attr('selected', true);
                $('#BaiDuMap_ctl00_dropdownlistCity').find('option[text='+hiddenAddress[1]+']').attr('selected', true);
                $('#BaiDuMap_ctl00_dropdownlistArea').find('option[text='+hiddenAddress[2]+']').attr('selected', true);
                break;
        }

        GetShops();

        $("#btnSearch").click(function () {
            var local = new BMap.LocalSearch(map, {
                renderOptions: {
                    map: map,
                    autoViewport: true,
                    selectFirstResult: true
                },
                pageCapacity: 1
            });
            local.search($("#txtAdress").val());
        });

        //var categorys = eval($('#BaiDuMap_ctl00_hiddenCategory').val());
        //if (categorys.length > 0) {
        //    var tbodyhtml = "<tbody>";
        //    $.each(categorys, function (index, item) {

        //        var itemdata = eval(item.ItemList);
        //        if (itemdata.length > 0) {
        //            tbodyhtml += "<tr><th><em>|</em><h4 code='" + item.Code + "' currentid='" + item.ID + "'>" + item.Name + "</h4></th>";
        //            tbodyhtml += "<td>";
        //            $.each(itemdata, function (itmIndex, itmItem) {
        //                tbodyhtml += "<span class='item' code='" + itmItem.Code + "' currentid='" + itmItem.ID + "'>"+itmItem.Name+"<em class='list_tips'></em></span>";
        //            });
        //            tbodyhtml += "</td>";
        //            tbodyhtml += "</tr>"
        //        }

        //    });
        //    tbodyhtml += "</tbody>";
        //    $('.outlet-filter>table').append(tbodyhtml);
        //}
    });

    function directMap(obj) {
       // map.clearOverlay();
        var lon = $(obj).attr('lon');
        var lat = $(obj).attr('lat');
        var shopname = $(obj).attr('shopname');
        var address = $(obj).attr('address');
        var point = new BMap.Point(lon, lat);
        map.centerAndZoom(point, 15);
        var marker = new BMap.Marker(point);  // 创建标注
        map.addOverlay(marker);              // 将标注添加到地图中
        marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画

        var opts = {
            width: 200,     // 信息窗口宽度
            height: 60,     // 信息窗口高度
            title: shopname, // 信息窗口标题
            enableMessage: true,//设置允许信息窗发送短息
            message: address
        }
        var infoWindow = new BMap.InfoWindow(address, opts);  // 创建信息窗口对象
        map.openInfoWindow(infoWindow, point); //开启信息窗口
    }
</script>

