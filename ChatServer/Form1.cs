using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        List<TcpClient> tcpClients = new();
        int bufferSize = 1024;
        int port = 9000;

        public Form1()
        {
            InitializeComponent();
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
                networkStream.Write(buffer, 0, buffer.Length);

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
                AddMessage("Set buffer size to " + bufferSize + ".");
            }
            else
            {
                AddMessage("Incorrect value for buffer size. Set to 1024.");
            }

        }

        private void setPort()
        {

            bool result = int.TryParse(txtServerPort.Text, out port);
            if (result)
            {
                AddMessage("Set port to " + port + ".");
            }
            else
            {
                AddMessage("Incorrect value for buffer size. Set to 9000.");
            }

        }

        async Task StartServer()
        {
            setBufferSize();
            setPort();

            try
            {
                TcpListener tcpListener = new TcpListener(IPAddress.Any, port);

                // TODO Deze mag maar 1 keer worden uitgevoerd.
                tcpListener.Start();

                while (true)
                {
                    AddMessage("Waiting for a connection...");
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    tcpClients.Add(tcpClient);
                    updateClientsList();

                    Task.Run(() => ReceiveData(tcpClient));
                }
            }

            catch (SocketException ex)
            {
                AddMessage("Port is al bezet...");
            }
            catch (Exception ex)
            {
                AddMessage("Server is gestopt...");
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

    }
}