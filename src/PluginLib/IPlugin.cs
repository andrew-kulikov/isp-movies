using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace IPlugin
{
    public interface IPlugin
    {
		string Name { get; }
		string HeaderColor { get; }
		string GetMoreInfo(object obj);
    }
}
