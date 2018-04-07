<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />

<div class="MapSearch">
    <input type="text" class="text" id="txtAdress" />
    <input type="button" class="btn" value="" id="btnSearch" />
</div>
<div id="l-map">
</div>
<div>
<asp:HiddenField  ID="hdShopName" runat="server"/>
<asp:HiddenField  ID="hdShopAdress" runat="server"/>
<asp:HiddenField  ID="hdMapValue" runat="server"/>
</div>


<script type="text/javascript">

// 百度地图API功能
var result=$("#<%=hdMapValue.ClientID%>").val();


var map = new BMap.Map("l-map");                        // 创建Map实例


var point = new BMap.Point(result.split(',')[0],result.split(',')[1]);

map.centerAndZoom(point, 15);     // 初始化地图,设置中心点坐标和地图级别

var local = new BMap.LocalSearch(map, {
  renderOptions:{map: map,selectFirstResult: false, autoViewport: false}
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
map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM}));  //右下角，仅包含缩放按钮

var opts = {
  width : 200,     // 信息窗口宽度
  height: 60,     // 信息窗口高度
  title : $("#<%=hdShopName.ClientID%>").val() , // 信息窗口标题
  enableMessage:true,//设置允许信息窗发送短息
  message:$("#<%=hdShopAdress.ClientID%>").val() 
}
var infoWindow = new BMap.InfoWindow($("#<%=hdShopAdress.ClientID%>").val() , opts);  // 创建信息窗口对象
map.openInfoWindow(infoWindow,point); //开启信息窗口



$(function(){

$("#btnSearch").click(function(){
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
});
  
</script>

