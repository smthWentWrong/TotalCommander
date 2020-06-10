using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell_v1._02.Template;

namespace Shell_v1._02.State
{
    class FolderChosen : ListState
    {
        public override Prototype.IFileOrFolder Copy( string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem(PathFrom, name);
            Prototype.IFileOrFolder copiedelement = element.Clone();
            copiedelement.SetPath(PathTo);
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(PathTo, name));
                OperationWithFolder operationWith = new OperationWithFolder();
                operationWith.Algorithm(element.GetName(), element.GetPath(), copiedelement.GetPath(), false);
                //element.Copy(copiedelement.GetPath());
                context.State = new NotReady();
                copiedelement.SetInfo("Copy folder success!");
            }
            catch
            {
                System.IO.Directory.Delete(System.IO.Path.Combine(PathTo, name));
                copiedelement.SetInfo("Copy folder error message!");
            }
            return copiedelement;
        }
        public override Prototype.IFileOrFolder Move( string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem(PathFrom, name);
            //MoveFolder moveFolder = new MoveFolder();
            
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(PathTo, name));
                OperationWithFolder operationWith = new OperationWithFolder();
                operationWith.Algorithm(element.GetName(), element.GetPath(), PathTo,true);
                //element.Move(PathTo);
                this.Delete( name, PathFrom);
                context.State = new NotReady();
                element.SetInfo("Move folder success!");
            }
            catch
            {
                
                System.IO.Directory.Delete(System.IO.Path.Combine(PathTo, name));
                element.SetInfo("Move folder error message");
            }
            element.SetPath(PathTo);
            return element;
        }
        public override string Delete( string name, string PathFrom)
        {
            string SourceFolder = System.IO.Path.Combine(PathFrom, name);
            try
            {
                System.IO.Directory.Delete(SourceFolder, true);
                context.State = new NotReady();
                return "Delete success!";
            }
            catch
            {
                return "An error ocured during deleting process";
            }
        }
    }
}
