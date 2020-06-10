using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell_v1._02.Template;

namespace Shell_v1._02.State
{
    class FileChosen : ListState
    {
        public override Prototype.IFileOrFolder Copy( string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FileItem(PathFrom, name);
            Prototype.IFileOrFolder copiedelement = element.Clone();
            copiedelement.SetPath(PathTo);
            try
            {
                OperationWithFile operationWith = new OperationWithFile();
                operationWith.Algorithm(element.GetName(),element.GetPath(),copiedelement.GetPath(),false);
                //element.Copy(copiedelement.GetPath());
                context.State = new NotReady();
                copiedelement.SetInfo("Copy file succes!");
            }
            catch
            {
                copiedelement.SetInfo("Copy file error message!");
            }
            return copiedelement;
        }
        public override Prototype.IFileOrFolder Move( string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FileItem(PathFrom, name);
            Prototype.IFileOrFolder copiedelement = element.Clone();
            copiedelement.SetPath(PathTo);
            try
            {
                OperationWithFile operationWith = new OperationWithFile();
                operationWith.Algorithm(element.GetName(), element.GetPath(), copiedelement.GetPath(), true);
                //element.Copy(copiedelement.GetPath());
                this.Delete( name, PathFrom);
                context.State = new NotReady();
                copiedelement.SetInfo("Move file success!");
            
            }
            catch
            {
                copiedelement.SetInfo("Move file error message!");
            }
            //element.SetPath(PathTo);
            return copiedelement;
        }
        public override string Delete( string name, string PathFrom)
        {
            string SourceFile = System.IO.Path.Combine(PathFrom, name);
            try
            {
                System.IO.File.Delete(SourceFile);
                context.State = new NotReady();
                return "Delete success!";
            }
            catch
            {
                //MessageBox.Show("An error ocured during deleting process", "Error", MessageBoxButtons.OK);
                return "An error ocured during deleting process";
            }
        }
    }
}
