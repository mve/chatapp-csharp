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

        /// <summary>
        /// Init component and hide disconnect button.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            btnDisconnect.Visible = false;
        }

        /// <summary>
        /// Add a message to the chat list.
        /// </summary>
        /// <param name="message"></param>
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

        /// <summary>
        /// Add a message to the chat list.
        /// </summary>
        /// <param name="message"></param>
        private void UpdateDisplay(string message)
        {
            listChat.Items.Add(message);
        }

        /// <summary>
        /// Read data from the networkstream.
        /// </summary>
        /// <returns></returns>
        private async Task ReceiveData()
        {
            StringBuilder message = new();
            byte[] buffer = new byte[bufferSize];

            networkStream = tcpClient.GetStream();

            btnConnect.Visible = false;
            btnDisconnect.Visible = true;
            AddMessage("Connected!");


            try
            {

                while (true)
                {
                    int readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                    message.Append(Encoding.ASCII.GetString(buffer, 0, readBytes));

                    while (networkStream.DataAvailable)
                    {
                        readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                        message.Append(Encoding.ASCII.GetString(buffer, 0, readBytes));
                    }

                    if (message.ToString() == "")
                        break;

                    AddMessage(message.ToString());
                    // Clear message.
                    message = new();
                }

                disconnectFromServer();

            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                disconnectFromServer();
            }

            AddMessage("Connection closed");
        }

        /// <summary>
        /// Set the buffersize, port and host. Connect to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Set the buffersize.
        /// </summary>
        private void setBufferSize()
        {
            bool result = int.TryParse(txtBufferSize.Text, out bufferSize);

            if (result)
            {

                if (bufferSize > 0 && bufferSize < 32768)
                {

                    AddMessage("Set buffer size to " + bufferSize + ".");

                }
                else
                {
                    bufferSize = 1024;
                    txtBufferSize.Text = bufferSize.ToString();
                    AddMessage("Incorrect value for buffer size. Set to 1024.");
                }



            }
            else
            {
                bufferSize = 1024;
                txtBufferSize.Text = bufferSize.ToString();
                AddMessage("Incorrect value for buffer size. Set to 1024.");
            }

        }

        /// <summary>
        /// Set the port.
        /// </summary>
        private void setPort()
        {
            bool result = int.TryParse(txtPort.Text, out port);
            if (result)
            {

                if (port > 0 && port < 32768)
                {
                    AddMessage("Set port to " + port + ".");
                }
                else
                {
                    port = 9000;
                    txtPort.Text = port.ToString();
                    AddMessage("Incorrect value for port. Set to 9000.");
                }

            }
            else
            {
                port = 9000;
                txtPort.Text = port.ToString();
                AddMessage("Incorrect value for port. Set to 9000.");
            }

        }

        /// <summary>
        /// Set the host.
        /// </summary>
        private void setHost()
        {

            if (txtServerIp.Text == "")
            {
                host = "localhost";
                txtServerIp.Text = host;
                AddMessage("Incorrect value for host. Set to localhost.");
                return;
            }

            host = txtServerIp.Text;
        }

        /// <summary>
        /// Send a message to the server if connected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (message == "bye")
            {
                disconnectFromServer();
                return;
            }

            byte[] buffer = Encoding.ASCII.GetBytes(message);
            await networkStream.WriteAsync(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessage.Clear();
            txtMessage.Focus();

        }

        /// <summary>
        ///  Disconnect the client from the server.
        /// </summary>
        private void disconnectFromServer()
        {
            // cleanup:
            networkStream.Close();
            tcpClient.Close();

            // send ending message.
            AddMessage("Closing connection...");
            txtMessage.Clear();
            txtMessage.Focus();

            btnConnect.Visible = true;
            btnDisconnect.Visible = false;

        }

        /// <summary>
        /// Button for disconnecting from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            disconnectFromServer();
        }
    }
}