﻿<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<link rel='stylesheet' type='text/css' href='style/dshow.css' />

<script type="text/javascript" language="javascript" src="js/dshow.js"></script>

<%DataTable dt = S_ThemeProductList.dt_GroupProduct; %>
<div class="ordmain1" id="content">
    <div class="biaogenr">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tb2">
            <tr>
                <th width="80%" class="th_le">
                    商品名称
                </th>
                
                <th width="20%">
                    审核状态
                </th>
            </tr>
            <!--循环代码-->
            <%if (dt != null)
              {
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      string strId = dt.Rows[i]["guid"].ToString();
                      string strName = dt.Rows[i]["ProductName"].ToString();
                      string strThemeImg = dt.Rows[i]["ProductImage"].ToString();
                      string strState = dt.Rows[i]["IsAudit"].ToString();
                      switch (strState.Trim())
                      {
                          case "0": strState = "<font color=red>未审核</font>"; break;
                          case "1": strState = "<font color=green>已通过</font>"; break;
                          case "2": strState = "<font color=red>未通过</font>"; break;
                          case "3": strState = "<font color=yellow>已结束</font>"; break;
                      }
                      string strProductUrl = ShopUrlOperate.RedirectProductDetailByMemloginIDNew(dt.Rows[i]["ProductGuid"].ToString(), dt.Rows[i]["MemloginId"].ToString(), "0", "0");
                          %>
            <tr>
                <td style="text-align: left;">
                    <a href="<%=strProductUrl %>" target="_blank" style="float: left; display: block;">
                        <img src="<%=strThemeImg %>" width="60" height="60" onerror="javascript:this,src='/ImgUpload/noImg.jpg_60x60.jpg'" /></a>
                    <a href="<%=strProductUrl %>" target="_blank" style="float: left; display: block; padding-left: 10px;
                        width: 210px;">
                        <%=strName%></a>
                </td>
                <td style="color: #D46A20;">
                   <%=strState%>
                </td>
            </tr>
            <%}
              }%>
            <!--循环代码-->
        </table>
        <%if (dt == null)
          { %>
        <div class="no_datas">
            <div class="no_data">
                暂无主题活动商品数据</div>
        </div>
        <%} %>
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    $(function(){
        $(".join").click(function(){
            $(this).next().text();
           $("#ThemeGuid").val($(this).next().text());
            funOpen();
        });
    })
</script>
