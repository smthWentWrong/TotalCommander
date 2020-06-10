using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell_v1._02.Prototype;

namespace Shell_v1._02.Template
{
    class OperationWithFolder : TemplateContext
    {
        
        public override void Iterate(string pathFrom, string pathTo)//was a virtual
        {
            DirectoryInfo dir = new DirectoryInfo(pathFrom);

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo curDir in dirs)
            {
                string SourceFolder = System.IO.Path.Combine(pathFrom, curDir.ToString());
                string DestFolder = System.IO.Path.Combine(pathTo, curDir.ToString());
                Operation(SourceFolder, DestFolder);
                this.Iterate(SourceFolder, DestFolder);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo curFile in files)
            {
                string SourceFile = System.IO.Path.Combine(pathFrom, curFile.ToString());
                string DestFile = System.IO.Path.Combine(pathTo, curFile.ToString());
                Operation(SourceFile, DestFile);
            }
            
        }

        public override void Operation(string pathFrom, string pathTo)
        {
            if (System.IO.Path.GetExtension(pathFrom) == "") System.IO.File.Copy(pathFrom, pathTo, true);
            else System.IO.Directory.CreateDirectory(pathTo);
        }
        public override void Delete(string pathFrom)
        {
            System.IO.Directory.Delete(pathFrom, true);
        }

        //public abstract void Operation(string pathfrom, string pathto);

        //public override void Move(string PathTo)
        //{
        //    string SourceFolder = System.IO.Path.Combine(folder.GetPath(), folder.GetName());
        //    string DestFolder = System.IO.Path.Combine(PathTo, folder.GetName());
        //    Template.MoveFolder Move = new Template.MoveFolder();
        //    Move.Iterate(SourceFolder, DestFolder);
        //    Move.Delete(SourceFolder);
        //}
        //public override void Copy(string PathTo)
        //{
        //    string SourceFolder = System.IO.Path.Combine(folder.GetPath(),folder.GetName());
        //    string DestFolder = System.IO.Path.Combine(PathTo, folder.GetName());
        //    Template.CopyFolder Copy = new Template.CopyFolder();
        //    Copy.Iterate(SourceFolder, DestFolder);
        //}


        //public abstract void Operation(string SourceFile, string DestFile);
    }
}
