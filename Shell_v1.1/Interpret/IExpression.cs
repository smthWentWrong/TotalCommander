using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Interpret
{
    interface IExpression
    {
        bool Interpret(Context context);
    }
}
