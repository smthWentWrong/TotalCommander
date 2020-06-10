using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Interpret
{
    class Context
    {
        Dictionary<string, bool> variables;
        public Context()
        {
            variables = new Dictionary<string, bool>();
        }

        public bool GetDes(string name)
        {
            return variables[name];
        }

        public void SetDes(string name, string comp_name)
        {
            if (variables.ContainsKey(name))
                variables[name] = name.ToLower().Contains(comp_name.ToLower());
            else
                variables.Add(name, name.ToLower().Contains(comp_name.ToLower()));
        }
    }
}
