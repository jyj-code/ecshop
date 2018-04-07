using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[DefaultProperty("EditText2"), ToolboxData("<{0}:Num1GridView runat=server></{0}:Num1GridView>")]
	public class Num1GridView : GridView
	{
		private int int_0 = -1;
		private string string_0 = "确实要删除指定的记录吗？";
		private bool bool_0 = false;
		private bool bool_1 = false;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		private string string_7;
		private bool bool_2 = false;
		private bool bool_3 = false;
		private string string_8;
		private System.Web.UI.WebControls.Button button_0 = new System.Web.UI.WebControls.Button();
		private TextBox textBox_0 = new TextBox();
		private Label label_0 = new Label();
		private int int_1 = 0;
		private Paging.PagingStyleCollection pagingStyleCollection_0;
		protected int? _recordCount = null;
		private string string_9 = string.Empty;
		public bool Del
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}
		public bool Edit
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}
		public string SortExpressionCust
		{
			get
			{
				return this.string_8;
			}
			set
			{
				this.string_8 = value;
			}
		}
		public string EditText1
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string EditText2
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		public override object DataSource
		{
			get
			{
				return base.DataSource;
			}
			set
			{
				base.DataSource = value;
				if (value != null)
				{
					if (this.DataSource is DataSet)
					{
						this.int_1 = ((DataSet)this.DataSource).Tables[0].Rows.Count;
					}
					if (this.DataSource is ICollection)
					{
						this.int_1 = ((ICollection)this.DataSource).Count;
					}
					if (this.DataSource is DataTable)
					{
						this.int_1 = ((DataTable)this.DataSource).Rows.Count;
					}
					if (this.DataSource is DataView)
					{
						this.int_1 = ((DataView)this.DataSource).Table.Rows.Count;
					}
				}
			}
		}
		[Category("扩展"), DefaultValue(""), Description("自定义分页样式")]
		public Paging.PagingStyleCollection PagingStyle
		{
			get
			{
				return this.pagingStyleCollection_0;
			}
			set
			{
				this.pagingStyleCollection_0 = value;
			}
		}
		public SortDirection GridViewSortDirection
		{
			get
			{
				if (this.ViewState["sortDirection"] == null)
				{
					this.ViewState["sortDirection"] = SortDirection.Ascending;
				}
				return (SortDirection)this.ViewState["sortDirection"];
			}
			set
			{
				this.ViewState["sortDirection"] = value;
			}
		}
		[Category("排序"), DefaultValue("true"), Description("是否启用多列排序功能")]
		public bool AllowMultiColumnSorting
		{
			get
			{
				object obj = this.ViewState["EnableMultiColumnSorting"];
				return obj != null && bool.Parse(obj.ToString());
			}
			set
			{
				this.AllowSorting = true;
				this.ViewState["EnableMultiColumnSorting"] = value;
			}
		}
		[Category("排序"), DefaultValue(""), Description("升序时显示图标"), Editor("System.Web.UI.Design.UrlEditor", typeof(UITypeEditor))]
		public string SortAscImageUrl
		{
			get
			{
				object obj = this.ViewState["SortImageAsc"];
				return (obj != null) ? obj.ToString() : "";
			}
			set
			{
				this.ViewState["SortImageAsc"] = value;
			}
		}
		[Category("排序"), DefaultValue(""), Description("降序时显示图标"), Editor("System.Web.UI.Design.UrlEditor", typeof(UITypeEditor))]
		public string SortDescImageUrl
		{
			get
			{
				object obj = this.ViewState["SortImageDesc"];
				return (obj != null) ? obj.ToString() : "";
			}
			set
			{
				this.ViewState["SortImageDesc"] = value;
			}
		}
		public string EditText3
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public string DeletePromptText
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public bool FixHeader
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public bool AddSequenceColumn
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}
		public override int PageSize
		{
			get
			{
				return base.PageSize;
			}
			set
			{
				base.PageSize = value;
			}
		}
		public string TableName
		{
			get
			{
				return this.string_9;
			}
			set
			{
				this.string_9 = value;
			}
		}
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			if (!this.Page.IsClientScriptBlockRegistered("gridFunctions"))
			{
				this.Page.RegisterClientScriptBlock(this.UniqueID + "_rowFunc", "<script language=\"Javascript\" type=\"text/javascript\">var oldcolor;function Num1GridViewShow_mout(rowEl){for(var i=0;i<rowEl.cells.length;i++){rowEl.cells[i].style.backgroundColor=oldcolor;}}function Num1GridViewShow_mover(rowEl){for(var i=0;i<rowEl.cells.length;i++){oldcolor = rowEl.cells[i].style.backgroundColor;rowEl.cells[i].style.backgroundColor=\"#ebeef5\";}}</script>");
			}
			ObjectDataSource objectDataSource = this.Parent.FindControl(this.DataSourceID) as ObjectDataSource;
			if (objectDataSource != null)
			{
				objectDataSource.Selected += new ObjectDataSourceStatusEventHandler(this.ods_Selected);
			}
			base.OnLoad(eventArgs_0);
		}
		protected void ods_Selected(object sender, ObjectDataSourceStatusEventArgs e)
		{
			if (e.ReturnValue is IListSource)
			{
				this._recordCount = new int?(((IListSource)e.ReturnValue).GetList().Count);
			}
		}
		protected override void OnInit(EventArgs eventArgs_0)
		{
			base.OnInit(eventArgs_0);
			this.string_1 = "Num1GridViewShow_sri";
			this.string_2 = "Num1GridViewShow_sr";
			this.string_3 = "Num1GridViewShow_mout";
			this.string_4 = "Num1GridViewShow_mover";
			for (int i = 0; i < this.Columns.Count; i++)
			{
				this.int_0 = i;
			}
		}
		public Num1GridView()
		{
			this.AutoGenerateColumns = false;
			this.PageSize = 10;
		}
		protected override void OnSorting(GridViewSortEventArgs gridViewSortEventArgs_0)
		{
			if (this.GridViewSortDirection == SortDirection.Ascending)
			{
				this.GridViewSortDirection = SortDirection.Descending;
				gridViewSortEventArgs_0.SortExpression += " DESC";
			}
			else
			{
				this.GridViewSortDirection = SortDirection.Ascending;
				gridViewSortEventArgs_0.SortExpression += " ASC";
			}
			base.OnSorting(gridViewSortEventArgs_0);
		}
		protected override void OnRowCreated(GridViewRowEventArgs gridViewRowEventArgs_0)
		{
			if (gridViewRowEventArgs_0.Row.RowType == DataControlRowType.Header)
			{
				this.DisplaySortOrderImages(this.SortExpressionCust, gridViewRowEventArgs_0.Row);
				this.CreateRow(0, 0, DataControlRowType.EmptyDataRow, DataControlRowState.Normal);
			}
			if (this.AllowPaging)
			{
				IEnumerable enumerable = this.DataSource as IEnumerable;
				if (enumerable != null)
				{
					IEnumerator enumerator = enumerable.GetEnumerator();
					int i = 0;
					while (enumerator.MoveNext())
					{
						i++;
					}
					this.Page.Visible = (i > 0);
				}
			}
			if (gridViewRowEventArgs_0.Row.RowType == DataControlRowType.Header && this.bool_0)
			{
				foreach (TableCell tableCell in gridViewRowEventArgs_0.Row.Cells)
				{
					tableCell.CssClass = "fhc";
				}
				TableCell tableCell2 = new TableCell();
				tableCell2.Text = "操作列";
				gridViewRowEventArgs_0.Row.Cells.Add(tableCell2);
			}
			else if (gridViewRowEventArgs_0.Row.RowType == DataControlRowType.Pager && this.AllowPaging)
			{
				LinkButton linkButton = new LinkButton();
				LinkButton linkButton2 = new LinkButton();
				LinkButton linkButton3 = new LinkButton();
				LinkButton linkButton4 = new LinkButton();
				linkButton.CausesValidation = false;
				linkButton2.CausesValidation = false;
				linkButton3.CausesValidation = false;
				linkButton4.CausesValidation = false;
				TableCell tableCell3 = new TableCell();
				gridViewRowEventArgs_0.Row.Controls.Clear();
				tableCell3.Height = 30;
				tableCell3.Controls.Add(new LiteralControl("<div class=\"btnlist\">"));
				HtmlGenericControl htmlGenericControl = new HtmlGenericControl("div");
				htmlGenericControl.Attributes.Add("class", "fnum");
				htmlGenericControl.Controls.Add(new LiteralControl(" 每页显示数量："));
				LinkButton linkButton5 = new LinkButton();
				linkButton5.Text = "10";
				linkButton5.ID = "linkBtnTen";
				linkButton5.CausesValidation = false;
				linkButton5.Click += new EventHandler(this.method_1);
				htmlGenericControl.Controls.Add(linkButton5);
				LinkButton linkButton6 = new LinkButton();
				linkButton6.Text = "20";
				linkButton6.ID = "linkBtnTwenty";
				linkButton6.CausesValidation = false;
				linkButton6.Click += new EventHandler(this.method_0);
				htmlGenericControl.Controls.Add(linkButton6);
				LinkButton linkButton7 = new LinkButton();
				linkButton7.Text = "50";
				linkButton7.ID = "linkBtnForty";
				linkButton7.CausesValidation = false;
				linkButton7.Click += new EventHandler(this.method_2);
				htmlGenericControl.Controls.Add(linkButton7);
				tableCell3.Controls.Add(htmlGenericControl);
				tableCell3.Controls.Add(new LiteralControl("<div class=\"fpage\"> <span style=\"padding-right: 10px;\">第"));
				tableCell3.Controls.Add(new LiteralControl("<font >" + (this.PageIndex + 1).ToString() + "</font>"));
				tableCell3.Controls.Add(new LiteralControl("页"));
				tableCell3.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				tableCell3.Controls.Add(new LiteralControl("当前页共"));
				if ((this.PageIndex + 1).ToString() == this.PageCount.ToString())
				{
					tableCell3.Controls.Add(new LiteralControl("<font >" + this.Rows.Count + "</font>"));
				}
				else
				{
					tableCell3.Controls.Add(new LiteralControl("<font >" + this.PageSize + "</font>"));
				}
				tableCell3.Controls.Add(new LiteralControl("条数据</span>"));
				tableCell3.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				tableCell3.Controls.Add(new LiteralControl("共"));
				tableCell3.Controls.Add(new LiteralControl("<font >" + this.PageCount.ToString() + "</font>"));
				tableCell3.Controls.Add(new LiteralControl("页</span>"));
				tableCell3.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				if (!string.IsNullOrEmpty(this.PagerSettings.FirstPageImageUrl))
				{
					linkButton.Text = "<<";
				}
				else
				{
					linkButton.Text = this.PagerSettings.FirstPageText;
				}
				linkButton.CommandName = "Page";
				linkButton.CommandArgument = "First";
				linkButton.Font.Underline = false;
				if (!string.IsNullOrEmpty(this.PagerSettings.PreviousPageImageUrl))
				{
					linkButton2.Text = "<img src='" + base.ResolveUrl(this.PagerSettings.PreviousPageImageUrl) + "' border='0'/>";
				}
				else
				{
					linkButton2.Text = "<<上一页";
				}
				linkButton2.CommandName = "Page";
				linkButton2.CommandArgument = "Prev";
				linkButton2.Font.Underline = false;
				linkButton2.CssClass = "gred_prev";
				linkButton3.Text = "下一页>>";
				linkButton3.CommandName = "Page";
				linkButton3.CommandArgument = "Next";
				linkButton3.Font.Underline = false;
				linkButton3.CssClass = "gred_prev";
				linkButton4.Text = ">>";
				linkButton4.CommandName = "Page";
				linkButton4.CommandArgument = "Last";
				linkButton4.Font.Underline = false;
				if (this.PageIndex <= 0)
				{
					System.Web.UI.WebControls.WebControl arg_5AD_0 = linkButton;
					linkButton2.Enabled = false;
					arg_5AD_0.Enabled = false;
				}
				else
				{
					System.Web.UI.WebControls.WebControl arg_5BF_0 = linkButton;
					linkButton2.Enabled = true;
					arg_5BF_0.Enabled = true;
				}
				if ((this.PageIndex + 1).ToString() != "1")
				{
					tableCell3.Controls.Add(linkButton);
					tableCell3.Controls.Add(linkButton2);
				}
				int num = this.PagerSettings.PageButtonCount / 2;
				int num2 = (this.PagerSettings.PageButtonCount % 2 == 0) ? (num - 1) : num;
				for (int i = 0; i < this.PageCount; i++)
				{
					if (this.PageCount <= this.PagerSettings.PageButtonCount || ((i >= this.PageIndex - num2 || this.PageCount - 1 - i <= this.PagerSettings.PageButtonCount - 1) && (i <= this.PageIndex + num || i <= this.PagerSettings.PageButtonCount - 1)))
					{
						if (i == this.PageIndex)
						{
							tableCell3.Controls.Add(new LiteralControl("<span class=\"cur\">" + (i + 1).ToString() + "</span>"));
						}
						else
						{
							LinkButton linkButton8 = new LinkButton();
							linkButton8.Text = (i + 1).ToString();
							linkButton8.CommandName = "Page";
							linkButton8.CommandArgument = (i + 1).ToString();
							linkButton8.CausesValidation = false;
							tableCell3.Controls.Add(linkButton8);
						}
					}
				}
				if (this.PageIndex >= this.PageCount - 1)
				{
					System.Web.UI.WebControls.WebControl arg_750_0 = linkButton3;
					linkButton4.Enabled = false;
					arg_750_0.Enabled = false;
				}
				else
				{
					System.Web.UI.WebControls.WebControl arg_762_0 = linkButton3;
					linkButton4.Enabled = true;
					arg_762_0.Enabled = true;
					tableCell3.Controls.Add(linkButton3);
					tableCell3.Controls.Add(linkButton4);
				}
				tableCell3.ColumnSpan = this.Columns.Count;
				tableCell3.Controls.Add(new LiteralControl("到第"));
				this.textBox_0.Width = 35;
				this.textBox_0.Text = "";
				tableCell3.Controls.Add(this.textBox_0);
				this.label_0.Visible = false;
				this.label_0.ForeColor = ColorTranslator.FromHtml("red");
				this.label_0.Width = 20;
				tableCell3.Controls.Add(this.label_0);
				tableCell3.Controls.Add(new LiteralControl("页"));
				this.button_0.Text = "确定";
				this.button_0.CssClass = "quedbtn";
				tableCell3.Controls.Add(this.button_0);
				tableCell3.Controls.Add(new LiteralControl("</div>"));
				tableCell3.Controls.Add(new LiteralControl("<div class=\"clear\"></div>"));
				tableCell3.Controls.Add(new LiteralControl("</div>"));
				gridViewRowEventArgs_0.Row.Controls.Add(tableCell3);
				this.button_0.Click += new EventHandler(this.button_0_Click);
				this.button_0.CausesValidation = false;
			}
			base.OnRowCreated(gridViewRowEventArgs_0);
		}
		private void method_0(object sender, EventArgs e)
		{
			((LinkButton)sender).CssClass = "cur";
			this.PageSize = 20;
		}
		private void method_1(object sender, EventArgs e)
		{
			((LinkButton)sender).CssClass = "cur";
			this.PageSize = 10;
		}
		private void method_2(object sender, EventArgs e)
		{
			((LinkButton)sender).CssClass = "cur";
			this.PageSize = 50;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.textBox_0.Text.Trim() == "")
			{
				this.label_0.Visible = true;
				this.label_0.Text = "请填写转到页数";
				this.textBox_0.Text = "0";
			}
			else
			{
				try
				{
					int.Parse(this.textBox_0.Text.Trim());
				}
				catch (Exception)
				{
					this.label_0.Visible = true;
					this.label_0.Text = "请填写真实的页码";
					this.textBox_0.Text = "0";
				}
			}
			if (int.Parse(this.textBox_0.Text.Trim()) < 1)
			{
				this.textBox_0.Text = "1";
			}
			this.label_0.Visible = true;
			this.button_0.CommandName = "Page";
			this.button_0.CommandArgument = this.textBox_0.Text.Trim();
		}
		protected override void OnRowDeleted(GridViewDeletedEventArgs gridViewDeletedEventArgs_0)
		{
			if (this.Rows.Count == 1 && this.PageIndex > 0)
			{
				this.PageIndex--;
			}
			base.OnRowDeleted(gridViewDeletedEventArgs_0);
		}
		protected override void OnRowDataBound(GridViewRowEventArgs gridViewRowEventArgs_0)
		{
			if (this.AllowPaging)
			{
				IEnumerable enumerable = this.DataSource as IEnumerable;
				if (enumerable != null)
				{
					IEnumerator enumerator = enumerable.GetEnumerator();
					int num = 0;
					while (enumerator.MoveNext())
					{
						num++;
					}
					this.Page.Visible = (num > 0);
				}
			}
			string[] array = new string[]
			{
                //-2147483648.ToString(),
                //-79228162514264337593543950335m.ToString(),
                //-79228162514264337593543950335m.ToString("0.00"),
                //-79228162514264337593543950335m.ToString("0.000"),
                //-79228162514264337593543950335m.ToString("0.0000"),
				DateTime.MinValue.ToString(),
				DateTime.MinValue.ToShortDateString(),
				DateTime.MinValue.ToString("yyyy年M月d日"),
				DateTime.MinValue.ToString("yyyy年MM月dd日")
			};
			foreach (TableCell tableCell in gridViewRowEventArgs_0.Row.Cells)
			{
				if (Array.IndexOf<string>(array, tableCell.Text) >= 0)
				{
					tableCell.Text = "";
				}
			}
			if (gridViewRowEventArgs_0.Row.RowType == DataControlRowType.DataRow)
			{
				gridViewRowEventArgs_0.Row.Style.Add("cursor", "default");
				gridViewRowEventArgs_0.Row.Attributes["onmouseover"] = this.string_4 + "(this)";
				gridViewRowEventArgs_0.Row.Attributes["onmouseout"] = this.string_3 + "(this)";
				if (this.int_0 >= 0)
				{
					try
					{
						ImageButton imageButton = (ImageButton)gridViewRowEventArgs_0.Row.Cells[0].FindControl("imb_Delete");
						imageButton.Attributes.Add("onclick", "return confirm('" + this.string_0 + "');");
						imageButton.CommandArgument = gridViewRowEventArgs_0.Row.RowIndex.ToString();
						if (!this.Del)
						{
							imageButton.Visible = false;
						}
						else
						{
							imageButton.Visible = true;
						}
					}
					catch
					{
					}
					HtmlImage htmlImage = (HtmlImage)gridViewRowEventArgs_0.Row.FindControl("htmlEdit");
					if (htmlImage != null)
					{
						try
						{
							int num2 = (int)this.DataKeys[Convert.ToInt32(gridViewRowEventArgs_0.Row.RowIndex.ToString())].Value;
							htmlImage.Attributes.Add("onclick", string.Concat(new object[]
							{
								this.EditText1,
								num2,
								this.EditText2,
								this.PageIndex,
								this.EditText3
							}));
						}
						catch
						{
							long num3 = (long)this.DataKeys[Convert.ToInt32(gridViewRowEventArgs_0.Row.RowIndex.ToString())].Value;
							htmlImage.Attributes.Add("onclick", string.Concat(new object[]
							{
								this.EditText1,
								num3,
								this.EditText2,
								this.PageIndex,
								this.EditText3
							}));
						}
					}
					if (!this.Edit)
					{
						if (htmlImage != null)
						{
							htmlImage.Visible = false;
						}
					}
					else if (htmlImage != null)
					{
						htmlImage.Visible = true;
					}
				}
			}
			base.OnRowDataBound(gridViewRowEventArgs_0);
		}
		protected string GetSortExpression(GridViewSortEventArgs gridViewSortEventArgs_0)
		{
			string[] sortColumns = null;
			string text = gridViewSortEventArgs_0.SortExpression;
			if (text != string.Empty && text != null)
			{
				sortColumns = text.Split(",".ToCharArray());
			}
			if (text.IndexOf(gridViewSortEventArgs_0.SortExpression) > 0 || text.StartsWith(gridViewSortEventArgs_0.SortExpression))
			{
				text = this.ModifySortExpression(sortColumns, gridViewSortEventArgs_0.SortExpression);
			}
			else
			{
				text += "," + gridViewSortEventArgs_0.SortExpression + " ASC ";
			}
			return text.TrimStart(",".ToCharArray()).TrimEnd(",".ToCharArray());
		}
		protected string ModifySortExpression(string[] sortColumns, string sortExpression)
		{
			string text = sortExpression + " ASC";
			string text2 = sortExpression + " DESC";
			for (int i = 0; i < sortColumns.Length; i++)
			{
				if (text.Equals(sortColumns[i]))
				{
					sortColumns[i] = text2;
				}
				else if (text2.Equals(sortColumns[i]))
				{
					Array.Clear(sortColumns, i, 1);
				}
			}
			return string.Join(",", sortColumns).Replace(",,", ",").TrimStart(",".ToCharArray());
		}
		protected void SearchSortExpression(string[] sortColumns, string sortColumn, out string sortOrder, out int sortOrderNo)
		{
			sortOrder = "";
			sortOrderNo = 1;
			if (sortColumns == null)
			{
				if (this.GridViewSortDirection == SortDirection.Ascending)
				{
					sortOrder = "DESC";
				}
				else
				{
					sortOrder = "ASC";
				}
			}
			else
			{
				for (int i = 0; i < sortColumns.Length; i++)
				{
					if (sortColumns[i].StartsWith(sortColumn))
					{
						sortOrderNo = i + 1;
						if (this.AllowMultiColumnSorting)
						{
							if (this.GridViewSortDirection == SortDirection.Ascending)
							{
								sortOrder = "DESC";
							}
							else
							{
								sortOrder = "ASC";
							}
						}
						else if (this.GridViewSortDirection == SortDirection.Ascending)
						{
							sortOrder = "DESC";
						}
						else
						{
							sortOrder = "ASC";
						}
					}
				}
			}
		}
		protected void DisplaySortOrderImages(string sortExpression, GridViewRow dgItem)
		{
			string[] sortColumns = null;
			if (sortExpression != string.Empty && sortExpression != null)
			{
				sortColumns = sortExpression.Split(",".ToCharArray());
			}
			for (int i = 0; i < dgItem.Cells.Count; i++)
			{
				if (dgItem.Cells[i].Controls.Count > 0 && dgItem.Cells[i].Controls[0] is LinkButton)
				{
					string commandArgument = ((LinkButton)dgItem.Cells[i].Controls[0]).CommandArgument;
					string text;
					int num;
					this.SearchSortExpression(sortColumns, commandArgument, out text, out num);
					if (num > 0)
					{
						string text2 = text.Equals("ASC") ? this.SortAscImageUrl : this.SortDescImageUrl;
						if (text2 != string.Empty)
						{
							System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
							image.ImageUrl = text2;
							dgItem.Cells[i].Controls.Add(image);
						}
						else if (this.AllowMultiColumnSorting)
						{
							Literal literal = new Literal();
							literal.Text = num.ToString();
							dgItem.Cells[i].Controls.Add(literal);
						}
					}
				}
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (!base.DesignMode)
			{
				if (this.Rows.Count == 0 || this.Rows[0].RowType == DataControlRowType.EmptyDataRow)
				{
					this.RenderEmptyContent(writer);
				}
				else
				{
					this.CssClass = "gridview_m";
					base.Render(writer);
				}
			}
			else
			{
				this.CssClass = "gridview_m";
				base.Render(writer);
			}
		}
		protected virtual void RenderEmptyContent(HtmlTextWriter writer)
		{
			if (!base.DesignMode)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				stringBuilder.Append("<table cellspacing=\"0\" cellpadding=\"4\" border=\"0\" style=\"background-color:White;border-color:#DEDFDE;border-width:1px;border-style:None;width:98%;border-collapse:collapse;\" id=\"num1GridViewShow\" descendingimageurl=\"~/images/SortDesc.gif\" ascendingimageurl=\"~/images/SortAsc.gif\" rules=\"cols\" class=\"gridview_m\" >");
				stringBuilder.Append("<tr align=\"center\" style=\"color: White;\" class=\"list_header\" >");
				foreach (DataControlField dataControlField in this.Columns)
				{
					if (dataControlField.Visible && dataControlField.ItemStyle.CssClass != "hidden")
					{
						if (dataControlField.HeaderText != "")
						{
							stringBuilder.Append("<th scope=\"col\">" + dataControlField.HeaderText + "</th>");
						}
						num++;
					}
				}
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				this.EmptyDataText = "无查询的记录！";
				stringBuilder.Append(string.Concat(new string[]
				{
					"<td colspan=\"",
					num.ToString(),
					"\" align=\"center\"  height=\"30\" ><strong style=\"font-size:13px;\">",
					this.EmptyDataText,
					"</strong></td>"
				}));
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<thcolspan=\"" + num.ToString() + "\" height=\"30\"></th>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				LiteralControl literalControl = new LiteralControl(stringBuilder.ToString());
				literalControl.RenderControl(writer);
			}
		}
	}
}
