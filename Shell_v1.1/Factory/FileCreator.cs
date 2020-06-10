using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Factory
{
    class FileCreator : Creator
    {
        public override Prototype.IFileOrFolder FactoryMethod(string path, string name)
        {
            return new Prototype.FileItem(path, name);
        }
    }
}
