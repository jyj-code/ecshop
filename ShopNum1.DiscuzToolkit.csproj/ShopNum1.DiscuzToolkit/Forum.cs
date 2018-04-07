using Newtonsoft.Json;
using System;
namespace ShopNum1.DiscuzToolkit
{
	public class Forum
	{
		[JsonProperty("parent_id")]
		public int ParentId;
		[JsonProperty("name")]
		public string Name;
		[JsonProperty("status")]
		public int? Status;
		[JsonProperty("template_id")]
		public int TemplateId;
		[JsonProperty("seo_keywords")]
		public string SeoKeywords;
		[JsonProperty("seo_description")]
		public string SeoDescription;
		[JsonProperty("rewrite_name")]
		public string RewriteName;
		[JsonProperty("description")]
		public string Description;
		[JsonProperty("icon")]
		public string Icon;
		[JsonProperty("moderators")]
		public string Moderators;
		[JsonProperty("rules")]
		public string Rules;
		[JsonProperty("allow_smilies")]
		public int AllowSmilies;
		[JsonProperty("allow_rss")]
		public int AllowRss;
		[JsonProperty("allow_bbcode")]
		public int AllowBbcode;
		[JsonProperty("allow_imgcode")]
		public int AllowImgcode;
		[JsonProperty("allow_edit_rules")]
		public int AllowEditRules;
		[JsonProperty("allow_thumbnail")]
		public int AllowThumbnail;
		[JsonProperty("allow_tag")]
		public int AllowTag;
		[JsonProperty("recycle_bin")]
		public int RecycleBin;
		[JsonProperty("mod_new_posts")]
		public int ModNewPosts;
		[JsonProperty("jammer")]
		public int Jammer;
		[JsonProperty("disable_watermark")]
		public int DisableWatermark;
		[JsonProperty("inherited_mod")]
		public int InheritedMod;
		[JsonProperty("auto_close")]
		public int AutoClose;
	}
}
