using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatServerApp.Forms
{
    public partial class ServerForm : Form
    {
        private TcpListener listener;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public ServerForm()
        {
            InitializeComponent();

            btnSend.Enabled = false;

            btnStart.Click += StartButton_Click;
            btnSend.Click += SendButton_Click;
            btnClear.Click += ClearButton_Click;
            FormClosing += ServerForm_FormClosing;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Port khong hop le.");
                return;
            }

            CloseConnection();

            btnStart.Enabled = false;
            txtPort.Enabled = false;
            btnSend.Enabled = false;
            lblStatus.Text = "Waiting for client...";
            AddLog("[Status] Dang cho client ket noi...");

            Thread serverThread = new Thread(() => WaitForClient(port));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void WaitForClient(int port)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);
                writer.AutoFlush = true;

                RunOnUiThread(() =>
                {
                    lblStatus.Text = "Client connected.";
                    btnSend.Enabled = true;
                    txtMessage.Focus();
                    AddLog("[Status] Client da ket noi.");
                });

                StartReceiveThread();
            }
            catch
            {
                RunOnUiThread(() =>
                {
                    AddLog("[Status] Khong the mo server.");
                    ResetUi();
                });
            }
        }

        private void StartReceiveThread()
        {
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void ReceiveMessages()
        {
            try
            {
                while (reader != null)
                {
                    string text = reader.ReadLine();
                    if (text == null)
                    {
                        break;
                    }

                    RunOnUiThread(() => AddLog("Client: " + text));
                }
            }
            catch
            {
                RunOnUiThread(() => AddLog("[Status] Mat ket noi client."));
            }

            RunOnUiThread(ResetUi);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (writer == null)
            {
                return;
            }

            string text = txtMessage.Text.Trim();
            if (text == string.Empty)
            {
                return;
            }

            try
            {
                writer.WriteLine(text);
                AddLog("Server: " + text);
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch
            {
                AddLog("[Status] Khong gui duoc tin nhan.");
                ResetUi();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void ResetUi()
        {
            CloseConnection();
            btnStart.Enabled = true;
            txtPort.Enabled = true;
            btnSend.Enabled = false;
            lblStatus.Text = "Server is idle...";
        }

        private void CloseConnection()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }

            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }

            if (listener != null)
            {
                listener.Stop();
                listener = null;
            }
        }

        private void AddLog(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void RunOnUiThread(Action action)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(action);
                return;
            }

            action();
        }
    }
}
