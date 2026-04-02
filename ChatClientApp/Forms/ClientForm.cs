using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatClientApp.Forms
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public ClientForm()
        {
            InitializeComponent();

            btnSend.Enabled = false;

            btnConnect.Click += ConnectButton_Click;
            btnSend.Click += SendButton_Click;
            btnClear.Click += ClearButton_Click;
            FormClosing += ClientForm_FormClosing;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text.Trim();
            if (host == string.Empty)
            {
                MessageBox.Show("Host khong hop le.");
                return;
            }

            if (!int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Port khong hop le.");
                return;
            }

            CloseConnection();

            btnConnect.Enabled = false;
            txtHost.Enabled = false;
            txtPort.Enabled = false;
            btnSend.Enabled = false;
            lblStatus.Text = "Connecting...";

            Thread clientThread = new Thread(() => ConnectToServer(host, port));
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        private void ConnectToServer(string host, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(host, port);

                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);
                writer.AutoFlush = true;

                RunOnUiThread(() =>
                {
                    lblStatus.Text = "Connected to server.";
                    btnSend.Enabled = true;
                    txtMessage.Focus();
                    AddLog("[Status] Da ket noi toi server.");
                });

                StartReceiveThread();
            }
            catch
            {
                RunOnUiThread(() =>
                {
                    AddLog("[Status] Khong the ket noi toi server.");
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

                    RunOnUiThread(() => AddLog("Server: " + text));
                }
            }
            catch
            {
                RunOnUiThread(() => AddLog("[Status] Mat ket noi server."));
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
                AddLog("Client: " + text);
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

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void ResetUi()
        {
            CloseConnection();
            btnConnect.Enabled = true;
            txtHost.Enabled = true;
            txtPort.Enabled = true;
            btnSend.Enabled = false;
            lblStatus.Text = "Client is idle...";
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
