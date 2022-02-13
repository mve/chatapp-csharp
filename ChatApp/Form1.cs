namespace ChatApp
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Text;
    using System.Net.NetworkInformation;

    public partial class Form1 : Form
    {

        // Stap 3:
        TcpClient tcpClient = new();
        NetworkStream networkStream;
        Thread thread;

        // Stap 4: 
        protected delegate void UpdateDisplayDelegate(string message);

        public Form1()
        {
            InitializeComponent();
        }

        // Stap 5:
        private void AddMessage(string message)
        {
            Console.WriteLine("Add message...");
            if (listChat.InvokeRequired)
            {
                Console.WriteLine("Invoke required");
                listChat.Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { message });
            }
            else
            {
                Console.WriteLine("Invoke not required");
                UpdateDisplay(message);
            }
        }

        private void UpdateDisplay(string message)
        {
            listChat.Items.Add(message);
        }

        // Stap 6:
        private void btnListen_Click(object sender, EventArgs e)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 9000);
            tcpListener.Start();

            //listChats.Items.Add("Listening for client.");     // conform opdracht maar zonder hergebruik
            AddMessage("Listening for client.");

            tcpClient = tcpListener.AcceptTcpClient();
            thread = new Thread(new ThreadStart(ReceiveData));
            thread.Start();
        }

        // Stap 7:
        private void ReceiveData()
        {
            int bufferSize = 1024;
            string message = "";
            byte[] buffer = new byte[bufferSize];

            networkStream = tcpClient.GetStream();

            AddMessage("Connected!");

            try
            {

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

            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }

            AddMessage("Connection closed");
        }

        // Stap 8:
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            AddMessage("Connecting...");

            try
            {
                // tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(txtServerIp.Text, 9000);

                thread = new Thread(new ThreadStart(ReceiveData));
                thread.Start();
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }


        }

        // Stap 9:
        private void btnSendMessage_Click(object sender, EventArgs e)
        {

            // IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            // TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections().Where(x => x.LocalEndPoint.Equals(tcpClient.Client.LocalEndPoint) && x.RemoteEndPoint.Equals(tcpClient.Client.RemoteEndPoint)).ToArray();

            //if (tcpConnections != null && tcpConnections.Length > 0)
            //{
                //TcpState stateOfConnection = tcpConnections.First().State;
                //if (stateOfConnection == TcpState.Established)
                //{
                    // Connection is OK
                    string message = txtMessage.Text;

                    byte[] buffer = Encoding.ASCII.GetBytes(message);
                    networkStream.Write(buffer, 0, buffer.Length);

                    AddMessage(message);
                    txtMessage.Clear();
                    txtMessage.Focus();
                //}
                //else
                //{
                    // No active tcp Connection to hostName:port
                    //AddMessage("Niet verbonden...");
                //}

            //}
            //else {
                // No active tcp Connection to hostName:port
                //AddMessage("Niet verbonden...");
            //}

        }
    }
}