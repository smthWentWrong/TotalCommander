using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Prototype
{
    interface IFileOrFolder
    {
        IFileOrFolder Clone();
        void Create();
        //void Copy(string PathTo);
        //void Move(string Pathto);
        void SetPath(string path);
        void SetInfo(string info);
        string GetPath();
        string GetName();
        string GetInfo();

    }
}
