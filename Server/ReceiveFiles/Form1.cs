using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ReceiveFiles
{
    public partial class Form1 : Form
    {
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        public Thread T = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Server is Running...";
            ThreadStart Ts = new ThreadStart(StartReceiving);
            T = new Thread(Ts);
            T.Start();


        }
        public void StartReceiving()
        {
            ReceiveTCP(29250);
        }

        private delegate DialogResult ShowSaveFileDialogInvoker();
        private string SaveDialog(string ext)
        {
            string SaveFileName = string.Empty;
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.Filter = "*" + ext + "| *" + ext;
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Where do you want to save the file?";
            DialogSave.InitialDirectory = @"C:/";
            ShowSaveFileDialogInvoker invoker = new ShowSaveFileDialogInvoker(DialogSave.ShowDialog);
            this.Invoke(invoker);
            SaveFileName = DialogSave.FileName;
            return SaveFileName;


        }
       
        public void ReceiveTCP(int portN)
        {
            TcpListener Listener = null;
            try
            {
                Listener = new TcpListener(IPAddress.Any, portN);
                Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            int RecBytes;

            for (; ; )
            {
                TcpClient client = null;
                NetworkStream netstream = null;
                Status = string.Empty;
                byte[] RecData = new byte[BufferSize];

                    
                    string message = "Accept the Incoming File ";
                    string caption = "Incoming Connection";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                

                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        Status = "Connected to a client\n";
                        result = MessageBox.Show(message, caption, buttons);
                        netstream.Read(RecData, 0, 4);
                        string ext = Encoding.ASCII.GetString(RecData);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            string SaveFileName = SaveDialog(ext);
                            if (SaveFileName != string.Empty)
                            {
                                int totalrecbytes = 0;
                                FileStream Fs = new FileStream(SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                                while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                                {
                                    Fs.Write(RecData, 0, RecBytes);
                                    totalrecbytes += RecBytes;
                                }
                                Fs.Close();
                            }
                            netstream.Close();
                            client.Close();

                        }
                    }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            T.Abort();
            this.Close();
        }

        
    }
}