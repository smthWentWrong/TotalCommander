using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Interpret
{
    class BoolExpression : IExpression
    {
        string name;
        public BoolExpression(string Vname)
        {
            name = Vname;
        }

        public bool Interpret(Context context)
        {
            return context.GetDes(name);
        }
    }
}
