<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<% DataTable dt_Prop = ProductProp.dt_Prop;
    DataTable dt_SubProp = null; %>
<div class="aBox11 clearfix" style="border-top:1px solid #D3D3D3;">
    <div class="content">
        <ul class="ProductProp clearfix">
        <%if (dt_Prop != null)
          {
              for (int i = 0; i < dt_Prop.Rows.Count; i++)
              {
                  string strId=dt_Prop.Rows[i]["id"].ToString();
                  string strName=dt_Prop.Rows[i]["PropName"].ToString();
                  string strSt = dt_Prop.Rows[i]["showtype"].ToString();
                  %>
                        <li class="li1">
                        <%
                  if (strSt != "4" & strSt != "0")
                          { %>
                        <%=strName%>：<%} %></li>
                        <li class="li2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                <%
                                  dt_SubProp = ProductProp.dt_SubPropv(strId);
                                  for (int j = 0; j < dt_SubProp.Rows.Count; j++)
                                  {
                                      string strShowType = dt_SubProp.Rows[j]["showtype"].ToString();
                                      string strsubId = dt_SubProp.Rows[j]["propvalueid"].ToString();
                                      string strV = dt_SubProp.Rows[j]["InputValue"].ToString();
                                      if (strV != "")
                                      {
                                %>
                                <!--根据不同的类型显示不同的布局-->   
                                 <%if (strShowType == "3")//多选
                                   { %>  
                                        
                                       <td style="min-width:30px;"> <%=ProductProp.GetPropValue(strsubId)%></td> 
                                 <%}
                                   else if (strShowType == "1" || strShowType == "2")//单选或下拉
                                   { %>
                                         <td><%=ProductProp.GetPropValue(strsubId)%> </td>
                                 <%}
                                   else if (strShowType == "0") //文本框输入
                                   { %>  
                                        <td><%=ProductProp.GetPropValue(strsubId)%>：<%=strV + ""%> </td>
                                 <%}
                                   else if (strShowType == "4") //自定义属性
                                   {
                                       if (strV.IndexOf("*") != -1)
                                       {%> <td>
                                           <%for (int m = 0; m < strV.Split('*').Length; m++)
                                             {%>
                                              <%=" " + strV.Split('*')[m].Split('%')[0]%>:<%=strV.Split('*')[m].Split('%')[1]%>
                                           <%}%>
                                            </td>    
                                       <%}
                                       else if (strV.IndexOf("%") != -1 && strV.Split('%')[0] != "")
                                       {%>
                                            <td><%=strV.Split('%')[0]%>:<%=strV.Split('%')[1]%> </td>
                                       <%}%>
                                 <%} %>       
                                <!--根据不同的类型显示不同的布局-->          
                                  <%}
                                  } %>
                                  </tr>
                            </table>
                        </li>
			<%}
          } %>
        </ul>
    </div>
</div>
