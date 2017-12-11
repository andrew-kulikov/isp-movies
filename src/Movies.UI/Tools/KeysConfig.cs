using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace Movies.UI.Tools
{
	public class KeysConfig : ConfigurationSection
	{
		[ConfigurationProperty("save", IsRequired = true)]
		public KeyConfigElement Save => (KeyConfigElement)base["save"];
		[ConfigurationProperty("open", IsRequired = true)]
		public KeyConfigElement Open => (KeyConfigElement)base["open"];
		[ConfigurationProperty("load", IsRequired = true)]
		public KeyConfigElement Load => (KeyConfigElement)base["load"];
		[ConfigurationProperty("nextPage", IsRequired = true)]
		public KeyConfigElement NextPage => (KeyConfigElement)base["nextPage"];
		[ConfigurationProperty("prevPage", IsRequired = true)]
		public KeyConfigElement PrevPage => (KeyConfigElement)base["prevPage"];
		[ConfigurationProperty("firstPage", IsRequired = true)]
		public KeyConfigElement FirstPage => (KeyConfigElement)base["firstPage"];
		[ConfigurationProperty("lastPage", IsRequired = true)]
		public KeyConfigElement LastPage => (KeyConfigElement)base["lastPage"];
	}
	public class KeyConfigElement : ConfigurationElement
	{
		[ConfigurationProperty("key", IsRequired = true)]
		public string Key
		{
			get => (string)base["key"];
			set => base["key"] = value;
		}
	}
}
