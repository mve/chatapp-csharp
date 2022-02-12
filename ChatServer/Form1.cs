using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        // Init tcp client and network stream.
        List<TcpClient> tcpClients = new();
        // NetworkStream networkStream;

        public Form1()
        {
            InitializeComponent();
        }

        // Add chat message.
        private void AddMessage(string message)
        {
            this.BeginInvoke(() => chatsList.Items.Add(message));
        }


        private void ReceiveData(TcpClient currentClient)
        {
            int bufferSize = 1024;
            string message = "";
            byte[] buffer = new byte[bufferSize];

            NetworkStream networkStream = currentClient.GetStream();

            AddMessage("Connected!");


            while (true)
            {
                int readBytes = networkStream.Read(buffer, 0, bufferSize);
                message = Encoding.ASCII.GetString(buffer, 0, readBytes);

                if (message == "bye")
                    break;

                AddMessage(message);
                sendMessageToClients(message, currentClient);
            }

            // Verstuur een reactie naar de client (afsluitend bericht)
            buffer = Encoding.ASCII.GetBytes("bye");
            networkStream.Write(buffer, 0, buffer.Length);

            // cleanup:
            networkStream.Close();
            currentClient.Close();

            AddMessage("Connection closed");
        }

        private void btnStartStopServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        async Task StartServer()
        { 
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 9000);

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

        private void updateClientsList()
        {
            clientsList.Items.Clear();

            for (var i = 1; tcpClients.Count >= i; i++) {
                clientsList.Items.Add("Client " + i);
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

        async Task sendMessageToClients(string message, TcpClient clientException = null) {
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            foreach (TcpClient tcpClient in tcpClients)
            {

                if (tcpClient == clientException)
                {
                    // Dont send back to sender...
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