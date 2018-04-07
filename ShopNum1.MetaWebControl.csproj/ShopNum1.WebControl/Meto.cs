using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class Meto : BaseWebControl
    {
        private string string_0 = "Meto.ascx";
        private Literal literal_0;
        private Literal literal_1;
        private Literal literal_2;
        private string string_1 = "all";
        private string string_2 = "0";
        public string Type
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }
        public Meto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = this.string_0;
            }
        }
        protected override void InitializeSkin(Control skin)
        {
            try
            {
                if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
                {
                    this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
                }
                this.literal_0 = (Literal)skin.FindControl("LiteralPageTitle");
                this.literal_1 = (Literal)skin.FindControl("LiteralPagekeywords");
                this.literal_2 = (Literal)skin.FindControl("LiteralPagedescription");
                if (this.Page.IsPostBack)
                {
                }
                this.method_0();
            }
            catch (Exception)
            {
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            try
            {
                StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
                HtmlTextWriter writer2 = new HtmlTextWriter(stringWriter);
                this.literal_0.RenderControl(writer2);
                this.literal_1.RenderControl(writer2);
                this.literal_2.RenderControl(writer2);
                writer.Write(stringWriter.ToString());
            }
            catch
            {
            }
        }
        private void method_0()
        {
            if (this.string_2 == "0")
            {
                this.method_1();
            }
            else
            {
                string physicalPath = this.Page.Request.PhysicalPath;
                string pageName = physicalPath.Substring(physicalPath.LastIndexOf("\\") + 1);
                DataTable dataTable = this.SelectByID(pageName);
                if (dataTable != null)
                {
                    this.literal_0.Text = "\n<title>" + dataTable.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\n";
                    this.literal_1.Text = "<meta name=\"keywords\" content=\"" + dataTable.Rows[0]["KeyWords"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
                    this.literal_2.Text = "<meta name=\"description\" content=\"" + dataTable.Rows[0]["Description"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
                }
                else
                {
                    this.method_1();
                }
            }
        }
        private void method_1()
        {
            if (this.string_1 == "all")
            {
                this.literal_0.Text = "\n<title>" + ShopSettings.GetValue("Title") + ShopNum1.Common.Common.GetCopyright() + "</title>\n";
                this.literal_1.Text = "<meta name=\"keywords\" content=\"" + ShopSettings.GetValue("KeyWords") + ShopNum1.Common.Common.GetCopyright() + "\">\n";
                this.literal_2.Text = "<meta name=\"description\" content=\"" + ShopSettings.GetValue("Description") + ShopNum1.Common.Common.GetCopyright() + "\">\n";
            }
            else
            {
                this.literal_0.Text = "\n<title>" + CitySettings.GetValue("Title", this.string_1) + ShopNum1.Common.Common.GetCopyright() + "</title>\n";
                this.literal_1.Text = "<meta name=\"keywords\" content=\"" + CitySettings.GetValue("KeyWords", this.string_1) + ShopNum1.Common.Common.GetCopyright() + "\">\n";
                this.literal_2.Text = "<meta name=\"description\" content=\"" + CitySettings.GetValue("Description", this.string_1) + ShopNum1.Common.Common.GetCopyright() + "\">\n";
            }
        }
        public DataTable SelectByID(string PageName)
        {
            DataTable result;
            if (this.string_1 == "all")
            {
                if (ShopNum1_ExtendSiteMota_Action.MetoTable == null)
                {
                    result = null;
                }
                else
                {
                    DataRow[] array = ShopNum1_ExtendSiteMota_Action.MetoTable.Select("PageName = '" + PageName + "'");
                    if (array.Length > 0)
                    {
                        result = array.CopyToDataTable<DataRow>();
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            else
            {
                ShopNum1_ExtendSiteMota_Action shopNum1_ExtendSiteMota_Action = (ShopNum1_ExtendSiteMota_Action)LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
                DataRow[] array = shopNum1_ExtendSiteMota_Action.MetoTable2(this.string_1).Select("PageName = '" + PageName + "'");
                if (array.Length > 0)
                {
                    result = array.CopyToDataTable<DataRow>();
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
    }
}
