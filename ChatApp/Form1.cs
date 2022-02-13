namespace ChatApp
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Net.NetworkInformation;

    public partial class Form1 : Form
    {

        // Stap 3:
        TcpClient tcpClient = new();
        NetworkStream networkStream;

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
            //    TcpListener tcpListener = new TcpListener(IPAddress.Any, 9000);
            //    tcpListener.Start();

            //    //listChats.Items.Add("Listening for client.");     // conform opdracht maar zonder hergebruik
            //    AddMessage("Listening for client.");

            //    tcpClient = tcpListener.AcceptTcpClient();
            //    thread = new Thread(new ThreadStart(ReceiveData));
            //    thread.Start();
        }

        private async Task ReceiveData()
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
                    int readBytes = await networkStream.ReadAsync(buffer, 0, bufferSize);
                    message = Encoding.ASCII.GetString(buffer, 0, readBytes);

                    if (message == "bye")
                        break;

                    AddMessage(message);
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

            try
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(txtServerIp.Text, 9000);
                await ReceiveData();
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }


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

            byte[] buffer = Encoding.ASCII.GetBytes(message);
            await networkStream.WriteAsync(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessage.Clear();
            txtMessage.Focus();

        }
    }
}