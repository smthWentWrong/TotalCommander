using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    class NotReady : ListState
    {
        public override Prototype.IFileOrFolder Copy( string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem("", "", "Can`t to copy nonexisiting object!");
            
            return element;
        }
        public override Prototype.IFileOrFolder Move( string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem("", "", "Can`t to move nonexisiting object!");
            
            return element;
        }
        public override string Delete( string name, string PathFrom)
        {
            return "Can`t to delete nonexisiting object!";
            
        }
    }
}
