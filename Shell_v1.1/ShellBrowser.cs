using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shell_v1._02.State;

namespace Shell_v1._02
{
    public partial class ShellBrowser : System.Windows.Forms.UserControl
    {
        public string CurrentPath;
        public string CurrentSelectedItem;
        private State.DecisionMaker context;

        internal State.DecisionMaker Context { get => context; set => context = value; }

        public ShellBrowser()
        {
            InitializeComponent();
            foreach (var drive in DriveInfo.GetDrives())
            {
                this.comboBoxDisks.Items.Add(drive.RootDirectory);
            }

            this.comboBoxDisks.Text = this.comboBoxDisks.Items[0].ToString();
            CurrentPath = this.comboBoxDisks.Text;
            context = DecisionMaker.GetNewInstance();
            context.SetNotReadyState();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\')
            {
                if (textBox1.Text.Remove(textBox1.Text.Length - 1, 1).Contains('\\'))
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);

                    while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    }
                }
                else textBox1.Text = CurrentPath;
            }

            else if (textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                if (textBox1.Text.Contains('\\'))
                {
                    while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    }
                }
                else textBox1.Text = CurrentPath;
            }
            
            listBox1.Items.Clear();

            SetCurrentDirectory(textBox1.Text);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SetCurrentDirectory(textBox1.Text);
            textBox1.Text = CurrentPath;
        }

        private void comboBoxDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBoxDisks.Text;
            SetCurrentDirectory(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                CurrentSelectedItem = listBox1.SelectedItem.ToString();
                string path = Path.Combine(CurrentPath, listBox1.SelectedItem.ToString());
                textBox1.Text = path;
                if (System.IO.Path.GetExtension(path) == "")
                {
                    context = State.DecisionMaker.GetNewInstance();
                    context.SetFolderChosenState();
                }
                else
                {
                    context = State.DecisionMaker.GetNewInstance();
                    context.SetFileChosenState();
                }
            }
            else
            {
                context = State.DecisionMaker.GetNewInstance();
                context.SetNotReadyState();
            }

        }

        public void SetCurrentDirectory(string path)
        {
            if (Path.GetExtension(path) == "")
            {
                try
                {
                    listBox1.Items.Clear();

                    DirectoryInfo dir = new DirectoryInfo(path);

                    DirectoryInfo[] dirs = dir.GetDirectories();

                    foreach (DirectoryInfo curDir in dirs)
                    {
                        listBox1.Items.Add(curDir.ToString());
                    }

                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo curFile in files)
                    {
                        listBox1.Items.Add(curFile.ToString());
                    }

                    CurrentPath = path;
                }

                catch (DirectoryNotFoundException dirEx)
                {
                    MessageBox.Show("The following path is incorrect","Error", MessageBoxButtons.OK);
                    SetCurrentDirectory(CurrentPath);
                }

                catch (System.UnauthorizedAccessException e)
                {
                    MessageBox.Show("You have no permission to enter that folder", "Error", MessageBoxButtons.OK);
                    SetCurrentDirectory(CurrentPath);
                }
            }

            else Process.Start(path);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string path = Path.Combine(CurrentPath, listBox1.SelectedItem.ToString());
                textBox1.Text = path;
            }
            SetCurrentDirectory(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.Items != null)
            {
                PythonString strs = new PythonString();

                DirectoryInfo dir = new DirectoryInfo(CurrentPath);

                DirectoryInfo[] dirs = dir.GetDirectories();

                foreach (DirectoryInfo curDir in dirs)
                {
                    strs.Append(curDir.ToString());
                }

                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo curFile in files)
                {
                    strs.Append(curFile.ToString());
                }

                string[] vars = strs.massiv;
                strs.massiv = null;

                foreach (string var in vars)
                {
                    Interpret.Context context = new Interpret.Context();
                    context.SetDes(var, textBox2.Text);
                    Interpret.BoolExpression Des = new Interpret.BoolExpression(var);
                    if (Des.Interpret(context))
                    {
                        strs.Append(var);
                    }
                }

                if (strs.massiv != null)
                {
                    listBox1.Items.Clear();
                    foreach (string var in strs.massiv)
                    {
                        listBox1.Items.Add(var);
                    }
                }
            }
        }
    }
}
