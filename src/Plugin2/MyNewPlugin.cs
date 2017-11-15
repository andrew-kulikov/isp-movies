using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPlugin;
using System.Reflection;

namespace Plugin2
{
	public class MyNewPlugin : IPlugin.IPlugin
	{
		public string Name => "Plugin2";

		public string HeaderColor => "#4F3";

		public string GetMoreInfo(object obj)
		{
			PropertyInfo prop = obj.GetType().GetProperty("Rating");
			Random r = new Random();
			//return prop.GetValue(obj, null).ToString();
			return (r.Next(10, 100)* (double)prop.GetValue(obj, null) / 10.0).ToString();
		}
	}
}
