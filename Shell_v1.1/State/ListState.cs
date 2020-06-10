using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    abstract class ListState
    {
        public DecisionMaker context;
        public abstract Prototype.IFileOrFolder Copy( string name, string PathFrom, string PathTo);
        public abstract Prototype.IFileOrFolder Move( string name, string PathFrom, string PathTo);
        public abstract string Delete( string name, string PathFrom);


    }
}
