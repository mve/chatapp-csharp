using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        List<TcpClient> tcpClients = new();
        TcpListener tcpListener;
        int bufferSize = 1024;
        int port = 9000;

        public Form1()
        {
            InitializeComponent();
            btnStop.Visible = false;
        }

        // Add chat message.
        private void AddMessage(string message)
        {
            this.BeginInvoke(() => chatsList.Items.Add(message));
        }


        private async void ReceiveData(TcpClient currentClient)
        {
            string message = "";
            byte[] buffer = new byte[bufferSize];

            NetworkStream networkStream = currentClient.GetStream();

            AddMessage("Connected!");

            try
            {
                while (true)
                {
                    int readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                    message += Encoding.ASCII.GetString(buffer, 0, readBytes);

                    while (networkStream.DataAvailable)
                    {
                        readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                        message += Encoding.ASCII.GetString(buffer, 0, readBytes);
                    }

                    if (message == "")
                        break;

                    AddMessage(message);
                    sendMessageToClients(message, currentClient);

                    // Clear message.
                    message = "";
                }

                // Verstuur een reactie naar de client (afsluitend bericht)
                buffer = Encoding.ASCII.GetBytes("bye");
                await networkStream.WriteAsync(buffer, 0, buffer.Length);

                // cleanup:
                // networkStream.Close();
                currentClient.Close();
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }

            updateClientsList();
            AddMessage("Connection closed");
        }

        private void btnStartStopServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }

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

        private void setPort()
        {

            bool result = int.TryParse(txtServerPort.Text, out port);
            if (result)
            {

                if (port > 0 && port < 32768)
                {
                    AddMessage("Set port to " + port + ".");
                }
                else
                {
                    port = 9000;
                    txtServerPort.Text = port.ToString();
                    AddMessage("Incorrect value for port. Set to 9000.");
                }

            }
            else
            {
                port = 9000;
                txtServerPort.Text = port.ToString();
                AddMessage("Incorrect value for port. Set to 9000.");
            }

        }

        async Task StartServer()
        {
            btnStartStopServer.Visible = false;
            btnStop.Visible = true;

            setBufferSize();
            setPort();

            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);

                // TODO Deze mag maar 1 keer worden uitgevoerd.
                tcpListener.Start();

                while (true)
                {
                    try
                    {

                        AddMessage("Waiting for a connection...");
                        TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                        tcpClients.Add(tcpClient);
                        updateClientsList();

                        Task.Run(() => ReceiveData(tcpClient));

                    }
                    catch (Exception ex)
                    {
                        stopServer();
                        AddMessage("De server is gestopt.");
                        break;
                    }

                }
            }

            catch (SocketException ex)
            {
                stopServer();
                AddMessage("De port is al bezet.");
            }
            catch (Exception ex)
            {
                stopServer();
                AddMessage("Server is gestopt.");
            }

        }

        private void updateClientsList()
        {
            if (clientsList.InvokeRequired)
            {
                this.BeginInvoke(() => clientsList.Items.Clear());
                this.BeginInvoke(() =>
                {
                    for (var i = 1; tcpClients.Count >= i; i++)
                    {
                        clientsList.Items.Add("Client " + i);
                    }
                });


            }
            else
            {
                clientsList.Items.Clear();
                for (var i = 1; tcpClients.Count >= i; i++)
                {
                    clientsList.Items.Add("Client " + i);
                }
            }

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;

            sendMessageToClients(message);

            // networkStream.Write(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessage.Clear();
            txtMessage.Focus();
        }

        async Task sendMessageToClients(string message, TcpClient clientException = null)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            foreach (TcpClient tcpClient in tcpClients)
            {

                if (tcpClient == clientException || tcpClient.Connected == false)
                {
                    // Dont send to sender or not connected client.
                    continue;
                }

                NetworkStream networkStream = tcpClient.GetStream();

                if (networkStream.CanRead)
                {
                    await networkStream.WriteAsync(buffer, 0, buffer.Length);
                }

            }

        }

        private void stopServer()
        {

            btnStop.Visible = false;
            btnStartStopServer.Visible = true;

            // Close all connections.
            foreach (TcpClient tcpClient in tcpClients)
            {
                tcpClient.Close();
            }

            updateClientsList();

            // Stop the server.
            tcpListener.Stop();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopServer();
        }
    }
}