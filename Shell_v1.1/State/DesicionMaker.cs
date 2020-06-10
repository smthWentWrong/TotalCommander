using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    class DecisionMaker
    {
        public ListState State { get; set; }
        public DecisionMaker()
        {
        }
        public Prototype.IFileOrFolder CopyRequest(string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = this.State.Copy( name, PathFrom, PathTo);
            return element;
        }
        public Prototype.IFileOrFolder MoveRequest(string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = this.State.Move( name, PathFrom, PathTo);
            return element;
        }
        public string DeleteRequest(string name, string PathFrom)
        {
            return this.State.Delete( name, PathFrom);
        }
        public void SetFolderChosenState()
        {
            this.State = new FolderChosen();
            this.State.context = this;
        }
        public void SetFileChosenState()
        {
            this.State = new FileChosen();
            this.State.context = this;
        }
        public void SetNotReadyState()
        {
            this.State = new NotReady();
            this.State.context = this;
        }
        public static DecisionMaker GetNewInstance()
        {
            return new DecisionMaker();
        }
    }
}
