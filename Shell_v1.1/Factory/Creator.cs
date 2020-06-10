using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Factory
{
    abstract class Creator
    {
        public abstract Prototype.IFileOrFolder FactoryMethod(string path, string name);

        public void SomeOperation(string path, string name)
        {
            var product = FactoryMethod(path, name);
        }
    }
}
