namespace ChatServer
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
            this.serverSettingsBox = new System.Windows.Forms.GroupBox();
            this.btnStartStopServer = new System.Windows.Forms.Button();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.bufferSizeLabel = new System.Windows.Forms.Label();
            this.clientsBox = new System.Windows.Forms.GroupBox();
            this.clientsList = new System.Windows.Forms.ListBox();
            this.sendMessageBox = new System.Windows.Forms.GroupBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.chatsBox = new System.Windows.Forms.GroupBox();
            this.chatsList = new System.Windows.Forms.ListBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.serverSettingsBox.SuspendLayout();
            this.clientsBox.SuspendLayout();
            this.sendMessageBox.SuspendLayout();
            this.chatsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverSettingsBox
            // 
            this.serverSettingsBox.Controls.Add(this.btnStop);
            this.serverSettingsBox.Controls.Add(this.btnStartStopServer);
            this.serverSettingsBox.Controls.Add(this.txtBufferSize);
            this.serverSettingsBox.Controls.Add(this.nameLabel);
            this.serverSettingsBox.Controls.Add(this.txtServerPort);
            this.serverSettingsBox.Controls.Add(this.portLabel);
            this.serverSettingsBox.Controls.Add(this.txtServerName);
            this.serverSettingsBox.Controls.Add(this.bufferSizeLabel);
            this.serverSettingsBox.Location = new System.Drawing.Point(12, 12);
            this.serverSettingsBox.Name = "serverSettingsBox";
            this.serverSettingsBox.Size = new System.Drawing.Size(243, 253);
            this.serverSettingsBox.TabIndex = 0;
            this.serverSettingsBox.TabStop = false;
            this.serverSettingsBox.Text = "Server Settings";
            // 
            // btnStartStopServer
            // 
            this.btnStartStopServer.Location = new System.Drawing.Point(4, 174);
            this.btnStartStopServer.Name = "btnStartStopServer";
            this.btnStartStopServer.Size = new System.Drawing.Size(227, 32);
            this.btnStartStopServer.TabIndex = 1;
            this.btnStartStopServer.Text = "Start";
            this.btnStartStopServer.UseVisualStyleBackColor = true;
            this.btnStartStopServer.Click += new System.EventHandler(this.btnStartStopServer_Click);
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.Location = new System.Drawing.Point(5, 145);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(227, 23);
            this.txtBufferSize.TabIndex = 6;
            this.txtBufferSize.Text = "1024";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(5, 21);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 15);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(5, 91);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(227, 23);
            this.txtServerPort.TabIndex = 5;
            this.txtServerPort.Text = "9000";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(7, 73);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 15);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(5, 39);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(227, 23);
            this.txtServerName.TabIndex = 4;
            // 
            // bufferSizeLabel
            // 
            this.bufferSizeLabel.AutoSize = true;
            this.bufferSizeLabel.Location = new System.Drawing.Point(7, 127);
            this.bufferSizeLabel.Name = "bufferSizeLabel";
            this.bufferSizeLabel.Size = new System.Drawing.Size(62, 15);
            this.bufferSizeLabel.TabIndex = 3;
            this.bufferSizeLabel.Text = "Buffer Size";
            // 
            // clientsBox
            // 
            this.clientsBox.Controls.Add(this.clientsList);
            this.clientsBox.Location = new System.Drawing.Point(10, 271);
            this.clientsBox.Name = "clientsBox";
            this.clientsBox.Size = new System.Drawing.Size(245, 186);
            this.clientsBox.TabIndex = 1;
            this.clientsBox.TabStop = false;
            this.clientsBox.Text = "Clients";
            // 
            // clientsList
            // 
            this.clientsList.FormattingEnabled = true;
            this.clientsList.ItemHeight = 15;
            this.clientsList.Location = new System.Drawing.Point(6, 22);
            this.clientsList.Name = "clientsList";
            this.clientsList.Size = new System.Drawing.Size(228, 154);
            this.clientsList.TabIndex = 2;
            // 
            // sendMessageBox
            // 
            this.sendMessageBox.Controls.Add(this.btnSendMessage);
            this.sendMessageBox.Controls.Add(this.messageLabel);
            this.sendMessageBox.Controls.Add(this.txtMessage);
            this.sendMessageBox.Location = new System.Drawing.Point(281, 388);
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Size = new System.Drawing.Size(528, 68);
            this.sendMessageBox.TabIndex = 2;
            this.sendMessageBox.TabStop = false;
            this.sendMessageBox.Text = "Send Message";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(447, 39);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(6, 21);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(53, 15);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 39);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(436, 23);
            this.txtMessage.TabIndex = 4;
            // 
            // chatsBox
            // 
            this.chatsBox.Controls.Add(this.chatsList);
            this.chatsBox.Location = new System.Drawing.Point(276, 12);
            this.chatsBox.Name = "chatsBox";
            this.chatsBox.Size = new System.Drawing.Size(528, 345);
            this.chatsBox.TabIndex = 3;
            this.chatsBox.TabStop = false;
            this.chatsBox.Text = "Chats";
            // 
            // chatsList
            // 
            this.chatsList.FormattingEnabled = true;
            this.chatsList.ItemHeight = 15;
            this.chatsList.Location = new System.Drawing.Point(6, 21);
            this.chatsList.Name = "chatsList";
            this.chatsList.Size = new System.Drawing.Size(517, 319);
            this.chatsList.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(7, 212);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(224, 35);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 466);
            this.Controls.Add(this.chatsBox);
            this.Controls.Add(this.sendMessageBox);
            this.Controls.Add(this.clientsBox);
            this.Controls.Add(this.serverSettingsBox);
            this.Name = "Form1";
            this.Text = " NOTS Chat Server";
            this.serverSettingsBox.ResumeLayout(false);
            this.serverSettingsBox.PerformLayout();
            this.clientsBox.ResumeLayout(false);
            this.sendMessageBox.ResumeLayout(false);
            this.sendMessageBox.PerformLayout();
            this.chatsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox serverSettingsBox;
        private Button btnStartStopServer;
        private TextBox txtBufferSize;
        private Label nameLabel;
        private TextBox txtServerPort;
        private Label portLabel;
        private TextBox txtServerName;
        private Label bufferSizeLabel;
        private GroupBox clientsBox;
        private ListBox clientsList;
        private GroupBox sendMessageBox;
        private Button btnSendMessage;
        private Label messageLabel;
        private TextBox txtMessage;
        private GroupBox chatsBox;
        private ListBox chatsList;
        private Button btnStop;
    }
}