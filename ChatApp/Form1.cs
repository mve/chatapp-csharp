namespace ChatApp
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Net.NetworkInformation;

    public partial class Form1 : Form
    {

        TcpClient tcpClient = new();
        NetworkStream networkStream;
        int bufferSize = 1024;
        int port = 9000;
        string host = "localhost";

        protected delegate void UpdateDisplayDelegate(string message);

        public Form1()
        {
            InitializeComponent();
        }

        // Stap 5:
        private void AddMessage(string message)
        {
            if (listChat.InvokeRequired)
            {
                // Invoke required
                listChat.Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { message });
            }
            else
            {
                // Invoke not required
                UpdateDisplay(message);
            }
        }

        private void UpdateDisplay(string message)
        {
            listChat.Items.Add(message);
        }

        private async Task ReceiveData()
        {
            string message = "";
            byte[] buffer = new byte[bufferSize];

            networkStream = tcpClient.GetStream();

            AddMessage("Connected!");

            try
            {

                while (true)
                {
                    int readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                    message = Encoding.ASCII.GetString(buffer, 0, readBytes);

                    while (networkStream.DataAvailable)
                    {
                        readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                        message += Encoding.ASCII.GetString(buffer, 0, readBytes);
                    }

                    //if (message == "bye")
                    //    break;

                    AddMessage(message);
                    // Clear message.
                    message = "";
                }

                // Verstuur een reactie naar de client (afsluitend bericht)
                buffer = Encoding.ASCII.GetBytes("bye");
                await networkStream.WriteAsync(buffer, 0, buffer.Length);

                // cleanup:
                networkStream.Close();
                tcpClient.Close();

            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                networkStream.Close();
            }

            AddMessage("Connection closed");
        }

        // Stap 8:
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            AddMessage("Connecting...");

            setBufferSize();
            setPort();
            setHost();

            try
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(host, port);
                await ReceiveData();
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }


        }

        private void setBufferSize()
        {
            bool result = int.TryParse(txtBufferSize.Text, out bufferSize);
            if (result)
            {
                AddMessage("Set buffer size to " + bufferSize + ".");
            }
            else
            {
                AddMessage("Incorrect value for buffer size. Set to 1024.");
            }

        }

        private void setPort()
        {
            bool result = int.TryParse(txtPort.Text, out port);
            if (result)
            {
                AddMessage("Set port size to " + port + ".");
            }
            else
            {
                AddMessage("Incorrect value for buffer size. Set to 9000.");
            }

        }

        private void setHost()
        {
            host = txtServerIp.Text;
        }

        // Stap 9:
        private async void btnSendMessage_Click(object sender, EventArgs e)
        {

            if (networkStream == null)
            {
                AddMessage("Niet verbonden...");
                return;
            }

            if (!networkStream.CanWrite)
            {
                AddMessage("Niet verbonden...");
                return;
            }

            string message = txtMessage.Text;

            if (message == "bye") {

                // cleanup:
                networkStream.Close();
                tcpClient.Close();

                // send ending message.
                AddMessage("Closing connection...");
                txtMessage.Clear();
                txtMessage.Focus();

                return;
            }

            byte[] buffer = Encoding.ASCII.GetBytes(message);
            await networkStream.WriteAsync(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessage.Clear();
            txtMessage.Focus();

        }
    }
}