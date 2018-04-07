using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Competence : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected CheckBox parent_1;
	protected CheckBox check_sub_1;
	protected CheckBox check_sub_2;
	protected CheckBox check_sub_300;
	protected CheckBox check_sub_1000;
	protected CheckBox parent_2;
	protected CheckBox check_sub_3;
	protected CheckBox check_sub_4;
	protected CheckBox check_sub_5;
	protected CheckBox parent_3;
	protected CheckBox check_sub_6;
	protected CheckBox check_sub_7;
	protected CheckBox check_sub_10002;
	protected CheckBox check_sub_10001;
	protected CheckBox parent_4;
	protected CheckBox check_sub_8;
	protected CheckBox check_sub_9;
	protected CheckBox parent_5;
	protected CheckBox check_sub_10;
	protected CheckBox check_sub_11;
	protected CheckBox parent_6;
	protected CheckBox check_sub_12;
	protected CheckBox check_sub_13;
	protected CheckBox check_sub_15;
	protected CheckBox check_sub_17;
	protected CheckBox check_sub_16;
	protected CheckBox parent_7;
	protected CheckBox check_sub_18;
	protected CheckBox check_sub_1002;
	protected CheckBox check_sub_19;
	protected CheckBox check_sub_20;
	protected CheckBox check_sub_21;
	protected CheckBox check_sub_22;
	protected CheckBox parent_8;
	protected CheckBox check_sub_23;
	protected CheckBox check_sub_24;
	protected CheckBox check_sub_25;
	protected CheckBox check_sub_26;
	protected CheckBox check_sub_27;
	protected CheckBox check_sub_28;
	protected CheckBox check_sub_29;
	protected CheckBox check_sub_30;
	protected CheckBox check_sub_1003;
	protected CheckBox check_sub_1004;
	protected CheckBox parent_9;
	protected CheckBox check_sub_31;
	protected CheckBox check_sub_32;
	protected CheckBox check_sub_33;
	protected CheckBox check_sub_34;
	protected CheckBox check_sub_302;
	protected CheckBox parent_10;
	protected CheckBox check_sub_35;
	protected CheckBox check_sub_303;
	protected CheckBox check_sub_36;
	protected CheckBox check_sub_38;
	protected CheckBox parent_11;
	protected CheckBox check_sub_39;
	protected CheckBox check_sub_40;
	protected CheckBox check_sub_41;
	protected CheckBox check_sub_4100;
	protected CheckBox parent_12;
	protected CheckBox check_sub_42;
	protected CheckBox check_sub_1005;
	protected CheckBox check_sub_43;
	protected CheckBox check_sub_1006;
	protected CheckBox parent_13;
	protected CheckBox check_sub_44;
	protected CheckBox check_sub_45;
	protected CheckBox check_sub_1600;
	protected CheckBox check_sub_1601;
	protected CheckBox check_sub_47;
	protected CheckBox check_sub_48;
	protected CheckBox check_sub_1007;
	protected CheckBox check_sub_1008;
	protected CheckBox parent_144;
	protected CheckBox check_sub_500;
	protected CheckBox check_sub_501;
	protected CheckBox parent_14;
	protected CheckBox check_sub_49;
	protected CheckBox check_sub_800;
	protected CheckBox parent_15;
	protected CheckBox check_sub_505;
	protected CheckBox check_sub_50;
	protected CheckBox parent_16;
	protected CheckBox check_sub_51;
	protected CheckBox check_sub_52;
	protected CheckBox check_sub_53;
	protected CheckBox check_sub_54;
	protected CheckBox check_sub_55;
	protected CheckBox check_sub_56;
	protected CheckBox check_sub_57;
	protected CheckBox check_sub_58;
	protected CheckBox check_sub_59;
	protected CheckBox check_sub_60;
	protected CheckBox check_sub_61;
	protected CheckBox check_sub_62;
	protected CheckBox parent_17;
	protected CheckBox check_sub_63;
	protected CheckBox check_sub_305;
	protected CheckBox check_sub_1009;
	protected CheckBox check_sub_306;
	protected CheckBox check_sub_64;
	protected CheckBox check_sub_65;
	protected CheckBox check_sub_66;
	protected CheckBox check_sub_307;
	protected CheckBox check_sub_1010;
	protected CheckBox parent_18;
	protected CheckBox check_sub_67;
	protected CheckBox check_sub_1011;
	protected CheckBox check_sub_68;
	protected CheckBox check_sub_1012;
	protected CheckBox parent_19;
	protected CheckBox check_sub_69;
	protected CheckBox check_sub_70;
	protected CheckBox parent_20;
	protected CheckBox check_sub_72;
	protected CheckBox check_sub_73;
	protected CheckBox check_sub_1013;
	protected CheckBox check_sub_76;
	protected CheckBox check_sub_77;
	protected CheckBox check_sub_1014;
	protected CheckBox check_sub_370;
	protected CheckBox check_sub_371;
	protected CheckBox check_sub_372;
	protected CheckBox parent_25;
	protected CheckBox check_sub_91;
	protected CheckBox check_sub_310;
	protected CheckBox check_sub_98;
	protected CheckBox check_sub_99;
	protected CheckBox check_sub_1015;
	protected CheckBox check_sub_92;
	protected CheckBox check_sub_93;
	protected CheckBox check_sub_97;
	protected CheckBox parent_26;
	protected CheckBox check_sub_102;
	protected CheckBox check_sub_103;
	protected CheckBox check_sub_104;
	protected CheckBox check_sub_105;
	protected CheckBox check_sub_106;
	protected CheckBox check_sub_107;
	protected CheckBox check_sub_108;
	protected CheckBox check_sub_109;
	protected CheckBox check_sub_110;
	protected CheckBox check_sub_111;
	protected CheckBox parent_27;
	protected CheckBox check_sub_112;
	protected CheckBox check_sub_113;
	protected CheckBox check_sub_1016;
	protected CheckBox parent_28;
	protected CheckBox check_sub_114;
	protected CheckBox parent_29;
	protected CheckBox check_sub_115;
	protected CheckBox check_sub_116;
	protected CheckBox check_sub_1017;
	protected CheckBox parent_30;
	protected CheckBox check_sub_117;
	protected CheckBox check_sub_118;
	protected CheckBox check_sub_119;
	protected CheckBox check_sub_120;
	protected CheckBox check_sub_121;
	protected CheckBox check_sub_308;
	protected CheckBox parent_58;
	protected CheckBox check_sub_203;
	protected CheckBox check_sub_204;
	protected CheckBox check_sub_205;
	protected CheckBox check_sub_206;
	protected CheckBox check_sub_207;
	protected CheckBox parent_31;
	protected CheckBox check_sub_123;
	protected CheckBox check_sub_124;
	protected CheckBox check_sub_125;
	protected CheckBox check_sub_126;
	protected CheckBox parent_32;
	protected CheckBox check_sub_127;
	protected CheckBox check_sub_128;
	protected CheckBox parent_33;
	protected CheckBox check_sub_1928;
	protected CheckBox parent_1000;
	protected CheckBox check_sub_1018;
	protected CheckBox check_sub_1019;
	protected CheckBox check_sub_1020;
	protected CheckBox check_sub_1021;
	protected CheckBox check_sub_1022;
	protected CheckBox check_sub_1023;
	protected CheckBox parent_1001;
	protected CheckBox check_sub_1024;
	protected CheckBox check_sub_1025;
	protected CheckBox check_sub_1026;
	protected CheckBox check_sub_1027;
	protected CheckBox check_sub_1028;
	protected CheckBox check_sub_1029;
	protected CheckBox check_sub_1030;
	protected CheckBox check_sub_1031;
	protected CheckBox parent_34;
	protected CheckBox check_sub_130;
	protected CheckBox check_sub_1032;
	protected CheckBox parent_35;
	protected CheckBox check_sub_131;
	protected CheckBox check_sub_1700;
	protected CheckBox parent_1002;
	protected CheckBox check_sub_1033;
	protected CheckBox parent_36;
	protected CheckBox check_sub_1050;
	protected CheckBox check_sub_1051;
	protected CheckBox check_sub_132;
	protected CheckBox check_sub_133;
	protected CheckBox parent_37;
	protected CheckBox check_sub_134;
	protected CheckBox check_sub_1034;
	protected CheckBox check_sub_135;
	protected CheckBox check_sub_136;
	protected CheckBox check_sub_137;
	protected CheckBox check_sub_1035;
	protected CheckBox parent_38;
	protected CheckBox check_sub_138;
	protected CheckBox check_sub_139;
	protected CheckBox check_sub_1037;
	protected CheckBox parent_100;
	protected CheckBox check_sub_315;
	protected CheckBox check_sub_316;
	protected CheckBox parent_499;
	protected CheckBox check_sub_1830;
	protected CheckBox check_sub_350;
	protected CheckBox check_sub_1832;
	protected CheckBox check_sub_1038;
	protected CheckBox check_sub_1831;
	protected CheckBox check_sub_1839;
	protected CheckBox parent_49;
	protected CheckBox check_sub_182;
	protected CheckBox check_sub_183;
	protected CheckBox check_sub_1800;
	protected CheckBox check_sub_1801;
	protected CheckBox parent_50;
	protected CheckBox check_sub_184;
	protected CheckBox check_sub_185;
	protected CheckBox parent_51;
	protected CheckBox check_sub_186;
	protected CheckBox check_sub_187;
	protected CheckBox check_sub_188;
	protected CheckBox check_sub_189;
	protected CheckBox parent_52;
	protected CheckBox check_sub_190;
	protected CheckBox check_sub_191;
	protected CheckBox check_sub_192;
	protected CheckBox check_sub_193;
	protected CheckBox parent_1004;
	protected CheckBox check_sub_1840;
	protected CheckBox check_sub_1841;
	protected CheckBox parent_5200;
	protected CheckBox check_sub_1900;
	protected CheckBox parent_53;
	protected CheckBox check_sub_194;
	protected CheckBox parent_55;
	protected CheckBox check_sub_195;
	protected CheckBox check_sub_351;
	protected CheckBox check_sub_196;
	protected CheckBox check_sub_352;
	protected CheckBox check_sub_197;
	protected CheckBox check_sub_353;
	protected CheckBox check_sub_198;
	protected CheckBox check_sub_354;
	protected CheckBox parent_56;
	protected CheckBox check_sub_199;
	protected CheckBox check_sub_355;
	protected CheckBox check_sub_200;
	protected CheckBox check_sub_1843;
	protected CheckBox check_sub_1844;
	protected CheckBox parent_1005;
	protected CheckBox check_sub_1845;
	protected CheckBox parent_57;
	protected CheckBox check_sub_201;
	protected CheckBox check_sub_202;
	protected CheckBox parent_21;
	protected CheckBox check_sub_80;
	protected CheckBox check_sub_801;
	protected CheckBox check_sub_82;
	protected CheckBox check_sub_83;
	protected CheckBox check_sub_851;
	protected CheckBox check_sub_84;
	protected CheckBox check_sub_85;
	protected CheckBox parent_22;
	protected CheckBox check_sub_86;
	protected CheckBox check_sub_87;
	protected CheckBox parent_23;
	protected CheckBox check_sub_88;
	protected CheckBox check_sub_89;
	protected CheckBox parent_24;
	protected CheckBox check_sub_9099;
	protected Button Button2;
	protected Button Button1;
	protected HtmlForm form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			string groupGuid = this.Page.Request.QueryString["id"].ToString();
			DataTable groupByGuid = this.GetGroupByGuid(groupGuid);
			for (int i = 0; i < groupByGuid.Rows.Count; i++)
			{
				foreach (Control control in this.form1.Controls)
				{
					if (control.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
					{
						CheckBox checkBox = (CheckBox)control;
						if (groupByGuid.Rows[i]["PageGuid"].ToString().Equals(checkBox.ToolTip))
						{
							checkBox.Checked = true;
						}
					}
				}
			}
		}
	}
	protected DataTable GetGroupByGuid(string GroupGuid)
	{
		GroupGuid = this.Page.Request.QueryString["id"].ToString();
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetGroupByGuid(GroupGuid);
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		string text = this.Page.Request.QueryString["id"].ToString();
		List<ShopNum1_GroupPage> list = new List<ShopNum1_GroupPage>();
		list.Clear();
		foreach (Control control in this.form1.Controls)
		{
			if (control.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
			{
				CheckBox checkBox = (CheckBox)control;
				if (checkBox.Checked && checkBox.ToolTip != "")
				{
					list.Add(new ShopNum1_GroupPage
					{
						GroupGuid = new Guid(text.Replace("'", "")),
						PageGuid = checkBox.ToolTip,
						CreateUser = base.ShopNum1LoginID,
						CreateTime = DateTime.Now,
						ModifyUser = base.ShopNum1LoginID,
						ModifyTime = DateTime.Now,
						IsDeleted = 0
					});
				}
			}
		}
		if (list.Count != 0)
		{
			ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			shopNum1_Group_Action.Add(list);
			MessageBox.Show("修改成功！");
		}
		else
		{
			MessageBox.Show("请勾选一个菜单设置权限！");
		}
	}
}
