using Shell_v1._02.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Template
{
    abstract class TemplateContext
    {
        public abstract void Iterate(string pathFrom, string pathTo);
        public abstract void Operation(string pathFrom, string pathTo);
        public abstract void Delete(string pathFrom);
        public string Combine(string PathFrom, string Name)
        {
            return System.IO.Path.Combine(PathFrom, Name);
            
        }
        
        public void Algorithm(string name,string PathFrom,string PathTo,bool Move)
        {
         
            string SourceItem = Combine(PathFrom, name);
            string DestItem = Combine(PathTo, name);
            Iterate(SourceItem, DestItem);
            if (Move)
            {
                Delete(SourceItem);
            }
        }
        bool IsFolder(string pathfrom)
        {
            if (System.IO.Path.GetExtension(pathfrom) == "")
            {
                return true;
            }
            return false;
        }
 
        //public void OperationFolder(string SourceFile, string DestFile)
        //{
        //    Operation(SourceFile,DestFile);
        //}
        //public void OperationFile(string PathTo)
        //{
        //    Operation(PathTo);
        //}

    }
}
