using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Template
{
    class OperationWithFile : TemplateContext
    {

        public override void Iterate(string pathFrom, string pathtTo)
        {
            Operation(pathFrom, pathtTo);
        }

        public override void Operation(string pathFrom, string pathTo)
        {
            System.IO.File.Copy(pathFrom, pathTo, true);
        }
        public override void Delete(string pathFrom)
        {
            System.IO.File.Delete(pathFrom);
        }
    }
}
