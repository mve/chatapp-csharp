namespace ChatApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listChat = new System.Windows.Forms.ListBox();
            this.connectToServerBox = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.bufferSizeLabel = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chatserverIpLabel = new System.Windows.Forms.Label();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.connectToServerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listChat
            // 
            this.listChat.FormattingEnabled = true;
            this.listChat.ItemHeight = 15;
            this.listChat.Location = new System.Drawing.Point(12, 12);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(602, 259);
            this.listChat.TabIndex = 0;
            // 
            // connectToServerBox
            // 
            this.connectToServerBox.Controls.Add(this.txtPort);
            this.connectToServerBox.Controls.Add(this.portLabel);
            this.connectToServerBox.Controls.Add(this.txtBufferSize);
            this.connectToServerBox.Controls.Add(this.bufferSizeLabel);
            this.connectToServerBox.Controls.Add(this.btnConnect);
            this.connectToServerBox.Controls.Add(this.chatserverIpLabel);
            this.connectToServerBox.Controls.Add(this.txtServerIp);
            this.connectToServerBox.Location = new System.Drawing.Point(620, 12);
            this.connectToServerBox.Name = "connectToServerBox";
            this.connectToServerBox.Size = new System.Drawing.Size(191, 220);
            this.connectToServerBox.TabIndex = 2;
            this.connectToServerBox.TabStop = false;
            this.connectToServerBox.Text = "Connect to Server:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(6, 87);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(179, 23);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "9000";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(6, 70);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 15);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "Port:";
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.Location = new System.Drawing.Point(5, 142);
            this.txtBufferSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(180, 23);
            this.txtBufferSize.TabIndex = 4;
            this.txtBufferSize.Text = "1024";
            // 
            // bufferSizeLabel
            // 
            this.bufferSizeLabel.AutoSize = true;
            this.bufferSizeLabel.Location = new System.Drawing.Point(5, 125);
            this.bufferSizeLabel.Name = "bufferSizeLabel";
            this.bufferSizeLabel.Size = new System.Drawing.Size(65, 15);
            this.bufferSizeLabel.TabIndex = 3;
            this.bufferSizeLabel.Text = "Buffer Size:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(-1, 186);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(186, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // chatserverIpLabel
            // 
            this.chatserverIpLabel.AutoSize = true;
            this.chatserverIpLabel.Location = new System.Drawing.Point(5, 20);
            this.chatserverIpLabel.Name = "chatserverIpLabel";
            this.chatserverIpLabel.Size = new System.Drawing.Size(79, 15);
            this.chatserverIpLabel.TabIndex = 1;
            this.chatserverIpLabel.Text = "Chatserver IP:";
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(6, 38);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(180, 23);
            this.txtServerIp.TabIndex = 0;
            this.txtServerIp.Text = "localhost";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 276);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(521, 23);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(539, 276);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 309);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.connectToServerBox);
            this.Controls.Add(this.listChat);
            this.Name = "Form1";
            this.Text = "NOTS Chat Client";
            this.connectToServerBox.ResumeLayout(false);
            this.connectToServerBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listChat;
        private GroupBox connectToServerBox;
        private Button btnConnect;
        private Label chatserverIpLabel;
        private TextBox txtServerIp;
        private TextBox txtMessage;
        private Button btnSendMessage;
        private TextBox txtBufferSize;
        private Label bufferSizeLabel;
        private TextBox txtPort;
        private Label portLabel;
    }
}