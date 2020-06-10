using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Shell_v1._02
{
    public partial class UserControl : System.Windows.Forms.UserControl
    {
        private const int BufferSize = 1024;
        public UserControl()
        {
            InitializeComponent();
        }

        private void buttonCopy12_Click(object sender, EventArgs e)
        {
            string name = shellBrowserLeft.CurrentSelectedItem;
            string PathFrom = shellBrowserLeft.CurrentPath;
            string PathTo = shellBrowserRight.CurrentPath;
            Prototype.IFileOrFolder copiedelement = shellBrowserLeft.Context.CopyRequest(name, PathFrom, PathTo);
            shellBrowserRight.SetCurrentDirectory(PathTo);
            MessageBox.Show(copiedelement.GetInfo(), "Success!", MessageBoxButtons.OK);
        }

        private void buttonCopy21_Click(object sender, EventArgs e)
        {
            string name = shellBrowserRight.CurrentSelectedItem;
            string PathFrom = shellBrowserRight.CurrentPath;
            string PathTo = shellBrowserLeft.CurrentPath;
            Prototype.IFileOrFolder copiedelement = shellBrowserRight.Context.CopyRequest(name, PathFrom, PathTo);
            shellBrowserLeft.SetCurrentDirectory(PathTo);
            MessageBox.Show(copiedelement.GetInfo(), "Success!", MessageBoxButtons.OK);
        }

        private void buttonMove12_Click(object sender, EventArgs e)
        {
            string name = shellBrowserLeft.CurrentSelectedItem;
            string PathFrom = shellBrowserLeft.CurrentPath;
            string PathTo = shellBrowserRight.CurrentPath;
            Prototype.IFileOrFolder element = shellBrowserLeft.Context.MoveRequest(name, PathFrom, PathTo);
            shellBrowserRight.SetCurrentDirectory(PathTo);
            shellBrowserLeft.SetCurrentDirectory(PathFrom);
            MessageBox.Show(element.GetInfo(), "Message", MessageBoxButtons.OK);
        }

        private void buttonMove21_Click(object sender, EventArgs e)
        {
            string name = shellBrowserRight.CurrentSelectedItem;
            string PathFrom = shellBrowserRight.CurrentPath;
            string PathTo = shellBrowserLeft.CurrentPath;
            Prototype.IFileOrFolder element = shellBrowserRight.Context.MoveRequest(name, PathFrom, PathTo);
            shellBrowserLeft.SetCurrentDirectory(PathTo);
            shellBrowserRight.SetCurrentDirectory(PathFrom);
            MessageBox.Show(element.GetInfo(), "Message", MessageBoxButtons.OK);
        }

        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            string name = shellBrowserLeft.CurrentSelectedItem;
            string PathFrom = shellBrowserLeft.CurrentPath;
            string info = shellBrowserLeft.Context.DeleteRequest(name, PathFrom);
            shellBrowserLeft.SetCurrentDirectory(PathFrom);
            MessageBox.Show(info, "Message", MessageBoxButtons.OK);

        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            string name = shellBrowserRight.CurrentSelectedItem;
            string PathFrom = shellBrowserRight.CurrentPath;
            string info = shellBrowserRight.Context.DeleteRequest(name, PathFrom);
            shellBrowserRight.SetCurrentDirectory(PathFrom);
            MessageBox.Show(info, "Message", MessageBoxButtons.OK);
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string PathFrom = shellBrowserLeft.CurrentPath;
            NewAction(name, PathFrom);
            shellBrowserLeft.SetCurrentDirectory(PathFrom);
            textBox1.Clear();
        }

        private void buttonNew2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string PathFrom = shellBrowserRight.CurrentPath;
            NewAction(name, PathFrom);
            shellBrowserRight.SetCurrentDirectory(PathFrom);
            textBox2.Clear();
        }

        public void NewAction(string name, string PathFrom)
        {
            if (name != null)
            {
                Factory.Creator God;
                Prototype.IFileOrFolder element;
                if (System.IO.Path.GetExtension(name) == "")
                {
                    God = new Factory.FolderCreator();
                }
                else
                {
                    God = new Factory.FileCreator();
                }
                element = God.FactoryMethod(PathFrom, name);
                element.Create();
            }
        }
        public void SendTCP(string FullPath, string IPA, Int32 PortN)
        {
            
            byte[] SendingBuffer = null;
            TcpClient client = null;
            labelStatus.Text = "";
            NetworkStream netstream = null;
            try
            {
                client = new TcpClient(IPA, PortN);
                labelStatus.Text = "Connected to the Server...\n";
                netstream = client.GetStream();
                string ext = FullPath;
                ext = Path.GetExtension(ext);
                byte[] ByteArr = Encoding.ASCII.GetBytes(ext);
                netstream.Write(ByteArr, 0, ByteArr.Length);
                FileStream Fs = new FileStream(FullPath, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                progressBar1.Maximum = NoOfPackets;
                int TotalLength = (int)Fs.Length, CurrentPacketLength, counter = 0;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                        CurrentPacketLength = TotalLength;
                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    if (progressBar1.Value >= progressBar1.Maximum)
                        progressBar1.Value = progressBar1.Minimum;
                    progressBar1.PerformStep();
                }

                labelStatus.Text = "";
                progressBar1.Value = 0;
                string msg = "Sent " + Fs.Length.ToString() + "bytes to the server";
                MessageBox.Show(msg, "Info", MessageBoxButtons.OK);
                Fs.Close();
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Couldn't connect to server", "Error", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (netstream != null)
                {
                    netstream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        private void Send1_Click(object sender, EventArgs e)
        {
            if ((Path.GetExtension(shellBrowserLeft.CurrentSelectedItem) != "") && (Path.GetExtension(shellBrowserLeft.CurrentSelectedItem) != null ))
            {
                int Port = 0;
                string name = shellBrowserLeft.CurrentSelectedItem;
                string PathFrom = shellBrowserLeft.CurrentPath;
                string FullPath = Path.Combine(PathFrom, name);
                string IPA = IPText.Text;
                try
                {
                    Port = int.Parse(PortText.Text);
                }
                catch 
                {
                    MessageBox.Show("Wrong Port Format", "Error", MessageBoxButtons.OK);
                }
                if (Port != 0)
                {
                    SendTCP(FullPath, IPA, Port);
                }
            }
            else
            {
                MessageBox.Show("Please choose File to Send", "Error", MessageBoxButtons.OK);
            }
        }

        private void Send2_Click(object sender, EventArgs e)
        {
            if ((Path.GetExtension(shellBrowserLeft.CurrentSelectedItem) != "") && (Path.GetExtension(shellBrowserLeft.CurrentSelectedItem) != null))
            {
                int Port = 0;
                string name = shellBrowserRight.CurrentSelectedItem;
                string PathFrom = shellBrowserRight.CurrentPath;
                string FullPath = Path.Combine(PathFrom, name);
                string IPA = IPText.Text;
                try
                {
                    Port = int.Parse(PortText.Text);
                }
                catch
                {
                    MessageBox.Show("Wrong Port Format", "Error", MessageBoxButtons.OK);
                }
                if (Port != 0)
                {
                    SendTCP(FullPath, IPA, Port);
                }
            }
            else 
            {
                MessageBox.Show("Please choose File to Send", "Error", MessageBoxButtons.OK);
            }
        }

        public void SetPortText(int Port)
        {
            PortText.Text = Port.ToString();
        }

        public void SetIPText(string IPA)
        {
            IPText.Text = IPA;
        }
    }
}
