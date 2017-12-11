using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Movies.UI.Tools
{
	public class PluginsConfig : ConfigurationSection
	{
		[ConfigurationProperty("pluginsFolder", IsRequired = true)]
		public PluginsElement Plugins
		{
			get => (PluginsElement)base["pluginsFolder"];
			set => base["pluginsFolder"] = value;
		}
	}
	public class PluginsElement : ConfigurationElement
	{
		[ConfigurationProperty("path", IsRequired = true)]
		public string Path
		{
			get => (string)base["path"];
			set => base["path"] = value;
		}
	}
}
