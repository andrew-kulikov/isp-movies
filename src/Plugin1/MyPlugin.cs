using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using IPlugin;

namespace Plugin1
{
	public class MyPlugin : IPlugin.IPlugin
	{
		public string Name => "Plugin1";

		public string HeaderColor => "#222";

		public string GetMoreInfo(object obj)
		{
			PropertyInfo prop = obj.GetType().GetProperty("YearOfRelease");
			return prop.GetValue(obj, null).ToString();
		}
	}
}
