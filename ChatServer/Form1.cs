using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        // Stap 3:
        TcpClient tcpClient;
        NetworkStream networkStream;
        Thread thread;

        public Form1()
        {
            InitializeComponent();
        }

        // Stap 5:
        private void AddMessage(string message)
        {
            this.BeginInvoke(() => chatsList.Items.Add(message));
        }

        // Stap 7:
        private void ReceiveData()
        {
            int bufferSize = 1024;
            string message = "";
            byte[] buffer = new byte[bufferSize];

            networkStream = tcpClient.GetStream();

            AddMessage("Connected!");

            while (true)
            {
                int readBytes = networkStream.Read(buffer, 0, bufferSize);
                message = Encoding.ASCII.GetString(buffer, 0, readBytes);

                if (message == "bye")
                    break;

                AddMessage(message);
            }

            // Verstuur een reactie naar de client (afsluitend bericht)
            buffer = Encoding.ASCII.GetBytes("bye");
            networkStream.Write(buffer, 0, buffer.Length);

            // cleanup:
            networkStream.Close();
            tcpClient.Close();

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

            AddMessage("Listening for client.");

            while (true)
            {
                AddMessage("Inside while...");

                tcpClient = await tcpListener.AcceptTcpClientAsync().ConfigureAwait(false);

                AddMessage("Below accept tcp client async...");

                var t = Task.Run(() => ReceiveData());
                t.Wait();

                AddMessage("After task run...");
            }

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;

            byte[] buffer = Encoding.ASCII.GetBytes(message);
            networkStream.Write(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessage.Clear();
            txtMessage.Focus();
        }


    }
}